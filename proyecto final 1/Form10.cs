using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Canvas.Draw;
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
    STRING_AGG(pr.nombreProducto + ' (' + CAST(ap.cantidad_consumo AS VARCHAR) + ')', ', ') AS productosConsumidos,
    SUM(ap.cantidad_consumo) AS totalCantidad,
    STRING_AGG(um.nombreUnidadMedida, ', ') AS unidadesMedida,
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
    producto pr ON ap.idProducto = pr.idProducto
LEFT JOIN 
    unidadMedida um ON ap.idUnidadMedida = um.idUnidadMedida
LEFT JOIN 
    actividad_fisica af ON p.idUsuario = af.idUsuario
LEFT JOIN 
    calculospaciente cp ON p.idUsuario = cp.idUsuario
WHERE 
    p.idUsuario = @idUsuario
GROUP BY
    p.idUsuario, p.nombres, p.apellidos, p.edad, p.genero, p.municipio, p.departamento,
    rp.fecha_registro, rp.peso, rp.altura,
    ap.fecha_alimentacion,
    af.tipoActividad, af.tiempoSemanal,
    cp.Masa_corporal, cp.CaloriasDiarias, cp.CaloriasRecomendadas, cp.Recomendaciones";


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
            if (int.TryParse(textBoxIdUsuario.Text, out int idUsuario))
            {
                string basePath = @"C:\Users\Notebook\Documents\";
                string fileName = $"Paciente_{idUsuario}.pdf";
                string pdfPath = System.IO.Path.Combine(basePath, fileName);

                DataTable dt = ObtenerDatosUsuario(idUsuario);

                PdfWriter writer = new PdfWriter(pdfPath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                // Fuente para el título
                PdfFont fontTitle = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                Paragraph titulo = new Paragraph("Datos del Paciente")
                    .SetFont(fontTitle)
                    .SetFontSize(18)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontColor(ColorConstants.BLUE)
                    .SetMarginBottom(20);

                document.Add(titulo);

                // Fuente para etiquetas y contenido
                PdfFont fontLabel = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontValue = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                foreach (DataRow row in dt.Rows)
                {
                    // Crear tabla para organizar datos en dos columnas (Etiqueta - Valor)
                    Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 30, 70 })).UseAllAvailableWidth();

                    void AddRow(string label, string value)
                    {
                        Cell cellLabel = new Cell().Add(new Paragraph(label).SetFont(fontLabel).SetFontSize(12).SetFontColor(ColorConstants.DARK_GRAY));
                        Cell cellValue = new Cell().Add(new Paragraph(value).SetFont(fontValue).SetFontSize(12));
                        cellLabel.SetBorder(Border.NO_BORDER);
                        cellValue.SetBorder(Border.NO_BORDER);
                        tabla.AddCell(cellLabel);
                        tabla.AddCell(cellValue);
                    }

                    AddRow("ID Usuario:", row["idUsuario"].ToString());
                    AddRow("Nombre:", $"{row["nombres"]} {row["apellidos"]}");
                    AddRow("Edad:", row["edad"].ToString());
                    AddRow("Género:", row["genero"].ToString());
                    AddRow("Municipio:", row["municipio"].ToString());
                    AddRow("Departamento:", row["departamento"].ToString());
                    AddRow("Fecha de Registro:", Convert.ToDateTime(row["fecha_registro"]).ToString("dd/MM/yyyy"));
                    AddRow("Peso:", row["peso"].ToString());
                    AddRow("Altura:", row["altura"].ToString());
                    AddRow("Fecha Alimentación:", Convert.ToDateTime(row["fecha_alimentacion"]).ToString("dd/MM/yyyy"));
                    AddRow("Productos Consumidos:", row["productosConsumidos"].ToString());
                    AddRow("Cantidad Consumo:", row["totalCantidad"].ToString());
                    AddRow("Unidad de Medida:", row["unidadesMedida"].ToString());
                    AddRow("Tipo Actividad:", row["tipoActividad"].ToString());
                    AddRow("Tiempo Semanal:", row["tiempoSemanal"].ToString());
                    AddRow("Masa Corporal:", row["Masa_corporal"].ToString());
                    AddRow("Calorías Diarias:", row["CaloriasDiarias"].ToString());
                    AddRow("Calorías Recomendadas:", row["CaloriasRecomendadas"].ToString());
                    AddRow("Recomendaciones:", row["Recomendaciones"].ToString());

                    document.Add(tabla);

                    // Línea separadora entre registros
                    document.Add(new Paragraph("\n"));
                    LineSeparator ls = new LineSeparator(new SolidLine());
                    document.Add(ls);
                    document.Add(new Paragraph("\n"));
                }

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
