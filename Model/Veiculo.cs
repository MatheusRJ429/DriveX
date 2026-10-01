namespace DriveX.Model
{
    public class Veiculo
    {
        // ID único do carro no banco.
        public int Id { get; set; }

        // Marca do carro. Exemplo: Chevrolet.
        public string Marca { get; set; } = string.Empty;

        // Modelo do carro. Exemplo: Onix.
        public string Modelo { get; set; } = string.Empty;

        // Placa do veículo.
        public string Placa { get; set; } = string.Empty;

        // Ano de fabricação/modelo.
        public int Ano { get; set; }

        // Categoria. Exemplo: SUV, Sedan, Hatch.
        public string Categoria { get; set; } = string.Empty;

        // Cor do veículo.
        public string Cor { get; set; } = string.Empty;

        // Quilometragem atual do carro.
        public int Quilometragem { get; set; }

        // Preço total para pagamento à vista.
        public decimal PrecoVista { get; set; }

        // Valor da entrada para financiamento.
        public decimal Entrada { get; set; }

        // Texto das parcelas. Exemplo: 48x R$ 1.200,00.
        public string Parcelas { get; set; } = string.Empty;

        // Situação atual: disponivel, vendido ou manutencao.
        public string Status { get; set; } = string.Empty;

        // Junta marca e modelo para mostrar no site.
        public string NomeCompleto => $"{Marca} {Modelo}";
    }
}