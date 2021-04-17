using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bDGeralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmBD")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                frmBD newMDIChild = new frmBD();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmCliente")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                frmCliente newMDIChild = new frmCliente();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }

        private void carrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmCarro")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                frmAnimais newMDIChild = new frmAnimais();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmReserva")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                frmReserva newMDIChild = new frmReserva();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmFuncionario")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                frmFuncionario newMDIChild = new frmFuncionario();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }

        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmUnidade")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                frmUnidade newMDIChild = new frmUnidade();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }

        private void patrimônioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmPatrimonio")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                frmPatrimonio newMDIChild = new frmPatrimonio();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }

        private void remédioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmMedicamentos")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                frmMedicamentos newMDIChild = new frmMedicamentos();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }

        private void estoqueDeRemédiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmEstoqueMedicacao")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                frmEstoqueMedicacao newMDIChild = new frmEstoqueMedicacao();
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
        }
    }
}
