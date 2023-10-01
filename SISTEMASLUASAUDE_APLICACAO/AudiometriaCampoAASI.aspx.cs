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
    public partial class AudiometriaCampoAASI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaProfissional();

                CarregaDadosPaciente();

                CarregaAudiogramaClinicoOD();
                CarregaAudiogramaClinicoOE();

                CarregaDDLaudioTonalVA();

                CarregaDDLaudioVocal();

                CarregaTesteWeber();

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

        protected void btnPlotarGeral_Click(object sender, EventArgs e)
        {
            PlotaDadosAudiogramaOD();
            PlotaDadosAudiogramaOE();
        }

        protected void btnMediaTritonal_Click(object sender, EventArgs e)
        {
            CalculaMediaTritonal();
            PlotaDadosAudiogramaOD();
            PlotaDadosAudiogramaOE();
        }

        protected void btnMediaQuadritonal_Click(object sender, EventArgs e)
        {
            CalculaMediaQuadritonal();
            PlotaDadosAudiogramaOD();
            PlotaDadosAudiogramaOE();
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimeAudiograma();
        }

        private void CarregaAudiogramaClinicoOD()
        {
            
        }

        private void CarregaAudiogramaClinicoOE()
        {
            
        }

        private void PlotaDadosAudiogramaOD()
        {
            
        }

        private void PlotaDadosAudiogramaOE()
        {
            
        }

        private void CarregaProfissional()
        {
            if (!String.IsNullOrEmpty(Convert.ToString(Session["ssnUsuario"])) && !String.IsNullOrEmpty(Convert.ToString(Session["ssnConselhoRegional"])))
            {
                var usuario = Session["ssnUsuario"].ToString();
                var conselhoRegional = Session["ssnConselhoRegional"].ToString();
                var boasVindas = "Seja bem-vindo (a) " + usuario + ", " + conselhoRegional + ".";
                var dataHoje = Session["ssnDataHoje"].ToString();
                lblBoasVindas.Text = boasVindas;

                txtExaminador.Text = usuario + ". " + conselhoRegional + ".";
                txtDataHoje.Text = dataHoje;
            }
        }

        private void CarregaDadosPaciente()
        {
            if (!String.IsNullOrEmpty(Convert.ToString(Session["ssnNomePaciente"])) && !String.IsNullOrEmpty(Convert.ToString(Session["ssnIdadePaciente"])) && !String.IsNullOrEmpty(Convert.ToString(Session["ssnDataHoje"])) ||
                !String.IsNullOrEmpty(Convert.ToString(Session["ssnNomeSocialPaciente"])))
            {
                var nomePaciente = Session["ssnNomePaciente"].ToString();
                var nomeSocialPaciente = Session["ssnNomeSocialPaciente"].ToString();
                var idadePaciente = Session["ssnIdadePaciente"].ToString();
                var dataHoje = Session["ssnDataHoje"].ToString();

                lblNomePaciente.Text = "Nome do Paciente: " + nomePaciente + ".";
                lblIdadePaciente.Text = "Idade: " + idadePaciente + ".";
                lblNomeSocialPaciente.Text = "Nome Social do Paciente: " + nomeSocialPaciente + ".";
                lblDataHoje.Text = "Data de Hoje: " + dataHoje + ".";
            }
        }

        private void CarregaDDLaudioTonalVA()
        {
            //para OD ######################################################
            //VA
            

            

            //VO
            

            

            //para OE ######################################################
            //VA
            
        }

        private void CarregaDDLaudioVocal()
        {
            //para o IPRF da OD
            //monossílabos
            
        }

        private void CarregaTesteWeber()
        {
            
        }

        private void CalculaMediaTritonal()
        { 
            //Para a OD #############################################
            try//no bloco de tratamento de erros
            {
                

                
            }
            catch (Exception ex)//tratamento de erro
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocorreu um erro.');" + ex.Message, true);
            }
        }

        private void CalculaMediaQuadritonal()
        {
            try//no bloco de tratamento de erros
            {
                

                
            }
            catch (Exception ex)//tratamento de erro
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocorreu um erro.');" + ex.Message, true);
            }
        }

        private void CarregaLaudoaudiologico()
        {
            
        }

        private void CarregaLaudosAutores()
        {
            
        }

        private void ImprimeAudiograma()
        {
            PlotaDadosAudiogramaOD();
            PlotaDadosAudiogramaOE();

            chartAudioEmCampo.SaveImage("C:\\users/public/documents/chartAudioEmCampo.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);

            DadosRelatorioImpressao();

            // Define o URL para onde você deseja redirecionar
            string url = "RelatorioImpressaoAudioCampoAASI.aspx";

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