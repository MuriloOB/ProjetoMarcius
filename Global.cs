using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProjetoCadastroMarcius
{
    class Global
    {
        public static MySqlConnection Conexao;
        public static MySqlCommand Comando;
        public static MySqlDataAdapter Adaptador;
        public static MySqlDataReader rConsulta;
        public static DataTable datTabela;
      


        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server = localhost; uid = root; pwd = 99278331");
                Conexao.Open();
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS bdProjeto_marcius; USE bdProjeto_marcius;", Conexao);
                Comando.ExecuteNonQuery();
                Conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conexao.Close();
            }
        }
        public static void CriarTabela()
        {
            try
            {
                Conexao.Open();
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Funcionario " +
                                               "(id integer auto_increment primary key, " +
                                               "Nome char(40), " +
                                               "CPF char(30)," +
                                               "RG char(40)," +
                                               "EMAIL char(30)," +
                                               "TELEFONE char(30)," +
                                               "CELULAR char(30)," +
                                               "ENDERECO char(30)," +
                                               "BAIRRO char(30)," +
                                               "NUMERO char(6)," +
                                               "COMPLEMENTO char(40)," +
                                               "CIDADE char(40)," +
                                               "UF char(2))", Conexao);
                Comando.ExecuteNonQuery();
                Conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conexao.Close();
            }


        }
        public static void ConsultarFuncionario(String nome)
        {
            try
            {
                Comando = new MySqlCommand("SELECT * FROM Funcionario where nome like ?nome order by nome", Conexao);
                Comando.Parameters.AddWithValue("?nome", nome + "%");
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
                
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }


       

    }
}
