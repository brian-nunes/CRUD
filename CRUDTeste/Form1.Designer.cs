
namespace CRUDTeste
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bDGeralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patrimônioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remédioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estoqueDeRemédiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bDGeralToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.carrosToolStripMenuItem,
            this.reservasToolStripMenuItem,
            this.funcionáriosToolStripMenuItem,
            this.unidadesToolStripMenuItem,
            this.patrimônioToolStripMenuItem,
            this.remédioToolStripMenuItem,
            this.estoqueDeRemédiosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bDGeralToolStripMenuItem
            // 
            this.bDGeralToolStripMenuItem.Name = "bDGeralToolStripMenuItem";
            this.bDGeralToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.bDGeralToolStripMenuItem.Text = "BD Geral";
            this.bDGeralToolStripMenuItem.Click += new System.EventHandler(this.bDGeralToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // carrosToolStripMenuItem
            // 
            this.carrosToolStripMenuItem.Name = "carrosToolStripMenuItem";
            this.carrosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.carrosToolStripMenuItem.Text = "Animais";
            this.carrosToolStripMenuItem.Click += new System.EventHandler(this.carrosToolStripMenuItem_Click);
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.reservasToolStripMenuItem.Text = "Reservas";
            this.reservasToolStripMenuItem.Click += new System.EventHandler(this.reservasToolStripMenuItem_Click);
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.funcionáriosToolStripMenuItem.Text = "Funcionários";
            this.funcionáriosToolStripMenuItem.Click += new System.EventHandler(this.funcionáriosToolStripMenuItem_Click);
            // 
            // unidadesToolStripMenuItem
            // 
            this.unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            this.unidadesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.unidadesToolStripMenuItem.Text = "Unidades";
            this.unidadesToolStripMenuItem.Click += new System.EventHandler(this.unidadesToolStripMenuItem_Click);
            // 
            // patrimônioToolStripMenuItem
            // 
            this.patrimônioToolStripMenuItem.Name = "patrimônioToolStripMenuItem";
            this.patrimônioToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.patrimônioToolStripMenuItem.Text = "Patrimônio";
            this.patrimônioToolStripMenuItem.Click += new System.EventHandler(this.patrimônioToolStripMenuItem_Click);
            // 
            // remédioToolStripMenuItem
            // 
            this.remédioToolStripMenuItem.Name = "remédioToolStripMenuItem";
            this.remédioToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.remédioToolStripMenuItem.Text = "Remédios";
            this.remédioToolStripMenuItem.Click += new System.EventHandler(this.remédioToolStripMenuItem_Click);
            // 
            // estoqueDeRemédiosToolStripMenuItem
            // 
            this.estoqueDeRemédiosToolStripMenuItem.Name = "estoqueDeRemédiosToolStripMenuItem";
            this.estoqueDeRemédiosToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.estoqueDeRemédiosToolStripMenuItem.Text = "Estoques de Remédios";
            this.estoqueDeRemédiosToolStripMenuItem.Click += new System.EventHandler(this.estoqueDeRemédiosToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 641);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "CRUD - Petshop e Clínica Veterinária";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bDGeralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patrimônioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remédioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estoqueDeRemédiosToolStripMenuItem;
    }
}

