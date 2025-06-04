using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_final_1
{
    public partial class Form6 : Form
    {
        private string connectionString = "Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";
        private int usuario;

        public Form6()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxUsuarios.SelectedValue != null && int.TryParse(comboBoxUsuarios.SelectedValue.ToString(), out usuario))
            {
                // idUsuario ya tiene el valor correcto para guardar
            }
            else
            {
                MessageBox.Show("Por favor seleccione un usuario válido.");
            }
            string TipoActividad = cmbactividad.SelectedItem.ToString();
            int TiempoSemanal = int.Parse(txttiempo.Text);

            string query = @"INSERT INTO actividad_fisica
                (idUsuario,tipoActividad, tiempoSemanal)
                VALUES (@idUsuario,@tipoActividad, @tiempoSemanal)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))

            {
                // Usar las variables ya convertidas
                //cmd.Parameters.AddWithValue("@idActividadFisica", ActividadF);
                //cmd.Parameters.AddWithValue("@idRegistroPaciente", RegistroPaciente);
                cmd.Parameters.AddWithValue("@idUsuario",usuario);
                cmd.Parameters.AddWithValue("@tipoActividad", TipoActividad);
                cmd.Parameters.AddWithValue("@tiempoSemanal", TiempoSemanal);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro guardado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 formulario7 = new Form7();

            // Mostrar el segundo formulario
            formulario7.Show();
            this.Hide();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            conexion conexion = new conexion();

            // Cargar los idUsuario en el ComboBox como opciones de autocompletado
            string queryUsuarios = "SELECT idUsuario, nombres + ' ' + apellidos AS nombreCompleto FROM paciente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Cargar usuarios
        using (SqlCommand commandUsuarios = new SqlCommand(queryUsuarios, connection))
        {
            SqlDataAdapter adapterUsuarios = new SqlDataAdapter(commandUsuarios);
            DataTable dtUsuarios = new DataTable();
            adapterUsuarios.Fill(dtUsuarios);

            comboBoxUsuarios.DataSource = dtUsuarios;
            comboBoxUsuarios.DisplayMember = "nombreCompleto";  // Nombre a mostrar
            comboBoxUsuarios.ValueMember = "idUsuario";          // Valor interno (ID)
            comboBoxUsuarios.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxUsuarios.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
                }
            }


            cmbactividad.Items.Add("GYM");
            cmbactividad.Items.Add("CORRER");
            cmbactividad.Items.Add("FUTBOL");
            cmbactividad.Items.Add("BALONCESTO");
            cmbactividad.Items.Add("NATACION");
        }

        private void cmbactividad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
