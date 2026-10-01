// Importa a classe Conexao, responsável por abrir a conexão com o MySQL.
using DriveX.Configs;

// Importa a classe ChamadoSuporte, que representa os chamados dos clientes.
using DriveX.Model;

// Define o namespace onde ficam as classes que acessam o banco de dados.
namespace DriveX.DAO;

// Classe responsável por buscar os chamados de suporte no banco.
public class ChamadoSuporteDAO
{
    // Guarda a conexão com o banco de dados.
    private readonly Conexao _conexao;

    // Construtor da classe.
    // Recebe a conexão criada e registrada no Program.cs.
    public ChamadoSuporteDAO(Conexao conexao)
    {
        // Salva a conexão recebida na variável _conexao.
        _conexao = conexao;
    }

    // Método que busca todos os chamados de suporte cadastrados.
    // Retorna uma lista de objetos ChamadoSuporte.
    public List<ChamadoSuporte> Listar()
    {
        // Cria uma lista vazia para guardar os chamados encontrados.
        var lista = new List<ChamadoSuporte>();

        // Abre a conexão com o MySQL.
        // using fecha a conexão automaticamente ao terminar o método.
        using var con = _conexao.GetConnection();

        // Cria o comando SQL que será enviado ao banco.
        using var comando = con.CreateCommand();

        // SELECT que busca os chamados de suporte.
        // INNER JOIN junta a tabela Chamados_Suporte com Clientes.
        // Isso permite mostrar o nome do cliente, e não apenas o ID dele.
        comando.CommandText = @"
            SELECT
                ch.id_chamado,
                ch.id_cliente_fk,
                cli.nome AS nome_cliente,
                ch.tipo_suporte,
                ch.mensagem,
                ch.data_chamado,
                ch.status
            FROM Chamados_Suporte ch
            INNER JOIN Clientes cli
                ON cli.id_cliente = ch.id_cliente_fk
            ORDER BY ch.data_chamado DESC;
        ";

        // Executa a consulta SELECT.
        // leitor permite percorrer os registros encontrados.
        using var leitor = comando.ExecuteReader();

        // Enquanto houver registros no resultado da consulta...
        while (leitor.Read())
        {
            // Cria um objeto ChamadoSuporte para cada linha encontrada
            // e adiciona diretamente na lista.
            lista.Add(new ChamadoSuporte
            {
                // Pega o ID do chamado.
                Id = Convert.ToInt32(leitor["id_chamado"]),

                // Pega o ID do cliente que abriu o chamado.
                IdCliente = Convert.ToInt32(leitor["id_cliente_fk"]),

                // Pega o nome do cliente pela tabela Clientes.
                NomeCliente = leitor["nome_cliente"].ToString() ?? "",

                // Pega o tipo do chamado: dúvida, pagamento, veículo etc.
                TipoSuporte = leitor["tipo_suporte"].ToString() ?? "",

                // Pega a mensagem enviada pelo cliente.
                Mensagem = leitor["mensagem"].ToString() ?? "",

                // Verifica se a data do chamado está vazia no banco.
                // Se estiver vazia, salva null.
                // Se existir uma data, converte para DateTime.
                DataChamado = leitor["data_chamado"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(leitor["data_chamado"]),

                // Pega o status do chamado: aberto, em andamento ou resolvido.
                Status = leitor["status"].ToString() ?? ""
            });
        }

        // Devolve a lista de chamados para a página Suporte.razor.
        return lista;
    }
}