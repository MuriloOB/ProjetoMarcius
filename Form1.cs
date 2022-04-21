using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoCadastroMarcius
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            
            InitializeComponent();
        }

        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void lblNumero_Click(object sender, EventArgs e)
        {

        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            Global.AbrirConexao();
            Global.CriarTabela();
            Global.ConsultarFuncionario("");
            dgvCadastro.DataSource = Global.datTabela;
        }

        private void dgvCadastro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCadastro.CurrentRow == null)
            {
                return;
            }

            txtID.Text = dgvCadastro.CurrentRow.Cells[0].Value.ToString();
            txtNOME.Text = dgvCadastro.CurrentRow.Cells[1].Value.ToString();
            txtCPF.Text = dgvCadastro.CurrentRow.Cells[2].Value.ToString();
            txtRG.Text = dgvCadastro.CurrentRow.Cells[3].Value.ToString();
            txtNUMERO.Text = dgvCadastro.CurrentRow.Cells[9].Value.ToString();
            txtEmail.Text = dgvCadastro.CurrentRow.Cells[4].Value.ToString();
            txtUF.Text = dgvCadastro.CurrentRow.Cells[12].Value.ToString();
            txtCelular.Text = dgvCadastro.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = dgvCadastro.CurrentRow.Cells[7].Value.ToString();
            txtBairro.Text = dgvCadastro.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = dgvCadastro.CurrentRow.Cells[10].Value.ToString();
            txtCIDADE.Text = dgvCadastro.CurrentRow.Cells[11].Value.ToString();
            txtTELEFONE.Text = dgvCadastro.CurrentRow.Cells[5].Value.ToString();





        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNOME.Text == "")
            {
                MessageBox.Show("Por Favor preencher o nome", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNOME.Focus();
                return;
            }
            else if (txtCPF.Text == "")
            {
                MessageBox.Show("Por Favor colocar o CPF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Focus();
                return;
            }
            else if (txtCelular.Text == "")
            {
                MessageBox.Show("Por Favor informe seu celular", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCelular.Focus();
                return;
            }
            try
            {
                
                Global.Conexao.Open();
                Global.Comando = new MySqlCommand("INSERT INTO Funcionario (NOME, CPF, RG, EMAIL, TELEFONE, CELULAR, ENDERECO, BAIRRO, NUMERO, COMPLEMENTO, CIDADE, UF) VALUES (?NOME, ?CPF, ?RG, ?EMAIL, ?TELEFONE, ?CELULAR, ?ENDERECO, ?BAIRRO, ?NUMERO, ?COMPLEMENTO, ?CIDADE, ?UF)", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?NOME", txtNOME.Text);
                Global.Comando.Parameters.AddWithValue("?CPF", txtCPF.Text);
                Global.Comando.Parameters.AddWithValue("?RG", txtRG.Text);
                Global.Comando.Parameters.AddWithValue("?EMAIL", txtEmail.Text);
                Global.Comando.Parameters.AddWithValue("?TELEFONE", txtTELEFONE.Text);
                Global.Comando.Parameters.AddWithValue("?CELULAR", txtCelular.Text);
                Global.Comando.Parameters.AddWithValue("?ENDERECO", txtEndereco.Text);
                Global.Comando.Parameters.AddWithValue("?BAIRRO", txtBairro.Text);
                Global.Comando.Parameters.AddWithValue("?NUMERO", txtNUMERO.Text);
                Global.Comando.Parameters.AddWithValue("?COMPLEMENTO", txtComplemento.Text);
                Global.Comando.Parameters.AddWithValue("?CIDADE", txtCIDADE.Text);
                Global.Comando.Parameters.AddWithValue("?UF", txtUF.Text);
                Global.Comando.ExecuteNonQuery();
                Global.Conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }

            btnCancelar.PerformClick();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtTELEFONE.Clear();
            txtNOME.Clear();
            txtEmail.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtCelular.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtNUMERO.Clear();
            txtComplemento.Clear();
            txtCIDADE.Clear();
            txtUF.Clear();
            btnPesquisar.PerformClick();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Global.ConsultarFuncionario(txtPesquisa.Text);
            dgvCadastro.DataSource = Global.datTabela;
            txtPesquisa.Clear();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Por Favor Selecionar um usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNOME.Focus();
                return;
            }
            try
            {
                Global.Conexao.Open();
                Global.Comando = new MySqlCommand("UPDATE Funcionario SET NOME=?NOME, CPF=?CPF, RG=?RG, EMAIL=?EMAIL,TELEFONE=?TELEFONE, CELULAR=?CELULAR, ENDERECO=?ENDERECO, BAIRRO=?BAIRRO, NUMERO=?NUMERO, COMPLEMENTO=?COMPLEMENTO, CIDADE=?CIDADE, UF=?UF WHERE id=?id", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?id", txtID.Text);
                Global.Comando.Parameters.AddWithValue("?NOME", txtNOME.Text);
                Global.Comando.Parameters.AddWithValue("?CPF", txtCPF.Text);
                Global.Comando.Parameters.AddWithValue("?RG", txtRG.Text);
                Global.Comando.Parameters.AddWithValue("?EMAIL", txtEmail.Text);
                Global.Comando.Parameters.AddWithValue("?TELEFONE", txtTELEFONE.Text);
                Global.Comando.Parameters.AddWithValue("?CELULAR", txtCelular.Text);
                Global.Comando.Parameters.AddWithValue("?ENDERECO", txtEndereco.Text);
                Global.Comando.Parameters.AddWithValue("?BAIRRO", txtBairro.Text);
                Global.Comando.Parameters.AddWithValue("?NUMERO", txtNUMERO.Text);
                Global.Comando.Parameters.AddWithValue("?COMPLEMENTO", txtComplemento.Text);
                Global.Comando.Parameters.AddWithValue("?CIDADE", txtCIDADE.Text);
                Global.Comando.Parameters.AddWithValue("?UF", txtUF.Text);
                Global.Comando.ExecuteNonQuery();
                Global.Conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }

            btnCancelar.PerformClick();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Por Favor Selecionar um usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNOME.Focus();
                return;
            }

            try
            {
                if (MessageBox.Show("Deseja realmente Excluir o Funcionario?", "Exclusão", MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Global.Conexao.Open();
                    Global.Comando = new MySqlCommand("DELETE FROM Funcionario WHERE id=?id", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?id", txtID.Text);
                    Global.Comando.ExecuteNonQuery();
                    Global.Conexao.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }

            btnCancelar.PerformClick();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dgvCadastro_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void txtNOME_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
