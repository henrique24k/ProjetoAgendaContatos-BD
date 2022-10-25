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
    public partial class frmConsulta : Form
    {

        cl_contato cont = new cl_contato();

        cl_ControleContato controle = new cl_ControleContato();

        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbOpcao.SelectedIndex == 0)
            {
                try
                {
                    int codigo = int.Parse(txtBuscar.Text);
                    dataGridView1.DataSource = controle.pesquisaCodigo(codigo);
                }
                catch
                {
                    MessageBox.Show("Digite um valor inteiro para o codigo");
                    txtBuscar.Clear();
                    txtBuscar.Focus();
                  }

            }
            else if (cbOpcao.SelectedIndex == 1)
            {
                try
                {
                    string nome = txtBuscar.Text;
                    dataGridView1.DataSource = controle.pesquisaNome(nome);
                }
                catch
                {
                    MessageBox.Show("Digite um nome válido!");
                    txtBuscar.Clear();
                    txtBuscar.Focus();
                }

            }
            else if (cbOpcao.SelectedIndex == 2)
            {
                try
                {
                    string telefone = txtBuscar.Text;
                    dataGridView1.DataSource = controle.pesquisaTelefone(telefone);
                }
                catch
                {
                    MessageBox.Show("Digite um telefone válido!");
                    txtBuscar.Clear();
                    txtBuscar.Focus();
                }

            }
            else if (cbOpcao.SelectedIndex == 3)
            {
                try
                {
                    string celular = txtBuscar.Text;
                    dataGridView1.DataSource = controle.pesquisaCelular(celular);
                }
                catch
                {
                    MessageBox.Show("Digite um numero de celular válido!");
                    txtBuscar.Clear();
                    txtBuscar.Focus();
                }

            }

            else if (cbOpcao.SelectedIndex == 4)
            {
                try
                {
                    string email = txtBuscar.Text;
                    dataGridView1.DataSource = controle.pesquisaEmail(email);
                }
                catch
                {
                    MessageBox.Show("Digite um numero de Email válido!");
                    txtBuscar.Clear();
                    txtBuscar.Focus();
                }

            }
        }

        private void cbOpcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOpcao.SelectedIndex < 0)
            {
                txtBuscar.Enabled = false;
                btnBuscar.Enabled = false;
                lblOpcao.Text = "";
            }
            else
            {
                txtBuscar.Enabled = true;
                lblOpcao.Text = "Digite o " + cbOpcao.Text;
                txtBuscar.Clear();
                txtBuscar.Focus();
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controle.PreencherTodos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtBuscar.Text != "")
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled  = false;
            }
        }
    }
}
