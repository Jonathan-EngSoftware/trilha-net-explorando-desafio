
namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        // Propriedade NOVA para guardar se tem animal
        public bool TemAnimalDeEstimacao { get; set; }

        // Propriedade NOVA para guardar se tem criança
        public bool TemCriancaMenorDe10 { get; set; }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Retorna um erro se a capacidade for menor que o número de hóspedes
                throw new Exception("A quantidade de hóspedes é maior que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor base da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // O valor da taxa para pet
            decimal taxaPet = 50.00M; 

            // CONDIÇÃO: Se tiver um animal, adiciona a taxa ao valor total
            if (TemAnimalDeEstimacao)
            {
                valor += taxaPet;
            }

            // Aplica desconto de 10% para reservas de 10 dias ou mais
            if (DiasReservados >= 10)
            {
                decimal desconto = valor * 0.10M;
                valor = valor - desconto;
            }

            return valor;
        }
    }
}