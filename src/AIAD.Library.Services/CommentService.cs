using AIAD.Library.Models;
using AIAD.Library.Data.Repositories.Interfaces;
using AIAD.Library.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AIAD.Library.Services
{
    public class CommentService : ICommentService
    {
        private readonly IIdeaRepository commentRepository;

        public CommentService(IIdeaRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public int Create(ApplicationContext context, Comment item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(ApplicationContext context, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetByCreatorId(ApplicationContext context, string creatorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetByCreatorUsername(ApplicationContext context, string username)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(ApplicationContext context, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetByIdeaId(ApplicationContext context, int ideaId)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationContext context, Comment item)
        {
            throw new NotImplementedException();
        }
    }
}
