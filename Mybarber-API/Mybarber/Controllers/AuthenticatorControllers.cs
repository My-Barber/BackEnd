
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mybarber.Exceptions;
using Mybarber.Models;
using Mybarber.Repositories;
using Mybarber.Repository;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        private readonly IRolesRepository _Aut;
        private readonly IBarbeirosRepository _repoBarbeiro;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly RoleManager<IdentityRole> _roleManager;



        public AuthenticatorControllers(IUsersRepository Authenticate,
            IGenerallyRepository generally, IRolesRepository aut,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IOptions<AppSettings> appSettings, RoleManager<IdentityRole> roleManager, IBarbeirosRepository repoBarbeiro)
        {
            this._Authenticate = Authenticate;
            this._generally = generally;
            this._Aut = aut;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._appSettings = appSettings.Value;
            this._roleManager = roleManager;
            this._repoBarbeiro = repoBarbeiro;


        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync(Users model)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            var userFinded = await _userManager.FindByEmailAsync(model.Email);
            var barbeiroFinded = await _repoBarbeiro.GetBarbeirosAsyncByEmail(model.Email);

            var result = await _signInManager.PasswordSignInAsync(userFinded.UserName, model.Password, false, true);

            var token = await GerarJwt(model.Email);






            RetornoUsuario retorno = new RetornoUsuario(barbeiroFinded.IdBarbeiro,userFinded.UserName, token,barbeiroFinded.BarbeariasId );




            if (result.Succeeded)
            {
                return Ok(retorno);
            }

            return BadRequest("Usuário ou senha inválidos");





            //var user = await _Authenticate.GetUserAsync(model.Username, model.Password);
            //var roles = await _Aut.GetRoleAsyncByUsersId(user.IdUser);

            //if (user == null)
            //    return NotFound(new { messaage = "Usuário ou senha inválido" });

            //var token = TokenServices.GenerateToken(user);

            ////HttpContext.Session.SetString("SessionNome", user.Username);

            ////HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));



            //user.Password = "";
            //return new
            //{
            //    user = user.Username,
            //    token = token
            //};

        }
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult> PostUserAsync(Users user)
        {

            var usuario = new IdentityUser
            {
                UserName = user.Username,
                Email = user.Email,
                EmailConfirmed = true

            };

            


            var result = await _userManager.CreateAsync(usuario, user.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _signInManager.SignInAsync(usuario, false);
            return Ok(await GerarJwt(user.Email));














            //try
            //{
            //    _generally.Add(user);

            //    if (await _generally.SaveChangesAsync())
            //    {
            //        return Ok();
            //    }
            //    else { return BadRequest(); }

            //}
            //catch (Exception)
            //{

            //    throw new Exception();
            //}


        }


        [HttpPatch]
        public async Task<ActionResult> PatchUserPasswordAsync( [FromBody] Users user)
        {
            try
            {
                
              
                


                var identityFinded = await _userManager.FindByEmailAsync(user.Email);

                var senha = _userManager.PasswordHasher.HashPassword(identityFinded, user.Password);
                identityFinded.PasswordHash = senha;
                await _userManager.UpdateAsync(identityFinded);

               

               
               
                

               

                await _generally.SaveChangesAsync();
                return Ok(); 
               
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }

            
           

        }






        private async Task<string> GerarJwt(string email)
        {



            var user = await _userManager.FindByEmailAsync(email);





            var identityClaims = new ClaimsIdentity();





            identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));



            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)

            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }









        public class RetornoUsuario
        {
            public int IdBarbeiro { get; set; }
            public string NomeUsuario { get; set; }

            public string Token { get; set; }

            public int IdBarbearia { get ; set; }

            public RetornoUsuario(int idUser,string nomeUsuario, string token, int idbarbearia)
            {
                this.NomeUsuario = nomeUsuario;
                this.Token = token;
                this.IdBarbearia = idbarbearia;
                this.IdBarbeiro = idUser;
            }




        }

    }
}
