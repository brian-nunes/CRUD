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
    public partial class frmAnimais : Form
    {
        MySqlConnection conexao;
        MySqlDataAdapter da;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string strSQL;
        public frmAnimais()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvServicos.DataSource = null;
            if (txtId.Text == "")
            {
                MessageBox.Show("Selecione o ID a ser pesquisado!", "Erro - Sem ID informado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    strSQL = "SELECT U.nome as Unidade, R.Chegada, R.Saida, R.locacao as Locação, S.nome as Serviço, R.Valor, F.nome as Funcionário_Responsável FROM reserva R, funcionario F, servicos S, unidade U WHERE R.animal = " + txtId.Text + " and U.id = R.unidade and F.id = R.responsavel and S.id = R.servico";

                    da = new MySqlDataAdapter(strSQL, conexao);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvServicos.DataSource = dt;

                    strSQL = "SELECT A.Nome, A.Raca, C.CPF as CPF_Dono, A.Vacinado, A.Castrado, A.Nascimento, A.Genero, E.nome as Especie FROM Animal A, Cliente C, Especie E WHERE A.ID = " + txtId.Text + " and C.ID = A.dono and E.id = A.especie";

                    cmd = new MySqlCommand(strSQL, conexao);

                    conexao.Open();

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        txtNome.Text = Convert.ToString(dr["Nome"]);
                        txtRaca.Text = Convert.ToString(dr["Raca"]);
                        txtCPFDono.Text = Convert.ToString(dr["CPF_Dono"]);
                        cbVacinado.Checked = Convert.ToBoolean(dr["Vacinado"]);
                        cbCastrado.Checked = Convert.ToBoolean(dr["Castrado"]);
                        dtpData.Value = Convert.ToDateTime(dr["Nascimento"]);
                        cbxGenero.Text = Convert.ToString(dr["Genero"]);
                        cbxEspecie.Text = Convert.ToString(dr["Especie"]);
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" | txtNome.Text == "" | cbxGenero.SelectedIndex == -1 | txtRaca.Text == "" | txtCPFDono.Text == "" | cbxEspecie.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult YN = MessageBox.Show("Tem certeza que deseja alterar este registro? Uma vez alterado não haverá como desfazer.", "Confirmação de Alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YN == DialogResult.Yes)
                {
                    try
                    {
                        conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                        strSQL = "UPDATE Animal SET NOME = @NOME, NASCIMENTO = @NASCIMENTO, GENERO = @GENERO, VACINADO = @VACINADO, CASTRADO = @CASTRADO, RACA = @RACA, DONO = (SELECT id FROM cliente WHERE cpf = @CPF), ESPECIE = (SELECT id FROM especie WHERE nome = @ESPECIE) WHERE ID = @ID";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = txtId.Text;
                        cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = txtCPFDono.Text;
                        cmd.Parameters.Add("@ESPECIE", MySqlDbType.VarChar).Value =cbxEspecie.Text;
                        cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                        cmd.Parameters.Add("@NASCIMENTO", MySqlDbType.Date).Value = dtpData.Value.Date;
                        cmd.Parameters.Add("@GENERO", MySqlDbType.Enum).Value = cbxGenero.Text;
                        if (cbCastrado.Checked)
                        {
                            cmd.Parameters.Add("@CASTRADO", MySqlDbType.Int16).Value = 1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@CASTRADO", MySqlDbType.Int16).Value = 0;
                        }
                        if (cbVacinado.Checked)
                        {
                            cmd.Parameters.Add("@VACINADO", MySqlDbType.Int16).Value = 1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@VACINADO", MySqlDbType.Int16).Value = 0;
                        }
                        cmd.Parameters.Add("@RACA", MySqlDbType.VarChar).Value = txtRaca.Text;

                        conexao.Open();
                        cmd.ExecuteNonQuery();

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

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Insira o ID desejado!", "Erro - ID vazio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult YN = MessageBox.Show("Tem certeza que deseja apagar este registro? Uma vez apagado não haverá como recupera-lo.", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YN == DialogResult.Yes)
                {
                    try
                    {
                        conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");
                        strSQL = "DELETE FROM ANIMAL WHERE ID = @ID";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = txtId.Text;

                        conexao.Open();

                        cmd.ExecuteNonQuery();

                        txtId.Clear();
                        txtNome.Clear();
                        txtCPFDono.Clear();
                        txtRaca.Clear();
                        cbxEspecie.SelectedIndex = -1;
                        cbxGenero.SelectedIndex = -1;
                        cbVacinado.Checked = false;
                        cbCastrado.Checked = false;
                        dgvServicos.DataSource = null;
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            dgvServicos.DataSource = null;
            if (txtNome.Text == "" | cbxGenero.SelectedIndex == -1 | txtRaca.Text == "" | txtCPFDono.Text == "" | cbxEspecie.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string idDono = "", especie = "";
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    strSQL = "SELECT id FROM cliente WHERE cpf = '" + txtCPFDono.Text + "'";
                    cmd = new MySqlCommand(strSQL, conexao);
                    conexao.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                         idDono = Convert.ToString(dr["id"]);
                    }
                    conexao.Close();

                    conexao.Open();
                    strSQL = "SELECT id FROM especie WHERE nome = '" + cbxEspecie.Text + "'";
                    cmd = new MySqlCommand(strSQL, conexao);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        especie = Convert.ToString(dr["id"]);
                    }
                    conexao.Close();

                    strSQL = "INSERT INTO Animal (NOME, NASCIMENTO, GENERO, VACINADO, CASTRADO, RACA, DONO, ESPECIE) VALUES (@NOME, @NASCIMENTO, @GENERO, @VACINADO, @CASTRADO, @RACA, " + idDono + ", " + especie + ")";

                    cmd = new MySqlCommand(strSQL, conexao);

                    cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@NASCIMENTO", MySqlDbType.Date).Value = dtpData.Value.Date;
                    cmd.Parameters.Add("@GENERO", MySqlDbType.Enum).Value = cbxGenero.Text;
                    if (cbCastrado.Checked)
                    {
                        cmd.Parameters.Add("@CASTRADO", MySqlDbType.Int16).Value = 1;
                    }
                    else
                    {
                        cmd.Parameters.Add("@CASTRADO", MySqlDbType.Int16).Value = 0;
                    }
                    if (cbVacinado.Checked)
                    {
                        cmd.Parameters.Add("@VACINADO", MySqlDbType.Int16).Value = 1;
                    }
                    else
                    {
                        cmd.Parameters.Add("@VACINADO", MySqlDbType.Int16).Value = 0;
                    }
                    cmd.Parameters.Add("@RACA", MySqlDbType.VarChar).Value = txtRaca.Text;

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

        private void frmAnimais_Load(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT nome FROM especie";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            cbxEspecie.Items.Clear();
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                cbxEspecie.Items.Add(reader.GetString("nome"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
