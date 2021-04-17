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
    public partial class frmReserva : Form
    {
        MySqlConnection conexao;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string strSQL;
        public frmReserva()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text == "")
            {
                MessageBox.Show("Selecione o CPF a ser pesquisado!", "Erro - Sem CPF informado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (var connection = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;"))
                    {
                        connection.Open();
                        var query = "SELECT A.id, A.nome FROM Animal A, Cliente C WHERE C.CPF = " + txtCPF.Text + " and C.ID = A.dono";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                cbxAnimal.Enabled = true;
                                cbxAnimal.Items.Clear();
                                //Iterate through the rows and add it to the combobox's items
                                while (reader.Read())
                                {
                                    cbxAnimal.Items.Add(reader.GetString("id") + " - " + reader.GetString("nome"));
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

        private void cbxAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxAnimal.SelectedIndex == -1)
            {
                cbxAnimal.Enabled = false;
                cbxProcedimentos.Enabled = false;
            }
            else
            {
                clearTexto();
                cbxProcedimentos.SelectedIndex = -1;
                cbxAnimal.Enabled = true;
                String[] codigoAnimal = cbxAnimal.Text.Split(' ');
                try
                {
                    using (var connection = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;"))
                    {
                        connection.Open();
                        var query = "SELECT R.id, S.nome FROM Servicos S, Animal A, Reserva R WHERE R.animal = " + codigoAnimal[0] + " and S.ID = R.servico and R.animal = A.id";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                cbxProcedimentos.Enabled = true;
                                cbxProcedimentos.Items.Clear();
                                //Iterate through the rows and add it to the combobox's items
                                while (reader.Read())
                                {
                                    cbxProcedimentos.Items.Add(reader.GetString("id") + " - " + reader.GetString("nome"));
                                }
                                cbxProcedimentos.Items.Add("Novo");
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

        private void cbxProcedimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProcedimentos.SelectedIndex == -1)
            {
                cbxProcedimentos.Enabled = false;
                btnCadastrar.Enabled = false;
            }
            else
            {
                clearTexto();
                if(cbxProcedimentos.Text == "Novo")
                {
                    btnCadastrar.Enabled = true;
                }
                else
                {
                    btnCadastrar.Enabled = false;
                    String[] codigoProcedimento = cbxProcedimentos.Text.Split(' ');
                    try
                    {
                        conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                        strSQL = "SELECT R.unidade as idUnidade, U.nome as Unidade, R.servico as idServico, s.nome as Servico, R.Chegada, R.Saida, R.Locacao, R.Valor, R.Responsavel as idResponsavel, F.Nome as Funcionario FROM Reserva R, Servicos S, Unidade U, Funcionario F WHERE R.ID = " + codigoProcedimento[0] + " and R.Unidade = U.ID and R.Servico = S.ID and R.Responsavel = F.ID";

                        cmd = new MySqlCommand(strSQL, conexao);

                        conexao.Open();

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            cbxUnidade.Text = Convert.ToString(dr["idUnidade"]) + " - " + Convert.ToString(dr["Unidade"]);
                            cbxServicos.Text = Convert.ToString(dr["idServico"]) + " - " + Convert.ToString(dr["Servico"]);
                            dtpEntrada.Value = Convert.ToDateTime(dr["Chegada"]);
                            dtpSaida.Value = Convert.ToDateTime(dr["Saida"]);
                            txtLocacao.Text = Convert.ToString(dr["Locacao"]);
                            nudValor.Value = Convert.ToDecimal(dr["Valor"]);
                            cbxResponsavel.Text = Convert.ToString(dr["idResponsavel"]) + " - " + Convert.ToString(dr["Funcionario"]);
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
        }

        private void clearForm()
        {
            txtCPF.Clear();
            txtLocacao.Clear();
            nudValor.Value = 0;
            cbxAnimal.SelectedIndex = -1;
            cbxProcedimentos.SelectedIndex = -1;
            cbxResponsavel.SelectedIndex = -1;
            cbxServicos.SelectedIndex = -1;
            cbxUnidade.SelectedIndex = -1;
            dtpEntrada.Value = DateTime.Today;
            dtpSaida.Value = DateTime.Today;
        }

        private void clearTexto()
        {
            txtLocacao.Clear();
            nudValor.Value = 0;
            cbxResponsavel.SelectedIndex = -1;
            cbxServicos.SelectedIndex = -1;
            cbxUnidade.SelectedIndex = -1;
            dtpEntrada.Value = DateTime.Today;
            dtpSaida.Value = DateTime.Today;
        }

        private void frmReserva_Load(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;"))
                {
                    connection.Open();
                    var query = "SELECT id, nome FROM Servicos";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            cbxServicos.Enabled = true;
                            cbxServicos.Items.Clear();
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                cbxServicos.Items.Add(reader.GetString("id") + " - " + reader.GetString("nome"));
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

        private void btnApagar_Click(object sender, EventArgs e)
        {
            String[] codigoReserva = cbxProcedimentos.Text.Split(' ');
            DialogResult YN = MessageBox.Show("Tem certeza que deseja apagar este registro? Uma vez apagado não haverá como recupera-lo.", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (YN == DialogResult.Yes)
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");
                    strSQL = "DELETE FROM RESERVA WHERE ID = @ID";

                    cmd = new MySqlCommand(strSQL, conexao);
                    cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = codigoReserva[0];

                    conexao.Open();

                    cmd.ExecuteNonQuery();

                    clearForm();
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text == "" | txtLocacao.Text == "" | cbxAnimal.SelectedIndex == -1 | cbxResponsavel.SelectedIndex == -1| cbxServicos.SelectedIndex == -1 | cbxUnidade.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os dados!", "Erro - Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    String[] codigoUnidade = cbxUnidade.Text.Split(' ');
                    String[] codigoServico = cbxServicos.Text.Split(' ');
                    String[] codigoResponsavel = cbxResponsavel.Text.Split(' ');
                    String[] codigoAnimal = cbxAnimal.Text.Split(' ');

                    strSQL = "INSERT INTO RESERVA (UNIDADE, CHEGADA, SAIDA, LOCACAO, SERVICO, VALOR, RESPONSAVEL, ANIMAL) VALUES (" + codigoUnidade[0] + ", @CHEGADA, @SAIDA, @LOCACAO, " + codigoServico[0] + ", @VALOR, " + codigoResponsavel[0] + ", " + codigoAnimal[0] + ")";

                    cmd = new MySqlCommand(strSQL, conexao);

                    cmd.Parameters.Add("@CHEGADA", MySqlDbType.Date).Value = dtpEntrada.Value.Date;
                    cmd.Parameters.Add("@SAIDA", MySqlDbType.Date).Value = dtpSaida.Value.Date;
                    cmd.Parameters.Add("@LOCACAO", MySqlDbType.VarChar).Value = txtLocacao.Text;
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
            if (txtCPF.Text == "" | txtLocacao.Text == "" | cbxAnimal.SelectedIndex == -1 | cbxResponsavel.SelectedIndex == -1 | cbxServicos.SelectedIndex == -1 | cbxUnidade.SelectedIndex == -1 | cbxProcedimentos.SelectedIndex == -1)
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

                        String[] codigoProcedimento = cbxProcedimentos.Text.Split(' ');
                        String[] codigoUnidade = cbxUnidade.Text.Split(' ');
                        String[] codigoServico = cbxServicos.Text.Split(' ');
                        String[] codigoResponsavel = cbxResponsavel.Text.Split(' ');
                        String[] codigoAnimal = cbxAnimal.Text.Split(' ');

                        strSQL = "UPDATE Reserva SET UNIDADE = " + codigoUnidade[0] + ", CHEGADA = @CHEGADA, SAIDA = @SAIDA, LOCACAO = @LOCACAO, SERVICO = " + codigoServico[0] + ", VALOR = @VALOR, RESPONSAVEL = " + codigoResponsavel[0] + ", ANIMAL =  " + codigoAnimal[0] + " WHERE ID =" + codigoProcedimento[0];

                        cmd = new MySqlCommand(strSQL, conexao);
                        cmd.Parameters.Add("@CHEGADA", MySqlDbType.Date).Value = dtpEntrada.Value.Date;
                        cmd.Parameters.Add("@SAIDA", MySqlDbType.Date).Value = dtpSaida.Value.Date;
                        cmd.Parameters.Add("@LOCACAO", MySqlDbType.VarChar).Value = txtLocacao.Text;
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

        private void cbxUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxUnidade.SelectedIndex != -1)
            {
                cbxResponsavel.Enabled = true;
                cbxResponsavel.Items.Clear();
                try
                {
                    using (var connection = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;"))
                    {
                        String[] codUnidade = cbxUnidade.Text.Split(' ');
                        connection.Open();
                        var query = "SELECT id, nome FROM Funcionario WHERE unidade = " + codUnidade[0];
                        using (var command = new MySqlCommand(query, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                cbxResponsavel.Enabled = true;
                                cbxResponsavel.Items.Clear();
                                //Iterate through the rows and add it to the combobox's items
                                while (reader.Read())
                                {
                                    cbxResponsavel.Items.Add(reader.GetString("id") + " - " + reader.GetString("nome"));
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
            else
            {
                cbxResponsavel.Enabled = false;
            }
        }
    }
}
