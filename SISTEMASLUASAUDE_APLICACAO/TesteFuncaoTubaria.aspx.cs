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
    public partial class TesteFuncaoTubaria : System.Web.UI.Page
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
            //primeira avaliaçao
            if (!String.IsNullOrEmpty(pressaoodTextBox.Text) || !String.IsNullOrEmpty(complodTextBox.Text))
            {
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

                DataPoint primeiroTeste = new DataPoint();
                decimal pontoB = valorB + 1/5;
                primeiroTeste.SetValueXY(valorA, pontoB);
                primeiroTeste.Label = "1a";
                primeiroTeste.LabelForeColor = Color.White;
                primeiroTeste.LabelBackColor = Color.Red;
                serA.Points.Add(primeiroTeste);

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

            //segunda avaliação
            if (!String.IsNullOrEmpty(txtPressaoSegDeglutOD.Text) || !String.IsNullOrEmpty(txtComplSegDeglutOD.Text))
            {
                txtFechaSegDeglutOD.Visible = true;

                decimal valorD, valorE, valorF;

                valorD = Convert.ToDecimal(txtPressaoSegDeglutOD.Text);
                valorE = Convert.ToDecimal(txtComplSegDeglutOD.Text);
                if (String.IsNullOrEmpty(txtFechaSegDeglutOD.Text))
                    txtFechaSegDeglutOD.Text = valorFechaCurva;
                valorF = Convert.ToDecimal(txtFechaSegDeglutOD.Text);

                string seriesNameE = "liga E";
                Series serE = chartODimp.Series.Add(seriesNameE);

                serE.ChartArea = chartODimp.ChartAreas[0].Name;
                serE.Name = seriesNameE;
                serE.ChartType = SeriesChartType.Line;

                serE.Points.AddXY(200, 0);
                serE.Points.AddXY(valorD, valorE);

                DataPoint segundoTeste = new DataPoint();
                decimal pontoB = valorE + 1 / 5;
                segundoTeste.SetValueXY(valorD, pontoB);
                segundoTeste.Label = "2a";
                segundoTeste.LabelForeColor = Color.White;
                segundoTeste.LabelBackColor = Color.Red;
                serE.Points.Add(segundoTeste);

                serE.IsVisibleInLegend = false;
                serE.MarkerStyle = MarkerStyle.None;
                serE.BorderColor = Color.Transparent;
                serE.Color = Color.Red;
                serE.BorderWidth = Convert.ToInt32(1.5);

                //******************

                string seriesNameF = "liga F";
                Series serF = chartODimp.Series.Add(seriesNameF);

                serF.ChartArea = chartODimp.ChartAreas[0].Name;
                serF.Name = seriesNameF;
                serF.ChartType = SeriesChartType.Line;

                serF.Points.AddXY(valorD, valorE);
                serF.Points.AddXY(valorF, 0);

                serF.IsVisibleInLegend = false;
                serF.MarkerStyle = MarkerStyle.None;
                serF.BorderColor = Color.Transparent;
                serF.Color = Color.Red;
                serF.BorderWidth = Convert.ToInt32(1.5);

                if (ckCurvaBsegDeglutOD.Checked == true)
                {
                    if (String.IsNullOrEmpty(txtFechaSegDeglutOD.Text))
                    {
                        chartODimp.Series.Clear();//limpa o gráfico
                        txtFechaSegDeglutOD.Text = valorFechaCurva;
                        txtFechaSegDeglutOD.Visible = false;

                        string seriesNameG = "liga G";
                        Series serG = chartODimp.Series.Add(seriesNameG);

                        serG.ChartArea = chartODimp.ChartAreas[0].Name;
                        serG.Name = seriesNameG;
                        serG.ChartType = SeriesChartType.Line;

                        serG.Points.AddXY(200, 0);
                        serG.Points.AddXY(valorD, valorE);

                        serG.IsVisibleInLegend = false;
                        serG.MarkerStyle = MarkerStyle.None;
                        serG.BorderColor = Color.Transparent;
                        serG.Color = Color.Red;
                        serG.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameH = "liga H";
                        Series serH = chartODimp.Series.Add(seriesNameH);

                        serH.ChartArea = chartODimp.ChartAreas[0].Name;
                        serH.Name = seriesNameH;
                        serH.ChartType = SeriesChartType.Line;

                        serH.Points.AddXY(valorD, valorE);
                        serH.Points.AddXY(-200000, 0);

                        serH.IsVisibleInLegend = false;
                        serH.MarkerStyle = MarkerStyle.None;
                        serH.BorderColor = Color.Transparent;
                        serH.Color = Color.Red;
                        serH.BorderWidth = Convert.ToInt32(1.5);
                    }
                    else
                    {
                        chartODimp.Series.Clear();//limpa o gráfico
                        txtFechaSegDeglutOD.Visible = false;

                        string seriesNameG = "liga G";
                        Series serG = chartODimp.Series.Add(seriesNameG);

                        serG.ChartArea = chartODimp.ChartAreas[0].Name;
                        serG.Name = seriesNameG;
                        serG.ChartType = SeriesChartType.Line;

                        serG.Points.AddXY(200, 0);
                        serG.Points.AddXY(valorD, valorE);

                        serG.IsVisibleInLegend = false;
                        serG.MarkerStyle = MarkerStyle.None;
                        serG.BorderColor = Color.Transparent;
                        serG.Color = Color.Red;
                        serG.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameH = "liga H";
                        Series serH = chartODimp.Series.Add(seriesNameH);

                        serH.ChartArea = chartODimp.ChartAreas[0].Name;
                        serH.Name = seriesNameH;
                        serH.ChartType = SeriesChartType.Line;

                        serH.Points.AddXY(valorD, valorE);
                        serH.Points.AddXY(-200000, 0);

                        serH.IsVisibleInLegend = false;
                        serH.MarkerStyle = MarkerStyle.None;
                        serH.BorderColor = Color.Transparent;
                        serH.Color = Color.Red;
                        serH.BorderWidth = Convert.ToInt32(1.5);
                    }
                }
            }

            //terceira avaliação
            if (!String.IsNullOrEmpty(txtPressaoTerDeglutOD.Text) || !String.IsNullOrEmpty(txtComplTerDeglutOD.Text))
            {
                txtFechaTerDeglutOD.Visible = true;

                decimal valorG, valorH, valorI;

                valorG = Convert.ToDecimal(txtPressaoTerDeglutOD.Text);
                valorH = Convert.ToDecimal(txtComplTerDeglutOD.Text);
                if (String.IsNullOrEmpty(txtFechaTerDeglutOD.Text))
                    txtFechaTerDeglutOD.Text = valorFechaCurva;
                valorI = Convert.ToDecimal(txtFechaTerDeglutOD.Text);

                string seriesNameI = "liga I";
                Series serI = chartODimp.Series.Add(seriesNameI);

                serI.ChartArea = chartODimp.ChartAreas[0].Name;
                serI.Name = seriesNameI;
                serI.ChartType = SeriesChartType.Line;

                serI.Points.AddXY(200, 0);
                serI.Points.AddXY(valorG, valorH);

                DataPoint terceiroTeste = new DataPoint();
                decimal pontoB = valorH + 1 / 5;
                terceiroTeste.SetValueXY(valorG, pontoB);
                terceiroTeste.Label = "3a";
                terceiroTeste.LabelForeColor = Color.White;
                terceiroTeste.LabelBackColor = Color.Red;
                serI.Points.Add(terceiroTeste);

                serI.IsVisibleInLegend = false;
                serI.MarkerStyle = MarkerStyle.None;
                serI.BorderColor = Color.Transparent;
                serI.Color = Color.Red;
                serI.BorderWidth = Convert.ToInt32(1.5);

                //******************

                string seriesNameJ = "liga J";
                Series serJ = chartODimp.Series.Add(seriesNameJ);

                serJ.ChartArea = chartODimp.ChartAreas[0].Name;
                serJ.Name = seriesNameJ;
                serJ.ChartType = SeriesChartType.Line;

                serJ.Points.AddXY(valorG, valorH);
                serJ.Points.AddXY(valorI, 0);

                serJ.IsVisibleInLegend = false;
                serJ.MarkerStyle = MarkerStyle.None;
                serJ.BorderColor = Color.Transparent;
                serJ.Color = Color.Red;
                serJ.BorderWidth = Convert.ToInt32(1.5);

                if (ckCurvaBterDeglutOD.Checked == true)
                {
                    if (String.IsNullOrEmpty(txtFechaTerDeglutOD.Text))
                    {
                        chartODimp.Series.Clear();//limpa o gráfico
                        txtFechaTerDeglutOD.Text = valorFechaCurva;
                        txtFechaTerDeglutOD.Visible = false;

                        string seriesNameK = "liga K";
                        Series serK = chartODimp.Series.Add(seriesNameK);

                        serK.ChartArea = chartODimp.ChartAreas[0].Name;
                        serK.Name = seriesNameK;
                        serK.ChartType = SeriesChartType.Line;

                        serK.Points.AddXY(200, 0);
                        serK.Points.AddXY(valorG, valorH);

                        serK.IsVisibleInLegend = false;
                        serK.MarkerStyle = MarkerStyle.None;
                        serK.BorderColor = Color.Transparent;
                        serK.Color = Color.Red;
                        serK.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameL = "liga L";
                        Series serL = chartODimp.Series.Add(seriesNameL);

                        serL.ChartArea = chartODimp.ChartAreas[0].Name;
                        serL.Name = seriesNameL;
                        serL.ChartType = SeriesChartType.Line;

                        serL.Points.AddXY(valorG, valorH);
                        serL.Points.AddXY(-200000, 0);

                        serL.IsVisibleInLegend = false;
                        serL.MarkerStyle = MarkerStyle.None;
                        serL.BorderColor = Color.Transparent;
                        serL.Color = Color.Red;
                        serL.BorderWidth = Convert.ToInt32(1.5);
                    }
                    else
                    {
                        chartODimp.Series.Clear();//limpa o gráfico
                        txtFechaTerDeglutOD.Visible = false;

                        string seriesNameK = "liga K";
                        Series serK = chartODimp.Series.Add(seriesNameK);

                        serK.ChartArea = chartODimp.ChartAreas[0].Name;
                        serK.Name = seriesNameK;
                        serK.ChartType = SeriesChartType.Line;

                        serK.Points.AddXY(200, 0);
                        serK.Points.AddXY(valorG, valorH);

                        serK.IsVisibleInLegend = false;
                        serK.MarkerStyle = MarkerStyle.None;
                        serK.BorderColor = Color.Transparent;
                        serK.Color = Color.Red;
                        serK.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameL = "liga L";
                        Series serL = chartODimp.Series.Add(seriesNameL);

                        serL.ChartArea = chartODimp.ChartAreas[0].Name;
                        serL.Name = seriesNameL;
                        serL.ChartType = SeriesChartType.Line;

                        serL.Points.AddXY(valorG, valorH);
                        serL.Points.AddXY(-200000, 0);

                        serL.IsVisibleInLegend = false;
                        serL.MarkerStyle = MarkerStyle.None;
                        serL.BorderColor = Color.Transparent;
                        serL.Color = Color.Red;
                        serL.BorderWidth = Convert.ToInt32(1.5);
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
            //primeira avaliação
            if (!String.IsNullOrEmpty(pressaooeTextBox.Text) || !String.IsNullOrEmpty(comploeTextBox.Text))
            {
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

                DataPoint primeiroTeste = new DataPoint();
                decimal pontoB = valorB + 1 / 5;
                primeiroTeste.SetValueXY(valorA, pontoB);
                primeiroTeste.Label = "1a";
                primeiroTeste.LabelForeColor = Color.White;
                primeiroTeste.LabelBackColor = Color.Blue;
                serA.Points.Add(primeiroTeste);

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

            //segundo teste
            if (!String.IsNullOrEmpty(txtPressaoSegDeglutOE.Text) || !String.IsNullOrEmpty(txtComplSegDeglutOE.Text))
            {
                txtFechaSegDeglutOE.Visible = true;

                decimal valorD, valorE, valorF;

                valorD = Convert.ToDecimal(txtPressaoSegDeglutOE.Text);
                valorE = Convert.ToDecimal(txtComplSegDeglutOE.Text);
                if (String.IsNullOrEmpty(txtFechaSegDeglutOE.Text))
                    txtFechaSegDeglutOE.Text = valorFechaCurva;
                valorF = Convert.ToDecimal(txtFechaSegDeglutOE.Text);

                string seriesNameE = "liga E";
                Series serE = chartOEimp.Series.Add(seriesNameE);

                serE.ChartArea = chartOEimp.ChartAreas[0].Name;
                serE.Name = seriesNameE;
                serE.ChartType = SeriesChartType.Line;

                serE.Points.AddXY(200, 0);
                serE.Points.AddXY(valorD, valorE);

                DataPoint segundoTeste = new DataPoint();
                decimal pontoB = valorE + 1 / 5;
                segundoTeste.SetValueXY(valorD, pontoB);
                segundoTeste.Label = "2a";
                segundoTeste.LabelForeColor = Color.White;
                segundoTeste.LabelBackColor = Color.Blue;
                serE.Points.Add(segundoTeste);

                serE.IsVisibleInLegend = false;
                serE.MarkerStyle = MarkerStyle.None;
                serE.BorderColor = Color.Transparent;
                serE.Color = Color.DodgerBlue;
                serE.BorderWidth = Convert.ToInt32(1.5);

                //******************

                string seriesNameF = "liga F";
                Series serF = chartOEimp.Series.Add(seriesNameF);

                serF.ChartArea = chartOEimp.ChartAreas[0].Name;
                serF.Name = seriesNameF;
                serF.ChartType = SeriesChartType.Line;

                serF.Points.AddXY(valorD, valorE);
                serF.Points.AddXY(valorF, 0);

                serF.IsVisibleInLegend = false;
                serF.MarkerStyle = MarkerStyle.None;
                serF.BorderColor = Color.Transparent;
                serF.Color = Color.DodgerBlue;
                serF.BorderWidth = Convert.ToInt32(1.5);

                if (ckCruvaBsegDeglutOE.Checked == true)
                {
                    if (String.IsNullOrEmpty(txtFechaSegDeglutOE.Text))
                    {
                        chartOEimp.Series.Clear();//limpa o gráfico
                        txtFechaSegDeglutOE.Text = valorFechaCurva;
                        txtFechaSegDeglutOE.Visible = false;

                        string seriesNameG = "liga G";
                        Series serG = chartOEimp.Series.Add(seriesNameG);

                        serG.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serG.Name = seriesNameG;
                        serG.ChartType = SeriesChartType.Line;

                        serG.Points.AddXY(200, 0);
                        serG.Points.AddXY(valorD, valorE);

                        serG.IsVisibleInLegend = false;
                        serG.MarkerStyle = MarkerStyle.None;
                        serG.BorderColor = Color.Transparent;
                        serG.Color = Color.DodgerBlue;
                        serG.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameH = "liga H";
                        Series serH = chartOEimp.Series.Add(seriesNameH);

                        serH.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serH.Name = seriesNameH;
                        serH.ChartType = SeriesChartType.Line;

                        serH.Points.AddXY(valorD, valorE);
                        serH.Points.AddXY(-200000, 0);

                        serH.IsVisibleInLegend = false;
                        serH.MarkerStyle = MarkerStyle.None;
                        serH.BorderColor = Color.Transparent;
                        serH.Color = Color.DodgerBlue;
                        serH.BorderWidth = Convert.ToInt32(1.5);
                    }
                    else
                    {
                        chartOEimp.Series.Clear();//limpa o gráfico
                        txtFechaSegDeglutOE.Visible = false;

                        string seriesNameG = "liga G";
                        Series serG = chartOEimp.Series.Add(seriesNameG);

                        serG.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serG.Name = seriesNameG;
                        serG.ChartType = SeriesChartType.Line;

                        serG.Points.AddXY(200, 0);
                        serG.Points.AddXY(valorD, valorE);

                        serG.IsVisibleInLegend = false;
                        serG.MarkerStyle = MarkerStyle.None;
                        serG.BorderColor = Color.Transparent;
                        serG.Color = Color.DodgerBlue;
                        serG.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameH = "liga H";
                        Series serH = chartOEimp.Series.Add(seriesNameH);

                        serH.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serH.Name = seriesNameH;
                        serH.ChartType = SeriesChartType.Line;

                        serH.Points.AddXY(valorD, valorE);
                        serH.Points.AddXY(-200000, 0);

                        serH.IsVisibleInLegend = false;
                        serH.MarkerStyle = MarkerStyle.None;
                        serH.BorderColor = Color.Transparent;
                        serH.Color = Color.DodgerBlue;
                        serH.BorderWidth = Convert.ToInt32(1.5);
                    }
                }
            }

            //terceiro teste
            if (!String.IsNullOrEmpty(txtPressaoTerDeglutOE.Text) || !String.IsNullOrEmpty(txtComplTerDeglutOE.Text))
            {
                txtFechaTercDeglutOE.Visible = true;

                decimal valorG, valorH, valorI;

                valorG = Convert.ToDecimal(txtPressaoTerDeglutOE.Text);
                valorH = Convert.ToDecimal(txtComplTerDeglutOE.Text);
                if (String.IsNullOrEmpty(txtFechaTercDeglutOE.Text))
                    txtFechaTercDeglutOE.Text = valorFechaCurva;
                valorI = Convert.ToDecimal(txtFechaTercDeglutOE.Text);

                string seriesNameI = "liga I";
                Series serI = chartOEimp.Series.Add(seriesNameI);

                serI.ChartArea = chartOEimp.ChartAreas[0].Name;
                serI.Name = seriesNameI;
                serI.ChartType = SeriesChartType.Line;

                serI.Points.AddXY(200, 0);
                serI.Points.AddXY(valorG, valorH);

                DataPoint terceiroTeste = new DataPoint();
                decimal pontoB = valorH + 1 / 5;
                terceiroTeste.SetValueXY(valorG, pontoB);
                terceiroTeste.Label = "3a";
                terceiroTeste.LabelForeColor = Color.White;
                terceiroTeste.LabelBackColor = Color.Blue;
                serI.Points.Add(terceiroTeste);

                serI.IsVisibleInLegend = false;
                serI.MarkerStyle = MarkerStyle.None;
                serI.BorderColor = Color.Transparent;
                serI.Color = Color.DodgerBlue;
                serI.BorderWidth = Convert.ToInt32(1.5);

                //******************

                string seriesNameJ = "liga J";
                Series serJ = chartOEimp.Series.Add(seriesNameJ);

                serJ.ChartArea = chartOEimp.ChartAreas[0].Name;
                serJ.Name = seriesNameJ;
                serJ.ChartType = SeriesChartType.Line;

                serJ.Points.AddXY(valorG, valorH);
                serJ.Points.AddXY(valorI, 0);

                serJ.IsVisibleInLegend = false;
                serJ.MarkerStyle = MarkerStyle.None;
                serJ.BorderColor = Color.Transparent;
                serJ.Color = Color.DodgerBlue;
                serJ.BorderWidth = Convert.ToInt32(1.5);

                if (ckCurvaBterDeglutOE.Checked == true)
                {
                    if (String.IsNullOrEmpty(txtFechaTercDeglutOE.Text))
                    {
                        chartOEimp.Series.Clear();//limpa o gráfico
                        txtFechaTercDeglutOE.Text = valorFechaCurva;
                        txtFechaTercDeglutOE.Visible = false;

                        string seriesNameK = "liga K";
                        Series serK = chartOEimp.Series.Add(seriesNameK);

                        serK.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serK.Name = seriesNameK;
                        serK.ChartType = SeriesChartType.Line;

                        serK.Points.AddXY(200, 0);
                        serK.Points.AddXY(valorG, valorH);

                        serK.IsVisibleInLegend = false;
                        serK.MarkerStyle = MarkerStyle.None;
                        serK.BorderColor = Color.Transparent;
                        serK.Color = Color.DodgerBlue;
                        serK.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameL = "liga L";
                        Series serL = chartOEimp.Series.Add(seriesNameL);

                        serL.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serL.Name = seriesNameL;
                        serL.ChartType = SeriesChartType.Line;

                        serL.Points.AddXY(valorG, valorH);
                        serL.Points.AddXY(-200000, 0);

                        serL.IsVisibleInLegend = false;
                        serL.MarkerStyle = MarkerStyle.None;
                        serL.BorderColor = Color.Transparent;
                        serL.Color = Color.DodgerBlue;
                        serL.BorderWidth = Convert.ToInt32(1.5);
                    }
                    else
                    {
                        chartOEimp.Series.Clear();//limpa o gráfico
                        txtFechaTercDeglutOE.Visible = false;

                        string seriesNameK = "liga K";
                        Series serK = chartOEimp.Series.Add(seriesNameK);

                        serK.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serK.Name = seriesNameK;
                        serK.ChartType = SeriesChartType.Line;

                        serK.Points.AddXY(200, 0);
                        serK.Points.AddXY(valorG, valorH);

                        serK.IsVisibleInLegend = false;
                        serK.MarkerStyle = MarkerStyle.None;
                        serK.BorderColor = Color.Transparent;
                        serK.Color = Color.DodgerBlue;
                        serK.BorderWidth = Convert.ToInt32(1.5);

                        //******************

                        string seriesNameL = "liga L";
                        Series serL = chartOEimp.Series.Add(seriesNameL);

                        serL.ChartArea = chartOEimp.ChartAreas[0].Name;
                        serL.Name = seriesNameL;
                        serL.ChartType = SeriesChartType.Line;

                        serL.Points.AddXY(valorG, valorH);
                        serL.Points.AddXY(-200000, 0);

                        serL.IsVisibleInLegend = false;
                        serL.MarkerStyle = MarkerStyle.None;
                        serL.BorderColor = Color.Transparent;
                        serL.Color = Color.DodgerBlue;
                        serL.BorderWidth = Convert.ToInt32(1.5);
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

        private void ImprimeAudiograma()
        {
            //PlotaDadosAudiogramaOD();
            //PlotaDadosAudiogramaOE();

            chartODimp.SaveImage("C:\\users/public/documents/chartODimp.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            chartOEimp.SaveImage("C:\\users/public/documents/chartOEimp.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);

            DadosRelatorioImpressao();

            // Define o URL para onde você deseja redirecionar
            string url = "RelatorioImpressaoTesteFuncaoTubaria.aspx";

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