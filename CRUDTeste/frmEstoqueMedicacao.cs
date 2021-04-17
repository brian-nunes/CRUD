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
    public partial class frmEstoqueMedicacao : Form
    {
        MySqlConnection conexao;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string strSQL;
        public frmEstoqueMedicacao()
        {
            InitializeComponent();
        }

        private void frmEstoqueMedicacao_Load(object sender, EventArgs e)
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
                            cbxUnidades.Enabled = true;
                            cbxUnidades.Items.Clear();
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                cbxUnidades.Items.Add(reader.GetString("id") + " - " + reader.GetString("nome"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;"))
                {
                    connection.Open();
                    var query = "SELECT id, tipo FROM Medicamentos";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            cbxRemedio.Enabled = true;
                            cbxRemedio.Items.Clear();
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                cbxRemedio.Items.Add(reader.GetString("id") + " - " + reader.GetString("tipo"));
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

                    strSQL = "select E.Unidade as idUnidade, U.nome as Unidade, E.Medicamentos as idRemedio, M.tipo as Remedio, E.Quantidade from Unidade U, Medicamentos M, Estoque_Medicamentos E where E.unidade = U.id and E.medicamentos = M.id and E.id = @ID";

                    cmd = new MySqlCommand(strSQL, conexao);
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = txtID.Text;

                    conexao.Open();

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        nudQuantidade.Value = Convert.ToInt32(dr["Quantidade"]);
                        cbxUnidades.Text = Convert.ToString(dr["idUnidade"]) + " - " + Convert.ToString(dr["Unidade"]);
                        cbxRemedio.Text = Convert.ToString(dr["idRemedio"]) + " - " + Convert.ToString(dr["Remedio"]);
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
                        strSQL = "DELETE FROM ESTOQUE_MEDICAMENTOS WHERE ID = @ID";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = txtID.Text;

                        conexao.Open();

                        cmd.ExecuteNonQuery();

                        txtID.Clear();
                        cbxUnidades.SelectedIndex = -1;
                        cbxRemedio.SelectedIndex = -1;
                        nudQuantidade.Value = 0;
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
            if (cbxRemedio.SelectedIndex == -1 | cbxUnidades.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    String[] codUnidade = cbxUnidades.Text.Split(' ');
                    String[] codMedicamentos = cbxRemedio.Text.Split(' ');

                    strSQL = "INSERT INTO ESTOQUE_MEDICAMENTOS (UNIDADE, MEDICAMENTOS, QUANTIDADE) VALUES (" + codUnidade[0] + ", " + codMedicamentos[0] + ", " + Convert.ToString(nudQuantidade.Value) + ")";

                    cmd = new MySqlCommand(strSQL, conexao);

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
            if (cbxRemedio.SelectedIndex == -1 | cbxUnidades.SelectedIndex == -1)
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

                        String[] codUnidade = cbxUnidades.Text.Split(' ');
                        String[] codMedicamentos = cbxRemedio.Text.Split(' ');

                        strSQL = "UPDATE ESTOQUE_MEDICAMENTOS SET UNIDADE = " + codUnidade[0] + ", MEDICAMENTOS = " + codMedicamentos[0] + ", QUANTIDADE = " + Convert.ToString(nudQuantidade.Value) + " WHERE ID = " + txtID.Text;

                        cmd = new MySqlCommand(strSQL, conexao);

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
