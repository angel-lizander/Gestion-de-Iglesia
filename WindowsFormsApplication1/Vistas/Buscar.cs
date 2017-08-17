using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Vistas
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
            if (frmBuscar == null)
            {
                frmBuscar = this;
            }
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            //Instancear la clase registro, y ejecutar el metodo Listar
            var registro = new Clases.Registro();
             registro.ListarDataGrid(dgv_buscar);
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registrar = new Vistas.Agregar();
            registrar.ShowDialog();
        }
        //Codigos necesarios para actualizacion
        private static Buscar frmBuscar;

        public static Buscar FrmBuscar
        {
            get
            {
                if (frmBuscar == null)
                {
                    frmBuscar = new Buscar();
                }
                return frmBuscar;
            }

            set
            {
                frmBuscar = value;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            var registro = new Clases.Registro();
            if (txtBuscar.Text.Trim().Length>0)
            {
                registro.BuscarEmpleadoLike(dgv_buscar, txtBuscar.Text.Trim());
            } else
            {
                registro.ListarDataGrid(dgv_buscar);
            }
        }

        private void dgv_buscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex !=1)
            {
                if (dgv_buscar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("editar"))
                {
                    var registro = new Clases.Registro();
                    var cedula = dgv_buscar.Rows[e.RowIndex].Cells[3].Value.ToString();
                    var tabla = registro.BUSCARCEDULA(cedula);
                    var f = new Actualizar();
                    f.Show();
                   if (tabla.Rows.Count==1)
                   {
                        Actualizar.Myform.txtNombre.Text = tabla.Rows[0]["NOMBRE"].ToString();
                        Actualizar.Myform.txtApellido.Text = tabla.Rows[0]["APELLIDO"].ToString();
                        Actualizar.Myform.txtCedula.Text = tabla.Rows[0]["CEDULA"].ToString();
                        Actualizar.Myform.txtDireccion.Text = tabla.Rows[0]["DIRECCION"].ToString();
                        Actualizar.Myform.txtTelefono.Text = tabla.Rows[0]["TELEFONO"].ToString();
                        Actualizar.Myform.txtCelular.Text = tabla.Rows[0]["CELULAR"].ToString();
                        Actualizar.Myform.txtconversion.Text= tabla.Rows[0]["FCONVERSION"].ToString();
                        Actualizar.Myform.txtbautismo.Text = tabla.Rows[0]["FBAUTISMO"].ToString();
                        Actualizar.Myform.txtmiembro.Text = tabla.Rows[0]["FMIEMBRO"].ToString();
                        Actualizar.Myform.comboBox1.Text = tabla.Rows[0]["CONGREGACION"].ToString();
                        Actualizar.Myform.txtnacimiento.Text = tabla.Rows[0]["F_NACIMIENTO"].ToString();
                        Actualizar.Myform.rdhombre.Checked = tabla.Rows[0]["GENERO"].ToString() == "H";
                        Actualizar.Myform.rdmujer.Checked = tabla.Rows[0]["GENERO"].ToString() == "M";
                        Actualizar.Myform.rdsoltero.Checked = tabla.Rows[0]["ECIVIL"].ToString() == "S";
                        Actualizar.Myform.rdsoltero.Checked = tabla.Rows[0]["ECIVIL"].ToString() == "C";
                        Actualizar.Myform.rdhsi.Checked = tabla.Rows[0]["HIJOS"].ToString() == "S";
                        Actualizar.Myform.rdhno.Checked = tabla.Rows[0]["HIJOS"].ToString() == "N";
                        Actualizar.Myform.radioButton6.Checked = tabla.Rows[0]["BAUTIZADOE"].ToString() == "S";
                        Actualizar.Myform.radioButton5.Checked = tabla.Rows[0]["BAUTIZADOE"].ToString() == "N";
                        Actualizar.Myform.radioButton1.Checked = Convert.ToBoolean(tabla.Rows[0]["H_MIEBRO"])==true;
                        Actualizar.Myform.radioButton2.Checked = Convert.ToBoolean(tabla.Rows[0]["H_MIEBRO"]) == false;

                   }







                }




                }

                if (dgv_buscar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("eliminar"))
                {
                    MessageBox.Show("Tu madre en bici");
                }
            }
           
        }
    }

