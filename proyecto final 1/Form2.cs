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
    public partial class Form2 : Form
    {
        private string connectionString = "Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conexion c = new conexion();

            // Cargar los idUsuario en el ComboBox como opciones de autocompletado
            string queryUsuarios = "SELECT idUsuario FROM paciente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(queryUsuarios, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Llenar el ComboBox con los idUsuario de la tabla paciente
                    while (reader.Read())
                    {
                        comboBoxUsuarios.Items.Add(reader["idUsuario"].ToString());
                    }

                    // Habilitar AutoComplete en el ComboBox
                    comboBoxUsuarios.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxUsuarios.AutoCompleteSource = AutoCompleteSource.ListItems;

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string RegistroPaciente = txtRegistroPaciente.Text;

            /*int IdUsuario;
            if (!int.TryParse(txtIdUsuario.Text, out IdUsuario))
            {
                MessageBox.Show("ID de usuario inválido.");
                return;
            }
            */

            int idUsuario = int.Parse(comboBoxUsuarios.Text);  // Asegúrate de que el TextBox tenga el ID del usuario

            DateTime FechaRegistro;
            if (!DateTime.TryParse(txtFechaRegistro.Text, out FechaRegistro))
            {
                MessageBox.Show("Fecha inválida.");
                return;
            }

            int Altura;
            if (!int.TryParse(txtAltura.Text, out Altura))
            {
                MessageBox.Show("Altura inválida.");
                return;
            }

            int Peso;
            if (!int.TryParse(txtPeso.Text, out Peso))
            {
                MessageBox.Show("Peso inválido.");
                return;
            }

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO registro_paciente (idUsuario,fecha_registro, peso, altura) " +
                               "VALUES (@idUsuario, @fecha_registro, @peso, @altura)";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                comando.Parameters.AddWithValue("@fecha_registro", FechaRegistro);
                comando.Parameters.AddWithValue("@peso", Peso); 
                comando.Parameters.AddWithValue("@altura", Altura); 

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Datos guardados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            Form3 formulario3 = new Form3();

            // Mostrar el segundo formulario
            formulario3.Show();
            this.Hide();
        }

        private void txtFechaRegistro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
    

