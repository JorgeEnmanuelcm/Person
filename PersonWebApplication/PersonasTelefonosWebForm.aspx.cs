using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.ComponentModel;
using System.Drawing;

namespace PersonWebApplication
{
    public partial class PersonasTelefonosWebForm : System.Web.UI.Page
    {
        PersonaClass Persona = new PersonaClass();

        private void Limpiar()
        {
            NombresTextBox.Text = string.Empty;
            PersonaIdTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            TipoTelefonoTextBox.Text = string.Empty;
            SexoRadioButtonList.SelectedIndex = 0;
            PersonasGridView.DataSource = null;
        }

        private bool ObtenerDatos()
        {
            bool Retorno = true;
            if (NombresTextBox.Text.Length > 0)
            {
                Persona.Nombres = NombresTextBox.Text;
            }
            else
            {
                Retorno = false;
            }

            if (SexoRadioButtonList.SelectedIndex == 1)
            {
                Persona.Sexo = true;
            }
            else
            {
                Persona.Sexo = false;
            }
            if (PersonasGridView.Rows.Count > 0)
            {
                foreach (GridView item in PersonasGridView.Rows)
                {
                  //  Persona.AgregarTelefonos(item.R, item.Cells["Telefono"].Value.ToString());
                }
            }
            else
            {
                Retorno = false;
            }
            return Retorno;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            //PersonaClass per;
            //if (Session["Persona"] == null) 
            //    Session["Persona"] = new PersonaClass(); per = (PersonaClass)Session["Persona"]; per.AgregarTelefonos(TipoTelefonoTextBox.Text, TelefonoTextBox.Text);
            //Session["Persona"] = per;
            //PersonasGridView.DataSource = per.TipoTelefono;
            //PersonasGridView.DataSource = per.Telefono;
            //PersonasGridView.DataBind();
            //TipoTelefonoTextBox.Text = "";
            //TelefonoTextBox.Text = "";
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
           // ObtenerDatos();
        }
    }
}