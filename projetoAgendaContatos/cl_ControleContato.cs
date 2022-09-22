using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//biblioteca do mysql

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

    }
}
