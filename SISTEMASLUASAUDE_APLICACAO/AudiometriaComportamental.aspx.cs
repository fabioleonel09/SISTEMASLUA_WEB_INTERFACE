using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using SISTEMASLUASAUDE_APLICACAO.ClassesDadosRelatorios;
using SISTEMASLUASAUDE_APLICACAO.ddlList_Items;

namespace SISTEMASLUASAUDE_APLICACAO
{
    public partial class AudiometriaComportamental : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaLaudoaudiologico();

                CarregaLaudosAutores();
            }
        }

        protected void btnVoltaTelaAplicativos(object sender, EventArgs e)
        {
            Response.Redirect("Aplicativos.aspx");
        }

        protected void btnVoltaTelaCadastro(object sender, EventArgs e)
        {
            Response.Redirect("CadastroInicial.aspx");
        }

        protected void btnVoltaTelaExames(object sender, EventArgs e)
        {
            Response.Redirect("Exames.aspx");
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimeAudiograma();
        }

        
        private void CarregaLaudoaudiologico()
        {
            //para ddl normal
            ddlAudicaoNormalOD.DataSource = DropdownData_LaudoAudioNormal.GetItems();
            ddlAudicaoNormalOD.DataBind();

            ddlAudicaoNormalOE.DataSource = DropdownData_LaudoAudioNormal.GetItems();
            ddlAudicaoNormalOE.DataBind();

            //para tipo de curva
            ddlCurvaTipoOD.DataSource = DropdownData_CurvaAudioTipo.GetItems();
            ddlCurvaTipoOD.DataBind();

            ddlCurvaTipoOE.DataSource = DropdownData_CurvaAudioTipo.GetItems();
            ddlCurvaTipoOE.DataBind();

            //para o grau
            ddlDeGrauOD.DataSource = DropdownData_GrauAudio.GetItems();
            ddlDeGrauOD.DataBind();

            ddlDeGrauOE.DataSource = DropdownData_GrauAudio.GetItems();
            ddlDeGrauOE.DataBind();

            //para a configuração
            ddlDeConfigOD.DataSource = DropdownData_ConfigTipo.GetItems();
            ddlDeConfigOD.DataBind();

            ddlDeConfigOE.DataSource = DropdownData_ConfigTipo.GetItems();
            ddlDeConfigOE.DataBind();

            //para a audio vocal
            ddlEaudioVocalOD.DataSource = DropdownData_LaudoAudioVocal.GetItems();
            ddlEaudioVocalOD.DataBind();

            ddlEaudioVocalOE.DataSource = DropdownData_LaudoAudioVocal.GetItems();
            ddlEaudioVocalOE.DataBind();
        }

        private void CarregaLaudosAutores()
        {
            ddlLaudos.AppendDataBoundItems = true;
            ddlLaudos.DataSource = DropdownData_LaudosAutores.GetItems();
            ddlLaudos.DataBind();
        }

        private void ImprimeAudiograma()
        {
            

            //chartAudioOD.SaveImage("C:\\users/public/documents/chartODAudioClinica.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            //chartAudioOE.SaveImage("C:\\users/public/documents/chartOEAudioClinica.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);

            DadosRelatorioImpressao();

            // Define o URL para onde você deseja redirecionar
            string url = "RelatorioImpressaoAudioComportamental.aspx";

            // Cria o script JavaScript para abrir uma nova janela
            string script = "window.open('" + url + "', '_blank');";

            // Registra o script no cliente para ser executado
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", script, true);
        }

        public void DadosRelatorioImpressao()
        {
            //instância da classe dos dados do relatório
            DadosRelatorioAudio dadosRel = new DadosRelatorioAudio();

            dadosRel.nomePaciente = Session["ssnNomePaciente"].ToString();
            dadosRel.nomeSocialPaciente = Session["ssnNomeSocialPaciente"].ToString();
            dadosRel.idadePaciente = Session["ssnIdadePaciente"].ToString();
            dadosRel.dataNascimento = Session["ssnDataNascimento"].ToString();

            dadosRel.monOD = ddlIPRFmonOd.Text;
            dadosRel.monOE = ddlIPRFmonOe.Text;
            dadosRel.dissOD = ddlIPRFdisOd.Text;
            dadosRel.dissOE = ddlIPRFdisOe.Text;
            var srtod = txtSRTOD.Text + " dBNA";
            if (!String.IsNullOrEmpty(txtSRTOD.Text))
            {
                dadosRel.srtOD = srtod;
            }
            else
            {
                dadosRel.srtOD = txtSRTOD.Text;
            }
            var srtoe = txtSRTOE.Text + " dBNA";
            if (!String.IsNullOrEmpty(txtSRTOE.Text))
            {
                dadosRel.srtOE = srtoe;
            }
            else
            {
                dadosRel.srtOE = txtSRTOE.Text;
            }
            var sdtod = txtSDTOD.Text + " dBNA";
            if (!String.IsNullOrEmpty(txtSDTOD.Text))
            {
                dadosRel.sdtOD = sdtod;
            }
            else
            {
                dadosRel.sdtOD = txtSDTOD.Text;
            }
            var sdtoe = txtSDTOE.Text + " dBNA";
            if (!String.IsNullOrEmpty(txtSDTOE.Text))
            {
                dadosRel.sdtOE = sdtoe;
            }
            else
            {
                dadosRel.sdtOE = txtSDTOE.Text;
            }
            var mediaod = mEDIAodTextBox.Text + " dBNA";
            if (!String.IsNullOrEmpty(mEDIAodTextBox.Text))
            {
                dadosRel.mediaOD = mediaod;
            }
            else
            {
                dadosRel.mediaOD = mEDIAodTextBox.Text;
            }
            var mediaoe = mEDIAoeTextBox.Text + " dBNA";
            if (!String.IsNullOrEmpty(mEDIAoeTextBox.Text))
            {
                dadosRel.mediaOE = mediaoe;
            }
            else
            {
                dadosRel.mediaOE = mEDIAoeTextBox.Text;
            }

            dadosRel.weber500Hz = weber500ComboBox.Text;
            dadosRel.weber1kHz = weber1kComboBox.Text;
            dadosRel.weber2kHz = weber2kComboBox.Text;
            dadosRel.weber4kHz = weber4kComboBox.Text;

            dadosRel.mascaramento = txtMascaramentoComent.Text;

            dadosRel.curvaAudioNormalOD = ddlAudicaoNormalOD.Text;
            dadosRel.curvaAudioNormalOE = ddlAudicaoNormalOE.Text;
            dadosRel.doTipoOD = ddlCurvaTipoOD.Text;
            dadosRel.doTipoOE = ddlCurvaTipoOE.Text;
            dadosRel.deGrauOD = ddlDeGrauOD.Text;
            dadosRel.deGrauOE = ddlDeGrauOE.Text;
            dadosRel.deConfigOD = ddlDeConfigOD.Text;
            dadosRel.deConfigOE = ddlDeConfigOE.Text;
            dadosRel.deAudioVocalOD = ddlEaudioVocalOD.Text;
            dadosRel.deAudioVocalOE = ddlEaudioVocalOE.Text;

            dadosRel.autoresLaudo = ddlLaudos.Text;

            dadosRel.comentarios = txtComentariosGerais.Text;

            var examinadorCompleto = Session["ssnUsuario"].ToString() + ". " + Session["ssnConselhoRegional"].ToString() + ".";
            dadosRel.examidador = examinadorCompleto;
            dadosRel.audiometro = txtAudiometro.Text;
            dadosRel.dataCalibracao = txtDataCalibracao.Text;

            // Configure as propriedades da classe com os dados da sessão
            RelatorioDataSource.NomePaciente = dadosRel.nomePaciente;
            RelatorioDataSource.NomeSocialPaciente = dadosRel.nomeSocialPaciente;
            RelatorioDataSource.IdadePaciente = dadosRel.idadePaciente;
            RelatorioDataSource.DataNascimento = dadosRel.dataNascimento;

            RelatorioDataSource.MonOD = dadosRel.monOD;
            RelatorioDataSource.MonOE = dadosRel.monOE;
            RelatorioDataSource.DissOD = dadosRel.dissOD;
            RelatorioDataSource.DissOE = dadosRel.dissOE;
            RelatorioDataSource.SrtOD = dadosRel.srtOD;
            RelatorioDataSource.SrtOE = dadosRel.srtOE;
            RelatorioDataSource.SdtOD = dadosRel.sdtOD;
            RelatorioDataSource.SdtOE = dadosRel.sdtOE;
            RelatorioDataSource.MediaOD = dadosRel.mediaOD;
            RelatorioDataSource.MediaOE = dadosRel.mediaOE;

            RelatorioDataSource.Weber500Hz = dadosRel.weber500Hz;
            RelatorioDataSource.Weber1kHz = dadosRel.weber1kHz;
            RelatorioDataSource.Weber2kHz = dadosRel.weber2kHz;
            RelatorioDataSource.Weber4kHz = dadosRel.weber4kHz;

            RelatorioDataSource.Mascaramento = dadosRel.mascaramento;

            RelatorioDataSource.CurvaAudioNormalOD = dadosRel.curvaAudioNormalOD;
            RelatorioDataSource.CurvaAudioNormalOE = dadosRel.curvaAudioNormalOE;
            RelatorioDataSource.DoTipoOD = dadosRel.doTipoOD;
            RelatorioDataSource.DoTipoOE = dadosRel.doTipoOE;
            RelatorioDataSource.DeGrauOD = dadosRel.deGrauOD;
            RelatorioDataSource.DeGrauOE = dadosRel.deGrauOE;
            RelatorioDataSource.DeConfigOD = dadosRel.deConfigOD;
            RelatorioDataSource.DeConfigOE = dadosRel.deConfigOE;
            RelatorioDataSource.DeAudioVocalOD = dadosRel.deAudioVocalOD;
            RelatorioDataSource.DeAudioVocalOE = dadosRel.deAudioVocalOE;

            RelatorioDataSource.AutoresLaudo = dadosRel.autoresLaudo;

            RelatorioDataSource.Comentarios = dadosRel.comentarios;

            RelatorioDataSource.Examinador = dadosRel.examidador;
            RelatorioDataSource.Audiometro = dadosRel.audiometro;
            RelatorioDataSource.DataCalibracao = dadosRel.dataCalibracao;

            // Chame o método GetDadosRelatorio
            DataSet dataSet = RelatorioDataSource.GetDadosRelatorio();
        }
    }
}