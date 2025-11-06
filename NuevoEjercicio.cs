using System;
using System.Windows.Forms;
using System.Linq;

namespace Taller2_G34
{
    public partial class NuevoEjercicio : Form
    {
        // Propiedades públicas para acceder a los datos después de que se presione Aceptar
        public string NombreEjercicio => txtNombre.Text.Trim();

        // Acceso directo a los valores de NumericUpDown
        public int CantSeries => (int)cantSeries.Value;
        public int Repeticiones => (int)cantRepeticiones.Value;

        public int Tiempo => string.IsNullOrWhiteSpace(txtTiempo.Text) ? 0 : int.Parse(txtTiempo.Text);


        public NuevoEjercicio()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            // La validación ahora se concentra en ValidarCampos()
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
            // 1. Validar nombre obligatorio
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del ejercicio es obligatorio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Validar que las series sean mayores a 0 (NumericUpDown no permite null, solo 0 si MinValue=0)
            if (CantSeries <= 0)
            {
                MessageBox.Show("Las series deben ser un número mayor a 0.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 3. Validar que al menos uno de los campos (Repeticiones o Tiempo) tenga un valor mayor a 0.
            // Repeticiones se lee directamente del NumericUpDown.
            if (Repeticiones < 0)
            {
                MessageBox.Show("Las repeticiones deben ser un número positivo o cero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int tiempoIngresado = 0;

            // Validar si se ingresó tiempo (que sigue siendo un TextBox)
            if (!string.IsNullOrWhiteSpace(txtTiempo.Text))
            {
                if (!int.TryParse(txtTiempo.Text, out tiempoIngresado) || tiempoIngresado < 0)
                {
                    MessageBox.Show("El tiempo debe ser un número entero (0 o más segundos).", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Validar la regla de negocio: Al menos Repeticiones > 0 O Tiempo > 0
            if (Repeticiones <= 0 && tiempoIngresado <= 0)
            {
                MessageBox.Show("Debe ingresar repeticiones (mayor a 0) o tiempo (mayor a 0) para el ejercicio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void NuevoEjercicio_Load(object sender, EventArgs e)
        {
            // Inicializar o limpiar campos si es necesario
        }
    }
}