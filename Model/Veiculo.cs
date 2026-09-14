namespace AutoFrota.Model;

public class Veiculo
{
    public int Id { get; set; }
    public string Modelo { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public int Ano { get; set; }
    public string Status { get; set; } = "Disponível";
    public string Cor { get; set; } = "#315b8f";
}
