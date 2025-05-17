using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace proyecto_final_1
{
    public partial class Form8 : Form
    {
        private string connectionString = "Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";
        private double carbohidratosConsumidos;
        private double proteinasConsumidas;
        private double grasasConsumidas;

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
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
            // Obtener el idUsuario seleccionado del ComboBox
            if (comboBoxUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario.");
                return;
            }

            string idUsuarioSeleccionado = comboBoxUsuarios.SelectedItem.ToString();

            // Consultas SQL para obtener datos de peso, altura, edad, genero y actividad física
            string queryPaciente = "SELECT p.peso, p.altura, pa.edad, pa.genero " +
                                   "FROM registro_paciente p " +
                                   "JOIN paciente pa ON pa.idUsuario = p.idUsuario " +
                                   "WHERE pa.idUsuario = @idUsuario";

            string queryActividad = "SELECT SUM(tiempoSemanal) as tiempoSemanal FROM actividad_fisica WHERE idUsuario = @idUsuario";

            // Si no necesitas una tabla intermedia, simplemente trabajas con la tabla producto
            string queryProductosConsumidos = "SELECT p.caloriaProducto, p.carbohidratoProducto, p.proteinaProducto, p.grasasProducto " +
                                              "FROM producto p";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Obtener datos del usuario (peso, altura, edad, genero)
                    SqlCommand command = new SqlCommand(queryPaciente, connection);
                    command.Parameters.AddWithValue("@idUsuario", idUsuarioSeleccionado);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Obtener los valores de peso, altura, edad, sexo
                        double peso = Convert.ToDouble(reader["peso"]);
                        double altura = Convert.ToDouble(reader["altura"]);
                        int edad = Convert.ToInt32(reader["edad"]);
                        string genero = reader["genero"].ToString();
                        reader.Close();  // Cerramos el lector antes de realizar la siguiente consulta

                        // Consultar el tiempo total de actividad física semanal
                        SqlCommand commandActividad = new SqlCommand(queryActividad, connection);
                        commandActividad.Parameters.AddWithValue("@idUsuario", idUsuarioSeleccionado);
                        int tiempoSemanal = Convert.ToInt32(commandActividad.ExecuteScalar()); // Obtener el valor del tiempo semanal

                        if (tiempoSemanal == 0)
                        {
                            MessageBox.Show("No se encontró actividad física registrada para este usuario.");
                            return;
                        }

                         // Calcular IMC (Índice de Masa Corporal)
                        double pesoKg = peso * 0.453592; // Convertir peso de libras a kg
                        double alturaM = altura * 0.01; // Convertir altura de cm a metros
                        double imc = pesoKg / (alturaM * alturaM);

                        // Mostrar los resultados del IMC en los controles correspondientes
                        textBoxPeso.Text = peso.ToString();  // Mostrar peso en libras
                        textBoxAltura.Text = altura.ToString();  // Mostrar altura en cm
                        textBoxIMC.Text = imc.ToString("F2");  // Mostrar IMC con 2 decimales

                        // Calcular TMB (Tasa Metabólica Basal) usando la fórmula de Harris-Benedict
                        double tmb;

                        if (genero.ToLower() == "masculino")
                        {
                            tmb = 88.362 + (13.397 * peso) + (4.799 * altura) - (5.677 * edad);
                        }
                        else // Femenino
                        {
                            tmb = 447.593 + (9.247 * peso) + (3.098 * altura) - (4.330 * edad);
                        }

                        // Determinar el factor de actividad según las horas de actividad
                        double factorActividad = 1.2; // Sedentario por defecto

                        if (tiempoSemanal <= 2)
                        {
                            factorActividad = 1.2; // Sedentario
                        }
                        else if (tiempoSemanal <= 5)
                        {
                            factorActividad = 1.375; // Actividad ligera
                        }
                        else if (tiempoSemanal <= 10)
                        {
                            factorActividad = 1.55; // Actividad moderada
                        }
                        else
                        {
                            factorActividad = 1.725; // Actividad intensa
                        }

                        // Calcular el requerimiento calórico diario
                        double requerimientoCalorico = tmb * factorActividad;

                        // Mostrar el resultado del requerimiento calórico en el TextBox
                        textBoxRequerimientoCalorico.Text = requerimientoCalorico.ToString("F2");

                        // 2. Obtener las calorías consumidas por los productos registrados
                        double caloriasConsumidasTotales = 0;
                        SqlCommand commandProductos = new SqlCommand(queryProductosConsumidos, connection);
                        SqlDataReader readerProductos = commandProductos.ExecuteReader();

                        if (readerProductos.HasRows) // Verificar si hay productos
                        {
                            while (readerProductos.Read())
                            {
                                // Obtener las calorías de cada producto
                                int caloriasProducto = Convert.ToInt32(readerProductos["caloriaProducto"]);
                                int carbohidratos = Convert.ToInt32(readerProductos["carbohidratoProducto"]);
                                int proteinas = Convert.ToInt32(readerProductos["proteinaProducto"]);
                                int grasas = Convert.ToInt32(readerProductos["grasasProducto"]);

                                // Calcular las calorías consumidas por cada producto
                                int caloriasProductoCalculadas = (carbohidratos * 4) + (proteinas * 4) + (grasas * 9);

                                // Acumular las calorías consumidas totales
                                caloriasConsumidasTotales += caloriasProductoCalculadas;
                            }

                            // Mostrar el total de calorías consumidas en un TextBox
                            textBoxCaloriasConsumidas.Text = caloriasConsumidasTotales.ToString("F2");
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron productos disponibles.");
                        }

                        readerProductos.Close();

                        // Calcular las necesidades de macronutrientes
                        double caloriasPorCarbohidratos = requerimientoCalorico * 0.55;
                        double caloriasPorProteinas = requerimientoCalorico * 0.15;
                        double caloriasPorGrasas = requerimientoCalorico * 0.30;

                        double gramosCarbohidratosNecesarios = caloriasPorCarbohidratos / 4; // 4 calorías por gramo de carbohidrato
                        double gramosProteinasNecesarios = caloriasPorProteinas / 4; // 4 calorías por gramo de proteína
                        double gramosGrasasNecesarios = caloriasPorGrasas / 9; // 9 calorías por gramo de grasa

                        // Generar el análisis nutricional
                        StringBuilder alerta = new StringBuilder();

                        // Comparar las calorías consumidas con las recomendadas y generar alertas
                        if (carbohidratosConsumidos > gramosCarbohidratosNecesarios)
                            alerta.AppendLine("Exceso de carbohidratos. Considera reducir su consumo.");
                        if (carbohidratosConsumidos < gramosCarbohidratosNecesarios)
                            alerta.AppendLine("Déficit de carbohidratos. Asegúrate de consumir suficientes carbohidratos.");

                        if (proteinasConsumidas > gramosProteinasNecesarios)
                            alerta.AppendLine("Exceso de proteínas. Considera reducir el consumo de proteínas.");
                        if (proteinasConsumidas < gramosProteinasNecesarios)
                            alerta.AppendLine("Déficit de proteínas. Asegúrate de consumir suficientes proteínas.");

                        if (grasasConsumidas > gramosGrasasNecesarios)
                            alerta.AppendLine("Exceso de grasas. Considera reducir las grasas en tu dieta.");
                        if (grasasConsumidas < gramosGrasasNecesarios)
                            alerta.AppendLine("Déficit de grasas. Asegúrate de consumir grasas saludables.");

                        // Mostrar el análisis completo en el TextBox
                        textBoxAnalisisNutricional.Text = alerta.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos para el usuario seleccionado.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular el IMC, requerimiento calórico y calorías consumidas: " + ex.Message);
                }
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            Form10 formulario10 = new Form10();

            // Mostrar el segundo formulario
            formulario10.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Recuperar los datos de los TextBox
            int idUsuario = int.Parse(comboBoxUsuarios.Text);  // Asegúrate de que el TextBox tenga el ID del usuario
            double masaCorporal = double.Parse(textBoxIMC.Text);
            double caloriasDiarias = double.Parse(textBoxCaloriasConsumidas.Text);
            double caloriasRecomendadas = double.Parse(textBoxRequerimientoCalorico.Text);
            string recomendaciones = textBoxAnalisisNutricional.Text;

            // Llamar a la función para insertar los datos en la base de datos
            InsertarDatos(idUsuario, (int)masaCorporal, (int)caloriasDiarias, (int)caloriasRecomendadas, recomendaciones);
        }

        // Función para insertar los datos en la base de datos
        private void InsertarDatos(int idUsuario, int masaCorporal, int caloriasDiarias, int caloriasRecomendadas, string recomendaciones)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear la consulta SQL para insertar los datos
                string query = "INSERT INTO calculospaciente (idUsuario, Masa_corporal, CaloriasDiarias, CaloriasRecomendadas, Recomendaciones) " +
                               "VALUES (@idUsuario, @masaCorporal, @caloriasDiarias, @caloriasRecomendadas, @recomendaciones)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar los parámetros de la consulta
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    command.Parameters.AddWithValue("@masaCorporal", masaCorporal);
                    command.Parameters.AddWithValue("@caloriasDiarias", caloriasDiarias);
                    command.Parameters.AddWithValue("@caloriasRecomendadas", caloriasRecomendadas);
                    command.Parameters.AddWithValue("@recomendaciones", recomendaciones);

                    // Abrir la conexión y ejecutar la consulta
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Datos guardados exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar los datos: " + ex.Message);
                    }
                }
            }
        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    