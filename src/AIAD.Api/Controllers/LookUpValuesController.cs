using System.Collections.Generic;
using System.Security.Claims;
using AIAD.Library.Models;
using AIAD.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIAD.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LookUpValuesController : BaseController
    {
        private readonly ILookUpService lookUpService;

        public LookUpValuesController(ILookUpService lookUpService)
        {
            this.lookUpService = lookUpService;
        }

        // GET api/lookUpValues
        [HttpGet]
        public ActionResult<IDictionary<string, IEnumerable<BaseLookUpModel>>> Get()
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return new ActionResult<IDictionary<string, IEnumerable<BaseLookUpModel>>>(this.lookUpService.GetAll(this.Context));
        }
    }
}