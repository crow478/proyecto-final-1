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

    public partial class Form4 : Form
    {
        private string connectionString = "Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {


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
            //  int IdMedida = int.Parse(idmedida.Text);
            int usuario = int.Parse(comboBoxUsuarios.Text);
            string NombreUnidadMedida = nombremedida.Text;

            String query = @"INSERT INTO unidadMedida (idUsuario,nombreUnidadMedida) 
                                    VALUES (@idUsuario,@nombreUnidadMedida)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))

            {
                // Usar las variables ya convertidas
                cmd.Parameters.AddWithValue("idUsuario",usuario);
                cmd.Parameters.AddWithValue("@nombreUnidadMedida", NombreUnidadMedida);

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
            Form5 formulario5 = new Form5();

            // Mostrar el segundo formulario
            formulario5.Show();
            this.Hide();
        }
    }
}
