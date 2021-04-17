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
    public partial class frmUnidade : Form
    {
        MySqlConnection conexao;
        MySqlDataAdapter da;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string strSQL;
        public frmUnidade()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvPatrimonio.DataSource = null;
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o ID a ser pesquisado!", "Erro - Sem ID informado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    strSQL = "SELECT P.ID, P.Nome, P.Tipo, P.Valor, U.nome as Unidade, P.Ultima_Manutencao as 'Última Manutenção', P.prox_manutencao as 'Próxima Manutenção' FROM Patrimonio P, Unidade U WHERE P.unidade = U.id and U.id = " + txtID.Text;

                    da = new MySqlDataAdapter(strSQL, conexao);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvPatrimonio.DataSource = dt;

                    strSQL = "SELECT * FROM Unidade WHERE ID = " + txtID.Text;

                    cmd = new MySqlCommand(strSQL, conexao);

                    conexao.Open();

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        txtNome.Text = Convert.ToString(dr["nome"]);
                        txtHorarios.Text = Convert.ToString(dr["horarios"]);
                        txtResponsavel.Text = Convert.ToString(dr["responsavel"]);
                        dtpDataAbertura.Value = Convert.ToDateTime(dr["data_abertura"]);
                        nudBruto.Value = Convert.ToDecimal(dr["renda_bruta"]);
                        nudCustos.Value = Convert.ToDecimal(dr["custos"]);
                        nudLiquida.Value = Convert.ToDecimal(dr["lucro_liquido"]);
                        txtCEP.Text = Convert.ToString(dr["cep"]);
                        txtEndereco.Text = Convert.ToString(dr["endereco"]);
                        nudNumero.Value = Convert.ToInt32(dr["numero"]);
                        txtCidade.Text = Convert.ToString(dr["cidade"]);
                        txtEstado.Text = Convert.ToString(dr["estado"]);
                        txtCoordenadas.Text = Convert.ToString(dr["coordenadas"]);
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
                        strSQL = "DELETE FROM UNIDADE WHERE ID = @ID";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = txtID.Text;

                        conexao.Open();

                        cmd.ExecuteNonQuery();

                        txtID.Clear();
                        txtNome.Clear();
                        txtResponsavel.Clear();
                        txtHorarios.Clear();
                        txtEstado.Clear();
                        txtEndereco.Clear();
                        txtCoordenadas.Clear();
                        txtCidade.Clear();
                        txtCEP.Clear();
                        nudBruto.Value = 0;
                        nudCustos.Value = 0;
                        nudLiquida.Value = 0;
                        nudNumero.Value = 1;
                        dtpDataAbertura.Value = DateTime.Now.Date;
                        dgvPatrimonio.DataSource = null;
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
            dgvPatrimonio.DataSource = null;
            if (txtCEP.Text == "" | txtCidade.Text == "" | txtCoordenadas.Text == "" | txtEndereco.Text == "" | txtEstado.Text == "" | txtHorarios.Text == "" | txtNome.Text == "" | txtResponsavel.Text == "")
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    strSQL = "INSERT INTO Unidade (NOME, HORARIOS, RESPONSAVEL, DATA_ABERTURA, RENDA_BRUTA, CUSTOS, LUCRO_LIQUIDO, CEP, ENDERECO, NUMERO, CIDADE, ESTADO, COORDENADAS) VALUES (@NOME, @HORARIOS, @RESPONSAVEL, @DATA_ABERTURA, " + Convert.ToString(nudBruto.Value).Replace(",", ".") + ", " + Convert.ToString(nudCustos.Value).Replace(",", ".") + ", " + Convert.ToString(nudLiquida.Value).Replace(",", ".") + ", @CEP, @ENDERECO, @NUMERO, @CIDADE, @ESTADO, '" + txtCoordenadas.Text.Replace("'", "''") + "')";

                    cmd = new MySqlCommand(strSQL, conexao);

                    cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@HORARIOS", MySqlDbType.VarChar).Value = txtHorarios.Text;
                    cmd.Parameters.Add("@RESPONSAVEL", MySqlDbType.VarChar).Value = txtResponsavel.Text;
                    cmd.Parameters.Add("@DATA_ABERTURA", MySqlDbType.Date).Value = dtpDataAbertura.Value.Date;
                    cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = txtCEP.Text;
                    cmd.Parameters.Add("@ENDERECO", MySqlDbType.VarChar).Value = txtEndereco.Text;
                    cmd.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = nudNumero.Value;
                    cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = txtCidade.Text;
                    cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = txtEstado.Text;

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
            if (txtCEP.Text == "" | txtCidade.Text == "" | txtCoordenadas.Text == "" | txtEndereco.Text == "" | txtEstado.Text == "" | txtHorarios.Text == "" | txtID.Text == "" | txtNome.Text == "" | txtResponsavel.Text == "")
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

                        strSQL = "UPDATE Unidade SET NOME = @NOME, HORARIOS = @HORARIOS, RESPONSAVEL = @RESPONSAVEL, DATA_ABERTURA = @DATA_ABERTURA, RENDA_BRUTA = " + Convert.ToString(nudBruto.Value).Replace(",", ".") + ", CUSTOS = " + Convert.ToString(nudCustos.Value).Replace(",", ".") + ", LUCRO_LIQUIDO = " + Convert.ToString(nudLiquida.Value).Replace(",", ".") + ", CEP = @CEP, ENDERECO = @ENDERECO, NUMERO = @NUMERO, CIDADE = @CIDADE, ESTADO = @ESTADO, COORDENADAS = '" + txtCoordenadas.Text.Replace("'", "''") + "' WHERE ID = @ID";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = txtID.Text;
                        cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                        cmd.Parameters.Add("@HORARIOS", MySqlDbType.VarChar).Value = txtHorarios.Text;
                        cmd.Parameters.Add("@RESPONSAVEL", MySqlDbType.VarChar).Value = txtResponsavel.Text;
                        cmd.Parameters.Add("@DATA_ABERTURA", MySqlDbType.Date).Value = dtpDataAbertura.Value.Date;
                        cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = txtCEP.Text;
                        cmd.Parameters.Add("@ENDERECO", MySqlDbType.VarChar).Value = txtEndereco.Text;
                        cmd.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = nudNumero.Value;
                        cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = txtCidade.Text;
                        cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = txtEstado.Text;

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
