using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoAgendaContatos
{
    public partial class Cadastro : Form
    {
        cl_contato cont = new cl_contato();
        cl_ControleContato controle = new cl_ControleContato();
        public Cadastro()
        {
            InitializeComponent();
        }

        private void limpar()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtCelular.Clear();
            txtEmail.Clear();
            txtNome.Focus();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Não é permitido cadastro sem um nome!!!");
            }
            else
            {
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.cadastrar(cont));
                limpar();
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            cont.Codcontato = int.Parse(txtCodigo.Text);
            cont.Nome = txtNome.Text;
            cont.Telefone = txtTelefone.Text;
            cont.Celular = txtCelular.Text;
            cont.Email = txtEmail.Text;

            MessageBox.Show(controle.alterar(cont));
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cont.Codcontato = int.Parse(txtCodigo.Text);
            MessageBox.Show(controle.excluir(cont));
        }
    }
}
