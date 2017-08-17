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
    class InfoEcle : Ifunciones
    {
        SqlConnection cn = new SqlConnection(
       ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public string idiglesia { get; set; }
        public DateTime fconversion { get; set; }
        public DateTime fbautismo { get; set; }
        public string bautizadoe { get; set; }
        public bool hmiembro { get; set; }
        public DateTime fmiembro { get; set; }
        public string congregacion { get; set; }

        public InfoEcle(string _idiglesia, DateTime _fconversion, DateTime _fbautismo, string _bautizadoe, bool _hmiembro, DateTime _fmiembro, string _congregacion)
        {
            this.idiglesia = _idiglesia;
            this.fconversion = _fconversion;
            this.fbautismo = _fbautismo;
            this.bautizadoe = _bautizadoe;
            this.hmiembro = _hmiembro;
            this.fmiembro = _fmiembro;
            this.congregacion = _congregacion;
          
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
                cmd.CommandText = "SP_INGRESARIGLESIA";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDIGLESIA", idiglesia);
                cmd.Parameters.AddWithValue("@FCONVERSION", fconversion);
                cmd.Parameters.AddWithValue("@FBAUTISMO", fbautismo);
                cmd.Parameters.AddWithValue("@BAUTIZADOE", bautizadoe);
                cmd.Parameters.AddWithValue("@H_MIEBRO", hmiembro);
                cmd.Parameters.AddWithValue("@FMIEMBRO", fmiembro);
                cmd.Parameters.AddWithValue("@CONGREGACION", congregacion);
               
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Se inserto correctamente");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return true;
        }
    }
}
