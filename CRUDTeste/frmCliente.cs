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

namespace CRUDTeste
{
    public partial class frmCliente : Form
    {
        MySqlConnection conexao;
         MySqlDataAdapter da;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string strSQL;
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvAnimais.DataSource = null;
            if (txtCPF.Text == "")
            {
                MessageBox.Show("Selecione o CPF a ser pesquisado!", "Erro - Sem CPF informado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    strSQL = "SELECT A.Nome, A.Nascimento, A.Genero, A.Vacinado, A.Castrado, A.Raca, E.Nome as Espécie FROM Animal A, Especie E, Cliente C WHERE A.dono = C.id and E.id = A.especie and C.cpf = " + txtCPF.Text;

                    da = new MySqlDataAdapter(strSQL, conexao);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvAnimais.DataSource = dt;

                    strSQL = "SELECT * FROM Cliente WHERE CPF = " + txtCPF.Text;

                    cmd = new MySqlCommand(strSQL, conexao);

                    conexao.Open();

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        txtNome.Text = Convert.ToString(dr["Nome"]);
                        cbxGenero.Text = Convert.ToString(dr["genero"]);
                        txtTelefone.Text = Convert.ToString(dr["telefone"]);
                        txtEmail.Text = Convert.ToString(dr["email"]);
                        dtpData.Value = Convert.ToDateTime(dr["nascimento"]);
                        txtCEP.Text = Convert.ToString(dr["cep"]);
                        txtEndereco.Text = Convert.ToString(dr["endereco"]);
                        nudNumero.Value = Convert.ToInt32(dr["numero"]);
                        txtCidade.Text = Convert.ToString(dr["cidade"]);
                        txtEstado.Text = Convert.ToString(dr["estado"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexao.Close();
                    conexao = null;
                    cmd = null;
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            dgvAnimais.DataSource = null;
            if (txtCPF.Text == "" | txtNome.Text == "" | txtTelefone.Text == "" | txtEstado.Text == "" | txtEndereco.Text == "" | txtEmail.Text == "" | txtCidade.Text == "" | txtCEP.Text == "" | cbxGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");
                    strSQL = "INSERT INTO Cliente (CPF, Nome, Genero, telefone, email, nascimento, cep, endereco, numero, cidade, estado) VALUES (@CPF, @NOME, @GENERO, @TELEFONE, @EMAIL, @NASCIMENTO, @CEP, @ENDERECO, @NUMERO, @CIDADE, @ESTADO)";

                    cmd = new MySqlCommand(strSQL, conexao);

                    cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = txtCPF.Text;
                    cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@TELEFONE", MySqlDbType.VarChar).Value = txtTelefone.Text;
                    cmd.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = txtCEP.Text;
                    cmd.Parameters.Add("@ENDERECO", MySqlDbType.VarChar).Value = txtEndereco.Text;
                    cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = txtCidade.Text;
                    cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = txtEstado.Text;
                    cmd.Parameters.Add("@GENERO", MySqlDbType.Enum).Value = cbxGenero.Text;
                    cmd.Parameters.Add("@NASCIMENTO", MySqlDbType.Date).Value = dtpData.Value.Date;
                    cmd.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = nudNumero.Value;

                    conexao.Open();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cadastro efetuado com sucesso!", "Cadastro Efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexao.Close();
                    conexao = null;
                    cmd = null;
                }
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text == "")
            {
                MessageBox.Show("Insira o CPF desejado!", "Erro - CPF vazio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult YN = MessageBox.Show("Tem certeza que deseja apagar este registro? Uma vez apagado não haverá como recupera-lo.", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(YN == DialogResult.Yes)
                {
                    try
                    {
                        conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");
                        strSQL = "DELETE FROM CLIENTE WHERE CPF = @CPF";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@CPF", MySqlDbType.Int64).Value = txtCPF.Text;

                        conexao.Open();

                        cmd.ExecuteNonQuery();

                        txtCPF.Clear();
                        txtCEP.Clear();
                        txtCidade.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtEstado.Clear();
                        txtTelefone.Clear();
                        txtNome.Clear();
                        dtpData.Value = System.DateTime.Now;
                        nudNumero.Value = 1;
                        cbxGenero.SelectedIndex = -1;
                        dgvAnimais.DataSource = null;
                        MessageBox.Show("Exclusão efetuada com sucesso!", "Exclusão Efetuada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conexao.Close();
                        conexao = null;
                        cmd = null;
                    }
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text == "" | txtNome.Text == "" | txtTelefone.Text == "" | txtEstado.Text == "" | txtEndereco.Text == "" | txtEmail.Text == "" | txtCidade.Text == "" | txtCEP.Text == "")
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Alteração Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult YN = MessageBox.Show("Tem certeza que deseja alterar este registro? Uma vez alterado não haverá como desfazer.", "Confirmação de Alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YN == DialogResult.Yes)
                {
                    try
                    {
                        conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                        strSQL = "UPDATE Cliente SET NOME = @NOME, GENERO = @GENERO, TELEFONE = @TELEFONE, EMAIL = @EMAIL, NASCIMENTO = @NASCIMENTO, CEP = @CEP, ENDERECO = @ENDERECO, NUMERO = @NUMERO, ESTADO = @ESTADO WHERE CPF = @CPF";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = txtCPF.Text;
                        cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                        cmd.Parameters.Add("@GENERO", MySqlDbType.Enum).Value = cbxGenero.Text;
                        cmd.Parameters.Add("@TELEFONE", MySqlDbType.VarChar).Value = txtTelefone.Text;
                        cmd.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = txtEmail.Text;
                        cmd.Parameters.Add("@NASCIMENTO", MySqlDbType.Date).Value = dtpData.Value.Date;
                        cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = txtCEP.Text;
                        cmd.Parameters.Add("@ENDERECO", MySqlDbType.VarChar).Value = txtEndereco.Text;
                        cmd.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = nudNumero.Value;
                        cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = txtEstado.Text;

                        conexao.Open();

                        cmd.ExecuteNonQuery();

                        conexao.Close();

                        MessageBox.Show("Alteração efetuada com sucesso!", "Alteração Efetuada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conexao.Close();
                        conexao = null;
                        cmd = null;
                    }
                }
            }
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
