﻿using dist_manage.DB;
using dist_manage.Models.Commands;
using dist_manage.Models.SqlServerEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dist_manage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService auth;

        public AuthController(AuthService auth)
        {
            this.auth = auth;
        }

        [HttpPost("login")]
        public ActionResult<LoginResCmd> Login([FromBody] LoginReqCmd data)
        {
            try
            {
                return auth.Login(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("RegisterAdmin")]
        public async Task<ActionResult<LoginResCmd>> Login([FromBody] RegisterUserReqCmd data)
        {
            try
            {
                return await auth.RegisterAdmin(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
