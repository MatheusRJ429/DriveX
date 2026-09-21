using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO;

public class ClienteDAO
{
    private readonly Conexao _conexao;

    public ClienteDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<Cliente> Listar()
    {
        var lista = new List<Cliente>();

        using var con = _conexao.GetConnection();
        using var comando = con.CreateCommand();

        comando.CommandText = "SELECT * FROM Clientes";

        using var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            lista.Add(new Cliente
            {
                Id = Convert.ToInt32(leitor["id_cliente"]),
                Nome = leitor["nome"].ToString() ?? "",
                Cpf = leitor["cpf"].ToString() ?? "",
                Telefone = leitor["telefone"].ToString() ?? "",
                Email = leitor["email"].ToString() ?? "",
                ModeloInteresse = leitor["modelo_interesse"].ToString() ?? "",
                StatusAtendimento = leitor["status_atend"].ToString() ?? "",
                Observacao = leitor["observacao"].ToString() ?? ""
            });
        }

        return lista;
    }
}