// Importa a classe Conexao, responsável por abrir a conexão com o MySQL.
using DriveX.Configs;

// Importa a classe DocumentoCar, que representa um tipo de documento.
using DriveX.Model;

namespace DriveX.DAO
{
    // Classe responsável por buscar os tipos de documentos na tabela Documento_Car.
    public class DocumentoCarDAO
    {
        // Guarda a conexão com o banco de dados.
        private readonly Conexao _conexao;

        // Construtor da classe.
        // Recebe a conexão criada e registrada no Program.cs.
        public DocumentoCarDAO(Conexao conexao)
        {
            // Salva a conexão recebida na variável _conexao.
            _conexao = conexao;
        }

        // Método que busca todos os documentos cadastrados no banco.
        // Retorna uma lista de objetos DocumentoCar.
        public List<DocumentoCar> Listar()
        {
            // Cria uma lista vazia para guardar os documentos encontrados.
            var lista = new List<DocumentoCar>();

            // Abre a conexão com o MySQL.
            // using fecha a conexão automaticamente ao terminar o método.
            using var con = _conexao.GetConnection();

            // Cria um comando SQL usando a conexão aberta.
            using var comando = con.CreateCommand();

            // Define a consulta que busca todos os registros da tabela Documento_Car.
            comando.CommandText = "SELECT * FROM Documento_Car";

            // Executa a consulta SELECT.
            // leitor permite percorrer os registros encontrados.
            using var leitor = comando.ExecuteReader();

            // Enquanto houver registros no resultado da consulta...
            while (leitor.Read())
            {
                // Cria um objeto DocumentoCar para cada linha encontrada
                // e adiciona esse objeto diretamente na lista.
                lista.Add(new DocumentoCar
                {
                    // Pega o ID do documento no banco.
                    Id = Convert.ToInt32(leitor["id_documento"]),

                    // Pega o nome do documento.
                    // ?? "" evita erro caso o valor venha vazio.
                    NomeDocumento = leitor["nome_documento"].ToString() ?? ""
                });
            }

            // Devolve a lista de documentos para outras partes do sistema.
            return lista;
        }
    }
}