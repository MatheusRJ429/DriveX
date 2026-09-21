namespace DriveX.Model;

public class Preco
{
    public int Id { get; set; }
    public int IdCarro { get; set; }
    public DateOnly DataPreco { get; set; }
    public decimal Entrada { get; set; }
    public string Parcelas { get; set; } = string.Empty;
    public decimal PrecoVista { get; set; }
    public decimal IpvaEstimado { get; set; }
    public string Status { get; set; } = string.Empty;
}