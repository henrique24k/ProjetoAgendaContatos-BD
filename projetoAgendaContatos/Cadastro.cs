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

            MessageBox.Show(controle.cadastrar(cont));

            limpar();
            AlteraBotoes(1);


        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            cont.Codcontato = int.Parse(txtCodigo.Text);
            cont.Nome = txtNome.Text;
            cont.Telefone = txtTelefone.Text;
            cont.Celular = txtCelular.Text;
            cont.Email = txtEmail.Text;

            MessageBox.Show(controle.alterar(cont));

            MessageBox.Show(controle.alterar(cont));

            AlteraBotoes(1);
            limpar();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cont.Codcontato = int.Parse(txtCodigo.Text);
            MessageBox.Show(controle.excluir(cont));

            MessageBox.Show(controle.excluir(cont));

            limpar();
            AlteraBotoes(1);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cont = controle.buscar(int.Parse(txtCodigo.Text));
                if(cont is null)
                {
                    MessageBox.Show("Registro não encontrado!");
                    limpar();
                }
                else
                {
                    txtCodigo.Text = cont.Codcontato.ToString();
                    txtNome.Text = cont.Nome;
                    txtTelefone.Text = cont.Telefone;
                    txtCelular.Text = cont.Celular;
                    txtEmail.Text = cont.Email;
                }
                AlteraBotoes(3);

            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AlteraBotoes(1);
            limpar();

        }

        public void AlteraBotoes(int op)
        {
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = false;
            btnBuscar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;

            if (op == 1)
            {
                btnNovo.Enabled = true;
            }
            
            if (op == 2)
            {
                btnCadastrar.Enabled = true;
                btnCancelar.Enabled = true;
            }

            if (op == 3)
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnCancelar.Enabled = true;
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            AlteraBotoes(2);
            limpar();
        }

        private void Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }

        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Pink;
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Pink;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Pink;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).BackColor = Color.Pink;
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).BackColor = Color.White;
        }

        private void txtCelular_Enter(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).BackColor = Color.Pink;
        }

        private void txtCelular_Leave(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).BackColor = Color.White;
        }
    }
}
