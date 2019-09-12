using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AIAD.Library.Models;
using AIAD.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIAD.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class CommentsController : BaseController
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // Get by commentId
        [HttpGet]
        [Route("api/comments/{id}")]
        public ActionResult<Comment> Get(int id)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.commentService.GetById(this.Context, id);
        }

        // Get by ideaId
        [HttpGet]
        [Route("api/ideas/{ideaId}/comments")]
        public ActionResult<IEnumerable<Comment>> GetByIdeaId(int ideaId)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.commentService.GetByIdeaId(this.Context, ideaId).ToList();
        }

        // Get by username
        [HttpGet]
        [Route("api/users/{username}/comments")]
        public ActionResult<IEnumerable<Comment>> GetByUsername(string username)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.commentService.GetByCreatorUsername(this.Context, username).ToList();
        }

        // Create a comment to an idea
        [HttpPost]
        [Route("api/comments")]
        public ActionResult Post(int ideaId, [FromBody] Comment value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                var newId = this.commentService.Create(this.Context, value);
                return Created($"api/comments/{newId}", newId);
            }
            catch(Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }
        }

        // TODO fix this.
        //AmbiguousMatchException: The request matched multiple endpoints.Matches: 
        //AIAD.Api.Controllers.CommentsController.Get(AIAD.Api)
        //AIAD.Api.Controllers.CommentsController.Put(AIAD.Api)
        //
        // PUT api/users/{username}/ideas/5
        [HttpPut]
        [Route("api/comments/{id}")]
        public ActionResult Put(int id, [FromBody] Comment value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);
            value.Id = id;

            try
            {
                this.commentService.Update(this.Context, value);
            }
            catch (Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }

            return Ok();
        }

        // DELETE api/users/{username}/ideas/5
        [HttpDelete]
        [Route("api/comments/{id}")]
        public ActionResult Delete(string username, int id)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.commentService.DeleteById(this.Context, id);
            }
            catch (Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }

            return Ok();
        }
    }
}