﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace SISTEMASLUASAUDE_APLICACAO
{
    public partial class Aplicativos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaProfissional();
        }

        protected void btnAgenda_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnProntuario_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnExames_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroInicial.aspx");
        }

        protected void btnRecepcao_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnReceituario_Click(object sender, EventArgs e)
        {

        }

        protected void btnFaturamento_Click(object sender, EventArgs e)
        {

        }

        protected void btnEstoque_Click(object sender, EventArgs e)
        {

        }

        protected void btnConservacaoAuditiva_Click(object sender, EventArgs e)
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