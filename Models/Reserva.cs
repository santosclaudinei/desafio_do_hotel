namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        protected Reserva() { }

        public Reserva(int diasReservados) => DiasReservados = diasReservados;

        public void CadastrarSuite(Suite suite) => Suite = suite;

        public int ObterQuantidadeHospedes() => Hospedes.Count;
        
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count() > Suite.Capacidade)
                throw new BadRequestException("Não é possível hospedar esse número de hospedes nesse quarto.");

            Hospedes = hospedes;
        }

        public decimal CalcularValorDiaria()
        {
            if (DiasReservados <= 10) return Suite.ValorDiaria * DiasReservados;
            
            var valor = Suite.ValorDiaria * DiasReservados;
            var desconto = valor * (decimal)0.10;
            return valor - desconto;
        }
    }
}