using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJAGRO_ADMIN
{
    public partial class admin_jjagro : Form
    {
        public admin_jjagro()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            
           
         
            this.Close();
            Process[] proc = Process.GetProcessesByName("JJAGRO-ADMIN.exe");
            proc[0].Kill();
        }



        private void AbrirFormHija(object formhija)
        {
            if (this.principal.Controls.Count > 0)
                this.principal.Controls.RemoveAt(0);

            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.principal.Controls.Add(fh);
            this.principal.Tag = fh;
            fh.Show();

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new clientes());
        }

       
    }
}
