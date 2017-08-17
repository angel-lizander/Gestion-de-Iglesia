using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Vistas
{
    public partial class Agregar : Form

    {
        string genero;
        string hijos;
        string ecivil;
        string espiritusanto;
        bool bautizoiglesia;
        string cajatexto;

        public Agregar()
        {
            InitializeComponent();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {

        }

        private void btm_agregar_Click(object sender, EventArgs e)
        {
           
            DateTime nacimiento = DateTime.Parse(txtnacimiento.Text);
            DateTime conversion = DateTime.Parse(txtconversion.Text);
            DateTime bautismo = DateTime.Parse(txtbautismo.Text);
            DateTime miembro = DateTime.Parse(txtmiembro.Text);
            var registrar = new Clases.Registro(txtCedula.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, genero, ecivil, hijos, txtCelular.Text, nacimiento);
                registrar.registrar();
            var info = new Clases.InfoEcle(txtCedula.Text, conversion, bautismo, espiritusanto, bautizoiglesia, miembro, cajatexto);
            info.registrar();
            registrar.ListarDataGrid(Vistas.Buscar.FrmBuscar.dgv_buscar);


        }

        private void rdhombre_CheckedChanged(object sender, EventArgs e)
        {
            
            genero = "H";
        }

        private void rdmujer_CheckedChanged(object sender, EventArgs e)
        {
            genero = "M";
        }

        private void rdsoltero_CheckedChanged(object sender, EventArgs e)
        {
            ecivil = "C";
        }

        private void rdcasado_CheckedChanged(object sender, EventArgs e)
        {
            ecivil = "S";
        }

        private void rdhsi_CheckedChanged(object sender, EventArgs e)
        {
            hijos = "N";
        }

        private void rdhno_CheckedChanged(object sender, EventArgs e)
        {
            hijos = "S";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            espiritusanto = "S";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            espiritusanto = "N";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bautizoiglesia = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bautizoiglesia = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cajatexto = comboBox1.SelectedItem.ToString();
        }

        private void txtmiembro_TextChanged(object sender, EventArgs e)
        {
            if (bautizoiglesia == false)
            {
                txtmiembro.ReadOnly = true;
            }
            else
            {
                txtmiembro.ReadOnly = false;
            }
            
           
        }


    }
    }

