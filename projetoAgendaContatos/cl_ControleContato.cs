using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//biblioteca do mysql
using MySqlX.XDevAPI.Relational;

namespace projetoAgendaContatos
{
    class cl_ControleContato
    {
        cl_Conexao c = new cl_Conexao();

        public string cadastrar(cl_contato cont)//método cadastrar
        {
            try
            {
                string sql = "INSERT INTO tbcontato (nome, telefone, celular, email) " +
                             "VALUES ('" + cont.Nome + "', '" + cont.Telefone + "', " +
                             "'" + cont.Celular + "', '" + cont.Email + "')";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                //abrindo a conexao
                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Cadastro realizado com sucesso.");
            }

            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string alterar(cl_contato cont)
        {
            try
            {
                string sql = "update tbcontato set nome = '" + cont.Nome + "' , " + "telefone = '" + cont.Telefone +
                    "', celular = '" + cont.Celular + "', email = '" + cont.Email +
                    "' where codcontato = " + cont.Codcontato + " ; ";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();

                return ("Alterado com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());

            }
        }
        public string excluir(cl_contato cont)
        {
            try
            {
                string sql = "delete from tbcontato where codcontato = " + cont.Codcontato + " ; ";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();

                return ("Registro excluido com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());

            }

        }

        public cl_contato buscar(int codigo)
        {
            cl_contato cont = new cl_contato();

            try
            {
                string sql = "select * from tbcontato where codcontato = " + codigo + " ; ";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                c.conectar();

                MySqlDataReader objDados = cmd.ExecuteReader();
                if (!objDados.HasRows)
                {
                    return null;
                }
                else
                {
                    objDados.Read();
                    cont.Codcontato = Convert.ToInt32(objDados["codcontato"]);
                    cont.Nome = objDados["nome"].ToString();
                    cont.Telefone = objDados["telefone"].ToString();
                    cont.Celular = objDados["celular"].ToString();
                    cont.Email = objDados["email"].ToString();

                    objDados.Close();
                    return cont;

                }
            }

            catch(MySqlException e)
            {
                throw (e);
            }
            finally
            {
                c.desconectar();
            }

        }

        public DataTable PreencherTodos()
        {
            string sql = " select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato ; ";

            MySqlCommand cmd = new MySqlCommand (sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;

        }

        public DataTable pesquisaCodigo(int codigo)
        {
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tbcontato where codcontato = " + codigo + " ; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato); ;
            c.desconectar() ;
            return contato;
        }
        public DataTable pesquisaNome(string nome)
        {
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tbcontato where nome like '%" + nome + "%' ; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato); ;
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaTelefone(string telefone)
        {
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tbcontato where telefone like '%" + telefone + "%' ; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato); ;
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaCelular(string celular)
        {
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tbcontato where celular like '%" + celular + "%' ; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato); ;
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaEmail(string email)
        {
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tbcontato where email like '%" + email + "%' ; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato); ;
            c.desconectar();
            return contato;
        }

        public string Backup(string Caminho)
        {
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string CaminhoBackup = Caminho + "\\backupContatos_" + dataAtual + ".sql";

            try
            {
                MySqlCommand cmd = new MySqlCommand(CaminhoBackup, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);
                c.conectar();
                mb.ExportToFile(CaminhoBackup);
                c.desconectar();
                return ("Backup  do banco de dados realizado com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string Retore(string Caminho) //Backup a MySQL database
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(Caminho, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);
                c.conectar();
                mb.ImportFromFile(Caminho);
                c.desconectar();
                return ("Banco de dados restaurado com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

    }
}
