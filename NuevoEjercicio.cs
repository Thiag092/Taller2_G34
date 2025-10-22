using System;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class NuevoEjercicio : Form
    {
        public int IdEjercicio { get; private set; } // Puede generarse temporal o usar un contador
        public string NombreEjercicio => txtNombre.Text.Trim();
        public int CantSeries => int.Parse(txtSeries.Text);
        public int Repeticiones => string.IsNullOrWhiteSpace(txtRepeticiones.Text) ? 0 : int.Parse(txtRepeticiones.Text);
        public int Tiempo => string.IsNullOrWhiteSpace(txtTiempo.Text) ? 0 : int.Parse(txtTiempo.Text);
        public NuevoEjercicio()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidarCampos()
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del ejercicio es obligatorio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que al menos uno de los campos (repeticiones o tiempo) tenga valor
            if (string.IsNullOrWhiteSpace(txtRepeticiones.Text) && string.IsNullOrWhiteSpace(txtTiempo.Text))
            {
                MessageBox.Show("Debe ingresar repeticiones o tiempo para el ejercicio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que las series sean numéricas y mayores a 0
            if (!int.TryParse(txtSeries.Text, out int series) || series <= 0)
            {
                MessageBox.Show("Las series deben ser un número mayor a 0.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar repeticiones si se ingresaron
            if (!string.IsNullOrWhiteSpace(txtRepeticiones.Text))
            {
                if (!int.TryParse(txtRepeticiones.Text, out int repeticiones) || repeticiones <= 0)
                {
                    MessageBox.Show("Las repeticiones deben ser un número mayor a 0.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Validar tiempo si se ingresó
            if (!string.IsNullOrWhiteSpace(txtTiempo.Text))
            {
                if (!int.TryParse(txtTiempo.Text, out int tiempo) || tiempo <= 0)
                {
                    MessageBox.Show("El tiempo debe ser un número mayor a 0.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void NuevoEjercicio_Load(object sender, EventArgs e)
        {
            // No necesitamos cargar nada específico
        }
    }
}