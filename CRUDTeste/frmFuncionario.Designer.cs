
namespace CRUDTeste
{
    partial class frmFuncionario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudNumero = new System.Windows.Forms.NumericUpDown();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxGenero = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpContratacao = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cbFerias = new System.Windows.Forms.CheckBox();
            this.dtpFerias = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.nudDependentes = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBeneficios = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.nudSalario = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.cbxPeriodo = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbxUnidade = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxProfissao = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDependentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalario)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(640, 120);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(148, 20);
            this.txtEstado.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(610, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "UF:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Cidade:";
            // 
            // nudNumero
            // 
            this.nudNumero.Location = new System.Drawing.Point(663, 94);
            this.nudNumero.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudNumero.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumero.Name = "nudNumero";
            this.nudNumero.Size = new System.Drawing.Size(125, 20);
            this.nudNumero.TabIndex = 39;
            this.nudNumero.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(69, 120);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(520, 20);
            this.txtCidade.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(610, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 54;
            this.label9.Text = "Número:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(69, 94);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(520, 20);
            this.txtEndereco.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Endereço: ";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(647, 68);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(141, 20);
            this.txtCEP.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(610, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "CEP:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(318, 68);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(271, 20);
            this.txtEmail.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "E-mail: ";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(69, 68);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(187, 20);
            this.txtTelefone.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Telefone: ";
            // 
            // cbxGenero
            // 
            this.cbxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGenero.FormattingEnabled = true;
            this.cbxGenero.Items.AddRange(new object[] {
            "M",
            "F",
            "N/I"});
            this.cbxGenero.Location = new System.Drawing.Point(735, 40);
            this.cbxGenero.Name = "cbxGenero";
            this.cbxGenero.Size = new System.Drawing.Size(53, 21);
            this.cbxGenero.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(681, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Gênero: ";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(553, 40);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(104, 20);
            this.dtpData.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Data de Nascimento:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(69, 41);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(368, 20);
            this.txtNome.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Nome:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(694, 11);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(94, 23);
            this.btnCadastrar.TabIndex = 45;
            this.btnCadastrar.Text = "Cadastrar Novo";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(514, 12);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(75, 23);
            this.btnApagar.TabIndex = 44;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(352, 12);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 43;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(162, 12);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 42;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(48, 14);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(108, 20);
            this.txtCPF.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "CPF:";
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(44, 146);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(128, 20);
            this.txtRG.TabIndex = 57;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "RG:";
            // 
            // dtpContratacao
            // 
            this.dtpContratacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContratacao.Location = new System.Drawing.Point(684, 146);
            this.dtpContratacao.Name = "dtpContratacao";
            this.dtpContratacao.Size = new System.Drawing.Size(104, 20);
            this.dtpContratacao.TabIndex = 59;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(569, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Data de Contratação:";
            // 
            // cbFerias
            // 
            this.cbFerias.AutoSize = true;
            this.cbFerias.Location = new System.Drawing.Point(535, 174);
            this.cbFerias.Name = "cbFerias";
            this.cbFerias.Size = new System.Drawing.Size(54, 17);
            this.cbFerias.TabIndex = 61;
            this.cbFerias.Text = "Férias";
            this.cbFerias.UseVisualStyleBackColor = true;
            // 
            // dtpFerias
            // 
            this.dtpFerias.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFerias.Location = new System.Drawing.Point(274, 146);
            this.dtpFerias.Name = "dtpFerias";
            this.dtpFerias.Size = new System.Drawing.Size(104, 20);
            this.dtpFerias.TabIndex = 62;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(184, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 63;
            this.label14.Text = "Data das Férias:";
            // 
            // nudDependentes
            // 
            this.nudDependentes.Location = new System.Drawing.Point(470, 146);
            this.nudDependentes.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDependentes.Name = "nudDependentes";
            this.nudDependentes.Size = new System.Drawing.Size(80, 20);
            this.nudDependentes.TabIndex = 64;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(390, 148);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 65;
            this.label15.Text = "Dependentes:";
            // 
            // txtBeneficios
            // 
            this.txtBeneficios.Location = new System.Drawing.Point(77, 172);
            this.txtBeneficios.Name = "txtBeneficios";
            this.txtBeneficios.Size = new System.Drawing.Size(421, 20);
            this.txtBeneficios.TabIndex = 66;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 175);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 13);
            this.label16.TabIndex = 67;
            this.label16.Text = "Benefícios:";
            // 
            // nudSalario
            // 
            this.nudSalario.Location = new System.Drawing.Point(663, 172);
            this.nudSalario.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudSalario.Name = "nudSalario";
            this.nudSalario.Size = new System.Drawing.Size(125, 20);
            this.nudSalario.TabIndex = 68;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(615, 175);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 69;
            this.label17.Text = "Salário:";
            // 
            // cbxPeriodo
            // 
            this.cbxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPeriodo.FormattingEnabled = true;
            this.cbxPeriodo.Items.AddRange(new object[] {
            "Manhã",
            "Tarde",
            "Noite"});
            this.cbxPeriodo.Location = new System.Drawing.Point(66, 198);
            this.cbxPeriodo.Name = "cbxPeriodo";
            this.cbxPeriodo.Size = new System.Drawing.Size(106, 21);
            this.cbxPeriodo.TabIndex = 70;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 201);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 71;
            this.label18.Text = "Período:";
            // 
            // cbxUnidade
            // 
            this.cbxUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidade.FormattingEnabled = true;
            this.cbxUnidade.Items.AddRange(new object[] {
            "Manhã",
            "Tarde",
            "Noite"});
            this.cbxUnidade.Location = new System.Drawing.Point(262, 198);
            this.cbxUnidade.Name = "cbxUnidade";
            this.cbxUnidade.Size = new System.Drawing.Size(165, 21);
            this.cbxUnidade.TabIndex = 72;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(206, 201);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 73;
            this.label19.Text = "Unidade:";
            // 
            // cbxProfissao
            // 
            this.cbxProfissao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProfissao.FormattingEnabled = true;
            this.cbxProfissao.Items.AddRange(new object[] {
            "Manhã",
            "Tarde",
            "Noite"});
            this.cbxProfissao.Location = new System.Drawing.Point(533, 198);
            this.cbxProfissao.Name = "cbxProfissao";
            this.cbxProfissao.Size = new System.Drawing.Size(255, 21);
            this.cbxProfissao.TabIndex = 74;
            this.cbxProfissao.SelectedIndexChanged += new System.EventHandler(this.cbxProfissao_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(474, 201);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 75;
            this.label20.Text = "Profissão:";
            // 
            // frmFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 229);
            this.Controls.Add(this.cbxProfissao);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cbxUnidade);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cbxPeriodo);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.nudSalario);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtBeneficios);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.nudDependentes);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpFerias);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbFerias);
            this.Controls.Add(this.dtpContratacao);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtRG);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudNumero);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCEP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxGenero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFuncionario";
            this.Text = "Funcionario";
            this.Load += new System.EventHandler(this.frmFuncionario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDependentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudNumero;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxGenero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpContratacao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbFerias;
        private System.Windows.Forms.DateTimePicker dtpFerias;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudDependentes;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBeneficios;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudSalario;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbxPeriodo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbxUnidade;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbxProfissao;
        private System.Windows.Forms.Label label20;
    }
}