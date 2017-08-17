using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Clases
{
    class Registro : Ifunciones
    {
        SqlConnection cn = new SqlConnection(
       ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string genero { get; set; }
        public string ecivil { get; set; }
        public string hijos { get; set; }
        public string celular { get; set; }
        public DateTime f_nacimiento { get; set; }

        //Constructor sin parametros
        public Registro()
        {

        }
        //Constructor con parametros
        public Registro(string _cedula, string _nombre, string _apellido, string _telefono, string _direccion, string _genero, string _ecivil, string _hijos, string _celular, DateTime _f_nacimiento)
        {
            this.cedula = _cedula;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.telefono = _telefono;
            this.direccion = _direccion;
            this.genero = _genero;
            this.ecivil = _ecivil;
            this.hijos = _hijos;
            this.celular = _celular;
            this.f_nacimiento = _f_nacimiento;

        }
        public DataTable BUSCARCEDULA(string cedula)
        {
            var tabla = new DataTable();

            try
            {
                using (var adaptador = new SqlDataAdapter("SP_BUSCARLIKEID", cn))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@CEDULA", cedula);
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.Fill(tabla);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return tabla;
            }
            return tabla;
        }

        public DataTable Listar()
        {
            var tabla = new DataTable();

            try
            {
                using (var adaptador = new SqlDataAdapter("SP_BUSCAR", cn))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.Fill(tabla);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return tabla;
            }
            return tabla;
        }

        //Buscarlike
        public DataTable BUSCARLIKE(string nombre)
        {
            var tabla = new DataTable();

            try
            {
                using (var adaptador = new SqlDataAdapter("SP_BUSCARLIKE", cn))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@NOMBRE", nombre.Trim().ToUpper());
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.Fill(tabla);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return tabla;
            }
            return tabla;
        }

        //Para presentar los parametros en el DGV con buscarlike
        public void BuscarEmpleadoLike(DataGridView dgv, String nombre)
        {
            var tabla = this.BUSCARLIKE(nombre);
            this.ListarGrid(dgv, tabla);
        }
        //Para presentar los parametros sin buscar en el dgv
        public void ListarDataGrid(DataGridView dgv)
        {
            var tabla = this.Listar();
            this.ListarGrid(dgv, tabla);
        }

        //Codigo para datagridview, y para la datatable
        private void ListarGrid(DataGridView dgv, DataTable tabla)
        {
            var numero_filas = tabla.Rows.Count;

            if (numero_filas > 0)
            {
                //Este codigo actuailiza la otra fila
                dgv.Rows.Clear();
                for (int i = 0; i < numero_filas; i++)
                {
                    string nombre_completo = tabla.Rows[i][0].ToString() + " " + tabla.Rows[i][1].ToString();
                    string cedula = tabla.Rows[i][2].ToString();
                    string telefono = tabla.Rows[i][3].ToString();
                    string genero = tabla.Rows[i][4].ToString();
                    string ecivil = tabla.Rows[i][5].ToString();
                    string fmiembro = tabla.Rows[i][6].ToString();
                    string fbautismo = tabla.Rows[i][7].ToString();
                    string congregacion = tabla.Rows[i][8].ToString();

                    dgv.Rows.Add("editar", "eliminar", nombre_completo, cedula, telefono, genero, ecivil, fmiembro, fbautismo, congregacion);
                }
            }
        }

        public bool actualizar()
        {
            throw new NotImplementedException();
        }

        public bool eliminar()
        {
            throw new NotImplementedException();
        }

        public bool registrar()
        {
           
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SP_REGISTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CEDULA", cedula);
                cmd.Parameters.AddWithValue("@NOMBRE", nombre);
                cmd.Parameters.AddWithValue("@APELLIDO", apellido);
                cmd.Parameters.AddWithValue("@TELEFONO", telefono);
                cmd.Parameters.AddWithValue("@DIRECCION", direccion);
                cmd.Parameters.AddWithValue("@GENERO", genero);
                cmd.Parameters.AddWithValue("@ECIVIL", ecivil);
                cmd.Parameters.AddWithValue("@HIJOS", hijos);
                cmd.Parameters.AddWithValue("@CELULAR", celular);
                cmd.Parameters.AddWithValue("@F_NACIMIENTO", f_nacimiento);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Se inserto correctamente");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return true;
        }
    }

    }

