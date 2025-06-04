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
        private int medida;
        private int usuario;

        public Form5()
        {

            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxUsuarios.SelectedValue != null && int.TryParse(comboBoxUsuarios.SelectedValue.ToString(), out usuario) &&
      comboBoxUnidad.SelectedValue != null && int.TryParse(comboBoxUnidad.SelectedValue.ToString(), out medida))
            {
                // Aquí ya tienes los IDs correctos
            }
            else
            {
                MessageBox.Show("Por favor selecciona un usuario y una unidad válidos.");
            }
            int producto = int.Parse(comboBoxProductos.Text.Split('-')[0].Trim());
            float cantidadconsumo = float.Parse(txtcantidad_consumo.Text);

            DateTime FechaAlimetacion;
            if (!DateTime.TryParse(txtFechaAlimentacion.Text, out FechaAlimetacion))
            {
                MessageBox.Show("Fecha inválida.");
                return;
            }

            // Consulta SQL para insertar en la tabla CORRECTA
            string query = @"INSERT INTO alimentacion_paciente
                (idUsuario,idUnidadMedida,fecha_alimentacion,cantidad_consumo,idProducto)
                VALUES (@idUsuario,@idUnidadMedida,@fecha_alimentacion, @cantidad_consumo,@idProducto)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Usar las variables ya convertidas
                cmd.Parameters.AddWithValue("idUsuario", usuario);
                cmd.Parameters.AddWithValue("idProducto",producto);
                cmd.Parameters.AddWithValue("idUnidadMedida", medida);
;                cmd.Parameters.AddWithValue("@fecha_alimentacion", FechaAlimetacion);
                cmd.Parameters.AddWithValue("@cantidad_consumo", cantidadconsumo);

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
            string queryUsuarios = "SELECT idUsuario, nombres + ' ' + apellidos AS nombreCompleto FROM paciente";
            string queryUnidadMedida = "SELECT idUnidadMedida, nombreUnidadMedida FROM unidadMedida";
            string queryProductos = "SELECT idProducto, nombreProducto FROM producto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

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

        // Cargar unidad de medida
        using (SqlCommand commandUnidad = new SqlCommand(queryUnidadMedida, connection))
        {
            SqlDataAdapter adapterUnidad = new SqlDataAdapter(commandUnidad);
            DataTable dtUnidad = new DataTable();
            adapterUnidad.Fill(dtUnidad);

            comboBoxUnidad.DataSource = dtUnidad;
            comboBoxUnidad.DisplayMember = "nombreUnidadMedida"; // Mostrar nombre de unidad
            comboBoxUnidad.ValueMember = "idUnidadMedida";       // Valor interno (ID)
            comboBoxUnidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxUnidad.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

                    // Cargar idProducto en comboBoxProductos
                    using (SqlCommand commandProductos = new SqlCommand(queryProductos, connection))
                    using (SqlDataReader readerProductos = commandProductos.ExecuteReader())
                    {
                        while (readerProductos.Read())
                        {
                            string idProducto = readerProductos["idProducto"].ToString();
                            string nombreProducto = readerProductos["nombreProducto"].ToString();
                            comboBoxProductos.Items.Add($"{idProducto} - {nombreProducto}");
                        }
                    }

                    // Habilitar AutoComplete para todos los ComboBoxes
                    comboBoxUsuarios.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxUsuarios.AutoCompleteSource = AutoCompleteSource.ListItems;

                    comboBoxUnidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxUnidad.AutoCompleteSource = AutoCompleteSource.ListItems;

                    comboBoxProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxProductos.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }

        private void comboBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }


