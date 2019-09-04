using AIAD.Library.Models;
//using AIAD.Library.Data.Repositories.Interfaces;
using AIAD.Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security;
using AIAD.Library.Models.LookUp;

namespace AIAD.Library.Services
{
    public class CommentService : ICommentService
    {
        // TODO replace this
        //private readonly IIdeaRepository commentRepository;
        private readonly dynamic commentRepository;

        // TODO replace this
        //public CommentService(IIdeaRepository commentRepository)
        public CommentService(dynamic commentRepository)
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
