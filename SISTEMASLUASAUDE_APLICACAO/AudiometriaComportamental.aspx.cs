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
                CarregaDDLlocalizaFonteSonora();

                CarregaComportamentoAuditivo();

                CarregaReacoesVerbais();

                CarregaOrdensSimples();

                CarregaConclusoesComportamental();
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
            ImprimeAudiometriaComportamental();
        }

        private void CarregaDDLlocalizaFonteSonora()
        {
            //para a OD
            guizo1odComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            guizo1odComboBox.DataBind();

            guizo2odComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            guizo2odComboBox.DataBind();

            sinoodComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            sinoodComboBox.DataBind();

            blackblackodComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            blackblackodComboBox.DataBind();

            agogoPeqodComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            agogoPeqodComboBox.DataBind();

            agogoGranodComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            agogoGranodComboBox.DataBind();

            chocalhoodComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            chocalhoodComboBox.DataBind();

            trianguloodComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            trianguloodComboBox.DataBind();

            pratoodComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            pratoodComboBox.DataBind();

            tamborodComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            tamborodComboBox.DataBind();

            //para a OE
            guizo1oeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            guizo1oeComboBox.DataBind();

            guizo2oeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            guizo2oeComboBox.DataBind();

            sinooeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            sinooeComboBox.DataBind();

            blackblackoeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            blackblackoeComboBox.DataBind();

            agogoPeqoeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            agogoPeqoeComboBox.DataBind();

            agogoGranoeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            agogoGranoeComboBox.DataBind();

            chocalhooeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            chocalhooeComboBox.DataBind();

            triangulooeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            triangulooeComboBox.DataBind();

            pratooeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            pratooeComboBox.DataBind();

            tamboroeComboBox.DataSource = DropdownData_LocalizaFonteSonora.GetItems();
            tamboroeComboBox.DataBind();
        }

        private void CarregaComportamentoAuditivo()
        {
            comportamentoAuditComboBox.DataSource = DropdownData_ComportamentoAuditivo.GetItems();
            comportamentoAuditComboBox.DataBind();
        }

        private void CarregaReacoesVerbais()
        {
            reacoesVerbaisComboBox.DataSource = DropdownData_ReacoesVerbais.GetItems();
            reacoesVerbaisComboBox.DataBind();
        }

        private void CarregaOrdensSimples()
        {
            ordensSimplesComboBox.DataSource = DropdownData_OrdensSimples.GetItems();
            ordensSimplesComboBox.DataBind();
        }

        private void CarregaConclusoesComportamental()
        {
            ddlConclusões.DataSource = DropdownData_ConclusoesComportamental.GetItems();
            ddlConclusões.DataBind();
        }

        private void ImprimeAudiometriaComportamental()
        {
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