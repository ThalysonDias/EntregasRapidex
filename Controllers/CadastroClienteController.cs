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
    public class CadastroClienteController : Controller
    {
        List<CadastroClienteViewModel> listDados;

        private readonly IConexao _conexao;

        public CadastroClienteController(IConexao conexao)
        {
            _conexao = conexao;
        }

        public IActionResult Login()
        {
            return View();
        }

        //Cadastrando novo cliente
        public IActionResult FormularioCadastro()
        {
            return View();
        }     
        
        
        [HttpGet("CadastroCliente/ClienteNovo")]
        public IActionResult ClienteNovo(int id, string cpf, string nome, string email, string senha, string telefone)
        {
            using (var conn = _conexao.OpenConnection())
            {
                var querySQL = $"INSERT INTO TB_Cliente VALUES (0,'{cpf}','{nome}','{email}','{senha}','{telefone}');";
                listDados = conn.Query<CadastroClienteViewModel>(querySQL).ToList();
            }
            return RedirectToAction("Login","CadastroCliente");
        
        }
        

        //Buscando cliente já existente     
        [HttpGet("CadastroCliente/Buscar/")]
        public IActionResult Index(string dado)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Cliente WHERE EmailCliente = '{dado}';";
                listDados = conn.Query<CadastroClienteViewModel>(querySQL).ToList();
            }

            return View(listDados);
        }
        

        //Listando Pedidos do Cliente
        [HttpGet("CadastroCliente/Pedidos/")]
        public IActionResult Pedidos(int dado)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Pedido WHERE IdCliente = {dado};";
                listDados = conn.Query<CadastroClienteViewModel>(querySQL).ToList();
            }
            
            return View(listDados);
        }


        //Listando cartões de crédito do cliente
        [HttpGet("CadastroCliente/Cartoes/")]
        public IActionResult Cartoes(int dado)
        {
            using(var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT * FROM TB_Cartao WHERE IdCliente = {dado};";
                listDados = conn.Query<CadastroClienteViewModel>(querySQL).ToList();
            }

            return View(listDados);
        }


        [HttpGet("CadastroCliente/Cartoes/Editar/")]
        public IActionResult CartoesEditar(int id)
        {
            using (var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT IdCartao, BandeiraCartao, NumCartao, ValidadeCartao, BinCartao, NomeCartao, CPFCartao FROM TB_Cartao where idCartao = {id};";
                listDados = conn.Query<CadastroClienteViewModel>(querySQL).ToList();
            }
            return View(listDados);
        }

        [HttpGet("CadastroCliente/CartaoSalvar")]
        public IActionResult CartaoSalvar(int id, string bandeira, string numero, string validade, string bin, string nome, string cpf)
        {
            using (var conn = _conexao.OpenConnection())
            {
                var querySQL = $"UPDATE TB_Cartao SET BandeiraCartao = '{bandeira}', NumCartao = '{numero}', ValidadeCartao = '{validade}', BinCartao = '{bin}', NomeCartao = '{nome}', CPFCartao = '{cpf}' WHERE IdCartao = {id};";
                listDados = conn.Query<CadastroClienteViewModel>(querySQL).ToList();
            }
            return RedirectToAction("Login");
        }

        public IActionResult CartaoDelete(int id)
        {
            using (var conn = _conexao.OpenConnection())
            {
                var querySQL = $"DELETE from TB_Cartao where IdCartao = {id};";
                conn.Execute(querySQL);
            }
            return RedirectToAction("Login");
        }

         
        [HttpGet("CadastroCliente/CartoesIncluir/")]
        public IActionResult CartoesIncluir(int idcliente)
        {
            using (var conn = _conexao.OpenConnection())
            {
                var querySQL = $"SELECT IdCliente FROM TB_Cartao where idCliente = {idcliente};";
                listDados = conn.Query<CadastroClienteViewModel>(querySQL).ToList();
            }
            return View(listDados);
        }
        
        [HttpGet("CadastroCliente/CartoesCadastrar")]
        public IActionResult CartoesCadastrar(int idcliente, string bandeira, string numero, string validade, string bin, string nome, string cpf)
        {
            using (var conn = _conexao.OpenConnection())
            {
                var querySQL = $"INSERT INTO TB_Cartao VALUES ({idcliente},0,'{bandeira}','{numero}','{validade}','{bin}','{nome}','{cpf}');";
                listDados = conn.Query<CadastroClienteViewModel>(querySQL).ToList();
            }
            return RedirectToAction("Login");
        }       
            
        
    }
}



