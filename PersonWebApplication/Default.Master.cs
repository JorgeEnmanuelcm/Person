using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonWebApplication
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PersonaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonasTelefonosWebForm.aspx");
        }
    }
}