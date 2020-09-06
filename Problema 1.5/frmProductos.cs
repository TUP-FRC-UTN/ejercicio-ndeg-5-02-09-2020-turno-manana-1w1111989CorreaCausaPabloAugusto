using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problema_1._5
{
    public partial class frmProductos : Form
    {
        int k,j;
        double total;
        public frmProductos()
        {
            InitializeComponent();
            k = j = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            for(int i = k; i < lstPrecio.Items.Count; i++)
            {

                lstSubtotal.Items.Add(Convert.ToString(Convert.ToDouble(lstPrecio.Items[i]) * Convert.ToDouble(lstCantidad.Items[i])));
            }
     
            btnSubtotal.Enabled = false;
            k = lstSubtotal.Items.Count;
            btnTotal.Enabled = true;

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                this.lstNombre.Items.Add(txtNombre.Text);
                this.lstPrecio.Items.Add(txtPrecio.Text);
                this.lstCantidad.Items.Add(txtCantidad.Text);
                txtNombre.Clear();
                txtPrecio.Clear();
                txtCantidad.Clear();
                txtNombre.Focus();
                btnSubtotal.Enabled = true;
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            for(int i = j; i < lstSubtotal.Items.Count; i++)
            {
                total += Convert.ToDouble(lstSubtotal.Items[i]);
            }
            txtTotal.Text = Convert.ToString(total);
            j = lstSubtotal.Items.Count;
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
                Close();
        }
        private void TxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.KeyCode == Keys.Enter) btnCargar.PerformClick();
            }
        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            btnSubtotal.Enabled = false;
            btnTotal.Enabled = false;
        }

        private bool ValidarCampos()
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Text = "";
                txtNombre.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Ingrese el precio del producto", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Text = "";
                txtPrecio.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Ingrese la cantidad de unidades del producto", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCantidad.Text = "";
                txtCantidad.Focus();
                return false;
            }
            return true;
        }
    }
}
