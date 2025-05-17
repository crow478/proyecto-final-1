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
    public partial class Form5 : Form
    {
        private string connectionString = "Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";

        public Form5()
        {

            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int usuario = int.Parse(comboBoxUsuarios.Text);
            int medida = int.Parse(comboBoxUnidad.Text);

            //int idproducto = int.Parse(txtidProducto.Text);
            float cantidadconsumo = float.Parse(txtcantidad_consumo.Text);
//            int idunidadmedida = int.Parse(txtidUnidadMedida.Text);

            DateTime FechaAlimetacion;
            if (!DateTime.TryParse(txtFechaAlimentacion.Text, out FechaAlimetacion))
            {
                MessageBox.Show("Fecha inválida.");
                return;
            }

            // Consulta SQL para insertar en la tabla CORRECTA
            string query = @"INSERT INTO alimentacion_paciente
                (idUsuario,idUnidadMedida,fecha_alimentacion,cantidad_consumo )
                VALUES (@idUsuario,@idUnidadMedida,@fecha_alimentacion, @cantidad_consumo)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Usar las variables ya convertidas
                cmd.Parameters.AddWithValue("idUsuario", usuario);
                cmd.Parameters.AddWithValue("idUnidadMedida", medida);
;                cmd.Parameters.AddWithValue("@fecha_alimentacion", FechaAlimetacion);
                //cmd.Parameters.AddWithValue("@idProducto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad_consumo", cantidadconsumo);
                //cmd.Parameters.AddWithValue("@idUnidadMedida", idunidadmedida);

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
            Form6 formulario6 = new Form6();

            // Mostrar el segundo formulario
            formulario6.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string queryUsuarios = "SELECT idUsuario FROM paciente";
            string queryUnidadMedida = "SELECT idUnidadMedida FROM unidadMedida";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Cargar idUsuario en comboBoxUsuarios
                    using (SqlCommand commandUsuarios = new SqlCommand(queryUsuarios, connection))
                    using (SqlDataReader readerUsuarios = commandUsuarios.ExecuteReader())
                    {
                        while (readerUsuarios.Read())
                        {
                            comboBoxUsuarios.Items.Add(readerUsuarios["idUsuario"].ToString());
                        }
                    }

                    // Cargar idUnidadMedida en comboBoxUnidad
                    using (SqlCommand commandUnidad = new SqlCommand(queryUnidadMedida, connection))
                    using (SqlDataReader readerUnidad = commandUnidad.ExecuteReader())
                    {
                        while (readerUnidad.Read())
                        {
                            comboBoxUnidad.Items.Add(readerUnidad["idUnidadMedida"].ToString());
                        }
                    }

                    // Habilitar AutoComplete para ambos ComboBoxes
                    comboBoxUsuarios.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxUsuarios.AutoCompleteSource = AutoCompleteSource.ListItems;

                    comboBoxUnidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxUnidad.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }
        }
    }


