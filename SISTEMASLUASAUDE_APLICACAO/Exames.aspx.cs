using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO
{
    public partial class Exames : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAudioClinica_Click(object sender, EventArgs e)
        {
            Response.Redirect("AudiometriaClinica.aspx");
        }
    }
}