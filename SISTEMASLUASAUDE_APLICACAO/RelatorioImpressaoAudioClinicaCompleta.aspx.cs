using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISTEMASLUASAUDE_APLICACAO.ClassesDadosRelatorios;
using System.Data;

namespace SISTEMASLUASAUDE_APLICACAO
{
    public partial class RelatorioImpressaoAudioClinicaCompleta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rpvRelatorioImpressaoAudioClinCompl.LocalReport.EnableExternalImages = true;

            DataSet dataSet = RelatorioDataSource.GetDadosRelatorio();

            // Configure o ReportViewer
            rpvRelatorioImpressaoAudioClinCompl.LocalReport.ReportPath = Server.MapPath("~/RelatoriosImpressao/rltAudioClinicaCompleta.rdlc"); // Substitua pelo caminho do seu arquivo .rdlc
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["DadosRelatorioAudio"]);
            rpvRelatorioImpressaoAudioClinCompl.LocalReport.DataSources.Add(reportDataSource);

            // Atualize o ReportViewer
            rpvRelatorioImpressaoAudioClinCompl.LocalReport.Refresh();
            //rpvRelatorioImpressaoAudioClinCompl.LocalReport.Refresh();
        }
    }
}