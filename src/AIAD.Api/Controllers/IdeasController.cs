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
    public class IdeasController : BaseController
    {
        private readonly IIdeaService ideaService;

        public IdeasController(IIdeaService ideaService)
        {
            this.ideaService = ideaService;
        }

        [Authorize("read:ideas")]
        [HttpGet]
        [Route("api/users/{username}/ideas")]
        public ActionResult<IEnumerable<Idea>> Get(string username)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.ideaService.GetByCreatorUsername(this.Context, username).ToList();
        }

        [Authorize("read:ideas")]
        [HttpGet]
        [Route("api/users/{username}/ideas/{id}")]
        public ActionResult<Idea> GetById(string username, int id)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.ideaService.GetById(Context, id);
        }

        [Authorize("add:ideas")]
        [HttpPost]
        [Route("api/users/{username}/ideas")]
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

        [Authorize("update:ideas")]
        [HttpPut]
        [Route("api/users/{username}/ideas/{id}")]
        public ActionResult Put(string username, int id, [FromBody] Idea value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.ideaService.Update(this.Context, value);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return Conflict(ex.InnerException.Message);
                }
                else
                {
                    return Conflict(ex.Message);
                }
            }

            return Ok();
        }

        [Authorize("delete:ideas")]
        [HttpDelete]
        [Route("api/users/{username}/ideas/{id}")]
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