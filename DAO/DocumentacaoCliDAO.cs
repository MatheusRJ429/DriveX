// Importa a classe Conexao, responsável por abrir a conexão com o MySQL.
using DriveX.Configs;

// Importa a classe DocumentacaoCli, que representa os documentos dos clientes.
using DriveX.Model;

// Define o namespace onde ficam as classes que acessam o banco de dados.
namespace DriveX.DAO;

// Classe responsável por buscar os documentos dos clientes no banco.
public class DocumentacaoCliDAO
{
    // Guarda a conexão com o banco de dados.
    private readonly Conexao _conexao;

    // Construtor da classe.
    // Recebe a conexão criada no Program.cs.
    public DocumentacaoCliDAO(Conexao conexao)
    {
        // Salva a conexão recebida na variável _conexao.
        _conexao = conexao;
    }

    // Método que busca todos os documentos dos clientes.
    // Retorna uma lista de objetos DocumentacaoCli.
    public List<DocumentacaoCli> Listar()
    {
        // Cria uma lista vazia para guardar os documentos encontrados.
        var lista = new List<DocumentacaoCli>();

        // Abre a conexão com o MySQL.
        // using fecha a conexão automaticamente ao terminar o método.
        using var con = _conexao.GetConnection();

        // Cria o comando SQL que será enviado ao banco.
        using var comando = con.CreateCommand();

        // SELECT que busca os documentos cadastrados.
        // O INNER JOIN junta informações de três tabelas:
        // Documentacao_Cli, Clientes e Documento_Car.
        comando.CommandText = @"
            SELECT
                dc.id_documentacao,
                dc.id_cliente_fk,
                dc.id_documento_fk,
                cli.nome AS nome_cliente,
                doc.nome_documento,
                dc.conferido,
                dc.data_conferencia
            FROM Documentacao_Cli dc
            INNER JOIN Clientes cli
                ON cli.id_cliente = dc.id_cliente_fk
            INNER JOIN Documento_Car doc
                ON doc.id_documento = dc.id_documento_fk
            ORDER BY dc.id_documentacao DESC;
        ";

        // Executa a consulta SELECT.
        // O leitor permite percorrer cada linha encontrada.
        using var leitor = comando.ExecuteReader();

        // Enquanto existirem registros no resultado da consulta...
        while (leitor.Read())
        {
            // Cria um objeto DocumentacaoCli e adiciona diretamente na lista.
            lista.Add(new DocumentacaoCli
            {
                // Pega o ID do registro de documentação.
                Id = Convert.ToInt32(leitor["id_documentacao"]),

                // Pega o ID do cliente relacionado ao documento.
                IdCliente = Convert.ToInt32(leitor["id_cliente_fk"]),

                // Pega o ID do tipo de documento.
                IdDocumento = Convert.ToInt32(leitor["id_documento_fk"]),

                // Pega o nome do cliente pela tabela Clientes.
                // ?? "" evita erro caso o valor venha vazio.
                NomeCliente = leitor["nome_cliente"].ToString() ?? "",

                // Pega o nome do documento pela tabela Documento_Car.
                NomeDocumento = leitor["nome_documento"].ToString() ?? "",

                // Pega a situação do documento: sim, pendente etc.
                Conferido = leitor["conferido"].ToString() ?? "",

                // Verifica se a data está vazia no banco.
                // Se estiver vazia, salva null.
                // Se existir uma data, converte para DateTime.
                DataConferencia = leitor["data_conferencia"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(leitor["data_conferencia"])
            });
        }

        // Devolve a lista de documentos para a página Documentacao.razor.
        return lista;
    }
}