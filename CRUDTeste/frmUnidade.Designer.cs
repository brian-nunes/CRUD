
namespace CRUDTeste
{
    partial class frmUnidade
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
            this.txtHorarios = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDataAbertura = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBruto = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudCustos = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudLiquida = new System.Windows.Forms.NumericUpDown();
            this.txtCoordenadas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudNumero = new System.Windows.Forms.NumericUpDown();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvPatrimonio = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudBruto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLiquida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatrimonio)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHorarios
            // 
            this.txtHorarios.Location = new System.Drawing.Point(67, 66);
            this.txtHorarios.Name = "txtHorarios";
            this.txtHorarios.Size = new System.Drawing.Size(187, 20);
            this.txtHorarios.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 95;
            this.label5.Text = "Horários: ";
            // 
            // dtpDataAbertura
            // 
            this.dtpDataAbertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataAbertura.Location = new System.Drawing.Point(537, 38);
            this.dtpDataAbertura.Name = "dtpDataAbertura";
            this.dtpDataAbertura.Size = new System.Drawing.Size(104, 20);
            this.dtpDataAbertura.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "Data de Abertura:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(53, 39);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(381, 20);
            this.txtNome.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Nome:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(546, 10);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(94, 23);
            this.btnCadastrar.TabIndex = 90;
            this.btnCadastrar.Text = "Cadastrar Novo";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(417, 10);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(75, 23);
            this.btnApagar.TabIndex = 89;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(288, 10);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 88;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(159, 10);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 87;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(36, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(108, 20);
            this.txtID.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "ID:";
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Location = new System.Drawing.Point(341, 66);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(300, 20);
            this.txtResponsavel.TabIndex = 96;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "Responsável: ";
            // 
            // nudBruto
            // 
            this.nudBruto.DecimalPlaces = 2;
            this.nudBruto.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudBruto.Location = new System.Drawing.Point(85, 92);
            this.nudBruto.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudBruto.Name = "nudBruto";
            this.nudBruto.Size = new System.Drawing.Size(120, 20);
            this.nudBruto.TabIndex = 98;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Renda Bruta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 101;
            this.label7.Text = "Custos:";
            // 
            // nudCustos
            // 
            this.nudCustos.DecimalPlaces = 2;
            this.nudCustos.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudCustos.Location = new System.Drawing.Point(287, 93);
            this.nudCustos.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudCustos.Name = "nudCustos";
            this.nudCustos.Size = new System.Drawing.Size(120, 20);
            this.nudCustos.TabIndex = 100;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(434, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 103;
            this.label8.Text = "Renda Líquida:";
            // 
            // nudLiquida
            // 
            this.nudLiquida.DecimalPlaces = 2;
            this.nudLiquida.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLiquida.Location = new System.Drawing.Point(521, 93);
            this.nudLiquida.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudLiquida.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudLiquida.Name = "nudLiquida";
            this.nudLiquida.Size = new System.Drawing.Size(120, 20);
            this.nudLiquida.TabIndex = 102;
            // 
            // txtCoordenadas
            // 
            this.txtCoordenadas.Location = new System.Drawing.Point(88, 118);
            this.txtCoordenadas.Name = "txtCoordenadas";
            this.txtCoordenadas.Size = new System.Drawing.Size(319, 20);
            this.txtCoordenadas.TabIndex = 104;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 105;
            this.label9.Text = "Coordenadas:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(514, 170);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(127, 20);
            this.txtEstado.TabIndex = 110;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(484, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 115;
            this.label11.Text = "UF:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 114;
            this.label10.Text = "Cidade:";
            // 
            // nudNumero
            // 
            this.nudNumero.Location = new System.Drawing.Point(537, 144);
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
            this.nudNumero.Size = new System.Drawing.Size(104, 20);
            this.nudNumero.TabIndex = 108;
            this.nudNumero.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(67, 170);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(398, 20);
            this.txtCidade.TabIndex = 109;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(484, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 113;
            this.label12.Text = "Número:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(67, 144);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(398, 20);
            this.txtEndereco.TabIndex = 107;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 112;
            this.label13.Text = "Endereço: ";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(471, 119);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(170, 20);
            this.txtCEP.TabIndex = 106;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(434, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 111;
            this.label14.Text = "CEP:";
            // 
            // dgvPatrimonio
            // 
            this.dgvPatrimonio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatrimonio.Location = new System.Drawing.Point(11, 196);
            this.dgvPatrimonio.Name = "dgvPatrimonio";
            this.dgvPatrimonio.Size = new System.Drawing.Size(629, 149);
            this.dgvPatrimonio.TabIndex = 116;
            // 
            // frmUnidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 357);
            this.Controls.Add(this.dgvPatrimonio);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudNumero);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCEP);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCoordenadas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudLiquida);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudCustos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudBruto);
            this.Controls.Add(this.txtResponsavel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHorarios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDataAbertura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUnidade";
            this.Text = "Unidade";
            ((System.ComponentModel.ISupportInitialize)(this.nudBruto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLiquida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatrimonio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtHorarios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDataAbertura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudBruto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudCustos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudLiquida;
        private System.Windows.Forms.TextBox txtCoordenadas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudNumero;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvPatrimonio;
    }
}