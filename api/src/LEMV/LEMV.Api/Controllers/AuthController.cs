using LEMV.Api.Configurations;
using LEMV.Api.ViewModels;
using LEMV.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.DirectoryServices.AccountManagement;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LEMV.Api.Controllers
{
    public class AuthController : BaseController
    {
        private readonly ActiveDirectory _configurationAD;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(IOptions<ActiveDirectory> configurationAD,
                              INotificator notificator,
                              SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager) : base(notificator)
        {
            _configurationAD = configurationAD.Value;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(LoginViewModel login)
        {
            if (AutenticateAD(login.Email, login.Senha))
            {
                await CreateUserAD(login.Email);

                var user = await _userManager.FindByNameAsync(login.Email);

                //await _signInManager.SignInAsync(user, false);

                return Ok(new
                {
                    user = user.UserName,
                    token = GenerateToken(user)
                });
            }

            return BadRequest("Login ou senha incorretos");
        }

        private async Task<bool> CreateUserAD(string user)
        {
            using (var context = new PrincipalContext(ContextType.Domain,
                                                      _configurationAD.Domain,
                                                      _configurationAD.Username,
                                                      _configurationAD.Password))
            using (var adUser = UserPrincipal.FindByIdentity(context, user))
            {
                var identity_user = new IdentityUser
                {
                    UserName = string.IsNullOrWhiteSpace(adUser.EmailAddress) ? "default@email.com" : adUser.SamAccountName,
                    Email = adUser.EmailAddress,
                    PhoneNumber = adUser.VoiceTelephoneNumber,
                };

                var result = await _userManager.CreateAsync(identity_user);

                if (result.Succeeded) return true;
            }

            return false;
        }

        private bool AutenticateAD(string username, string password)
        {
            using var context = new PrincipalContext(ContextType.Domain,
                                                      _configurationAD.Domain,
                                                      _configurationAD.Username,
                                                      _configurationAD.Password);
            return context.ValidateCredentials(username, password);
        }

        private string GenerateToken(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("TESTESUPERSECRETO");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "Aluno")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}