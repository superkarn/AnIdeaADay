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
    [Route("api/users/{username}/ideas")]
    [ApiController]
    public class IdeasController : BaseController
    {
        private readonly IIdeaService ideaService;

        public IdeasController(IIdeaService ideaService)
        {
            this.ideaService = ideaService;
        }

        // GET api/users/{username}/ideas
        [HttpGet]
        public ActionResult<IEnumerable<Idea>> Get(string username)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.ideaService.GetByCreatorUsername(this.Context, username).ToList();
        }

        // GET api/users/{username}/ideas/5
        [HttpGet("{id}")]
        public ActionResult<Idea> Get(string username, int id)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.ideaService.GetById(Context, id);
        }

        // POST api/users/{username}/ideas
        [HttpPost]
        public ActionResult Post(string username, [FromBody] Idea value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                var newId = this.ideaService.Create(this.Context, value);
                return Created($"api/users/{username}/ideas/{newId}", newId);
            }
            catch(Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }
        }

        // PUT api/users/{username}/ideas/5
        [HttpPut("{id}")]
        public ActionResult Put(string username, int id, [FromBody] Idea value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.ideaService.Update(this.Context, value);
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
        [HttpDelete("{id}")]
        public ActionResult Delete(string username, int id)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.ideaService.DeleteById(this.Context, id);
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