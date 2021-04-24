using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using AppWeb.Models;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using AppWeb.Config;
using Dapper;
using System;
using MySql.Data.MySqlClient;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


namespace AppWeb.Controllers
{
    public class BackofficeController : Controller
    {
        //Criar uma lista de pedidos 
        List<BackofficeViewModel> listDados;
        
        private readonly IConexao _conexao;

        //Construtor da classe RastreamentoController
        public BackofficeController(IConexao conexao)
        {
            _conexao = conexao;
        }
        
        
        public IActionResult Index()
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = @"SELECT * FROM usuario;";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();
            }

            return View(listDados);
        }

        //Manipulação de senha do admin
        [HttpGet("Backoffice/Admin")]
        public IActionResult Admin(int id)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM usuario WHERE idUsuario = {id};";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();   
            }
            
            return View(listDados);
        }

        [HttpGet("Backoffice/AdminSenha")]
        public IActionResult AdminSenha(int id, string senha)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"UPDATE usuario SET Senha = '{senha}' WHERE idUsuario = {id};";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();   
            }
            
            return RedirectToAction("Index");
        }


        //Manipulação da tabela de frete
        public IActionResult Frete()
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = @"SELECT * FROM TB_Frete;";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();
            }

            return View(listDados);
        }

        [HttpGet("Backoffice/FreteInclusao")]
        public IActionResult FreteInclusao(string modalidade, decimal valorMin, decimal coefDist, decimal coefPeso, decimal coefVol, string cepInicio, string cepFim)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"INSERT INTO TB_Frete VALUES(0,'{modalidade}',{valorMin},{coefDist},{coefPeso},{coefVol},'{cepInicio}','{cepFim}');";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();   
            }
            
            return RedirectToAction("Frete");
        }

        [HttpGet("Backoffice/FreteEdicao")]
        public IActionResult FreteEdicao(int id)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Frete WHERE IdFrete = {id};";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();   
            }
            
            return View(listDados);
        }

        [HttpGet("Backoffice/FreteAtualizacao")]
        public IActionResult FreteAtualizacao(int id, string modalidade, decimal valorMin, decimal coefDist, decimal coefPeso, decimal coefVol, string cepInicio, string cepFim)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"UPDATE TB_Frete SET ModFrete = '{modalidade}', ValorMinFrete = {valorMin}, CoefDistFrete = {coefDist}, CoefPesoFrete = {coefPeso}, CoefVolFrete = {coefVol}, CepInicioFrete = '{cepInicio}', CepFimFrete = '{cepFim}' WHERE IdFrete = {id};";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();   
            }
            
            return RedirectToAction("Frete");
        }

        [HttpGet("Backoffice/FreteExclusao")]
        public IActionResult FreteExclusao(int id)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"DELETE from TB_Frete where IdFrete = {id};";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();   
            }
            
            return RedirectToAction("Frete");
        }

        //Manipulação da tabela de cliente
        public IActionResult Cliente()
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = @"SELECT * FROM TB_Cliente;";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();
            }

            return View(listDados);
        }

        [HttpGet("Backoffice/ClientePedido")]
        public IActionResult ClientePedido(int id)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Pedido WHERE IdCliente = {id};";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();   
            }
            
            return View(listDados);
        }

        //Manipulação da tabela de pedidos
        public IActionResult Pedido()
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = @"SELECT IdCliente, IdPedido, DataEntregaPedido, ValorPedido, StatusPedido FROM TB_Pedido;";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();
            }

            return View(listDados);
        }

        [HttpGet("Backoffice/PedidoEdicaoStatus")]
        public IActionResult PedidoEdicaoStatus(int id)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Pedido WHERE IdPedido = {id};";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();   
            }
            
            return View(listDados);
        }

        [HttpGet("Backoffice/PedidoAtualizacaoStatus")]
        public IActionResult PedidoAtualizacaoStatus(int id, string status)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"UPDATE TB_Pedido SET StatusPedido = '{status}' WHERE IdPedido = {id};";
                listDados = conn.Query<BackofficeViewModel>(querySQL).ToList();   
            }
            
            return RedirectToAction("Pedido");
        }


    }
}