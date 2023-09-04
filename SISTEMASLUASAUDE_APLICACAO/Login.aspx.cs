using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //armazena o usuário e a senha em sessions
            Session["ssnUsuario"] = txtUsuario.Text;
            Session["ssnConselhoRegional"] = txtRegistroConselho.Text;

            //redireciona para a próxima págna
            Response.Redirect("Aplicativos.aspx");
        }

        protected void btnInstrucoes_Click(object sender, EventArgs e)
        {
            
        }
    }
}