using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LabApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace LabApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet("/Auth/Login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("/Auth/Login")]
        public async Task<IActionResult> Validar(string username, string password, string returnUrl)
        {
            // lectura de base de datos
            var db = new lab_mundoContext();
            var usuarioLogueado = db.Empleados.FirstOrDefault(u => u.Usuario == username && u.Contraseña == password);

            if (usuarioLogueado != null)
            {
                var solicitudes = new List<Claim>();
                solicitudes.Add(new Claim("username", username));
                solicitudes.Add(new Claim(ClaimTypes.NameIdentifier, username));
                solicitudes.Add(new Claim(ClaimTypes.Name, usuarioLogueado.Nombre));
                solicitudes.Add(new Claim(ClaimTypes.Role, usuarioLogueado.Rol));
                var solicitud_identidad = new ClaimsIdentity(solicitudes, CookieAuthenticationDefaults.AuthenticationScheme);
                var solicitud_principal = new ClaimsPrincipal(solicitud_identidad);
                await HttpContext.SignInAsync(solicitud_principal);
                return Redirect("Cuenta");
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                TempData["Error"] = "El usuario o contraseña no son válidos.";
                return View("Login");
            }
        }

        [Authorize]
        public async Task<IActionResult> SalirSesion()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [Authorize]
        public IActionResult Cuenta()
        {
            return View();
        }

        [Authorize]
        public IActionResult Denegado()
        {
            return View();
        }
    }
}
