namespace AppWeb.Models
{
    public class FreteViewModel
    {
        public string IdFrete { get; set; }

        public string ModFrete { get; set; }

        public decimal ValorMinFrete { get; set; }

        public decimal CoefDistFrete { get; set; }

        public decimal CoefPesoFrete { get; set; }

        public decimal CoefVolFrete { get; set; }

        public string CepInicioFrete { get; set; }

        public string CepFimFrete { get; set; }

        public int quantidade { get; set; }

        public int peso { get; set; }

        public int resultado { get; set; }

    }
}