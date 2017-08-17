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
    public partial class Actualizar : Form
    {
        string genero;
        string hijos;
        string ecivil;
        string espiritusanto;
        bool bautizoiglesia;
        string cajatexto;

        public Actualizar()
        {
            InitializeComponent();
            if (_myForm == null)
            {
                _myForm = this;
            }
        }

        private static Actualizar _myForm;

        public static Actualizar Myform
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new Actualizar();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }


      

private void btm_actualizar_Click(object sender, EventArgs e)
        {
            bool uno = rdhombre.Checked;
            if (uno)
            {
                genero = "H";
            }
            else
            {
                genero = "M";
            }

            bool dos = rdsoltero.Checked;
            if (dos)
            {
                ecivil = "Soltero";
            }else
            {
                ecivil = "Casado";
            }
            bool tres = rdhsi.Checked;
            if (tres)
            {
                hijos = "N";
            }
            else
            {
                hijos = "S";
            }

            bool cuatro = radioButton6.Checked;
            if (cuatro)
            {
                espiritusanto = "S";
            }
            else
            {
                espiritusanto = "N";
            }

            bool cinco = radioButton1.Checked;
            if (cinco)
            {
                bautizoiglesia = true;
            }else
            {
                bautizoiglesia = false;
            }



            string cajatexto = comboBox1.SelectedItem.ToString();
            DateTime nacimiento = DateTime.Parse(txtnacimiento.Text);
            DateTime conversion = DateTime.Parse(txtconversion.Text);
            DateTime bautismo = DateTime.Parse(txtbautismo.Text);
            DateTime miembro = DateTime.Parse(txtmiembro.Text);
            var registrar = new Clases.Registro(txtCedula.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, genero, ecivil, hijos, txtCelular.Text, nacimiento);
            registrar.actualizar();
            //var info = new Clases.InfoEcle(/*txtCedula.Text,*/ conversion, bautismo, espiritusanto, bautizoiglesia, miembro, cajatexto);
            //info.registrar();
            registrar.ListarDataGrid(Vistas.Buscar.FrmBuscar.dgv_buscar);



        }





       /* private void txtmiembro_TextChanged(object sender, EventArgs e)
        {
            if (bautizoiglesia == false)
            {
                txtmiembro.ReadOnly = true;
            }
            else
            {
                txtmiembro.ReadOnly = false;
            }


        }*/

        private void Actualizar_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myForm = null;
        }

        private void rdhombre_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }

    }

