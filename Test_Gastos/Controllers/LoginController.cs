using Test_Gastos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Test_Gastos.Extensiones;
using Layers;

namespace Test_Gastos.Controllers
{
    public class LoginController : SessionController
    {
        [HttpGet]
        public IActionResult Index()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.username))
            {
                return View(model);
            }
            if (string.IsNullOrEmpty(model.password))
            {
                return View(model);
            }
            //Encripta password
            model.password = model.password.Trim().ToUpper();
            model.password = Extensiones.AESCryptography.Encrypt(model.password);
            List<Usuario_BE> Lst = Usuario_BLL.Login(new Usuario_BE { usuario = model.username, password = model.password });
            var userLogin = Lst.FirstOrDefault();

            if (userLogin == null)
            {
                AddAlerta("Verifique sus credenciales.", NotifyIcon.warning);
                return View(model);
            }
            #region Authentication
            var claims = new[]
            {
                new Claim("Usuario",userLogin.usuario),
                new Claim("primer_nombre",userLogin.nombre),
                new Claim("primer_apellido",userLogin.apellido),
                new Claim("PathFoto",userLogin.path??""),
                new Claim("IdUsuario",userLogin.id_usuario.ToString()),
                new Claim("nombre_rol",userLogin.NOMBRE_ROL),
                new Claim("telefono",userLogin.telefono),
                new Claim("correo",userLogin.EMAIL)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            #endregion

            #region Listar Menu
            //Menu
            List<Usuario_BE> lst_menu = new List<Usuario_BE>();
            Set(SessionKeys.Menu, lst_menu);
            #endregion

            //Valida contraseña expirada
            /*
            if (userLogin.fecha_pass <= DateTime.Now)
            {
                AddAlerta("Tu contraseña debe ser actualizada", NotifyIcon.warning);
                return RedirectToAction(nameof(ResetPassword));
            }
            */
            return RedirectToAction(nameof(Index), "Home");
        }
        public async Task<IActionResult> Out()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpGet]
        [Authorize]
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
