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
    public partial class AudiometriaEmCampoConvencional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaProfissional();

                CarregaDadosPaciente();

                CarregaAudiogramaCampoConvenOD();
                CarregaAudiogramaCampoConvenOE();

                CarregaDDLaudioTonalVA();

                CarregaDDLaudioVocal();
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

        private void CarregaAudiogramaCampoConvenOD()
        {
            chartCampoConvenOD.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartCampoConvenOD.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartCampoConvenOD.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartCampoConvenOD.Series.Add(fundoChart);

            imgFundo.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaODCampoConven.SelectedValue == "0")
            {
                var fundoAudioOD = new NamedImage("bananaVermelha", Properties.Resources.bananaVermelha);
                chartCampoConvenOD.Images.Clear();
                chartCampoConvenOD.Images.Add(fundoAudioOD);
                imgFundo.MarkerImage = "bananaVermelha";
                imgFundo.Points.AddXY(7.50, 45);
            }
            else if (rbBananaFalaODCampoConven.SelectedValue == "1")
            {
                chartCampoConvenOD.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1OD";
            Series ser1 = chartCampoConvenOD.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2OD";
            Series ser2 = chartCampoConvenOD.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3OD";
            Series ser3 = chartCampoConvenOD.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4OD";
            Series ser4 = chartCampoConvenOD.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5OD";
            Series ser5 = chartCampoConvenOD.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6OD";
            Series ser6 = chartCampoConvenOD.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7OD";
            Series ser7 = chartCampoConvenOD.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8OD";
            Series ser7a = chartCampoConvenOD.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9OD";
            Series ser9a = chartCampoConvenOD.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10OD";
            Series ser10a = chartCampoConvenOD.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11OD";
            Series ser11a = chartCampoConvenOD.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12OD";
            Series ser12a = chartCampoConvenOD.Series.Add(seriesName12a);

            ser12a.IsVisibleInLegend = false;
            ser12a.ChartType = SeriesChartType.Line;

            ser12a.BorderWidth = 1;
            ser12a.Color = Color.Black;
            ser12a.MarkerStyle = MarkerStyle.None;
            ser12a.Points.AddXY(15, -10);  // x, high
            ser12a.Points.AddXY(15, 120);
        }

        private void CarregaAudiogramaCampoConvenOE()
        {
            chartCampoConvenOE.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartCampoConvenOE.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartCampoConvenOE.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartCampoConvenOE.Series.Add(fundoChart);

            imgFundo.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaOECampoConven.SelectedValue == "0")
            {
                var fundoAudioOE = new NamedImage("bananaAzul", Properties.Resources.bananaAzul);
                chartCampoConvenOE.Images.Clear();
                chartCampoConvenOE.Images.Add(fundoAudioOE);
                imgFundo.MarkerImage = "bananaAzul";
                imgFundo.Points.AddXY(7.50, 45);
            }
            else if (rbBananaFalaOECampoConven.SelectedValue == "1")
            {
                chartCampoConvenOE.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1OD";
            Series ser1 = chartCampoConvenOE.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2OD";
            Series ser2 = chartCampoConvenOE.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3OD";
            Series ser3 = chartCampoConvenOE.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4OD";
            Series ser4 = chartCampoConvenOE.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5OD";
            Series ser5 = chartCampoConvenOE.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6OD";
            Series ser6 = chartCampoConvenOE.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7OD";
            Series ser7 = chartCampoConvenOE.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8OD";
            Series ser7a = chartCampoConvenOE.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9OD";
            Series ser9a = chartCampoConvenOE.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10OD";
            Series ser10a = chartCampoConvenOE.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11OD";
            Series ser11a = chartCampoConvenOE.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12OD";
            Series ser12a = chartCampoConvenOE.Series.Add(seriesName12a);

            ser12a.IsVisibleInLegend = false;
            ser12a.ChartType = SeriesChartType.Line;

            ser12a.BorderWidth = 1;
            ser12a.Color = Color.Black;
            ser12a.MarkerStyle = MarkerStyle.None;
            ser12a.Points.AddXY(15, -10);  // x, high
            ser12a.Points.AddXY(15, 120);
        }

        private void PlotaDadosAudiogramaOD()
        {
            chartCampoConvenOD.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartCampoConvenOD.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartCampoConvenOD.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartCampoConvenOD.Series.Add(fundoChart);

            imgFundo.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaODCampoConven.SelectedValue == "0")
            {
                var fundoAudioOD = new NamedImage("bananaVermelha", Properties.Resources.bananaVermelha);
                chartCampoConvenOD.Images.Clear();
                chartCampoConvenOD.Images.Add(fundoAudioOD);
                imgFundo.MarkerImage = "bananaVermelha";
                imgFundo.Points.AddXY(7.50, 45);
            }
            else if (rbBananaFalaODCampoConven.SelectedValue == "1")
            {
                chartCampoConvenOD.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1OD";
            Series ser1 = chartCampoConvenOD.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2OD";
            Series ser2 = chartCampoConvenOD.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3OD";
            Series ser3 = chartCampoConvenOD.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4OD";
            Series ser4 = chartCampoConvenOD.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5OD";
            Series ser5 = chartCampoConvenOD.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6OD";
            Series ser6 = chartCampoConvenOD.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7OD";
            Series ser7 = chartCampoConvenOD.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8OD";
            Series ser7a = chartCampoConvenOD.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9OD";
            Series ser9a = chartCampoConvenOD.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10OD";
            Series ser10a = chartCampoConvenOD.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11OD";
            Series ser11a = chartCampoConvenOD.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12OD";
            Series ser12a = chartCampoConvenOD.Series.Add(seriesName12a);

            ser12a.IsVisibleInLegend = false;
            ser12a.ChartType = SeriesChartType.Line;

            ser12a.BorderWidth = 1;
            ser12a.Color = Color.Black;
            ser12a.MarkerStyle = MarkerStyle.None;
            ser12a.Points.AddXY(15, -10);  // x, high
            ser12a.Points.AddXY(15, 120);
        }

        private void PlotaDadosAudiogramaOE()
        {
            chartCampoConvenOE.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartCampoConvenOE.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartCampoConvenOE.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartCampoConvenOE.Series.Add(fundoChart);

            imgFundo.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaOECampoConven.SelectedValue == "0")
            {
                var fundoAudioOE = new NamedImage("bananaAzul", Properties.Resources.bananaAzul);
                chartCampoConvenOE.Images.Clear();
                chartCampoConvenOE.Images.Add(fundoAudioOE);
                imgFundo.MarkerImage = "bananaAzul";
                imgFundo.Points.AddXY(7.50, 45);
            }
            else if (rbBananaFalaOECampoConven.SelectedValue == "1")
            {
                chartCampoConvenOE.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1OD";
            Series ser1 = chartCampoConvenOE.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2OD";
            Series ser2 = chartCampoConvenOE.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3OD";
            Series ser3 = chartCampoConvenOE.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4OD";
            Series ser4 = chartCampoConvenOE.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5OD";
            Series ser5 = chartCampoConvenOE.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6OD";
            Series ser6 = chartCampoConvenOE.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7OD";
            Series ser7 = chartCampoConvenOE.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8OD";
            Series ser7a = chartCampoConvenOE.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9OD";
            Series ser9a = chartCampoConvenOE.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10OD";
            Series ser10a = chartCampoConvenOE.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11OD";
            Series ser11a = chartCampoConvenOE.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12OD";
            Series ser12a = chartCampoConvenOE.Series.Add(seriesName12a);

            ser12a.IsVisibleInLegend = false;
            ser12a.ChartType = SeriesChartType.Line;

            ser12a.BorderWidth = 1;
            ser12a.Color = Color.Black;
            ser12a.MarkerStyle = MarkerStyle.None;
            ser12a.Points.AddXY(15, -10);  // x, high
            ser12a.Points.AddXY(15, 120);
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
            

            //para OE ######################################################
            //VA
            
        }

        private void CarregaDDLaudioVocal()
        {
            //para o IPRF da OD
            //monossílabos
            ddlIPRFmonOd.DataSource = DropdownData_Vocal.GetItems();
            ddlIPRFmonOd.DataBind();

            //dissílabos
            ddlIPRFdisOd.DataSource = DropdownData_Vocal.GetItems();
            ddlIPRFdisOd.DataBind();

            //para o IPRF da OE
            //monossílabos
            ddlIPRFmonOe.DataSource = DropdownData_Vocal.GetItems();
            ddlIPRFmonOe.DataBind();

            //dissílabos
            ddlIPRFdisOe.DataSource = DropdownData_Vocal.GetItems();
            ddlIPRFdisOe.DataBind();
        }

        private void CalculaMediaTritonal()
        { 
            //Para a OD #############################################
            
        }

        private void CalculaMediaQuadritonal()
        {
            
        }

        private void ImprimeAudiograma()
        {
            PlotaDadosAudiogramaOD();
            PlotaDadosAudiogramaOE();

            chartCampoConvenOD.SaveImage("C:\\users/public/documents/chartCampoConvenOD.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            chartCampoConvenOE.SaveImage("C:\\users/public/documents/chartCampoConvenOE.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);

            DadosRelatorioImpressao();

            // Define o URL para onde você deseja redirecionar
            string url = "RelatorioImpressaoAudioEmCampoConvencional.aspx";

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