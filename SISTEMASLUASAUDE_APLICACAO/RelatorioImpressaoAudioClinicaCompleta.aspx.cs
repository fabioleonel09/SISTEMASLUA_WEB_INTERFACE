using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISTEMASLUASAUDE_APLICACAO.ClassesDadosRelatorios;

namespace SISTEMASLUASAUDE_APLICACAO
{
    public partial class RelatorioImpressaoAudioClinicaCompleta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rpvRelatorioImpressaoAudioClinCompl.LocalReport.EnableExternalImages = true;

            rpvRelatorioImpressaoAudioClinCompl.LocalReport.Refresh();  
        }
    }
}