using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppWeb.Models;
using AppWeb.Config;
using MySql.Data.MySqlClient;
using Dapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;



namespace AppWeb.Controllers
{
    public class FreteController : Controller
    {
        
         List<FreteViewModel> listDados;
        
        private readonly IConexao _conexao;

        //Construtor da classe RastreamentoController
        public FreteController(IConexao conexao)
        {
            _conexao = conexao;
        }
        

        public IActionResult FreteRapido()
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Frete WHERE IdFrete = 1;";
                listDados = conn.Query<FreteViewModel>(querySQL).ToList();   
            }
            
            return View(listDados);
        }


        public IActionResult FreteEstadual()
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Frete WHERE IdFrete = 2;";
                listDados = conn.Query<FreteViewModel>(querySQL).ToList();   
            }

            return View(listDados);
        }

        public IActionResult FreteNacional()
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Frete WHERE IdFrete = 3;";
                listDados = conn.Query<FreteViewModel>(querySQL).ToList();   
            }
            return View(listDados);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}