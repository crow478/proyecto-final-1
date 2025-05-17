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
    public partial class Form7 : Form
    {
        private string connectionString = "Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";

        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // int InformacionNutricional = int.Parse(txtinfo.Text);
            string  DescripcionNutricional = txtdescripcion.Text;
            string DietaNutricional = txtdieta.Text;
            int TiempoDieta = int.Parse(txttiempo.Text);

            string query = @"INSERT INTO informacion_nutricional (descripcionNutricional,dietaNutricional,tiempoDieta)
                                                Values(@descripcionNutricional,@dietaNutricional,@tiempoDieta)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))

            {
                // Usar las variables ya convertidas
                //cmd.Parameters.AddWithValue("@idInformacionNutricional", InformacionNutricional);
                cmd.Parameters.AddWithValue("@descripcionNutricional", DescripcionNutricional);
                cmd.Parameters.AddWithValue("@dietaNutricional", DietaNutricional);
                cmd.Parameters.AddWithValue("@tiempoDieta", TiempoDieta);

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
            Form8 formulario8 = new Form8();

            // Mostrar el segundo formulario
            formulario8.Show();
            this.Hide();
        }

        private void txttiempo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}

