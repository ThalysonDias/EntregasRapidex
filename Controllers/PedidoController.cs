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
    public class PedidoController : Controller
    {
        List<PedidoViewModel> listDados;

        private readonly IConexao _conexao;

        public PedidoController(IConexao conexao)
        {
            _conexao = conexao;
        }

        [HttpGet("Pedido/Inclusao/")]
        public IActionResult Inclusao(int id, string nome, string telefone, string senha)
        {
            using (var conn = _conexao.OpenConnection())
            {
                var querySQL = $"UPDATE TB_Cliente SET NomeCliente = '{nome}', TelefoneCliente = '{telefone}', SenhaCliente = '{senha}' WHERE IdCliente = {id};";
                listDados = conn.Query<PedidoViewModel>(querySQL).ToList();
                
                var querySQL3 = $"SELECT * FROM TB_Cliente where IdCliente = {id};";
                listDados = conn.Query<PedidoViewModel>(querySQL3).ToList();
            }
            return View(listDados);
        }


        [HttpGet("Pedido/Finalizacao/")]
        public IActionResult Finalizacao(int id, decimal peso, string tel, string dest, string telDest, decimal vol, string cepOrg, string logOrg, int numOrg, string compOrg, string bairroOrg, string cidOrg, string ufOrg, string cepDest, string logDest, int numDest, string compDest, string bairroDest, string cidDest, string ufDest, string bandeira, string numero, string validade, string bin, string nome, string cpf)
        {
            using (var conn = _conexao.OpenConnection())
            {
                var querySQL = $"INSERT INTO TB_Pedido VALUES ({id},0,'30/06/2020',50.25,'Rapido','Pago',{peso},'{tel}','{dest}','{telDest}',{vol},'{cepOrg}','{logOrg}',{numOrg},'{bairroOrg}','{compOrg}','{cidOrg}','{ufOrg}','{cepDest}','{logDest}',{numDest},'{bairroDest}','{compDest}','{cidDest}','{ufDest}');";
                listDados = conn.Query<PedidoViewModel>(querySQL).ToList();

                var querySQL2 = $"INSERT INTO TB_Cartao VALUES ({id},0,'{bandeira}','{numero}','{validade}','{bin}','{nome}','{cpf}');";
                listDados = conn.Query<PedidoViewModel>(querySQL2).ToList();
            }

            return RedirectToAction("Sucesso");
        }

        public IActionResult Sucesso()
        {
            return View();
        }
    }
}