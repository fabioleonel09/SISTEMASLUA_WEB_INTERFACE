using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace SISTEMASLUASAUDE_APLICACAO
{
    public partial class CadastroInicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaProfissional();
        }

        protected void btnVai_Click(object sender, EventArgs e)
        {
            EnviaDadosPaciente();
            Response.Redirect("Exames.aspx");
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

        private void EnviaDadosPaciente()
        {
            //coloca das informações do paciente e associa a Sessions
            Session["ssnNomePaciente"] = txtNomePaciente.Text;
            Session["ssnNomeSocialPaciente"] = txtNomeSocial.Text;
            Session["ssnIdadePaciente"] = txtIdade.Text;
            Session["ssnDataNascimento"] = txtDataNasc.Text;
            Session["ssnDataHoje"] = txtDataHoje.Text;
            Session["ssnInspecaoMAE"] = txtInspecaoMAE.Text;
            Session["ssnQueixasClinicas"] = txtQueixasClinicas.Text;
        }
    }
}