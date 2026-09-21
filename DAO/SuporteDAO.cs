using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO
{
    

    public class ChamadoSuporteDAO
    {
        private readonly Conexao _conexao;

        public ChamadoSuporteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<ChamadoSuporte> Listar()
        {
            var lista = new List<ChamadoSuporte>();

            using var con = _conexao.GetConnection();
            using var comando = con.CreateCommand();

            comando.CommandText = "SELECT * FROM Chamados_Suporte";

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(new ChamadoSuporte
                {
                    Id = Convert.ToInt32(leitor["id_chamado"]),
                    IdCliente = Convert.ToInt32(leitor["id_cliente_fk"]),
                    TipoSuporte = leitor["tipo_suporte"].ToString() ?? "",
                    Mensagem = leitor["mensagem"].ToString() ?? "",
                    DataChamado = leitor["data_chamado"] == DBNull.Value
                        ? null
                        : Convert.ToDateTime(leitor["data_chamado"]),
                    Status = leitor["status"].ToString() ?? ""
                });
            }

            return lista;
        }
    }

}
