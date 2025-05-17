using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proyecto_final_1
{
    public partial class Form9 : Form
    {
        private string connectionString = "Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";

        public Form9()
        {
            InitializeComponent();
        }

        // Evento para cargar la información cuando el formulario se carga (si es necesario)
        private void Form9_Load(object sender, EventArgs e)
        {
            // Puedes agregar lógica aquí si necesitas cargar algo cuando el formulario se abre.
        }

        // Evento que se ejecuta al hacer clic en el botón (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            int idUsuario = 1; // Aquí puedes obtener el idUsuario de un TextBox, ComboBox, o un valor fijo como ejemplo.

            // Obtener los datos del usuario y mostrarlo en el DataGridView
            DataTable dt = ObtenerDatosUsuario(idUsuario);
            dataGridView1.DataSource = dt;  // Asegúrate de que tienes un DataGridView llamado "dataGridView1"
        }

        // Método que realiza la consulta y retorna un DataTable con los resultados
        private DataTable ObtenerDatosUsuario(int idUsuario)
        {
            DataTable dt = new DataTable();

            // Consulta SQL
            string query = @"
            SELECT 
                p.idUsuario,
                p.nombres,
                p.apellidos,
                p.edad,
                p.genero,
                p.municipio,
                p.departamento,
                rp.fecha_registro,
                rp.peso,
                rp.altura,
                ap.fecha_alimentacion,
                pr.nombreProducto,
                ap.cantidad_consumo,
                um.nombreUnidadMedida,
                af.tipoActividad,
                af.tiempoSemanal,
                inut.descripcionNutricional,
                inut.dietaNutricional,
                inut.tiempoDieta,
                apac.recomendacionDieta
            FROM 
                paciente p
            LEFT JOIN 
                registro_paciente rp ON p.idUsuario = rp.idUsuario
            LEFT JOIN 
                alimentacion_paciente ap ON p.idUsuario = ap.idUsuario
            LEFT JOIN 
                producto pr ON ap.idProducto = pr.idProducto
            LEFT JOIN 
                unidadMedida um ON ap.idUnidadMedida = um.idUnidadMedida
            LEFT JOIN 
                actividad_fisica af ON p.idUsuario = af.idUsuario
            LEFT JOIN 
                analisis_paciente apac ON p.idUsuario = apac.idUsuario
            LEFT JOIN 
                informacion_nutricional inut ON apac.idInformacionNutricional = inut.idInformacionNutricional
            WHERE 
                p.idUsuario = @idUsuario;";

            // Crear la conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar el parámetro idUsuario
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    // Crear un adaptador de datos para llenar el DataTable
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        // Llenar el DataTable con los resultados de la consulta
                        dataAdapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // Evento adicional para manejar clics en las celdas del DataGridView si es necesario
        private void ObtenerDatosUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Aquí puedes manejar los clics en las celdas si es necesario
        }
    }
}

