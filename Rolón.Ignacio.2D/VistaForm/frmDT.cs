using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace VistaForm
{
    public partial class frmDT : Form
    {
        private DirectorTecnico dt;
        public frmDT()
        {
            InitializeComponent();
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            dt = new DirectorTecnico(textBoxNombre.Text, textBoxApellido.Text, int.Parse(numericUpDownEdad.Value.ToString()), int.Parse(numericUpDownDni.Value.ToString()), int.Parse(numericUpDownExperiencia.Value.ToString()));
            MessageBox.Show("Se ha creado el DT!", "DT Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonValidar_Click(object sender, EventArgs e)
        {
            if(dt == null)
            {
                MessageBox.Show("Aún no se ha creado el DT del formulario", "DT Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(dt.ValidarAptitud() == false)
            {
                MessageBox.Show("El DT no es apto.", "DT Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("El DT es apto.", "DT Valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
