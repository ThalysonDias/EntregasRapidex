using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using AppWeb.Models;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using AppWeb.Config;
using Dapper;

namespace AppWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConexao _conexao;

        public LoginController(IConexao conexao)
        {
            _conexao = conexao;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        
        [HttpGet]
        public ActionResult UsuarioLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UsuarioLogin([FromForm] UsuarioViewModel model)
        {
            UsuarioViewModel usuario = null;

            using (var conn = _conexao.OpenConnection())
            {
                string queryQuery = $"select * from usuario where login = '{model.Login}' and senha = '{model.Senha}'; ";
                usuario = conn.QueryFirst<UsuarioViewModel>(queryQuery);
            }

            if (usuario != null)
            {
                var userClaims = new List<Claim>()
                {
                    //definir o cookie
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email,usuario.Email)
                };

                var minhaIdentidade = new ClaimsIdentity(userClaims, "Usuario");
                var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentidade });

                await HttpContext.SignInAsync(userPrincipal);
                return RedirectToAction("Index", "Backoffice");
            }

            ViewBag.Mensagem = "Crendencias inválidas!";

            return View(model);
        }

       
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}