using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proyecto_final_1
{
    internal class conexion
    {
        SqlConnection cnx;
        public conexion() {
            try
            {
                cnx = new SqlConnection("Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True");
                cnx.Open();
                MessageBox.Show("Conetcado Correctamente","Exito al conectar",MessageBoxButtons.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: "+e.Message,"Error inesperado",MessageBoxButtons.OK);
            
           }    
        
        }
    }
}
