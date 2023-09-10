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
            CarregaProfissional();
        }

        protected void btnAudioConvencional_Click(object sender, EventArgs e)
        {
            Response.Redirect("AudiometriaClinicaConvencional.aspx");
        }

        protected void btnAudioCompleta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AudiometriaClinicaTodasFreq.aspx");
        }

        protected void btnAudioComportamental_Click(object sender, EventArgs e)
        {

        }

        protected void btnAudioCampoLivre_Click(object sender, EventArgs e)
        {

        }

        protected void btnAudioCampoConvencional_Click(object sender, EventArgs e)
        {
            Response.Redirect("AudiometriaEmCampoConvencional.aspx");
        }

        protected void btnAltasFrequencias_Click(object sender, EventArgs e)
        {

        }

        protected void btnImpedanciometria_Click(object sender, EventArgs e)
        {

        }

        private void CarregaProfissional()
        {
            if (!String.IsNullOrEmpty(Convert.ToString(Session["ssnUsuario"])) && !String.IsNullOrEmpty(Convert.ToString(Session["ssnConselhoRegional"])))
            {
                var usuario = Session["ssnUsuario"].ToString();
                var conselhoRegional = Session["ssnConselhoRegional"].ToString();
                var boasVindas = "Seja bem-vindo (a) " + usuario + ", " + conselhoRegional + ".";
                lblBoasVindas.Text = boasVindas;
            }
        }
    }
}