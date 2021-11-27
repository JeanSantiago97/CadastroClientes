using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes
{
    public class Cadastro
    {
        // Instanciar a Classe Conexao
        Conexao conexao = new Conexao();

        // Instanciar a Classe de Comandos do SQL (Classe que manipula o banco)
        SqlCommand cmd = new SqlCommand();

        // Criar String de mensagem
        public string _mensagem = "";

        //Criar construtor com os parâmetros
        public Cadastro(string nome, string telefone)
        {
            //Criar um Try and Catch
            try
            {
                // Comando Sql -- Insert, update, delete, etc...
                cmd.CommandText = "insert into TB_CLIENTE(Nome, Telefone) values (@Nome, @Telefone)";

                // Parametros
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Telefone", telefone);

                // Conectar com banco
                cmd.Connection = conexao.Conectar();

                // Executar comando
                cmd.ExecuteNonQuery();

                // Desconectar banco
                conexao.Desconectar();

                // Mostrar mensagem de erro/sucesso
                _mensagem = "Dados enviados com sucesso!";
            }
            catch (SqlException)
            {
                _mensagem = "Dados não enviados!";
            }

        }
    }
}