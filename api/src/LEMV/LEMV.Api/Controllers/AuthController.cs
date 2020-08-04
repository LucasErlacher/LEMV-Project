using LEMV.Api.ViewModels;
using LEMV.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;

namespace LEMV.Api.Controllers
{
    public class AuthController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotificator notificator,
                              SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager) : base(notificator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(LoginViewModel login)
        {
            if (AutenticateAD(login.Email, login.Senha))
            {
                var created = await CreateUserAD(login.Email);

                if (!created)
                {
                    // Atualiza informações do usuário
                    // _userManager.UpdateAsync();
                }

                var user = await _userManager.FindByNameAsync(login.Email);

                await _signInManager.SignInAsync(user, false);

                return Ok("Usuário Logado");
            }


            return BadRequest("Login ou senha incorretos");
        }

        private async Task<bool> CreateUserAD(string user)
        {
            var ADDomain = "192.168.250.195";
            var ADUsername = "administrator";
            var ADPassword = "pass@word1";

            using (var context = new PrincipalContext(ContextType.Domain, ADDomain, ADUsername, ADPassword))
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
            var ADDomain = "192.168.250.195";
            var ADUsername = "administrator";
            var ADPassword = "pass@word1";

            using var context = new PrincipalContext(ContextType.Domain,
                                                     ADDomain,
                                                     ADUsername,
                                                     ADPassword);

            return context.ValidateCredentials(username, password);
        }
    }
}