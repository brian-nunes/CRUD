using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace CRUDTeste
{
    public partial class frmBD : Form
    {
        MySqlConnection conexao;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        string strSQL;
        public frmBD()
        {
            InitializeComponent();
        }

        private void frmBD_Load(object sender, EventArgs e)
        {

        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            if (cbxTable.Text == "")
            {
                MessageBox.Show("Selecione a tabela desejada na ComboBox", "Erro - Sem tabela selecionada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtID.Text == "")
            {
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    if (cbxTable.Text == "Animal")
                    {
                        strSQL = "select A.ID, A.Nome, A.Nascimento, A.Genero, A.Vacinado, A.Castrado, A.Raca, C.CPF as CPF_Dono, E.Nome as Espécie  from Animal A, Cliente C, Especie E where C.id = A.dono and E.id = A.Especie";
                    }
                    else if (cbxTable.Text == "Funcionario")
                    {
                        strSQL = "select F.ID, F.CPF, F.Nome, F.RG, F.Data_Contratacao as 'Data de Contratação', F.Ferias as Férias, F.Data_Ferias as 'Data das Férias', F.Nascimento as 'Data de Nascimento', F.Genero as Gênero, F.Dependentes, F.Telefone, F.Email as 'E-mail', F.Beneficios as Benefícios, F.Salario as Salário, F.Periodo_Trabalho as Período, U.Nome as Unidade, P.nome as Profissão, F.CEP, F.Endereco as Endereço, F.Numero as Número, F.Cidade, F.Estado from Funcionario F, Unidade U, Profissao P where F.profissao = P.id and F.unidade = U.id";
                    }
                    else
                    {
                        strSQL = "SELECT * FROM " + cbxTable.Text;
                    }

                    da = new MySqlDataAdapter(strSQL, conexao);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvDados.DataSource = dt;
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
            else
            {
                if (cbxTable.Text == "Cliente")
                {
                    strSQL = "SELECT * FROM Cliente WHERE CPF = '" + txtID.Text + "'";
                }
                else if (cbxTable.Text == "Funcionario")
                {
                    strSQL = "select F.ID, F.CPF, F.Nome, F.RG, F.Data_Contratacao as 'Data de Contratação', F.Ferias as Férias, F.Data_Ferias as 'Data das Férias', F.Nascimento as 'Data de Nascimento', F.Genero as Gênero, F.Dependentes, F.Telefone, F.Email as 'E-mail', F.Beneficios as Benefícios, F.Salario as Salário, F.Periodo_Trabalho as Período, U.Nome as Unidade, P.nome as Profissão, F.CEP, F.Endereco as Endereço, F.Numero as Número, F.Cidade, F.Estado from Funcionario F, Unidade U, Profissao P where F.profissao = P.id and F.unidade = U.id and F.CPF = '" + txtID.Text + "'";
                }
                else if (cbxTable.Text == "Unidade")
                {
                    strSQL = "SELECT * FROM Unidade WHERE NOME = '" + txtID.Text + "'";
                }
                else if (cbxTable.Text == "Medicamentos")
                {
                    strSQL = "SELECT * FROM Medicamentos WHERE TIPO = '" + txtID.Text + "'";
                }
                else if (cbxTable.Text == "Animal")
                {
                    strSQL = "select A.ID, A.Nome, A.Nascimento, A.Genero, A.Vacinado, A.Castrado, A.Raca, C.CPF, E.Nome  from Animal A, Cliente C, Especie E where A.ID = " + txtID.Text + " and C.Id = (select dono from animal where id = " + txtID.Text + ") and E.id = (select especie from animal where id = " + txtID.Text + ") ";
                }
                try
                {
                    conexao = new MySqlConnection("Server=localhost;Database=dbpetshop;Uid=root;Pwd=root;");

                    da = new MySqlDataAdapter(strSQL, conexao);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvDados.DataSource = dt;
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

        private void cbxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTable.SelectedIndex == -1 | cbxTable.SelectedIndex == 4)
            {
                lblChave.Text = "ID: ";
                lblChave.Left = txtID.Left - (lblChave.Width + 3);
            }
            else if (cbxTable.SelectedIndex == 0 | cbxTable.SelectedIndex == 3)
            {
                lblChave.Text = "CPF: ";
                lblChave.Left = txtID.Left - (lblChave.Width + 3);
            }
            else if (cbxTable.SelectedIndex == 1)
            {
                lblChave.Text = "Nome: ";
                lblChave.Left = txtID.Left - (lblChave.Width + 3);
            }
            else if (cbxTable.SelectedIndex == 2)
            {
                lblChave.Text = "Tipo: ";
                lblChave.Left = txtID.Left - (lblChave.Width + 3);
            }
        }

        private void frmBD_Load_1(object sender, EventArgs e)
        {

        }
    }
}
