using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace proyecto_final_1
{
    public partial class Form10 : Form
    {
        // Cadena de conexión a la base de datos
        private string connectionString = "Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";

        public Form10()
        {
            InitializeComponent();
        }

        // Evento para cargar la información cuando el formulario se carga (si es necesario)
        private void Form10_Load(object sender, EventArgs e)
        {
            
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
    cp.Masa_corporal,
    cp.CaloriasDiarias,
    cp.CaloriasRecomendadas,
    cp.Recomendaciones
FROM 
    paciente p
LEFT JOIN 
    registro_paciente rp ON p.idUsuario = rp.idUsuario
LEFT JOIN 
    alimentacion_paciente ap ON p.idUsuario = ap.idUsuario
LEFT JOIN 
    producto pr ON ap.idUsuario = p.idUsuario
LEFT JOIN 
    unidadMedida um ON ap.idUnidadMedida = um.idUnidadMedida
LEFT JOIN 
    actividad_fisica af ON p.idUsuario = af.idUsuario
LEFT JOIN 
    calculospaciente cp ON p.idUsuario = cp.idUsuario

WHERE 
    p.idUsuario = @idUsuario";

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

        private void button1_Click_1(object sender, EventArgs e)
        {

           

            // Obtener el idUsuario del TextBox
            if (int.TryParse(textBoxIdUsuario.Text, out int idUsuario))
            {
                // Obtener los datos del usuario y mostrarlo en el DataGridView
                DataTable dt = ObtenerDatosUsuario(idUsuario);
                dataGridView1.DataSource = dt;  // Asegúrate de que tienes un DataGridView llamado "dataGridView1"

                // Si no se encontraron datos para el ID, puedes limpiar el DataGridView
                if (dt.Rows.Count == 0)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show($"No se encontraron datos para el ID de usuario: {idUsuario}.", "Información");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de usuario válido.", "Error");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica adicional para el clic en celdas del DataGridView (si es necesario)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Intenta obtener el idUsuario del TextBox
            if (int.TryParse(textBoxIdUsuario.Text, out int idUsuario))
            {
                // Define la ruta base del documento
                string basePath = @"C:\Users\Notebook\Documents\";
                // Crea el nombre del archivo dinámicamente usando el idUsuario
                string fileName = $"Paciente_{idUsuario}.pdf";
                // Combina la ruta base y el nombre del archivo
                string pdfPath = System.IO.Path.Combine(basePath, fileName);

                // Obtener los datos desde la base de datos utilizando el método correcto
                DataTable dt = ObtenerDatosUsuario(idUsuario);

                // Crear el escritor PDF (PdfWriter)
                PdfWriter writer = new PdfWriter(pdfPath);

                // Crear el documento PDF (PdfDocument)
                PdfDocument pdf = new PdfDocument(writer);

                // Crear el objeto Document para agregar contenido al PDF
                Document document = new Document(pdf);

                // Agregar un título al documento
                document.Add(new Paragraph("Datos del Paciente"));

                // Recorrer las filas del DataTable y agregar los datos al PDF
                foreach (DataRow row in dt.Rows)
                {
                    document.Add(new Paragraph($"ID Usuario: {row["idUsuario"]}"));
                    document.Add(new Paragraph($"Nombre: {row["nombres"]} {row["apellidos"]}"));
                    document.Add(new Paragraph($"Edad: {row["edad"]}"));
                    document.Add(new Paragraph($"Género: {row["genero"]}"));
                    document.Add(new Paragraph($"Municipio: {row["municipio"]}"));
                    document.Add(new Paragraph($"Departamento: {row["departamento"]}"));
                    document.Add(new Paragraph($"Fecha de Registro: {row["fecha_registro"]}"));
                    document.Add(new Paragraph($"Peso: {row["peso"]}"));
                    document.Add(new Paragraph($"Altura: {row["altura"]}"));
                    document.Add(new Paragraph($"Fecha Alimentación: {row["fecha_alimentacion"]}"));
                    document.Add(new Paragraph($"Producto: {row["nombreProducto"]}"));
                    document.Add(new Paragraph($"Cantidad Consumo: {row["cantidad_consumo"]}"));
                    document.Add(new Paragraph($"Unidad de Medida: {row["nombreUnidadMedida"]}"));
                    document.Add(new Paragraph($"Tipo Actividad: {row["tipoActividad"]}"));
                    document.Add(new Paragraph($"Tiempo Semanal: {row["tiempoSemanal"]}"));
                    document.Add(new Paragraph($"Masa Corporal: {row["Masa_corporal"]}"));
                    document.Add(new Paragraph($"Calorías Diarias: {row["CaloriasDiarias"]}"));
                    document.Add(new Paragraph($"Calorías Recomendadas: {row["CaloriasRecomendadas"]}"));
                    document.Add(new Paragraph($"Recomendaciones: {row["Recomendaciones"]}"));
                    document.Add(new Paragraph("\n"));  // Agrega un salto de línea entre los registros
                }

                // Cerrar el documento
                document.Close();

                MessageBox.Show($"PDF del paciente con ID {idUsuario} generado exitosamente como: {fileName}");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de usuario válido para generar el PDF.", "Error");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
