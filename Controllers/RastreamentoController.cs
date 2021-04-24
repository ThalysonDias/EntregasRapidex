using System;
using System.Collections.Generic;
using AppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using AppWeb.Config;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;


namespace AppWeb.Controllers
{
    public class RastreamentoController : Controller
    {
        
        //Criar uma lista de pedidos 
        List<RastreamentoViewModel> listPedidos;
        private readonly IConexao _conexao;

        //Construtor da classe RastreamentoController
        public RastreamentoController(IConexao conexao)
        {
            _conexao = conexao;
        }

       
        [HttpGet("Rastreamento/Listar/")]
        public IActionResult Index(int pedido)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Pedido WHERE IdPedido = {pedido};";
                listPedidos = conn.Query<RastreamentoViewModel>(querySQL).ToList();
            }

            return View(listPedidos);
        }

    }
}