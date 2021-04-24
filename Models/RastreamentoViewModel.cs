namespace AppWeb.Models
{
    public class RastreamentoViewModel
    {
        //Métodos get e métodos sets. 
        public int IdPedido { get; set; }

        public string DataEntregaPedido { get; set; }

        public string ValorPedido { get; set; }

        public string FretePedido { get; set;}

        public string StatusPedido { get; set;}

        public string DestinatarioPedido { get; set;}

        public string CepOrgPedido { get; set;}

        public string LogrOrgPedido { get; set;}

        public string CepDestPedido { get; set;}

        public string LogrDestPedido { get; set;}

        public string NumDestPedido { get; set;}

        
    }
}