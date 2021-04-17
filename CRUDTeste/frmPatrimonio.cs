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
    public partial class frmPatrimonio : Form
    {
        MySqlConnection conexao;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string strSQL;
        public frmPatrimonio()
        {
            InitializeComponent();
        }

        private void frmPatrimonio_Load(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;"))
                {
                    connection.Open();
                    var query = "SELECT id, nome FROM Unidade";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            cbxUnidade.Enabled = true;
                            cbxUnidade.Items.Clear();
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                cbxUnidade.Items.Add(reader.GetString("id") + " - " + reader.GetString("nome"));
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o ID a ser pesquisado!", "Erro - Sem ID informado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    strSQL = "SELECT P.nome, P.tipo, P.valor, P.unidade as idUnidade, U.nome as Unidade, P.ultima_manutencao, P.prox_manutencao FROM Patrimonio P, Unidade U WHERE P.unidade = U.id and P.id = " + txtID.Text;

                    cmd = new MySqlCommand(strSQL, conexao);

                    conexao.Open();

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        txtNome.Text = Convert.ToString(dr["nome"]);
                        cbxTipo.Text = Convert.ToString(dr["tipo"]);
                        nudValor.Value = Convert.ToDecimal(dr["valor"]);
                        cbxUnidade.Text = Convert.ToString(dr["idUnidade"]) + " - " + Convert.ToString(dr["Unidade"]);
                        dtpUltima.Value = Convert.ToDateTime(dr["ultima_manutencao"]);
                        dtpProxima.Value = Convert.ToDateTime(dr["prox_manutencao"]);
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

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
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
                        strSQL = "DELETE FROM PATRIMONIO WHERE ID = @ID";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = txtID.Text;

                        conexao.Open();

                        cmd.ExecuteNonQuery();

                        txtID.Clear();
                        txtNome.Clear();
                        dtpProxima.Value = DateTime.Now.Date;
                        dtpUltima.Value = DateTime.Now.Date;
                        cbxTipo.SelectedIndex = -1;
                        cbxUnidade.SelectedIndex = -1;
                        nudValor.Value = 0;
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
            if (txtID.Text == "" | txtNome.Text == "" | cbxUnidade.SelectedIndex == -1 | cbxTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    String[] codUnidade = cbxUnidade.Text.Split(' ');

                    strSQL = "INSERT INTO Patrimonio (NOME, TIPO, VALOR, UNIDADE, ULTIMA_MANUTENCAO, PROX_MANUTENCAO) VALUES (@NOME, @TIPO, @VALOR, " + codUnidade[0] + ", @ULTIMA_MANUTENCAO, @PROX_MANUTENCAO)";

                    cmd = new MySqlCommand(strSQL, conexao);

                    cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@TIPO", MySqlDbType.VarChar).Value = cbxTipo.Text;
                    cmd.Parameters.Add("@ULTIMA_MANUTENCAO", MySqlDbType.Date).Value = dtpUltima.Value.Date;
                    cmd.Parameters.Add("@PROX_MANUTENCAO", MySqlDbType.Date).Value = dtpProxima.Value.Date;
                    cmd.Parameters.Add("@VALOR", MySqlDbType.Decimal).Value = nudValor.Value;

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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" | txtNome.Text == "" | cbxUnidade.SelectedIndex == -1 | cbxTipo.SelectedIndex == -1)
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

                        strSQL = "UPDATE PATRIMONIO SET NOME = @NOME, TIPO = @TIPO, ULTIMA_MANUTENCAO = @ULTIMA_MANUTENCAO, PROX_MANUTENCAO = @PROX_MANUTENCAO, VALOR = @VALOR WHERE ID = @ID";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = txtID.Text;
                        cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                        cmd.Parameters.Add("@TIPO", MySqlDbType.VarChar).Value = cbxTipo.Text;
                        cmd.Parameters.Add("@ULTIMA_MANUTENCAO", MySqlDbType.Date).Value = dtpUltima.Value.Date;
                        cmd.Parameters.Add("@PROX_MANUTENCAO", MySqlDbType.Date).Value = dtpProxima.Value.Date;
                        cmd.Parameters.Add("@VALOR", MySqlDbType.Decimal).Value = nudValor.Value;

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
    }
}
