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
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/bananaVermelha.png";

                // Define o caminho virtual da imagem como imagem do marcador
                imgFundo.Points.AddXY(7.50, 45);
                imgFundo.MarkerImage = caminhoVirtual;
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
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/bananaAzul.png";

                // Define o caminho virtual da imagem como imagem do marcador
                imgFundo.Points.AddXY(7.50, 45);
                imgFundo.MarkerImage = caminhoVirtual;
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
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/bananaVermelha.png";

                // Define o caminho virtual da imagem como imagem do marcador
                imgFundo.Points.AddXY(7.50, 45);
                imgFundo.MarkerImage = caminhoVirtual;
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

            //SIMBOLOGIA OD

            string seriesName13 = "simbol_500campo";
            Series ser13 = chartCampoConvenOD.Series.Add(seriesName13);

            ser13.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
            ser13.Name = seriesName13;
            ser13.ChartType = SeriesChartType.Point;

            if (campo500odComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if (campo500odComboBox.Text != "")
            {
                int valor13;
                valor13 = Convert.ToInt32(campo500odComboBox.Text);
                ser13.Points.AddXY(6, valor13);  // x, high
            }


            if (campoVAodAus500CheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if (campoVAodAus500CheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            //*****

            string seriesName14 = "simbol_1kcampo";
            Series ser14 = chartCampoConvenOD.Series.Add(seriesName14);

            ser14.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
            ser14.Name = seriesName14;
            ser14.ChartType = SeriesChartType.Point;

            if (campo1kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if (campo1kodComboBox.Text != "")
            {
                int valor14;
                valor14 = Convert.ToInt32(campo1kodComboBox.Text);
                ser14.Points.AddXY(8, valor14);  // x, high
            }


            if (campoVAodAus1kCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if (campoVAodAus1kCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            //*****

            string seriesName15 = "simbol_2kcampo";
            Series ser15 = chartCampoConvenOD.Series.Add(seriesName15);

            ser15.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
            ser15.Name = seriesName15;
            ser15.ChartType = SeriesChartType.Point;

            if (campo2kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if (campo2kodComboBox.Text != "")
            {
                int valor15;
                valor15 = Convert.ToInt32(campo2kodComboBox.Text);
                ser15.Points.AddXY(10, valor15);  // x, high
            }


            if (campoVAodAus2kCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if (campoVAodAus2kCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }


            //*****

            string seriesName16 = "simbol_3kcampo";
            Series ser16 = chartCampoConvenOD.Series.Add(seriesName16);

            ser16.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
            ser16.Name = seriesName16;
            ser16.ChartType = SeriesChartType.Point;

            if (campo3kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if (campo3kodComboBox.Text != "")
            {
                int valor16;
                valor16 = Convert.ToInt32(campo3kodComboBox.Text);
                ser16.Points.AddXY(11.25, valor16);  // x, high
            }


            if (campoVAodAus3kCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if (campoVAodAus3kCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            //******

            string seriesName17 = "simbol_4kcampo";
            Series ser17 = chartCampoConvenOD.Series.Add(seriesName17);

            ser17.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
            ser17.Name = seriesName17;
            ser17.ChartType = SeriesChartType.Point;

            if (campo4kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if (campo4kodComboBox.Text != "")
            {
                int valor17;
                valor17 = Convert.ToInt32(campo4kodComboBox.Text);
                ser17.Points.AddXY(12, valor17);  // x, high
            }


            if (campoVAodAus4kCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if (campoVAodAus4kCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            //LIGA A SIMBOLOGIA OD

            try
            {

                string seriesName23 = "liga 500_1kCAMPOOD";
                Series ser23 = chartCampoConvenOD.Series.Add(seriesName23);

                ser23.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
                ser23.Name = seriesName23;
                ser23.ChartType = SeriesChartType.Line;

                if (campoLiga500_1kodCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(campo500odComboBox.Text);
                    valorB = Convert.ToInt32(campo1kodComboBox.Text);

                    ser23.Points.AddXY(6, valorA);
                    ser23.Points.AddXY(8, valorB);

                    ser23.BorderColor = Color.Transparent;
                    ser23.Color = Color.Red;
                    ser23.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (campoLiga500_1kodCheckBox.Checked == false)
                {
                    ser23.Points.Clear();
                }

                //*******

                string seriesName24 = "liga 1k_2kCAMPOOD";
                Series ser24 = chartCampoConvenOD.Series.Add(seriesName24);

                ser24.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
                ser24.Name = seriesName24;
                ser24.ChartType = SeriesChartType.Line;

                if (campoLiga1k_2kodCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(campo1kodComboBox.Text);
                    valorB = Convert.ToInt32(campo2kodComboBox.Text);

                    ser24.Points.AddXY(8, valorA);
                    ser24.Points.AddXY(10, valorB);

                    ser24.BorderColor = Color.Transparent;
                    ser24.Color = Color.Red;
                    ser24.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (campoLiga1k_2kodCheckBox.Checked == false)
                {
                    ser24.Points.Clear();
                }

                //*******

                string seriesName25 = "liga 2k_3kCAMPOOD";
                Series ser25 = chartCampoConvenOD.Series.Add(seriesName25);

                ser25.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
                ser25.Name = seriesName25;
                ser25.ChartType = SeriesChartType.Line;

                if (campoLiga2k_3kodCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(campo2kodComboBox.Text);
                    valorB = Convert.ToInt32(campo3kodComboBox.Text);

                    ser25.Points.AddXY(10, valorA);
                    ser25.Points.AddXY(11.25, valorB);

                    ser25.BorderColor = Color.Transparent;
                    ser25.Color = Color.Red;
                    ser25.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (campoLiga2k_3kodCheckBox.Checked == false)
                {
                    ser25.Points.Clear();
                }

                //******

                string seriesName26 = "liga 3k_4kCAMPOOD";
                Series ser26 = chartCampoConvenOD.Series.Add(seriesName26);

                ser26.ChartArea = chartCampoConvenOD.ChartAreas[0].Name;
                ser26.Name = seriesName26;
                ser26.ChartType = SeriesChartType.Line;

                if (campoLiga3k_4kodCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(campo3kodComboBox.Text);
                    valorB = Convert.ToInt32(campo4kodComboBox.Text);

                    ser26.Points.AddXY(11.25, valorA);
                    ser26.Points.AddXY(12, valorB);

                    ser26.BorderColor = Color.Transparent;
                    ser26.Color = Color.Red;
                    ser26.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (campoLiga3k_4kodCheckBox.Checked == false)
                {
                    ser26.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                campoLiga500_1kodCheckBox.Checked = false;
                campoLiga1k_2kodCheckBox.Checked = false;
                campoLiga2k_3kodCheckBox.Checked = false;
                campoLiga3k_4kodCheckBox.Checked = false;
            }
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
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/bananaAzul.png";

                // Define o caminho virtual da imagem como imagem do marcador
                imgFundo.Points.AddXY(7.50, 45);
                imgFundo.MarkerImage = caminhoVirtual;
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

            //SIMBOLOGIA OE

            string seriesName18 = "simbol_500campoOE";
            Series ser18 = chartCampoConvenOE.Series.Add(seriesName18);

            ser18.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
            ser18.Name = seriesName18;
            ser18.ChartType = SeriesChartType.Point;

            if (campo500oeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if (campo500oeComboBox.Text != "")
            {
                int valor18;
                valor18 = Convert.ToInt32(campo500oeComboBox.Text);
                ser18.Points.AddXY(6, valor18);  // x, high
            }


            if (campoVAoeAus500CheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if (campoVAoeAus500CheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            //*****

            string seriesName19 = "simbol_1kcampoOE";
            Series ser19 = chartCampoConvenOE.Series.Add(seriesName19);

            ser19.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
            ser19.Name = seriesName19;
            ser19.ChartType = SeriesChartType.Point;

            if (campo1koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if (campo1koeComboBox.Text != "")
            {
                int valor19;
                valor19 = Convert.ToInt32(campo1koeComboBox.Text);
                ser19.Points.AddXY(8, valor19);  // x, high
            }


            if (campoVAoeAus1kCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if (campoVAoeAus1kCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            //*****

            string seriesName20 = "simbol_2kcampoOE";
            Series ser20 = chartCampoConvenOE.Series.Add(seriesName20);

            ser20.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
            ser20.Name = seriesName20;
            ser20.ChartType = SeriesChartType.Point;

            if (campo2koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if (campo2koeComboBox.Text != "")
            {
                int valor20;
                valor20 = Convert.ToInt32(campo2koeComboBox.Text);
                ser20.Points.AddXY(10, valor20);  // x, high
            }


            if (campoVAoeAus2kCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if (campoVAoeAus2kCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }


            //*****

            string seriesName21 = "simbol_3kcampoOE";
            Series ser21 = chartCampoConvenOE.Series.Add(seriesName21);

            ser21.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
            ser21.Name = seriesName21;
            ser21.ChartType = SeriesChartType.Point;

            if (campo3koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if (campo3koeComboBox.Text != "")
            {
                int valor21;
                valor21 = Convert.ToInt32(campo3koeComboBox.Text);
                ser21.Points.AddXY(11.25, valor21);  // x, high
            }


            if (campoVAoeAus3kCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if (campoVAoeAus3kCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            //******

            string seriesName22 = "simbol_4kcampoOE";
            Series ser22 = chartCampoConvenOE.Series.Add(seriesName22);

            ser22.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
            ser22.Name = seriesName22;
            ser22.ChartType = SeriesChartType.Point;

            if (campo4koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if (campo4koeComboBox.Text != "")
            {
                int valor22;
                valor22 = Convert.ToInt32(campo4koeComboBox.Text);
                ser22.Points.AddXY(12, valor22);  // x, high
            }


            if (campoVAoeAus4kCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if (campoVAoeAus4kCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoLivreOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            //LIGA A SIMBOLOGIA OE

            try
            {

                string seriesName27 = "liga 500_1kCAMPOOE";
                Series ser27 = chartCampoConvenOE.Series.Add(seriesName27);

                ser27.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
                ser27.Name = seriesName27;
                ser27.ChartType = SeriesChartType.Line;

                if (campoLiga500_1koeCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(campo500oeComboBox.Text);
                    valorB = Convert.ToInt32(campo1koeComboBox.Text);

                    ser27.Points.AddXY(6, valorA);
                    ser27.Points.AddXY(8, valorB);

                    ser27.BorderColor = Color.Transparent;
                    ser27.Color = Color.DodgerBlue;
                    ser27.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (campoLiga500_1koeCheckBox.Checked == false)
                {
                    ser27.Points.Clear();
                }

                //*******

                string seriesName28 = "liga 1k_2kCAMPOOE";
                Series ser28 = chartCampoConvenOE.Series.Add(seriesName28);

                ser28.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
                ser28.Name = seriesName28;
                ser28.ChartType = SeriesChartType.Line;

                if (campoLiga1k_2koeCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(campo1koeComboBox.Text);
                    valorB = Convert.ToInt32(campo2koeComboBox.Text);

                    ser28.Points.AddXY(8, valorA);
                    ser28.Points.AddXY(10, valorB);

                    ser28.BorderColor = Color.Transparent;
                    ser28.Color = Color.DodgerBlue;
                    ser28.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (campoLiga1k_2koeCheckBox.Checked == false)
                {
                    ser28.Points.Clear();
                }

                //*******

                string seriesName29 = "liga 2k_3kCAMPOOE";
                Series ser29 = chartCampoConvenOE.Series.Add(seriesName29);

                ser29.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
                ser29.Name = seriesName29;
                ser29.ChartType = SeriesChartType.Line;

                if (campoLiga2k_3koeCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(campo2koeComboBox.Text);
                    valorB = Convert.ToInt32(campo3koeComboBox.Text);

                    ser29.Points.AddXY(10, valorA);
                    ser29.Points.AddXY(11.25, valorB);

                    ser29.BorderColor = Color.Transparent;
                    ser29.Color = Color.DodgerBlue;
                    ser29.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (campoLiga2k_3koeCheckBox.Checked == false)
                {
                    ser29.Points.Clear();
                }

                //******

                string seriesName30 = "liga 3k_4kCAMPOOE";
                Series ser30 = chartCampoConvenOE.Series.Add(seriesName30);

                ser30.ChartArea = chartCampoConvenOE.ChartAreas[0].Name;
                ser30.Name = seriesName30;
                ser30.ChartType = SeriesChartType.Line;

                if (campoLiga3k_4koeCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(campo3koeComboBox.Text);
                    valorB = Convert.ToInt32(campo4koeComboBox.Text);

                    ser30.Points.AddXY(11.25, valorA);
                    ser30.Points.AddXY(12, valorB);

                    ser30.BorderColor = Color.Transparent;
                    ser30.Color = Color.DodgerBlue;
                    ser30.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (campoLiga3k_4koeCheckBox.Checked == false)
                {
                    ser30.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                campoLiga500_1koeCheckBox.Checked = false;
                campoLiga1k_2koeCheckBox.Checked = false;
                campoLiga2k_3koeCheckBox.Checked = false;
                campoLiga3k_4koeCheckBox.Checked = false;
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
            try//no bloco de tratamento de erros
            {
                //PARA CAMPO CONVENCIONAL OD
                campoMEDIATconvODTextBox.Text = "";//limpa o txt média tritonal 

                if ((campo500odComboBox.Text == "") || (campo1kodComboBox.Text == "") || (campo2kodComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média tritonal de 500Hz, 1kHz e 2kHZ da OD.');", true);
                }

                else//do contrário
                {
                    if ((campoVAodAus500CheckBox.Checked == true) || (campoVAodAus1kCheckBox.Checked == true) || (campoVAodAus2kCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        campoMEDIATconvODTextBox.Text = "Saída máxima";//atritui a frase à txt média
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, resultado;

                        valor1 = Convert.ToInt32(campo500odComboBox.Text);
                        valor2 = Convert.ToInt32(campo1kodComboBox.Text);
                        valor3 = Convert.ToInt32(campo2kodComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3) / 3);

                        campoMEDIATconvODTextBox.Text = Convert.ToString(resultado);
                        lblMediaCampoConvenOD.Text = "Média Tritonal (dBNA):";
                    }
                }

                //PARA CAMPO CONVENCIONAL OE #######################################
                campoMEDIATconvOETextBox.Text = "";//limpa o txt média tritonal 

                if ((campo500oeComboBox.Text == "") || (campo1koeComboBox.Text == "") || (campo2koeComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média tritonal de 500Hz, 1kHz e 2kHZ da OE.');", true);
                }

                else//do contrário
                {
                    if ((campoVAoeAus500CheckBox.Checked == true) || (campoVAoeAus1kCheckBox.Checked == true) || (campoVAoeAus2kCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        campoMEDIATconvOETextBox.Text = "Saída máxima";//atritui a frase à txt média com AASI
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, resultado;

                        valor1 = Convert.ToInt32(campo500oeComboBox.Text);
                        valor2 = Convert.ToInt32(campo1koeComboBox.Text);
                        valor3 = Convert.ToInt32(campo2koeComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3) / 3);

                        campoMEDIATconvOETextBox.Text = Convert.ToString(resultado);
                        lblMediaCampoConvenOE.Text = "Média Tritonal (dBNA):";
                    }
                }
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
                //Para a OD #########################################
                campoMEDIATconvODTextBox.Text = "";//limpa o txt média tritonal

                if ((campo500odComboBox.Text == "") || (campo1kodComboBox.Text == "") || (campo2kodComboBox.Text == "") || (campo4kodComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média quadritonal de 500Hz, 1kHz, 2kHZ e 4kHz da OD.');", true);
                }

                else//do contrário
                {
                    if ((campoVAodAus500CheckBox.Checked == true) || (campoVAodAus1kCheckBox.Checked == true) || (campoVAodAus2kCheckBox.Checked == true) || (campoVAodAus4kCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        campoMEDIATconvODTextBox.Text = "Saída máxima";//atritui a frase à txt média
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, valor4, resultado;

                        valor1 = Convert.ToInt32(campo500odComboBox.Text);
                        valor2 = Convert.ToInt32(campo1kodComboBox.Text);
                        valor3 = Convert.ToInt32(campo2kodComboBox.Text);
                        valor4 = Convert.ToInt32(campo4kodComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3 + valor4) / 4);

                        campoMEDIATconvODTextBox.Text = Convert.ToString(resultado);
                        lblMediaCampoConvenOD.Text = "Média Quadritonal (dBNA):";
                    }
                }

                //Para a OE #######################################
                campoMEDIATconvOETextBox.Text = "";//limpa o txt média tritonal

                if ((campo500oeComboBox.Text == "") || (campo1koeComboBox.Text == "") || (campo2koeComboBox.Text == "") || (campo4koeComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média quadritonal de 500Hz, 1kHz, 2kHZ e 4kHz da OE.');", true);
                }

                else//do contrário
                {
                    if ((campoVAoeAus500CheckBox.Checked == true) || (campoVAoeAus1kCheckBox.Checked == true) || (campoVAoeAus2kCheckBox.Checked == true) || (campoVAoeAus4kCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        campoMEDIATconvOETextBox.Text = "Saída máxima";//atritui a frase à txt média
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, valor4, resultado;

                        valor1 = Convert.ToInt32(campo500oeComboBox.Text);
                        valor2 = Convert.ToInt32(campo1koeComboBox.Text);
                        valor3 = Convert.ToInt32(campo2koeComboBox.Text);
                        valor4 = Convert.ToInt32(campo4koeComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3 + valor4) / 4);

                        campoMEDIATconvOETextBox.Text = Convert.ToString(resultado);
                        lblMediaCampoConvenOE.Text = "Média Quadritonal (dBNA):";
                    }
                }
            }
            catch (Exception ex)//tratamento de erro
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocorreu um erro.');" + ex.Message, true);
            }
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