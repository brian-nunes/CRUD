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
    public partial class frmMedicamentos : Form
    {
        MySqlConnection conexao;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string strSQL;
        public frmMedicamentos()
        {
            InitializeComponent();
        }

        private void frmMedicamentos_Load(object sender, EventArgs e)
        {

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

                    strSQL = "SELECT * FROM MEDICAMENTOS WHERE ID = @ID";

                    cmd = new MySqlCommand(strSQL, conexao);
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = txtID.Text;

                    conexao.Open();

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        txtTipo.Text = Convert.ToString(dr["tipo"]);
                        nudValor.Value = Convert.ToDecimal(dr["valor"]);
                        txtLaboratorio.Text = Convert.ToString(dr["laboratorio"]);
                        cbxProcedencia.Text = Convert.ToString(dr["procedencia"]);
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
                        strSQL = "DELETE FROM MEDICAMENTOS WHERE ID = @ID";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = txtID.Text;

                        conexao.Open();

                        cmd.ExecuteNonQuery();

                        txtID.Clear();
                        txtLaboratorio.Clear();
                        txtTipo.Clear();
                        cbxProcedencia.SelectedIndex = -1;
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
            if (txtTipo.Text == "" | txtLaboratorio.Text == "" | cbxProcedencia.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    strSQL = "INSERT INTO MEDICAMENTOS (TIPO, VALOR, LABORATORIO, PROCEDENCIA) VALUES (@TIPO, @VALOR, @LABORATORIO, @PROCEDENCIA)";

                    cmd = new MySqlCommand(strSQL, conexao);

                    cmd.Parameters.Add("@TIPO", MySqlDbType.VarChar).Value = txtTipo.Text;
                    cmd.Parameters.Add("@LABORATORIO", MySqlDbType.VarChar).Value = txtLaboratorio.Text;
                    cmd.Parameters.Add("@PROCEDENCIA", MySqlDbType.Enum).Value = cbxProcedencia.Text;
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
            if (txtTipo.Text == "" | txtLaboratorio.Text == "" | cbxProcedencia.SelectedIndex == -1)
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

                        strSQL = "UPDATE MEDICAMENTOS SET TIPO = @TIPO, LABORATORIO = @LABORATORIO, PROCEDENCIA = @PROCEDENCIA, VALOR = @VALOR WHERE ID = @ID";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = txtID.Text;
                        cmd.Parameters.Add("@TIPO", MySqlDbType.VarChar).Value = txtTipo.Text;
                        cmd.Parameters.Add("@LABORATORIO", MySqlDbType.VarChar).Value = txtLaboratorio.Text;
                        cmd.Parameters.Add("@PROCEDENCIA", MySqlDbType.Enum).Value = cbxProcedencia.Text;
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
