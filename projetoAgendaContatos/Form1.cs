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
    public partial class Form1 : Form
    {
        cl_contato cont = new cl_contato();

        cl_ControleContato controle = new cl_ControleContato();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cl_Conexao conexao = new cl_Conexao();

            MessageBox.Show(conexao.conectar());

            FormPrincipal TelaLogin = new FormPrincipal();
            TelaLogin.ShowDialog();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro FormCad = new Cadastro();
            FormCad.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta frmConsulta = new frmConsulta();
            frmConsulta.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(controle.Backup("C:\\Backup"), "Backup do Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //O backup é criado no disco local c do pc
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void restauraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string CaminhoBackup = openFileDialog1.FileName;
                MessageBox.Show(controle.Retore(CaminhoBackup), "Restauração do BD",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
