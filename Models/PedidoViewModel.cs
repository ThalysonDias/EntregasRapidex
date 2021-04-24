namespace AppWeb.Models
{
    public class PedidoViewModel
    {
        public int IdCliente { get; set; }

        public string CPFCliente { get; set; }

        public string NomeCliente { get; set; }

        public string EmailCliente { get; set;}

        public string TelefoneCliente { get; set;}

        public string SenhaCliente { get; set;}

        public int IdPedido { get; set;}

        public string DataEntregaPedido { get; set;}
        
        public decimal ValorPedido { get; set;}

        public string FretePedido { get; set;}

        public string StatusPedido { get; set;}

        public decimal PesoPedido { get; set;}

        public decimal VolumePedido { get; set;}

        public string TelRemPedido { get; set;}

        public string DestinatarioPedido { get; set;}

        public string TelDestinatarioPedido { get; set;}

        public string CepOrgPedido { get; set;}

        public string LogrOrgPedido { get; set;}

        public int NumOrgPedido { get; set;}

        public string CompOrgPedido { get; set;}

        public string BairroOrgPedido { get; set;}

        public string CidadeOrgPedido { get; set;}

        public string UFOrgPedido { get; set;}

        public string CepDestPedido { get; set;}

        public string LogrDestPedido { get; set;}

        public int NumDestPedido { get; set;}

        public string CompDestPedido { get; set;}

        public string BairroDestPedido { get; set;}

        public string CidadeDestPedido { get; set;}

        public string UFDestPedido { get; set;}

        public int IdCartao { get; set;}

        public string BandeiraCartao { get; set;}

        public string NumCartao {get; set;}

        public string ValidadeCartao {get; set;}

        public string BinCartao {get; set;}

        public string NomeCartao {get; set;}

        public string CPFCartao {get; set;}
    }
}