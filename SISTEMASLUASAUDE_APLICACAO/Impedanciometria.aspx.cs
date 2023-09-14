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
    public partial class Impedanciometria : System.Web.UI.Page
    {
        #region VARIAVEIS E CONSTANTES
        public const string valorFechaCurva = "-200";
        #endregion

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
            PlotaDadosTimpanogramaOD();
            PlotaDadosTimpanogramaOE();
        }

        protected void btnCalculaDiferenca_Click(object sender, EventArgs e)
        {
            CalculaDiferenca();
           
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

        private void PlotaDadosTimpanogramaOD()
        {
            if (!String.IsNullOrEmpty(pressaoodTextBox.Text) || !String.IsNullOrEmpty(complodTextBox.Text))
            {
                chartODimp.Series.Clear();//limpa o gráfico 
                fechaodTextBox.Visible = true;

                decimal valorA, valorB, valorC;

                valorA = Convert.ToDecimal(pressaoodTextBox.Text);
                valorB = Convert.ToDecimal(complodTextBox.Text);
                if (String.IsNullOrEmpty(fechaodTextBox.Text))
                    fechaodTextBox.Text = valorFechaCurva;
                valorC = Convert.ToDecimal(fechaodTextBox.Text);

                string fundoChart = "fundoChartTransp";
                Series imgFundo = chartODimp.Series.Add(fundoChart);

                string seriesNameA = "liga A";
                Series serA = chartODimp.Series.Add(seriesNameA);

                serA.ChartArea = chartODimp.ChartAreas[0].Name;
                serA.Name = seriesNameA;
                serA.ChartType = SeriesChartType.Line;

                serA.Points.AddXY(200, 0);
                serA.Points.AddXY(valorA, valorB);

                serA.IsVisibleInLegend = false;
                serA.MarkerStyle = MarkerStyle.None;
                serA.BorderColor = Color.Transparent;
                serA.Color = Color.Red;
                serA.BorderWidth = Convert.ToInt32(1.5);

                //******************

                string seriesNameB = "liga B";
                Series serB = chartODimp.Series.Add(seriesNameB);

                serB.ChartArea = chartODimp.ChartAreas[0].Name;
                serB.Name = seriesNameB;
                serB.ChartType = SeriesChartType.Line;

                serB.Points.AddXY(valorA, valorB);
                serB.Points.AddXY(valorC, 0);

                serB.IsVisibleInLegend = false;
                serB.MarkerStyle = MarkerStyle.None;
                serB.BorderColor = Color.Transparent;
                serB.Color = Color.Red;
                serB.BorderWidth = Convert.ToInt32(1.5);

                if (curvaBodCheckBox.Checked == true)
                {
                    if (String.IsNullOrEmpty(fechaodTextBox.Text))
                    {
                        chartODimp.Series.Clear();//limpa o gráfico
                        fechaodTextBox.Text = valorFechaCurva;
                        fechaodTextBox.Visible = false;

                        string seriesNameC = "liga C";
                        Series serC = chartODimp.Series.Add(seriesNameC);

                        serC.ChartArea = chartODimp.ChartAreas[0].Name;
                        serC.Name = seriesNameC;
                        serC.ChartType = SeriesChartType.Line;

                        serC.Points.AddXY(200, 0);
                        serC.Points.AddXY(valorA, valorB);

                        serC.IsVisibleInLegend = false;
                        serC.MarkerStyle = MarkerStyle.None;
                        serC.BorderColor = Color.Transparent;
                        serC.Color = Color.Red;
                        serC.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameD = "liga D";
                        Series serD = chartODimp.Series.Add(seriesNameD);

                        serD.ChartArea = chartODimp.ChartAreas[0].Name;
                        serD.Name = seriesNameD;
                        serD.ChartType = SeriesChartType.Line;

                        serD.Points.AddXY(valorA, valorB);
                        serD.Points.AddXY(-200000, 0);

                        serD.IsVisibleInLegend = false;
                        serD.MarkerStyle = MarkerStyle.None;
                        serD.BorderColor = Color.Transparent;
                        serD.Color = Color.Red;
                        serD.BorderWidth = Convert.ToInt32(1.5);
                    }
                    else
                    {
                        chartODimp.Series.Clear();//limpa o gráfico
                        fechaodTextBox.Visible = false;

                        string seriesNameC = "liga C";
                        Series serC = chartODimp.Series.Add(seriesNameC);

                        serC.ChartArea = chartODimp.ChartAreas[0].Name;
                        serC.Name = seriesNameC;
                        serC.ChartType = SeriesChartType.Line;

                        serC.Points.AddXY(200, 0);
                        serC.Points.AddXY(valorA, valorB);

                        serC.IsVisibleInLegend = false;
                        serC.MarkerStyle = MarkerStyle.None;
                        serC.BorderColor = Color.Transparent;
                        serC.Color = Color.Red;
                        serC.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameD = "liga D";
                        Series serD = chartODimp.Series.Add(seriesNameD);

                        serD.ChartArea = chartODimp.ChartAreas[0].Name;
                        serD.Name = seriesNameD;
                        serD.ChartType = SeriesChartType.Line;

                        serD.Points.AddXY(valorA, valorB);
                        serD.Points.AddXY(-200000, 0);

                        serD.IsVisibleInLegend = false;
                        serD.MarkerStyle = MarkerStyle.None;
                        serD.BorderColor = Color.Transparent;
                        serD.Color = Color.Red;
                        serD.BorderWidth = Convert.ToInt32(1.5);
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Valor (es) incorreto (s) para plotar o gráfico!');", true);
            }
        }

        private void PlotaDadosTimpanogramaOE()
        {
            if (!String.IsNullOrEmpty(pressaooeTextBox.Text) || !String.IsNullOrEmpty(comploeTextBox.Text))
            {
                chartOEimp.Series.Clear();//limpa o gráfico
                fechaoeTextBox.Visible = true;

                decimal valorA, valorB, valorC;

                valorA = Convert.ToDecimal(pressaooeTextBox.Text);
                valorB = Convert.ToDecimal(comploeTextBox.Text);
                if (String.IsNullOrEmpty(fechaoeTextBox.Text))
                    fechaoeTextBox.Text = valorFechaCurva;
                valorC = Convert.ToDecimal(fechaoeTextBox.Text);

                string seriesNameA = "liga A";
                Series serA = chartOEimp.Series.Add(seriesNameA);

                serA.ChartArea = chartOEimp.ChartAreas[0].Name;
                serA.Name = seriesNameA;
                serA.ChartType = SeriesChartType.Line;

                serA.Points.AddXY(200, 0);
                serA.Points.AddXY(valorA, valorB);

                serA.IsVisibleInLegend = false;
                serA.MarkerStyle = MarkerStyle.None;
                serA.BorderColor = Color.Transparent;
                serA.Color = Color.DodgerBlue;
                serA.BorderWidth = Convert.ToInt32(1.5);

                //******************

                string seriesNameB = "liga B";
                Series serB = chartOEimp.Series.Add(seriesNameB);

                serB.ChartArea = chartOEimp.ChartAreas[0].Name;
                serB.Name = seriesNameB;
                serB.ChartType = SeriesChartType.Line;

                serB.Points.AddXY(valorA, valorB);
                serB.Points.AddXY(valorC, 0);

                serB.IsVisibleInLegend = false;
                serB.MarkerStyle = MarkerStyle.None;
                serB.BorderColor = Color.Transparent;
                serB.Color = Color.DodgerBlue;
                serB.BorderWidth = Convert.ToInt32(1.5);

                if (curvaBoeCheckBox.Checked == true)
                {
                    if (String.IsNullOrEmpty(fechaoeTextBox.Text))
                    {
                        chartOEimp.Series.Clear();//limpa o gráfico
                        fechaoeTextBox.Text = valorFechaCurva;
                        fechaoeTextBox.Visible = false;

                        string seriesNameC = "liga C";
                        Series serC = chartOEimp.Series.Add(seriesNameC);

                        serC.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serC.Name = seriesNameC;
                        serC.ChartType = SeriesChartType.Line;

                        serC.Points.AddXY(200, 0);
                        serC.Points.AddXY(valorA, valorB);

                        serC.IsVisibleInLegend = false;
                        serC.MarkerStyle = MarkerStyle.None;
                        serC.BorderColor = Color.Transparent;
                        serC.Color = Color.DodgerBlue;
                        serC.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameD = "liga D";
                        Series serD = chartOEimp.Series.Add(seriesNameD);

                        serD.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serD.Name = seriesNameD;
                        serD.ChartType = SeriesChartType.Line;

                        serD.Points.AddXY(valorA, valorB);
                        serD.Points.AddXY(-200000, 0);

                        serD.IsVisibleInLegend = false;
                        serD.MarkerStyle = MarkerStyle.None;
                        serD.BorderColor = Color.Transparent;
                        serD.Color = Color.DodgerBlue;
                        serD.BorderWidth = Convert.ToInt32(1.5);
                    }
                    else
                    {
                        chartOEimp.Series.Clear();//limpa o gráfico
                        fechaoeTextBox.Visible = false;

                        string seriesNameC = "liga C";
                        Series serC = chartOEimp.Series.Add(seriesNameC);

                        serC.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serC.Name = seriesNameC;
                        serC.ChartType = SeriesChartType.Line;

                        serC.Points.AddXY(200, 0);
                        serC.Points.AddXY(valorA, valorB);

                        serC.IsVisibleInLegend = false;
                        serC.MarkerStyle = MarkerStyle.None;
                        serC.BorderColor = Color.Transparent;
                        serC.Color = Color.DodgerBlue;
                        serC.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameD = "liga D";
                        Series serD = chartOEimp.Series.Add(seriesNameD);

                        serD.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serD.Name = seriesNameD;
                        serD.ChartType = SeriesChartType.Line;

                        serD.Points.AddXY(valorA, valorB);
                        serD.Points.AddXY(-200000, 0);

                        serD.IsVisibleInLegend = false;
                        serD.MarkerStyle = MarkerStyle.None;
                        serD.BorderColor = Color.Transparent;
                        serD.Color = Color.DodgerBlue;
                        serD.BorderWidth = Convert.ToInt32(1.5);
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Valor (es) incorreto (s) para plotar o gráfico!');", true);
            }
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
            

            
        }

        private void CarregaDDLaudioVocal()
        {
            
        }

        private void CarregaTesteWeber()
        {
            
        }

        private void CalculaDiferenca()
        { 
            
        }

        private void CarregaLaudoaudiologico()
        {
            

            //para tipo de curva
            ddlCurvaTipoOD.DataSource = DropdownData_CurvaAudioTipo.GetItems();
            ddlCurvaTipoOD.DataBind();

            ddlCurvaTipoOE.DataSource = DropdownData_CurvaAudioTipo.GetItems();
            ddlCurvaTipoOE.DataBind();

            
        }

        private void CarregaLaudosAutores()
        {
            ddlLaudos.AppendDataBoundItems = true;
            ddlLaudos.DataSource = DropdownData_LaudosAutores.GetItems();
            ddlLaudos.DataBind();
        }

        private void ImprimeAudiograma()
        {
            //PlotaDadosAudiogramaOD();
            //PlotaDadosAudiogramaOE();

            chartODimp.SaveImage("C:\\users/public/documents/chartODimp.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            chartOEimp.SaveImage("C:\\users/public/documents/chartOEimp.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);

            DadosRelatorioImpressao();

            // Define o URL para onde você deseja redirecionar
            string url = "RelatorioImpressaoImpedanciometria.aspx";

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


            dadosRel.autoresLaudo = ddlLaudos.Text;

            dadosRel.comentarios = txtComentariosGerais.Text;

            var examinadorCompleto = Session["ssnUsuario"].ToString() + ". " + Session["ssnConselhoRegional"].ToString() + ".";
            dadosRel.examidador = examinadorCompleto;
            //dadosRel.audiometro = txtAudiometro.Text;*********
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