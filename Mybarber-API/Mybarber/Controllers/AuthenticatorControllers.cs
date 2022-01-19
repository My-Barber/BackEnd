using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mybarber.Models;
using Mybarber.Repositories;
using Mybarber.Repository;
using Mybarber.Services;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors]
    [ApiController]
    [Route("api/v1/aut")]
    public class AuthenticatorControllers : ControllerBase
    {
        private readonly IUsersRepository _Authenticate;
        private readonly IGenerallyRepository _generally;
        public AuthenticatorControllers(IUsersRepository Authenticate, IGenerallyRepository generally)
        {
            this._Authenticate = Authenticate;
            this._generally = generally;

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync(Users model)
        {
            var user = await _Authenticate.GetUserAsync(model.Username, model.Password);

            if (user == null)
                return NotFound(new { messaage = "Usuário ou senha inválido" });

            var token = TokenServices.GenerateToken(user);

            //HttpContext.Session.SetString("SessionNome", user.Username);

            //HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));



            user.Password = "";
            return new
            {
                user = user.Username,
                token = token
            };

        }
        [HttpPost("create")]
        public async Task<ActionResult> PostUserAsync(Users user)
        {
            try
            {
                _generally.Add(user);

                if (await _generally.SaveChangesAsync())
                {
                    return Ok();
                }
                else { return BadRequest(); }

            }
            catch (Exception)
            {

                throw new Exception();
            }


        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var userInfo = JsonConvert.DeserializeObject<Users>
                   (HttpContext.Session.GetString("SessionUser"));

                return Ok(userInfo);
            }
            catch (Exception)

            {
                throw new Exception();
            }




        }
    }
}
