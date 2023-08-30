using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO
{
    public partial class Aplicativos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgenda_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnProntuario_Click(object sender, EventArgs e)
        {

        }

        protected void btnExames_Click(object sender, EventArgs e)
        {
            Response.Redirect("Exames.aspx");
        }
    }
}