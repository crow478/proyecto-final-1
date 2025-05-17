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
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=LAPTOP-R1VO187T\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

      
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       

      

        private void Form1_Load_1(object sender, EventArgs e)
        {

            conexion conexion = new conexion();
            cmbGenero.Items.Add("MASCULINO");
            cmbGenero.Items.Add("FEMENINO");
            cmbGenero.Items.Add("PREFIERO NO DECIRLO");

            cmbDepartamento.Items.Add("ALTA VERAPAZ");
            cmbDepartamento.Items.Add("BAJA VERAPAZ");
            cmbDepartamento.Items.Add("CHIMALTENANGO");
            cmbDepartamento.Items.Add("CHIQUIMULA");
            cmbDepartamento.Items.Add("EL PROGRESO");
            cmbDepartamento.Items.Add("ESCUINTLA");
            cmbDepartamento.Items.Add("GUATEMALA");
            cmbDepartamento.Items.Add("HUEHUETENANGO");
            cmbDepartamento.Items.Add("IZABAL");
            cmbDepartamento.Items.Add("JALAPA");
            cmbDepartamento.Items.Add("JUTIAPA");
            cmbDepartamento.Items.Add("PETEN");
            cmbDepartamento.Items.Add("QUETZALTENANGO");
            cmbDepartamento.Items.Add("QUICHE");
            cmbDepartamento.Items.Add("RETALHULEU");
            cmbDepartamento.Items.Add("SACATEPEQUEZ");
            cmbDepartamento.Items.Add("SAN MARCOS");
            cmbDepartamento.Items.Add("SANTA ROSA");
            cmbDepartamento.Items.Add("SOLOLA");
            cmbDepartamento.Items.Add("SUCHITEPEQUEZ");
            cmbDepartamento.Items.Add("TOTONICAPAN");
            cmbDepartamento.Items.Add("ZACAPA");



        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpiamos el ComboBox2 antes de agregar nuevos items
            cmbMunicipio.Items.Clear();

   

               

                // Obtenemos el departamento seleccionado
               // string departamentoSeleccionado = cmbDepartamento.SelectedItem.ToString();

                if (cmbDepartamento.SelectedItem != null)
                {
                    string departamentoSeleccionado = cmbDepartamento.SelectedItem.ToString();

                // Agregamos los municipios correspondientes según el departamento seleccionado
                if (departamentoSeleccionado == "CHIMALTENANGO")
                {
                    cmbMunicipio.Items.Add("CHIMALTENANGO");
                    cmbMunicipio.Items.Add("POAQUIL");
                    cmbMunicipio.Items.Add("SAN MARTIN");
                    cmbMunicipio.Items.Add("COMALAPA");
                    cmbMunicipio.Items.Add("SANTA APOLONIA");
                    cmbMunicipio.Items.Add("TECPAN");
                    cmbMunicipio.Items.Add("PATZUN");
                    cmbMunicipio.Items.Add("POCHUTA");
                    cmbMunicipio.Items.Add("PATZICIA");
                    cmbMunicipio.Items.Add("BALANYA");
                    cmbMunicipio.Items.Add("ACATENANGO");
                    cmbMunicipio.Items.Add("YEPOCAPA");
                    cmbMunicipio.Items.Add("ZARAGOZA");
                    cmbMunicipio.Items.Add("EL TEJAR");
                    cmbMunicipio.Items.Add("ITZAPA");


                }
                else if (departamentoSeleccionado == "GUATEMALA")
                {
                    cmbMunicipio.Items.Add("GUATEMALA");
                    cmbMunicipio.Items.Add("SANTA CANTARINA PINULA");
                    cmbMunicipio.Items.Add("SAN JOSE PINULA");
                    cmbMunicipio.Items.Add("SAN JOSE DEL GOLFO");
                    cmbMunicipio.Items.Add("PALENCIA");
                    cmbMunicipio.Items.Add("CHINAUTLA");
                    cmbMunicipio.Items.Add("SAN PEDRO AYAMPUC");
                    cmbMunicipio.Items.Add("MIXCO");
                    cmbMunicipio.Items.Add("SAN PEDRO SACATEPEQUEZ");
                    cmbMunicipio.Items.Add("SAN JUAN SACATEPEQUEZ");
                    cmbMunicipio.Items.Add("SAN RAYMUNDO");
                    cmbMunicipio.Items.Add("CHUARRANCHO");
                    cmbMunicipio.Items.Add("FRAIJANES");
                    cmbMunicipio.Items.Add("AMATITLAN");
                    cmbMunicipio.Items.Add("VILLA NUEVA");
                    cmbMunicipio.Items.Add("VILLA CANELES");
                    cmbMunicipio.Items.Add("SAN MIGUEL PETAPA");



                }
                else if (departamentoSeleccionado == "ESCUINTLA")
                {
                    cmbMunicipio.Items.Add("ESCUINTLA");
                    cmbMunicipio.Items.Add("SANTA LUCIA COTZUMALGUAPA");
                    cmbMunicipio.Items.Add("LA DEMOCRACIA");
                    cmbMunicipio.Items.Add("SIQUINALA");
                    cmbMunicipio.Items.Add("MASAGUA");
                    cmbMunicipio.Items.Add("TIQUISATE");
                    cmbMunicipio.Items.Add("LA GOMERA");
                    cmbMunicipio.Items.Add("GUANAGAZAPA");
                    cmbMunicipio.Items.Add("SAN JOSE");
                    cmbMunicipio.Items.Add("IZTAPA");
                    cmbMunicipio.Items.Add("PALIN");
                    cmbMunicipio.Items.Add("SAN VICENTE PACAYA");
                    cmbMunicipio.Items.Add("NUEVA CONCEPCION");




                }

                else if (departamentoSeleccionado == "ALTA VERAPAZ")
                {
                    cmbMunicipio.Items.Add("COBAN");
                    cmbMunicipio.Items.Add("SAN PEDRO CARCHA");
                    cmbMunicipio.Items.Add("SAN JUAN CHAMELCO");
                    cmbMunicipio.Items.Add("SAN CRISTOBAL");
                    cmbMunicipio.Items.Add("TACTIC");
                    cmbMunicipio.Items.Add("TAMAHU");
                    cmbMunicipio.Items.Add("TUCURU");
                    cmbMunicipio.Items.Add("PANZOS");
                    cmbMunicipio.Items.Add("SANAHU");
                    cmbMunicipio.Items.Add("SANTA CATALINA LA TINTA");
                    cmbMunicipio.Items.Add("LANQUIN");
                    cmbMunicipio.Items.Add("CAHABON");
                    cmbMunicipio.Items.Add("CHISEC");
                    cmbMunicipio.Items.Add("CHAHAL");
                    cmbMunicipio.Items.Add("FRAY BARTOLOME DE LAS CASAS");
                    cmbMunicipio.Items.Add("SANTA CRUZ VERAPAZ");

                }
                else if (departamentoSeleccionado == "BAJA VERAPAZ")
                {
                    cmbMunicipio.Items.Add("SALAMA");
                    cmbMunicipio.Items.Add("SAN MIGUEL CHICAJ");
                    cmbMunicipio.Items.Add("RABINAL");
                    cmbMunicipio.Items.Add("CUBULCO");
                    cmbMunicipio.Items.Add("GRANADOS");
                    cmbMunicipio.Items.Add("SANTA CRUZ EL CHOL");
                    cmbMunicipio.Items.Add("SAN JERONIMO");
                    cmbMunicipio.Items.Add("PURULHA");

                }
                else if (departamentoSeleccionado == "CHIQUIMULA")
                {
                    cmbMunicipio.Items.Add("CHIQUIMULA");
                    cmbMunicipio.Items.Add("SAN JOSE LA ARADA");
                    cmbMunicipio.Items.Add("SAN JUAN ERMITA");
                    cmbMunicipio.Items.Add("JOCOTAN");
                    cmbMunicipio.Items.Add("CAMOTAN");
                    cmbMunicipio.Items.Add("OLOPA");
                    cmbMunicipio.Items.Add("ESQUIPULAS");
                    cmbMunicipio.Items.Add("CONCEPCION LAS MINAS");
                    cmbMunicipio.Items.Add("QUETZALTEPEQUE");

                }
                else if (departamentoSeleccionado == "EL PROGRESO")
                {
                    cmbMunicipio.Items.Add("EL JICARO");
                    cmbMunicipio.Items.Add("GUASTATOYA");
                    cmbMunicipio.Items.Add("MORAZAN");
                    cmbMunicipio.Items.Add("SAN AGUSTIN ACASAGUASTLAN");
                    cmbMunicipio.Items.Add("SAN CRISTOBAL ACASAGUASTLAN");
                    cmbMunicipio.Items.Add("SAN ANTONIO LA PAZ");
                    cmbMunicipio.Items.Add("SANARATE");
                    cmbMunicipio.Items.Add("SANSARE");

                }

                else if (departamentoSeleccionado == "HUEHUETENANGO")
                {
                    cmbMunicipio.Items.Add("AGUACATAN");
                    cmbMunicipio.Items.Add("CHIANTLA");
                    cmbMunicipio.Items.Add("COLOTENANGO");
                    cmbMunicipio.Items.Add("CONCEPCION HUISTA");
                    cmbMunicipio.Items.Add("CUILCO");
                    cmbMunicipio.Items.Add("JACALTENANGO");
                    cmbMunicipio.Items.Add("LA DEMOCRACIA");
                    cmbMunicipio.Items.Add("LA LIBRETAD");
                    cmbMunicipio.Items.Add("MALACATANCITO");
                    cmbMunicipio.Items.Add("NENTON");
                    cmbMunicipio.Items.Add("SAN ANTONIO HUISTA");
                    cmbMunicipio.Items.Add("SAN GASPAR IXCHIL");
                    cmbMunicipio.Items.Add("SAN ILDEFONSO IXTAHUACAN");
                    cmbMunicipio.Items.Add("SAN JUAN ATITAN");
                    cmbMunicipio.Items.Add("SAN JUAN IXCOY");
                    cmbMunicipio.Items.Add("SAN MATEO IXTATAN");
                    cmbMunicipio.Items.Add("SAN MIGUEL ACATAN");
                    cmbMunicipio.Items.Add("SAN PEDRO NECTA");
                    cmbMunicipio.Items.Add("SAN PEDRO SOLOMA");
                    cmbMunicipio.Items.Add("SAN RAFAEL LA INDEPENDENCIA");
                    cmbMunicipio.Items.Add("SAN RAFAEL PETZAL");
                    cmbMunicipio.Items.Add("SAN SEBASTIAN COATAN");
                    cmbMunicipio.Items.Add("SAN SEBASTIAN HUEHUETENANGO");
                    cmbMunicipio.Items.Add("SANTA ANA HUISTA");
                    cmbMunicipio.Items.Add("SANTA BARBARA");
                    cmbMunicipio.Items.Add("SANTA CRUZ BARILLAS");
                    cmbMunicipio.Items.Add("SANTA EULALIA");
                    cmbMunicipio.Items.Add("SANTIAGO CHIMALTENANGO");
                    cmbMunicipio.Items.Add("TECTITAN");
                    cmbMunicipio.Items.Add("TODOS SANTOS CUCHUMATAN");
                    cmbMunicipio.Items.Add("UNION CANTINIL");
                    cmbMunicipio.Items.Add("HUEHUETENANGO");

                }
                else if (departamentoSeleccionado == "IZABAL")
                {
                    cmbMunicipio.Items.Add("EL ESTOR");
                    cmbMunicipio.Items.Add("LIVINSTON");
                    cmbMunicipio.Items.Add("LOS AMATES");
                    cmbMunicipio.Items.Add("MORALES");
                    cmbMunicipio.Items.Add("PUERTO BARRIOS");

                }
                else if (departamentoSeleccionado == "JALAPA")
                {
                    cmbMunicipio.Items.Add("JALAPA");
                    cmbMunicipio.Items.Add("MATAQUESCUINTLA");
                    cmbMunicipio.Items.Add("MONJAS");
                    cmbMunicipio.Items.Add("SAN CARLOS ALZATATE");
                    cmbMunicipio.Items.Add("SAN LUIS JILOTEPEQUE");
                    cmbMunicipio.Items.Add("SAN MANUEL CHAPARRON");
                    cmbMunicipio.Items.Add("SAN PEDRO PINULA");


                }
                else if (departamentoSeleccionado == "JUTIAPA")
                {
                    cmbMunicipio.Items.Add("AGUA BLANCA");
                    cmbMunicipio.Items.Add("ASUNCION MITA");
                    cmbMunicipio.Items.Add("ATESCATEMPA");
                    cmbMunicipio.Items.Add("COMAPA");
                    cmbMunicipio.Items.Add("CONGUACO");
                    cmbMunicipio.Items.Add("EL ADELTANTO");
                    cmbMunicipio.Items.Add("EL PROGRESO");
                    cmbMunicipio.Items.Add("JALPATAGUA");
                    cmbMunicipio.Items.Add("JEREZ");
                    cmbMunicipio.Items.Add("JUTIAPA");
                    cmbMunicipio.Items.Add("MOYUTA");
                    cmbMunicipio.Items.Add("PASACO");
                    cmbMunicipio.Items.Add("QUEZADA");
                    cmbMunicipio.Items.Add("SAN JOSE ACATEMPA");
                    cmbMunicipio.Items.Add("SANTA CATARINA MITA");
                    cmbMunicipio.Items.Add("YUPILTEPEQUE");
                    cmbMunicipio.Items.Add("ZAPOTITLAN");

                }
                else if (departamentoSeleccionado == "PETEN")
                {
                    cmbMunicipio.Items.Add("DOLORES");
                    cmbMunicipio.Items.Add("EL CHAL");
                    cmbMunicipio.Items.Add("FLORES");
                    cmbMunicipio.Items.Add("LA LIBERTAD");
                    cmbMunicipio.Items.Add("MELCHOR DE MENCOS");
                    cmbMunicipio.Items.Add("POCTUN");
                    cmbMunicipio.Items.Add("SAN ANDRES");
                    cmbMunicipio.Items.Add("SAN BENITO");
                    cmbMunicipio.Items.Add("SAN FRANCISCO");
                    cmbMunicipio.Items.Add("SAN JOSE");
                    cmbMunicipio.Items.Add("SAN LUIS");
                    cmbMunicipio.Items.Add("SANTA ANA");
                    cmbMunicipio.Items.Add("SAYAXCHE");
                    cmbMunicipio.Items.Add("LAS CRUCES");


                }
                else if (departamentoSeleccionado == "QUETZALTENANGO")
                {

                    cmbMunicipio.Items.Add("ALMOLONGA");
                    cmbMunicipio.Items.Add("CABRICAN");
                    cmbMunicipio.Items.Add("CAJOLA");
                    cmbMunicipio.Items.Add("CANTEL");
                    cmbMunicipio.Items.Add("COATEPEQUE");
                    cmbMunicipio.Items.Add("COLOMBA");
                    cmbMunicipio.Items.Add("CONCEPCION CHIQUIRICHAPA");
                    cmbMunicipio.Items.Add("EL PALMAR");
                    cmbMunicipio.Items.Add("FLORES COSTACUCA");
                    cmbMunicipio.Items.Add("GENOVA");
                    cmbMunicipio.Items.Add("HUITAN");
                    cmbMunicipio.Items.Add("LA ESPERANZA");
                    cmbMunicipio.Items.Add("OLINTEPEQUE");
                    cmbMunicipio.Items.Add("OSTUNCALCO");
                    cmbMunicipio.Items.Add("PALESTINA DE LOS ALTOS");
                    cmbMunicipio.Items.Add("QUETZALTENANGO");
                    cmbMunicipio.Items.Add("SALCAJA");
                    cmbMunicipio.Items.Add("SAN CARLOS SIJA");
                    cmbMunicipio.Items.Add("SAN FRANCISCO LA UNION");
                    cmbMunicipio.Items.Add("SAN JUAN OSTULCALCO");
                    cmbMunicipio.Items.Add("SAN MARTIN SACATEPEQUEZ");
                    cmbMunicipio.Items.Add("SAN MATEO");
                    cmbMunicipio.Items.Add("SAN MIGUEL SIGUILA");
                    cmbMunicipio.Items.Add("ZUNIL");


                }
                else if (departamentoSeleccionado == "QUICHE")
                {
                    cmbMunicipio.Items.Add("CANILLA");
                    cmbMunicipio.Items.Add("CHAJUL");
                    cmbMunicipio.Items.Add("CHICAMAN");
                    cmbMunicipio.Items.Add("CHICHE");
                    cmbMunicipio.Items.Add("CHICHICASTENANGO");
                    cmbMunicipio.Items.Add("CHINIQUE");
                    cmbMunicipio.Items.Add("CUNEN");
                    cmbMunicipio.Items.Add("IXCAN");
                    cmbMunicipio.Items.Add("JOYABAJ");
                    cmbMunicipio.Items.Add("NEBAJ");
                    cmbMunicipio.Items.Add("PACHALUM");
                    cmbMunicipio.Items.Add("PATZITE");
                    cmbMunicipio.Items.Add("SACAPULAS");
                    cmbMunicipio.Items.Add("SAN ANDRES SAJCABAJA");
                    cmbMunicipio.Items.Add("SAN ANTONIO LOTENANGO");
                    cmbMunicipio.Items.Add("SAN BARTOLOME JOCOTENANGO");
                    cmbMunicipio.Items.Add("SAN JUAN COTZAL");
                    cmbMunicipio.Items.Add("SAN PEDRO JOCOPILAS");
                    cmbMunicipio.Items.Add("SANTA CRUZ DEL QUICHE");
                    cmbMunicipio.Items.Add("USPANTAM");
                    cmbMunicipio.Items.Add("SACUALPA");

                }
                else if (departamentoSeleccionado == "RETALHULEU")
                {
                    cmbMunicipio.Items.Add("CHANPERICO");
                    cmbMunicipio.Items.Add("EL ASINTAL");
                    cmbMunicipio.Items.Add("NUEVO SAN CARLOS");
                    cmbMunicipio.Items.Add("RETALHULEU");
                    cmbMunicipio.Items.Add("SAN ANDRES VILLA SECA");
                    cmbMunicipio.Items.Add("SAN FELIPE");
                    cmbMunicipio.Items.Add("SAN MARTIN ZAPOTITLAN");
                    cmbMunicipio.Items.Add("SAN SEBASTIAN");
                    cmbMunicipio.Items.Add("SANTA CRUZ MULUA");


                }
                else if (departamentoSeleccionado == "SACATEPEQUEZ")
                {
                    cmbMunicipio.Items.Add("ANTIGUA GUATEMALA");
                    cmbMunicipio.Items.Add("CIUDAD VIEJA");
                    cmbMunicipio.Items.Add("JOCOTENANGO");
                    cmbMunicipio.Items.Add("MAGDALENA MILPAS ALTAS");
                    cmbMunicipio.Items.Add("PASTORES");
                    cmbMunicipio.Items.Add("SAN ANTONIO AGUAS CALIENTES");
                    cmbMunicipio.Items.Add("SAN BARTOLOME MILPAS ALTAS");
                    cmbMunicipio.Items.Add("SAN LUCAS SACATEPEQUEZ");
                    cmbMunicipio.Items.Add("SAN MIGUEL DUEÑAS");
                    cmbMunicipio.Items.Add("SAN JUAN ALOTENANGO");
                    cmbMunicipio.Items.Add("SANTA CATARINA BARAHONA");
                    cmbMunicipio.Items.Add("SANTA LUCIA MILPAS ALTAS");
                    cmbMunicipio.Items.Add("SANTA MARIA DE JESUS");
                    cmbMunicipio.Items.Add("SANTIAGO SACATEPEQUEZ");
                    cmbMunicipio.Items.Add("SANTO DOMINGO XENACOJ");
                    cmbMunicipio.Items.Add("SUMPANGO");


                }
                else if (departamentoSeleccionado == "SAN MARCOS")
                {
                    cmbMunicipio.Items.Add("AYUTLA");
                    cmbMunicipio.Items.Add("CATARINA");
                    cmbMunicipio.Items.Add("COMITANCILLO");
                    cmbMunicipio.Items.Add("CONCEPCION TUTUAPA");
                    cmbMunicipio.Items.Add("EL QUETZAL");
                    cmbMunicipio.Items.Add("EL RODEO");
                    cmbMunicipio.Items.Add("EL TUMBADOR");
                    cmbMunicipio.Items.Add("ESQUIPULAS PALO GORDO");
                    cmbMunicipio.Items.Add("IXCHIGUAN");
                    cmbMunicipio.Items.Add("LA REFORMA");
                    cmbMunicipio.Items.Add("MALACATAN");
                    cmbMunicipio.Items.Add("NUEVO PROGRESO");
                    cmbMunicipio.Items.Add("OCOS");
                    cmbMunicipio.Items.Add("PAJAPITA");
                    cmbMunicipio.Items.Add("SAN ANTONIO SACATEPEQUEZ");
                    cmbMunicipio.Items.Add("SAN CRISTOBAL CUCHO");
                    cmbMunicipio.Items.Add("SAN JOSE EL RODEO");
                    cmbMunicipio.Items.Add("SAN JOSE OJETENAM");
                    cmbMunicipio.Items.Add("SAN LORENZO");
                    cmbMunicipio.Items.Add("SAN MARCOS");
                    cmbMunicipio.Items.Add("SAN MIGUEL IXTAHUACAN");
                    cmbMunicipio.Items.Add("SAN PABLO");
                    cmbMunicipio.Items.Add("SAN PEDRO SACATEPEQUEZ");
                    cmbMunicipio.Items.Add("SAN RAFAEL PIE DE LA CUESTA");
                    cmbMunicipio.Items.Add("SIBINAL");
                    cmbMunicipio.Items.Add("SIPACATE");
                    cmbMunicipio.Items.Add("TACANA");
                    cmbMunicipio.Items.Add("TAJUMULCO");
                    cmbMunicipio.Items.Add("TEJUTLA");


                }
                else if (departamentoSeleccionado == "SANTA ROSA")
                {
                    cmbMunicipio.Items.Add("BARBERENA");
                    cmbMunicipio.Items.Add("CASILLAS");
                    cmbMunicipio.Items.Add("CHIQUIMULILLA");
                    cmbMunicipio.Items.Add("CUILAPA");
                    cmbMunicipio.Items.Add("GUAZACAPAN");
                    cmbMunicipio.Items.Add("NUEVA SANTA ROSA");
                    cmbMunicipio.Items.Add("ORATORIO");
                    cmbMunicipio.Items.Add("PEUBLO NUEVO VIÑAS");
                    cmbMunicipio.Items.Add("SAN JUAN TECUACO");
                    cmbMunicipio.Items.Add("SAN RAFAEL LAS FLORES");
                    cmbMunicipio.Items.Add("SANTA CRUZ NARANJO");
                    cmbMunicipio.Items.Add("SANTA MARIA IXHUATAN");
                    cmbMunicipio.Items.Add("SANTA ROSA DE LIMA");
                    cmbMunicipio.Items.Add("TAXISCO");



                }
                else if (departamentoSeleccionado == "SOLOLA")
                {
                    cmbMunicipio.Items.Add("CONCEPCION");
                    cmbMunicipio.Items.Add("NAHUALA");
                    cmbMunicipio.Items.Add("PANAJACHEL");
                    cmbMunicipio.Items.Add("SAN ANDRES SEMETABAJ ");
                    cmbMunicipio.Items.Add("SAN ANTONIO PALOPO");
                    cmbMunicipio.Items.Add("SAN JOSE CHACAYA");
                    cmbMunicipio.Items.Add("SAN JUAN LA LAGUNA");
                    cmbMunicipio.Items.Add("SAN LUCAS TOLIMAN");
                    cmbMunicipio.Items.Add("SAN MARCOS LA LAGUNA");
                    cmbMunicipio.Items.Add("SAN PABLO LA LAGUNA");
                    cmbMunicipio.Items.Add("SN PEDRO LA LAGUNA");
                    cmbMunicipio.Items.Add("SANTA CATARINA IXTAHUACAN");
                    cmbMunicipio.Items.Add("SANTA CATARRINA PALOPO");
                    cmbMunicipio.Items.Add("SANTA CLARA LA LAGUNA");
                    cmbMunicipio.Items.Add("SANTA CRUZ LA LAGUNA");
                    cmbMunicipio.Items.Add("SANTA LUCIA UTATLAN");
                    cmbMunicipio.Items.Add("SANTA MARIA VISITACION");
                    cmbMunicipio.Items.Add("SANTIAGO ATITLAN");
                    cmbMunicipio.Items.Add("SOLOLA");

                }

                else if (departamentoSeleccionado == "SUCHITEPEQUEZ")
                {
                    cmbMunicipio.Items.Add("CHICACAO");
                    cmbMunicipio.Items.Add("CUYOTENANGO");
                    cmbMunicipio.Items.Add("MASATENANGO");
                    cmbMunicipio.Items.Add("PATULUL");
                    cmbMunicipio.Items.Add("PUEBLO NUEVO");
                    cmbMunicipio.Items.Add("RIO BRAVO");
                    cmbMunicipio.Items.Add("SAMAYAC");
                    cmbMunicipio.Items.Add("SAN ANTONIO SUCHITIPEQUEZ");
                    cmbMunicipio.Items.Add("SAN BERNARDINO");
                    cmbMunicipio.Items.Add("SAN FRANSICO ZAPOTITLAN");
                    cmbMunicipio.Items.Add("SAN GABRIEL");
                    cmbMunicipio.Items.Add("SANTA JOSE EL IDOLO");
                    cmbMunicipio.Items.Add("SANTA JUAN BAUTISTA");
                    cmbMunicipio.Items.Add("SANTA LORENZO");
                    cmbMunicipio.Items.Add("SANTA MIGUEL PANAN");
                    cmbMunicipio.Items.Add("SANTA PABLO JOCOPILAS");
                    cmbMunicipio.Items.Add("SANTA BARBARA");
                    cmbMunicipio.Items.Add("SANTIAGO DOMINGO SUCHITEOEQUEZ");
                    cmbMunicipio.Items.Add("SANTO TOMAS LA UNION");
                    cmbMunicipio.Items.Add("ZUNILITO");


                }
                else if (departamentoSeleccionado == "TOTONICAPAN")
                {
                    cmbMunicipio.Items.Add("MOMOSTENANGO");
                    cmbMunicipio.Items.Add("SAN ANDRES XECUL");
                    cmbMunicipio.Items.Add("SAN BARTOLO AGUAS CALIENTES");
                    cmbMunicipio.Items.Add("SAN CRISTOBAL TOTONICAPAN");
                    cmbMunicipio.Items.Add("SAN FRANCISCO DEL ALTO");
                    cmbMunicipio.Items.Add("SANTA LUCIA LA REFORMA");
                    cmbMunicipio.Items.Add("SANTA MARIA CHIQUIMULA");
                    cmbMunicipio.Items.Add("TOTONICAPAN");

                }
                else if (departamentoSeleccionado == "ZACAPA")
                {
                    cmbMunicipio.Items.Add("CABAÑAS");
                    cmbMunicipio.Items.Add("ESTANZUELA");
                    cmbMunicipio.Items.Add("GUALAN");
                    cmbMunicipio.Items.Add("HUITE");
                    cmbMunicipio.Items.Add("LA UNION");
                    cmbMunicipio.Items.Add("RIO HONDO");
                    cmbMunicipio.Items.Add("SAN DIEGO");
                    cmbMunicipio.Items.Add("SAN JORGE");
                    cmbMunicipio.Items.Add("TECULUTAN");
                    cmbMunicipio.Items.Add("ZACAPA");



                }

            }
            




        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear una instancia del segundo formulario
            Form2 formulario2 = new Form2();

            // Mostrar el segundo formulario
            formulario2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtEdad.Text) ||
               // string.IsNullOrWhiteSpace(txtUSUARIO.Text) ||
                cmbMunicipio.SelectedIndex == -1 ||
                cmbDepartamento.SelectedIndex == -1 ||
                cmbGenero.SelectedIndex == -1) // Verificar que el ComboBox de género también esté seleccionado
            {
                //MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();

                    string query = "INSERT INTO paciente (nombres, apellidos, edad, genero,departamento, municipio ) " +
                                   "VALUES (@nombres, @apellidos, @edad,@genero,@departamento,@municipio)";

                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        // Asignar valores de los TextBox y ComboBox a los parámetros
                        cmd.Parameters.AddWithValue("@nombres", txtNombres.Text);
                        cmd.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                        cmd.Parameters.AddWithValue("@edad", int.Parse(txtEdad.Text)); // Convertir a entero
                        cmd.Parameters.AddWithValue("@genero", cmbGenero.SelectedItem?.ToString() ?? "No especificado"); // Usar valor predeterminado si es null
                  //      cmd.Parameters.AddWithValue("@idUsuario", int.Parse(txtUSUARIO.Text)); // Convertir a entero
                        cmd.Parameters.AddWithValue("@departamento", cmbDepartamento.SelectedItem?.ToString() ?? "No especificado"); // Usar valor predeterminado si es null
                        cmd.Parameters.AddWithValue("@municipio", cmbMunicipio.SelectedItem?.ToString() ?? "No especificado"); // Usar valor predeterminado si es null

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Datos guardados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos después de guardar
        private void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEdad.Clear();
            //txtUSUARIO.Clear();
            cmbGenero.SelectedIndex = -1;
            cmbDepartamento.SelectedIndex = -1;
            cmbMunicipio.SelectedIndex = -1;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
