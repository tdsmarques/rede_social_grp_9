using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RedeSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Comment : ControllerBase
    {
        [HttpGet]
        public IEnumerable<String> Get()
        {
            return new string[] {"v1", "v2"};
        }
    }
}