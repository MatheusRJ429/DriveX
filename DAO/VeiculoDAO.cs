using AutoFrota.Model;

namespace AutoFrota.DAO;

// Dados em memória para manter o exemplo simples e pronto para demonstração.
public class VeiculoDAO
{
    private readonly List<Veiculo> _veiculos =
    [
        new() { Id = 1, Modelo = "Toyota Corolla", Placa = "ABC-1D23", Categoria = "Sedan", Ano = 2023, Status = "Disponível", Cor = "#2878d4" },
        new() { Id = 2, Modelo = "Jeep Compass", Placa = "QWE-4R56", Categoria = "SUV", Ano = 2024, Status = "Em uso", Cor = "#2d8b73" },
        new() { Id = 3, Modelo = "Fiat Strada", Placa = "RTY-7U89", Categoria = "Picape", Ano = 2022, Status = "Manutenção", Cor = "#e3a53b" },
        new() { Id = 4, Modelo = "Chevrolet Onix", Placa = "FGH-0J12", Categoria = "Hatch", Ano = 2023, Status = "Disponível", Cor = "#7a6fd6" }
    ];

    public IReadOnlyList<Veiculo> Listar() => _veiculos;
    public void Adicionar(Veiculo veiculo)
    {
        veiculo.Id = _veiculos.Count == 0 ? 1 : _veiculos.Max(v => v.Id) + 1;
        _veiculos.Add(veiculo);
    }
}
