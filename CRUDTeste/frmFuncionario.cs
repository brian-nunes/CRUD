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
    public partial class frmFuncionario : Form
    {
        MySqlConnection conexao;
        MySqlDataAdapter da;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string strSQL;
        public frmFuncionario()
        {
            InitializeComponent();
        }

        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;"))
                {
                    connection.Open();
                    var query = "SELECT id, nome FROM Unidade order by id";
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

            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;"))
                {
                    connection.Open();
                    var query = "SELECT id, nome FROM Profissao order by id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            cbxProfissao.Enabled = true;
                            cbxProfissao.Items.Clear();
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                cbxProfissao.Items.Add(reader.GetString("id") + " - " + reader.GetString("nome"));
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
            if (txtCPF.Text == "")
            {
                MessageBox.Show("Selecione o CPF a ser pesquisado!", "Erro - Sem CPF informado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    strSQL = "SELECT F.*, U.Nome as NomeUnidade, P.Nome as NomeProfissao FROM Funcionario F, Unidade U, Profissao P WHERE F.Profissao = P.Id and F.Unidade = U.id and F.cpf = " + txtCPF.Text;

                    cmd = new MySqlCommand(strSQL, conexao);

                    conexao.Open();

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        txtNome.Text = Convert.ToString(dr["Nome"]);
                        txtRG.Text = Convert.ToString(dr["rg"]);
                        dtpContratacao.Value = Convert.ToDateTime(dr["data_contratacao"]);
                        cbFerias.Checked = Convert.ToBoolean(dr["ferias"]);
                        dtpFerias.Value = Convert.ToDateTime(dr["data_ferias"]);
                        dtpData.Value = Convert.ToDateTime(dr["nascimento"]);
                        cbxGenero.Text = Convert.ToString(dr["genero"]);
                        nudDependentes.Value = Convert.ToInt32(dr["dependentes"]);
                        txtTelefone.Text = Convert.ToString(dr["telefone"]);
                        txtEmail.Text = Convert.ToString(dr["email"]);
                        txtBeneficios.Text = Convert.ToString(dr["beneficios"]);
                        nudSalario.Value = Convert.ToInt32(dr["salario"]);
                        cbxPeriodo.Text = Convert.ToString(dr["periodo_trabalho"]);
                        cbxUnidade.Text = Convert.ToString(dr["unidade"]) + " - " + Convert.ToString(dr["NomeUnidade"]);
                        cbxProfissao.Text = Convert.ToString(dr["profissao"]) + " - " + Convert.ToString(dr["NomeProfissao"]);
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

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text == "")
            {
                MessageBox.Show("Insira o CPF desejado!", "Erro - CPF vazio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult YN = MessageBox.Show("Tem certeza que deseja apagar este registro? Uma vez apagado não haverá como recupera-lo.", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YN == DialogResult.Yes)
                {
                    try
                    {
                        conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");
                        strSQL = "DELETE FROM FUNCIONARIO WHERE CPF = @CPF";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = txtCPF.Text;

                        conexao.Open();

                        cmd.ExecuteNonQuery();

                        txtBeneficios.Clear();
                        txtCEP.Clear();
                        txtCidade.Clear();
                        txtCPF.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtEstado.Clear();
                        txtNome.Clear();
                        txtRG.Clear();
                        txtTelefone.Clear();
                        nudDependentes.Value = 0;
                        nudNumero.Value = 1;
                        nudSalario.Value = 0;
                        dtpContratacao.Value = DateTime.Now.Date;
                        dtpData.Value = DateTime.Now.Date;
                        dtpFerias.Value = DateTime.Now.Date;
                        cbxGenero.SelectedIndex = -1;
                        cbxPeriodo.SelectedIndex = -1;
                        cbxProfissao.SelectedIndex = -1;
                        cbxUnidade.SelectedIndex = -1;
                        cbFerias.Checked = false;
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
            if (txtBeneficios.Text == "" | txtCEP.Text == "" | txtCidade.Text == "" | txtEmail.Text == "" | txtEndereco.Text == "" | txtEstado.Text == "" | txtNome.Text == "" | txtRG.Text == "" | txtTelefone.Text == "" | cbxGenero.SelectedIndex == -1 | cbxPeriodo.SelectedIndex == -1 | cbxProfissao.SelectedIndex == -1 | cbxUnidade.SelectedIndex == -1)
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

                        String[] codUnidade = cbxUnidade.Text.Split(' ');
                        String[] codProfissao = cbxProfissao.Text.Split(' ');

                        strSQL = "UPDATE FUNCIONARIO SET NOME = @NOME, RG = @RG, DATA_CONTRATACAO = @DATA_CONTRATACAO, FERIAS = @FERIAS, DATA_FERIAS = @DATA_FERIAS, NASCIMENTO = @NASCIMENTO, GENERO = @GENERO, DEPENDENTES = @DEPENDENTES, TELEFONE = @TELEFONE, EMAIL = @EMAIL, BENEFICIOS = @BENEFICIOS, SALARIO = @SALARIO, PERIODO_TRABALHO = @PERIODO_TRABALHO, CEP = @CEP, ENDERECO = @ENDERECO, NUMERO = @NUMERO, CIDADE = @CIDADE, ESTADO = @ESTADO, UNIDADE = " + codUnidade[0] + ", PROFISSAO = " + codProfissao[0] + " WHERE CPF = @CPF";

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = txtCPF.Text;
                        cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                        cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = txtRG.Text;
                        cmd.Parameters.Add("@DATA_CONTRATACAO", MySqlDbType.Date).Value = dtpContratacao.Value.Date;
                        cmd.Parameters.Add("@DATA_FERIAS", MySqlDbType.Date).Value = dtpFerias.Value.Date;
                        cmd.Parameters.Add("@NASCIMENTO", MySqlDbType.Date).Value = dtpData.Value.Date;
                        cmd.Parameters.Add("@GENERO", MySqlDbType.Enum).Value = cbxGenero.Text;
                        cmd.Parameters.Add("@DEPENDENTES", MySqlDbType.Int32).Value = nudDependentes.Value;
                        cmd.Parameters.Add("@TELEFONE", MySqlDbType.VarChar).Value = txtTelefone.Text;
                        cmd.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = txtEmail.Text;
                        cmd.Parameters.Add("@BENEFICIOS", MySqlDbType.VarChar).Value = txtBeneficios.Text;
                        cmd.Parameters.Add("@SALARIO", MySqlDbType.Int32).Value = nudSalario.Value;
                        cmd.Parameters.Add("@CEP", MySqlDbType.Int32).Value = txtCEP.Text;
                        cmd.Parameters.Add("@PERIODO_TRABALHO", MySqlDbType.Enum).Value = cbxPeriodo.Text;
                        cmd.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = nudNumero.Value;
                        cmd.Parameters.Add("@ENDERECO", MySqlDbType.VarChar).Value = txtEndereco.Text;
                        cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = txtCidade.Text;
                        cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = txtEstado.Text;
                        if (cbFerias.Checked)
                        {
                            cmd.Parameters.Add("@FERIAS", MySqlDbType.Int16).Value = 1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@FERIAS", MySqlDbType.Int16).Value = 0;
                        }

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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtBeneficios.Text == "" | txtCEP.Text == "" | txtCPF.Text == "" | txtCidade.Text == "" | txtEmail.Text == "" | txtEndereco.Text == "" | txtEstado.Text == "" | txtNome.Text == "" | txtRG.Text == "" | txtTelefone.Text == "" | cbxGenero.SelectedIndex == -1 | cbxPeriodo.SelectedIndex == -1 | cbxProfissao.SelectedIndex == -1 | cbxUnidade.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    String[] codUnidade = cbxUnidade.Text.Split(' ');
                    String[] codProfissao = cbxProfissao.Text.Split(' ');

                    strSQL = "INSERT INTO Funcionario (CPF, NOME, RG, DATA_CONTRATACAO, DATA_FERIAS, NASCIMENTO, GENERO, DEPENDENTES, TELEFONE, EMAIL, BENEFICIOS, SALARIO, CEP, PERIODO_TRABALHO, NUMERO, ENDERECO, CIDADE, ESTADO, FERIAS, UNIDADE, PROFISSAO) VALUES (@CPF, @NOME, @RG, @DATA_CONTRATACAO, @DATA_FERIAS, @NASCIMENTO, @GENERO, @DEPENDENTES, @TELEFONE, @EMAIL, @BENEFICIOS, @SALARIO, @CEP, @PERIODO_TRABALHO, @NUMERO, @ENDERECO, @CIDADE, @ESTADO, @FERIAS, " + codUnidade[0] + ", " + codProfissao[0] + ")";

                    cmd = new MySqlCommand(strSQL, conexao);

                    cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = txtCPF.Text;
                    cmd.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = txtRG.Text;
                    cmd.Parameters.Add("@DATA_CONTRATACAO", MySqlDbType.Date).Value = dtpContratacao.Value.Date;
                    cmd.Parameters.Add("@DATA_FERIAS", MySqlDbType.Date).Value = dtpFerias.Value.Date;
                    cmd.Parameters.Add("@NASCIMENTO", MySqlDbType.Date).Value = dtpData.Value.Date;
                    cmd.Parameters.Add("@GENERO", MySqlDbType.Enum).Value = cbxGenero.Text;
                    cmd.Parameters.Add("@DEPENDENTES", MySqlDbType.Int32).Value = nudDependentes.Value;
                    cmd.Parameters.Add("@TELEFONE", MySqlDbType.VarChar).Value = txtTelefone.Text;
                    cmd.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@BENEFICIOS", MySqlDbType.VarChar).Value = txtBeneficios.Text;
                    cmd.Parameters.Add("@SALARIO", MySqlDbType.Int32).Value = nudSalario.Value;
                    cmd.Parameters.Add("@CEP", MySqlDbType.Int32).Value = txtCEP.Text;
                    cmd.Parameters.Add("@PERIODO_TRABALHO", MySqlDbType.Enum).Value = cbxPeriodo.Text;
                    cmd.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = nudNumero.Value;
                    cmd.Parameters.Add("@ENDERECO", MySqlDbType.VarChar).Value = txtEndereco.Text;
                    cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = txtCidade.Text;
                    cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = txtEstado.Text;
                    if (cbFerias.Checked)
                    {
                        cmd.Parameters.Add("@FERIAS", MySqlDbType.Int16).Value = 1;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FERIAS", MySqlDbType.Int16).Value = 0;
                    }

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

        private void cbxProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
