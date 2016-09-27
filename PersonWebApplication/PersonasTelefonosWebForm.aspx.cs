using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

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
            PersonasGridView.DataSource = string.Empty;
            PersonasGridView.DataBind();
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
                foreach (GridViewRow item in PersonasGridView.Rows)
                {
                    Persona.AgregarTelefonos(item.Cells[0].Text, item.Cells[1].Text);
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
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("TipoTelefono"), new DataColumn("Telefono") });
            ViewState["PersonaClass"] = dt;
        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["PersonaClass"];
                DataRow fila;
                fila = dt.NewRow();
                fila["TipoTelefono"] = TipoTelefonoTextBox.Text;
                fila["Telefono"] = TelefonoTextBox.Text;
                dt.Rows.Add(fila);
                ViewState["PersonaClass"] = dt;
                PersonasGridView.DataSource = (DataTable)ViewState["PersonaClass"];
                PersonasGridView.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
           // ObtenerDatos();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ObtenerDatos();
            //Persona.Insertar();
        }

        protected void GButton_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
            Persona.Insertar();
        }
    }
}