﻿using AIAD.Library.Data.Repositories.Interfaces;
using AIAD.Library.Models;
using AIAD.Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security;

namespace AIAD.Library.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IApplicationUserRepository applicationUserRepository;

        public CommentService(ICommentRepository commentRepository, IApplicationUserRepository applicationUserRepository)
        {
            this.commentRepository = commentRepository;
            this.applicationUserRepository = applicationUserRepository;
        }

        public int Create(ApplicationContext context, Comment item)
        {
            return this.commentRepository.Create(item);
        }

        public void DeleteById(ApplicationContext context, int id)
        {
            // If there's no current user, don't allow
            if (context.CurrentUser == null)
            {
                throw new SecurityException($"User NULL is unauthorized to delete Comment id {id}");
            }

            var item = this.commentRepository.GetById(id);

            // If the item doesn't exist, treat it as if the item has been deleted
            if (item == null)
            {
                return;
            }

            // TODO allow Admin 
            // If the current user is not the item creator, don't allow
            if (item.CreatorId != context.CurrentUser.Id)
            {
                throw new SecurityException($"User {context.CurrentUser.Id} is unauthorized to delete Comment id {id}");
            }

            try
            {
                this.commentRepository.Delete(item);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // This exception is expected when trying to delete an item that does not exist.
                // We catch it and let it through, because the end result is as intially requested: the item no longer exists.
                // For any other exception, we let it bubble up.
                if (!ex.Message.Contains("Database operation expected to affect 1 row(s) but actually affected 0 row(s)"))
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Comment> GetByCreatorId(ApplicationContext context, string creatorId)
        {
            return this.commentRepository.GetByCreatorId(creatorId);
        }

        public IEnumerable<Comment> GetByCreatorUsername(ApplicationContext context, string username)
        {
            var user = this.applicationUserRepository.GetByUsername(username).FirstOrDefault();

            return this.commentRepository.GetByCreatorId(user.Id);
        }

        public Comment GetById(ApplicationContext context, int id)
        {
            return this.commentRepository.GetById(id);
        }

        public IEnumerable<Comment> GetByIdeaId(ApplicationContext context, int ideaId)
        {
            return this.commentRepository.GetByIdeaId(ideaId);
        }

        public void Update(ApplicationContext context, Comment item)
        {
            // If there's no current user, don't allow
            if (context.CurrentUser == null)
            {
                throw new SecurityException($"User NULL is unauthorized to delete Comment id {item.Id}");
            }

            var existingItem = this.commentRepository.GetById(item.Id);

            // If the item doesn't exist, throw an exception
            if (existingItem == null)
            {
                throw new NullReferenceException($"Comment id {item.Id} does not exist.");
            }

            // TODO allow Admin 
            // If the current user is not the item creator, don't allow
            if (existingItem.CreatorId != context.CurrentUser.Id)
            {
                throw new SecurityException($"User {context.CurrentUser.Id} is unauthorized to update Comment id {item.Id}.");
            }

            // TODO make this work with PATCH
            existingItem.Content = item.Content;
            existingItem.LastModifiedDate = DateTime.UtcNow;

            this.commentRepository.Update(existingItem);
        }
    }
}
