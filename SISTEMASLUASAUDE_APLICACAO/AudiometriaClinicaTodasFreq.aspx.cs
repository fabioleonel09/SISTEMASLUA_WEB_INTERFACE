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
    public partial class AudiometriaClinicaTodasFreq : System.Web.UI.Page
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
            chartAudioOD.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartAudioOD.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAudioOD.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartAudioOD.Series.Add(fundoChart);

            imgFundo.ChartArea = chartAudioOD.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaODClinica.SelectedValue == "0")
            {
                var fundoAudioOD = new NamedImage("bananaVermelha", Properties.Resources.bananaVermelha);
                chartAudioOD.Images.Clear();
                chartAudioOD.Images.Add(fundoAudioOD);
                imgFundo.MarkerImage = "bananaVermelha";
                imgFundo.Points.AddXY(7.50, 45);
            }
            else if (rbBananaFalaODClinica.SelectedValue == "1")
            {
                chartAudioOD.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1OD";
            Series ser1 = chartAudioOD.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2OD";
            Series ser2 = chartAudioOD.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3OD";
            Series ser3 = chartAudioOD.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4OD";
            Series ser4 = chartAudioOD.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5OD";
            Series ser5 = chartAudioOD.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6OD";
            Series ser6 = chartAudioOD.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7OD";
            Series ser7 = chartAudioOD.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8OD";
            Series ser7a = chartAudioOD.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9OD";
            Series ser9a = chartAudioOD.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10OD";
            Series ser10a = chartAudioOD.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11OD";
            Series ser11a = chartAudioOD.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12OD";
            Series ser12a = chartAudioOD.Series.Add(seriesName12a);

            ser12a.IsVisibleInLegend = false;
            ser12a.ChartType = SeriesChartType.Line;

            ser12a.BorderWidth = 1;
            ser12a.Color = Color.Black;
            ser12a.MarkerStyle = MarkerStyle.None;
            ser12a.Points.AddXY(15, -10);  // x, high
            ser12a.Points.AddXY(15, 120);
        }

        private void CarregaAudiogramaClinicoOE()
        {
            chartAudioOE.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartAudioOE.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAudioOE.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartAudioOE.Series.Add(fundoChart);

            imgFundo.ChartArea = chartAudioOE.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaOEClinica.SelectedValue == "0")
            {
                var fundoAudioOE = new NamedImage("bananaAzul", Properties.Resources.bananaAzul);
                chartAudioOE.Images.Clear();
                chartAudioOE.Images.Add(fundoAudioOE);
                imgFundo.MarkerImage = "bananaAzul";
                imgFundo.Points.AddXY(7.50, 45);
            }
            else if (rbBananaFalaOEClinica.SelectedValue == "1")
            {
                chartAudioOE.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1OE";
            Series ser1 = chartAudioOE.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2OE";
            Series ser2 = chartAudioOE.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3OE";
            Series ser3 = chartAudioOE.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4OE";
            Series ser4 = chartAudioOE.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5OE";
            Series ser5 = chartAudioOE.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6OE";
            Series ser6 = chartAudioOE.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7OE";
            Series ser7 = chartAudioOE.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8OE";
            Series ser7a = chartAudioOE.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9OE";
            Series ser9a = chartAudioOE.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10OE";
            Series ser10a = chartAudioOE.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11OE";
            Series ser11a = chartAudioOE.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12OE";
            Series ser12a = chartAudioOE.Series.Add(seriesName12a);

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
            chartAudioOD.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartAudioOD.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAudioOD.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartAudioOD.Series.Add(fundoChart);

            imgFundo.ChartArea = chartAudioOD.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaODClinica.SelectedValue == "0")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/bananaVermelha.png";

                // Define o caminho virtual da imagem como imagem do marcador
                imgFundo.Points.AddXY(7.50, 45);
                imgFundo.MarkerImage = caminhoVirtual;
            }
            else if (rbBananaFalaODClinica.SelectedValue == "1")
            {
                chartAudioOD.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1OD";
            Series ser1 = chartAudioOD.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2OD";
            Series ser2 = chartAudioOD.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3OD";
            Series ser3 = chartAudioOD.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4OD";
            Series ser4 = chartAudioOD.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5OD";
            Series ser5 = chartAudioOD.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6OD";
            Series ser6 = chartAudioOD.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7OD";
            Series ser7 = chartAudioOD.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8OD";
            Series ser7a = chartAudioOD.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9OD";
            Series ser9a = chartAudioOD.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10OD";
            Series ser10a = chartAudioOD.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11OD";
            Series ser11a = chartAudioOD.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12OD";
            Series ser12a = chartAudioOD.Series.Add(seriesName12a);

            ser12a.IsVisibleInLegend = false;
            ser12a.ChartType = SeriesChartType.Line;

            ser12a.BorderWidth = 1;
            ser12a.Color = Color.Black;
            ser12a.MarkerStyle = MarkerStyle.None;
            ser12a.Points.AddXY(15, -10);  // x, high
            ser12a.Points.AddXY(15, 120);

            //***SIMBOLOGIA DE VA DA OD

            string seriesName13 = "simbol125";
            Series ser13 = chartAudioOD.Series.Add(seriesName13);

            ser13.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser13.Name = seriesName13;
            ser13.ChartType = SeriesChartType.Point;

            if (va125odComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if (va125odComboBox.Text != "")
            {
                int valor13;
                valor13 = Convert.ToInt32(va125odComboBox.Text);
                ser13.Points.AddXY(2, valor13);  // x, high
            }

            if ((aus125vaODCheckBox.Checked == false) && (masc125vaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((aus125vaODCheckBox.Checked == true) && (masc125vaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((aus125vaODCheckBox.Checked == false) && (masc125vaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((masc125vaODCheckBox.Checked == true) && (aus125vaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName14 = "simbol250";
            Series ser14 = chartAudioOD.Series.Add(seriesName14);

            ser14.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser14.Name = seriesName14;
            ser14.ChartType = SeriesChartType.Point;

            if (va250odComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if (va250odComboBox.Text != "")
            {
                int valor14;
                valor14 = Convert.ToInt32(va250odComboBox.Text);
                ser14.Points.AddXY(4, valor14);  // x, high
            }

            if ((aus250vaODCheckBox.Checked == false) && (masc250vaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((aus250vaODCheckBox.Checked == true) && (masc250vaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((aus250vaODCheckBox.Checked == false) && (masc250vaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((masc250vaODCheckBox.Checked == true) && (aus250vaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            //**********

            string seriesName15 = "simbol500";
            Series ser15 = chartAudioOD.Series.Add(seriesName15);

            ser15.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser15.Name = seriesName15;
            ser15.ChartType = SeriesChartType.Point;

            if (va500odComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if (va500odComboBox.Text != "")
            {
                int valor15;
                valor15 = Convert.ToInt32(va500odComboBox.Text);
                ser15.Points.AddXY(6, valor15);  // x, high
            }

            if ((aus500vaODCheckBox.Checked == false) && (masc500vaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if ((aus500vaODCheckBox.Checked == true) && (masc500vaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if ((aus500vaODCheckBox.Checked == false) && (masc500vaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if ((masc500vaODCheckBox.Checked == true) && (aus500vaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            //********

            string seriesName16 = "simbol750";
            Series ser16 = chartAudioOD.Series.Add(seriesName16);

            ser16.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser16.Name = seriesName16;
            ser16.ChartType = SeriesChartType.Point;

            if (va750odComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if (va750odComboBox.Text != "")
            {
                int valor16;
                valor16 = Convert.ToInt32(va750odComboBox.Text);
                ser16.Points.AddXY(7.25, valor16);  // x, high
            }

            if ((aus750vaODCheckBox.Checked == false) && (masc750vaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if ((aus750vaODCheckBox.Checked == true) && (masc750vaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if ((aus750vaODCheckBox.Checked == false) && (masc750vaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if ((masc750vaODCheckBox.Checked == true) && (aus750vaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName17 = "simbol1k";
            Series ser17 = chartAudioOD.Series.Add(seriesName17);

            ser17.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser17.Name = seriesName17;
            ser17.ChartType = SeriesChartType.Point;

            if (va1kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if (va1kodComboBox.Text != "")
            {
                int valor17;
                valor17 = Convert.ToInt32(va1kodComboBox.Text);
                ser17.Points.AddXY(8, valor17);  // x, high
            }

            if ((aus1kvaODCheckBox.Checked == false) && (masc1kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if ((aus1kvaODCheckBox.Checked == true) && (masc1kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if ((aus1kvaODCheckBox.Checked == false) && (masc1kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if ((masc1kvaODCheckBox.Checked == true) && (aus1kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            //***********

            string seriesName18 = "simbol1,5k";
            Series ser18 = chartAudioOD.Series.Add(seriesName18);

            ser18.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser18.Name = seriesName18;
            ser18.ChartType = SeriesChartType.Point;

            if (va1e5kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if (va1e5kodComboBox.Text != "")
            {
                int valor18;
                valor18 = Convert.ToInt32(va1e5kodComboBox.Text);
                ser18.Points.AddXY(9.25, valor18);  // x, high
            }

            if ((aus1_5kvaODCheckBox.Checked == false) && (masc1_5kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if ((aus1_5kvaODCheckBox.Checked == true) && (masc1_5kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if ((aus1_5kvaODCheckBox.Checked == false) && (masc1_5kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if ((masc1_5kvaODCheckBox.Checked == true) && (aus1_5kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            //************

            string seriesName19 = "simbol2k";
            Series ser19 = chartAudioOD.Series.Add(seriesName19);

            ser19.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser19.Name = seriesName19;
            ser19.ChartType = SeriesChartType.Point;

            if (va2kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if (va2kodComboBox.Text != "")
            {
                int valor19;
                valor19 = Convert.ToInt32(va2kodComboBox.Text);
                ser19.Points.AddXY(10, valor19);  // x, high
            }

            if ((aus2kvaODCheckBox.Checked == false) && (masc2kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if ((aus2kvaODCheckBox.Checked == true) && (masc2kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if ((aus2kvaODCheckBox.Checked == false) && (masc2kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if ((masc2kvaODCheckBox.Checked == true) && (aus2kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName20 = "simbol3k";
            Series ser20 = chartAudioOD.Series.Add(seriesName20);

            ser20.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser20.Name = seriesName20;
            ser20.ChartType = SeriesChartType.Point;

            if (va3kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if (va3kodComboBox.Text != "")
            {
                int valor20;
                valor20 = Convert.ToInt32(va3kodComboBox.Text);
                ser20.Points.AddXY(11.25, valor20);  // x, high
            }

            if ((aus3kvaODCheckBox.Checked == false) && (masc3kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if ((aus3kvaODCheckBox.Checked == true) && (masc3kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if ((aus3kvaODCheckBox.Checked == false) && (masc3kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if ((masc3kvaODCheckBox.Checked == true) && (aus3kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            //********

            string seriesName21 = "simbol4k";
            Series ser21 = chartAudioOD.Series.Add(seriesName21);

            ser21.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser21.Name = seriesName21;
            ser21.ChartType = SeriesChartType.Point;

            if (va4kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if (va4kodComboBox.Text != "")
            {
                int valor21;
                valor21 = Convert.ToInt32(va4kodComboBox.Text);
                ser21.Points.AddXY(12, valor21);  // x, high
            }

            if ((aus4kvaODCheckBox.Checked == false) && (masc4kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if ((aus4kvaODCheckBox.Checked == true) && (masc4kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if ((aus4kvaODCheckBox.Checked == false) && (masc4kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if ((masc4kvaODCheckBox.Checked == true) && (aus4kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            //**********

            string seriesName22 = "simbol6k";
            Series ser22 = chartAudioOD.Series.Add(seriesName22);

            ser22.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser22.Name = seriesName22;
            ser22.ChartType = SeriesChartType.Point;

            if (va6kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if (va6kodComboBox.Text != "")
            {
                int valor22;
                valor22 = Convert.ToInt32(va6kodComboBox.Text);
                ser22.Points.AddXY(13.25, valor22);  // x, high
            }

            if ((aus6kvaODCheckBox.Checked == false) && (masc6kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if ((aus6kvaODCheckBox.Checked == true) && (masc6kvaODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if ((aus6kvaODCheckBox.Checked == false) && (masc6kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if ((masc6kvaODCheckBox.Checked == true) && (aus6kvaODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            //***********

            string seriesName23 = "simbol8k";
            Series ser23 = chartAudioOD.Series.Add(seriesName23);

            ser23.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser23.Name = seriesName23;
            ser23.ChartType = SeriesChartType.Point;

            if (va8kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser23.MarkerImage = caminhoVirtual;
            }

            else if (va8kodComboBox.Text != "")
            {
                int valor23;
                valor23 = Convert.ToInt32(va8kodComboBox.Text);
                ser23.Points.AddXY(14, valor23);  // x, high

                if ((aus8kvaODCheckBox.Checked == false) && (masc8kvaODCheckBox.Checked == false))
                {
                    // Caminho virtual da imagem (relativo à raiz do projeto)
                    string caminhoVirtual = "~/Images/vaODpresente.png";

                    // Define o caminho virtual da imagem como imagem do marcador
                    ser23.MarkerImage = caminhoVirtual;
                }

                else if ((aus8kvaODCheckBox.Checked == true) && (masc8kvaODCheckBox.Checked == false))
                {
                    // Caminho virtual da imagem (relativo à raiz do projeto)
                    string caminhoVirtual = "~/Images/vaODausente.png";

                    // Define o caminho virtual da imagem como imagem do marcador
                    ser23.MarkerImage = caminhoVirtual;
                }

                else if ((aus8kvaODCheckBox.Checked == false) && (masc8kvaODCheckBox.Checked == true))
                {
                    // Caminho virtual da imagem (relativo à raiz do projeto)
                    string caminhoVirtual = "~/Images/vaODmascPresente.png";

                    // Define o caminho virtual da imagem como imagem do marcador
                    ser23.MarkerImage = caminhoVirtual;
                }

                else if ((masc8kvaODCheckBox.Checked == true) && (aus8kvaODCheckBox.Checked == true))
                {
                    // Caminho virtual da imagem (relativo à raiz do projeto)
                    string caminhoVirtual = "~/Images/vaODmascAusente.png";

                    // Define o caminho virtual da imagem como imagem do marcador
                    ser23.MarkerImage = caminhoVirtual;
                }
            }

            //********LIGAR A SIMBOLOGIA DA OD

            try
            {
                string seriesName24 = "liga 125_ 250 vaOD";
                Series ser24 = chartAudioOD.Series.Add(seriesName24);

                ser24.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser24.Name = seriesName24;
                ser24.ChartType = SeriesChartType.Line;

                if (liga125_250vaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va125odComboBox.Text);
                    valorB = Convert.ToInt32(va250odComboBox.Text);

                    ser24.Points.AddXY(2, valorA);
                    ser24.Points.AddXY(4, valorB);

                    ser24.BorderColor = Color.Transparent;
                    ser24.Color = Color.Red;
                    ser24.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga125_250vaODCheckBox.Checked == false)
                {
                    ser24.Points.Clear();
                }

                //*******

                string seriesName25 = "liga 250_500 vaOD";
                Series ser25 = chartAudioOD.Series.Add(seriesName25);

                ser25.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser25.Name = seriesName25;
                ser25.ChartType = SeriesChartType.Line;

                if (liga250_500vaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va250odComboBox.Text);
                    valorB = Convert.ToInt32(va500odComboBox.Text);

                    ser25.Points.AddXY(4, valorA);
                    ser25.Points.AddXY(6, valorB);

                    ser25.BorderColor = Color.Transparent;
                    ser25.Color = Color.Red;
                    ser25.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga250_500vaODCheckBox.Checked == false)
                {
                    ser25.Points.Clear();
                }

                //*******

                string seriesName26 = "liga 500_750 vaOD";
                Series ser26 = chartAudioOD.Series.Add(seriesName26);

                ser26.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser26.Name = seriesName26;
                ser26.ChartType = SeriesChartType.Line;

                if (liga500_750vaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va500odComboBox.Text);
                    valorB = Convert.ToInt32(va750odComboBox.Text);

                    ser26.Points.AddXY(6, valorA);
                    ser26.Points.AddXY(7.25, valorB);

                    ser26.BorderColor = Color.Transparent;
                    ser26.Color = Color.Red;
                    ser26.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga500_750vaODCheckBox.Checked == false)
                {
                    ser26.Points.Clear();
                }

                //******

                string seriesName27 = "liga 750_1k OD";
                Series ser27 = chartAudioOD.Series.Add(seriesName27);

                ser27.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser27.Name = seriesName27;
                ser27.ChartType = SeriesChartType.Line;

                if (liga750_1kvaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va750odComboBox.Text);
                    valorB = Convert.ToInt32(va1kodComboBox.Text);

                    ser27.Points.AddXY(7.25, valorA);
                    ser27.Points.AddXY(8, valorB);

                    ser27.BorderColor = Color.Transparent;
                    ser27.Color = Color.Red;
                    ser27.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga750_1kvaODCheckBox.Checked == false)
                {
                    ser27.Points.Clear();
                }

                //******

                string seriesName28 = "liga 1k_1,5K vaOD";
                Series ser28 = chartAudioOD.Series.Add(seriesName28);

                ser28.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser28.Name = seriesName28;
                ser28.ChartType = SeriesChartType.Line;

                if (liga1k_1_5kvaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va1kodComboBox.Text);
                    valorB = Convert.ToInt32(va1e5kodComboBox.Text);

                    ser28.Points.AddXY(8, valorA);
                    ser28.Points.AddXY(9.25, valorB);

                    ser28.BorderColor = Color.Transparent;
                    ser28.Color = Color.Red;
                    ser28.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga1k_1_5kvaODCheckBox.Checked == false)
                {
                    ser28.Points.Clear();
                }

                //******

                string seriesName29 = "liga 1,5k _ 2k vaOD";
                Series ser29 = chartAudioOD.Series.Add(seriesName29);

                ser29.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser29.Name = seriesName29;
                ser29.ChartType = SeriesChartType.Line;

                if (liga1_5k_2kvaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va1e5kodComboBox.Text);
                    valorB = Convert.ToInt32(va2kodComboBox.Text);

                    ser29.Points.AddXY(9.25, valorA);
                    ser29.Points.AddXY(10, valorB);

                    ser29.BorderColor = Color.Transparent;
                    ser29.Color = Color.Red;
                    ser29.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga1_5k_2kvaODCheckBox.Checked == false)
                {
                    ser29.Points.Clear();
                }

                //******

                string seriesName30 = "liga 2k_3k vaOD";
                Series ser30 = chartAudioOD.Series.Add(seriesName30);

                ser30.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser30.Name = seriesName30;
                ser30.ChartType = SeriesChartType.Line;

                if (liga2k_3kvaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va2kodComboBox.Text);
                    valorB = Convert.ToInt32(va3kodComboBox.Text);

                    ser30.Points.AddXY(10, valorA);
                    ser30.Points.AddXY(11.25, valorB);

                    ser30.BorderColor = Color.Transparent;
                    ser30.Color = Color.Red;
                    ser30.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga2k_3kvaODCheckBox.Checked == false)
                {
                    ser30.Points.Clear();
                }

                //******

                string seriesName31 = "liga 3k_4k vaOD";
                Series ser31 = chartAudioOD.Series.Add(seriesName31);

                ser31.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser31.Name = seriesName31;
                ser31.ChartType = SeriesChartType.Line;

                if (liga3k_4kvaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va3kodComboBox.Text);
                    valorB = Convert.ToInt32(va4kodComboBox.Text);

                    ser31.Points.AddXY(11.25, valorA);
                    ser31.Points.AddXY(12, valorB);

                    ser31.BorderColor = Color.Transparent;
                    ser31.Color = Color.Red;
                    ser31.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga3k_4kvaODCheckBox.Checked == false)
                {
                    ser31.Points.Clear();
                }

                //******

                string seriesName32 = "liga 4k_6k vaOD";
                Series ser32 = chartAudioOD.Series.Add(seriesName32);

                ser32.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser32.Name = seriesName32;
                ser32.ChartType = SeriesChartType.Line;

                if (liga4k_6kvaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va4kodComboBox.Text);
                    valorB = Convert.ToInt32(va6kodComboBox.Text);

                    ser32.Points.AddXY(12, valorA);
                    ser32.Points.AddXY(13.25, valorB);

                    ser32.BorderColor = Color.Transparent;
                    ser32.Color = Color.Red;
                    ser32.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga4k_6kvaODCheckBox.Checked == false)
                {
                    ser32.Points.Clear();
                }

                //******

                string seriesName33 = "liga 6k-8k vaOD";
                Series ser33 = chartAudioOD.Series.Add(seriesName33);

                ser33.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser33.Name = seriesName33;
                ser33.ChartType = SeriesChartType.Line;

                if (liga6k_8kvaODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va6kodComboBox.Text);
                    valorB = Convert.ToInt32(va8kodComboBox.Text);

                    ser33.Points.AddXY(13.25, valorA);
                    ser33.Points.AddXY(14, valorB);

                    ser33.BorderColor = Color.Transparent;
                    ser33.Color = Color.Red;
                    ser33.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga6k_8kvaODCheckBox.Checked == false)
                {
                    ser33.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                liga125_250vaODCheckBox.Checked = false;
                liga250_500vaODCheckBox.Checked = false;
                liga500_750vaODCheckBox.Checked = false;
                liga750_1kvaODCheckBox.Checked = false;
                liga1k_1_5kvaODCheckBox.Checked = false;
                liga1_5k_2kvaODCheckBox.Checked = false;
                liga2k_3kvaODCheckBox.Checked = false;
                liga3k_4kvaODCheckBox.Checked = false;
                liga4k_6kvaODCheckBox.Checked = false;
                liga6k_8kvaODCheckBox.Checked = false;
            }

            //*********
            //********** SIMBOLOGIA DE VO OD


            string seriesName34 = "simbol 250 voOD";
            Series ser34 = chartAudioOD.Series.Add(seriesName34);

            ser34.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser34.Name = seriesName34;
            ser34.ChartType = SeriesChartType.Point;

            if (vo250odComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            else if (vo250odComboBox.Text != "")
            {
                int valor34;
                valor34 = Convert.ToInt32(vo250odComboBox.Text);
                ser34.Points.AddXY(4, valor34);  // x, high
            }

            if ((aus250vo_ODCheckBox.Checked == false) && (masc250vo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            else if ((aus250vo_ODCheckBox.Checked == true) && (masc250vo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            else if ((aus250vo_ODCheckBox.Checked == false) && (masc250vo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            else if ((masc250vo_ODCheckBox.Checked == true) && (aus250vo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            //**********

            string seriesName35 = "simbol500 voOD";
            Series ser35 = chartAudioOD.Series.Add(seriesName35);

            ser35.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser35.Name = seriesName35;
            ser35.ChartType = SeriesChartType.Point;

            if (vo500odComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            else if (vo500odComboBox.Text != "")
            {
                int valor35;
                valor35 = Convert.ToInt32(vo500odComboBox.Text);
                ser35.Points.AddXY(6, valor35);  // x, high
            }

            if ((aus500vo_ODCheckBox.Checked == false) && (masc500vo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            else if ((aus500vo_ODCheckBox.Checked == true) && (masc500vo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            else if ((aus500vo_ODCheckBox.Checked == false) && (masc500vo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            else if ((masc500vo_ODCheckBox.Checked == true) && (aus500vo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            //********

            string seriesName36 = "simbol750 voOD";
            Series ser36 = chartAudioOD.Series.Add(seriesName36);

            ser36.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser36.Name = seriesName36;
            ser36.ChartType = SeriesChartType.Point;

            if (vo750odComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            else if (vo750odComboBox.Text != "")
            {
                int valor36;
                valor36 = Convert.ToInt32(vo750odComboBox.Text);
                ser36.Points.AddXY(7.25, valor36);  // x, high
            }

            if ((aus750vo_ODCheckBox.Checked == false) && (masc750vo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            else if ((aus750vo_ODCheckBox.Checked == true) && (masc750vo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            else if ((aus750vo_ODCheckBox.Checked == false) && (masc750vo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            else if ((masc750vo_ODCheckBox.Checked == true) && (aus750vo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName37 = "simbol1k voOD";
            Series ser37 = chartAudioOD.Series.Add(seriesName37);

            ser37.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser37.Name = seriesName37;
            ser37.ChartType = SeriesChartType.Point;

            if (vo1kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            else if (vo1kodComboBox.Text != "")
            {
                int valor37;
                valor37 = Convert.ToInt32(vo1kodComboBox.Text);
                ser37.Points.AddXY(8, valor37);  // x, high
            }

            if ((aus1kvo_ODCheckBox.Checked == false) && (masc1kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            else if ((aus1kvo_ODCheckBox.Checked == true) && (masc1kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            else if ((aus1kvo_ODCheckBox.Checked == false) && (masc1kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            else if ((masc1kvo_ODCheckBox.Checked == true) && (aus1kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            //***********

            string seriesName38 = "simbol1,5k voOD";
            Series ser38 = chartAudioOD.Series.Add(seriesName38);

            ser38.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser38.Name = seriesName38;
            ser38.ChartType = SeriesChartType.Point;

            if (vo1e5kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            else if (vo1e5kodComboBox.Text != "")
            {
                int valor38;
                valor38 = Convert.ToInt32(vo1e5kodComboBox.Text);
                ser38.Points.AddXY(9.25, valor38);  // x, high
            }

            if ((aus1_5kvo_ODCheckBox.Checked == false) && (masc1_5kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            else if ((aus1_5kvo_ODCheckBox.Checked == true) && (masc1_5kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            else if ((aus1_5kvo_ODCheckBox.Checked == false) && (masc1_5kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            else if ((masc1_5kvo_ODCheckBox.Checked == true) && (aus1_5kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            //************

            string seriesName39 = "simbol2k voOD";
            Series ser39 = chartAudioOD.Series.Add(seriesName39);

            ser39.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser39.Name = seriesName39;
            ser39.ChartType = SeriesChartType.Point;

            if (vo2kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            else if (vo2kodComboBox.Text != "")
            {
                int valor39;
                valor39 = Convert.ToInt32(vo2kodComboBox.Text);
                ser39.Points.AddXY(10, valor39);  // x, high
            }

            if ((aus2kvo_ODCheckBox.Checked == false) && (masc2kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            else if ((aus2kvo_ODCheckBox.Checked == true) && (masc2kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            else if ((aus2kvo_ODCheckBox.Checked == false) && (masc2kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            else if ((masc2kvo_ODCheckBox.Checked == true) && (aus2kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName40 = "simbol3k voOD";
            Series ser40 = chartAudioOD.Series.Add(seriesName40);

            ser40.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser40.Name = seriesName40;
            ser40.ChartType = SeriesChartType.Point;

            if (vo3kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            else if (vo3kodComboBox.Text != "")
            {
                int valor40;
                valor40 = Convert.ToInt32(vo3kodComboBox.Text);
                ser40.Points.AddXY(11.25, valor40);  // x, high
            }

            if ((aus3kvo_ODCheckBox.Checked == false) && (masc3kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            else if ((aus3kvo_ODCheckBox.Checked == true) && (masc3kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            else if ((aus3kvo_ODCheckBox.Checked == false) && (masc3kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            else if ((masc3kvo_ODCheckBox.Checked == true) && (aus3kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            //********

            string seriesName41 = "simbol4k voOD";
            Series ser41 = chartAudioOD.Series.Add(seriesName41);

            ser41.ChartArea = chartAudioOD.ChartAreas[0].Name;
            ser41.Name = seriesName41;
            ser41.ChartType = SeriesChartType.Point;

            if (vo4kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            else if (vo4kodComboBox.Text != "")
            {
                int valor41;
                valor41 = Convert.ToInt32(vo4kodComboBox.Text);
                ser41.Points.AddXY(12, valor41);  // x, high
            }

            if ((aus4kvo_ODCheckBox.Checked == false) && (masc4kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            else if ((aus4kvo_ODCheckBox.Checked == true) && (masc4kvo_ODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            else if ((aus4kvo_ODCheckBox.Checked == false) && (masc4kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            else if ((masc4kvo_ODCheckBox.Checked == true) && (aus4kvo_ODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            //********LIGAR A SIMBOLOGIA DA OD (VO)

            try
            {
                //*******

                string seriesName42 = "liga 250_500 voOD";
                Series ser42 = chartAudioOD.Series.Add(seriesName42);

                ser42.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser42.Name = seriesName42;
                ser42.ChartType = SeriesChartType.Line;

                if (liga250_500vo_ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo250odComboBox.Text);
                    valorB = Convert.ToInt32(vo500odComboBox.Text);

                    ser42.Points.AddXY(3.75, valorA);
                    ser42.Points.AddXY(5.75, valorB);

                    ser42.BorderColor = Color.Transparent;
                    ser42.Color = Color.Red;
                    ser42.BorderDashStyle = ChartDashStyle.Dash;
                    ser42.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga250_500vo_ODCheckBox.Checked == false)
                {
                    ser42.Points.Clear();
                }

                //*******

                string seriesName43 = "liga 500_750 voOD";
                Series ser43 = chartAudioOD.Series.Add(seriesName43);

                ser43.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser43.Name = seriesName43;
                ser43.ChartType = SeriesChartType.Line;

                if (liga500_750vo_ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo500odComboBox.Text);
                    valorB = Convert.ToInt32(vo750odComboBox.Text);

                    ser43.Points.AddXY(5.75, valorA);
                    ser43.Points.AddXY(7, valorB);

                    ser43.BorderColor = Color.Transparent;
                    ser43.Color = Color.Red;
                    ser43.BorderDashStyle = ChartDashStyle.Dash;
                    ser43.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga500_750vo_ODCheckBox.Checked == false)
                {
                    ser43.Points.Clear();
                }

                //******

                string seriesName44 = "liga 750_1k voOD";
                Series ser44 = chartAudioOD.Series.Add(seriesName44);

                ser44.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser44.Name = seriesName44;
                ser44.ChartType = SeriesChartType.Line;

                if (liga750_1kvo_ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo750odComboBox.Text);
                    valorB = Convert.ToInt32(vo1kodComboBox.Text);

                    ser44.Points.AddXY(7, valorA);
                    ser44.Points.AddXY(7.75, valorB);

                    ser44.BorderColor = Color.Transparent;
                    ser44.Color = Color.Red;
                    ser44.BorderDashStyle = ChartDashStyle.Dash;
                    ser44.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga750_1kvo_ODCheckBox.Checked == false)
                {
                    ser44.Points.Clear();
                }

                //******

                string seriesName45 = "liga 1k_1,5K voOD";
                Series ser45 = chartAudioOD.Series.Add(seriesName45);

                ser45.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser45.Name = seriesName45;
                ser45.ChartType = SeriesChartType.Line;

                if (liga1k_1_5kvo_ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo1kodComboBox.Text);
                    valorB = Convert.ToInt32(vo1e5kodComboBox.Text);

                    ser45.Points.AddXY(7.75, valorA);
                    ser45.Points.AddXY(9, valorB);

                    ser45.BorderColor = Color.Transparent;
                    ser45.Color = Color.Red;
                    ser45.BorderDashStyle = ChartDashStyle.Dash;
                    ser45.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga1k_1_5kvo_ODCheckBox.Checked == false)
                {
                    ser45.Points.Clear();
                }

                //******

                string seriesName46 = "liga 1,5k _ 2k voOD";
                Series ser46 = chartAudioOD.Series.Add(seriesName46);

                ser46.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser46.Name = seriesName46;
                ser46.ChartType = SeriesChartType.Line;

                if (liga1_5k_2kvo_ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo1e5kodComboBox.Text);
                    valorB = Convert.ToInt32(vo2kodComboBox.Text);

                    ser46.Points.AddXY(9, valorA);
                    ser46.Points.AddXY(9.75, valorB);

                    ser46.BorderColor = Color.Transparent;
                    ser46.Color = Color.Red;
                    ser46.BorderDashStyle = ChartDashStyle.Dash;
                    ser46.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga1_5k_2kvo_ODCheckBox.Checked == false)
                {
                    ser46.Points.Clear();
                }

                //******

                string seriesName47 = "liga 2k_3k voOD";
                Series ser47 = chartAudioOD.Series.Add(seriesName47);

                ser47.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser47.Name = seriesName47;
                ser47.ChartType = SeriesChartType.Line;

                if (liga2k_3kvo_ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo2kodComboBox.Text);
                    valorB = Convert.ToInt32(vo3kodComboBox.Text);

                    ser47.Points.AddXY(9.75, valorA);
                    ser47.Points.AddXY(11, valorB);

                    ser47.BorderColor = Color.Transparent;
                    ser47.Color = Color.Red;
                    ser47.BorderDashStyle = ChartDashStyle.Dash;
                    ser47.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga2k_3kvo_ODCheckBox.Checked == false)
                {
                    ser47.Points.Clear();
                }

                //******

                string seriesName48 = "liga 3k_4k voOD";
                Series ser48 = chartAudioOD.Series.Add(seriesName48);

                ser48.ChartArea = chartAudioOD.ChartAreas[0].Name;
                ser48.Name = seriesName48;
                ser48.ChartType = SeriesChartType.Line;

                if (liga3k_4kvo_ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo3kodComboBox.Text);
                    valorB = Convert.ToInt32(vo4kodComboBox.Text);

                    ser48.Points.AddXY(11, valorA);
                    ser48.Points.AddXY(11.75, valorB);

                    ser48.BorderColor = Color.Transparent;
                    ser48.Color = Color.Red;
                    ser48.BorderDashStyle = ChartDashStyle.Dash;
                    ser48.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga3k_4kvo_ODCheckBox.Checked == false)
                {
                    ser48.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                liga250_500vo_ODCheckBox.Checked = false;
                liga500_750vo_ODCheckBox.Checked = false;
                liga750_1kvo_ODCheckBox.Checked = false;
                liga1k_1_5kvo_ODCheckBox.Checked = false;
                liga1_5k_2kvo_ODCheckBox.Checked = false;
                liga2k_3kvo_ODCheckBox.Checked = false;
                liga3k_4kvo_ODCheckBox.Checked = false;
            }
        }

        private void PlotaDadosAudiogramaOE()
        {
            chartAudioOE.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartAudioOE.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAudioOE.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartAudioOE.Series.Add(fundoChart);

            imgFundo.ChartArea = chartAudioOE.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaOEClinica.SelectedValue == "0")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/bananaAzul.png";

                // Define o caminho virtual da imagem como imagem do marcador
                imgFundo.Points.AddXY(7.50, 45);
                imgFundo.MarkerImage = caminhoVirtual;
            }
            else if (rbBananaFalaOEClinica.SelectedValue == "1")
            {
                chartAudioOE.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1OE";
            Series ser1 = chartAudioOE.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2OE";
            Series ser2 = chartAudioOE.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3OE";
            Series ser3 = chartAudioOE.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4OE";
            Series ser4 = chartAudioOE.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5OE";
            Series ser5 = chartAudioOE.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6OE";
            Series ser6 = chartAudioOE.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7OE";
            Series ser7 = chartAudioOE.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8OE";
            Series ser7a = chartAudioOE.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9OE";
            Series ser9a = chartAudioOE.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10OE";
            Series ser10a = chartAudioOE.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11OE";
            Series ser11a = chartAudioOE.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12OE";
            Series ser12a = chartAudioOE.Series.Add(seriesName12a);

            ser12a.IsVisibleInLegend = false;
            ser12a.ChartType = SeriesChartType.Line;

            ser12a.BorderWidth = 1;
            ser12a.Color = Color.Black;
            ser12a.MarkerStyle = MarkerStyle.None;
            ser12a.Points.AddXY(15, -10);  // x, high
            ser12a.Points.AddXY(15, 120);

            //***SIMBOLOGIA DE VA DA OE

            string seriesName13 = "simbol125";
            Series ser13 = chartAudioOE.Series.Add(seriesName13);

            ser13.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser13.Name = seriesName13;
            ser13.ChartType = SeriesChartType.Point;

            if (va125oeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if (va125oeComboBox.Text != "")
            {
                int valor13;
                valor13 = Convert.ToInt32(va125oeComboBox.Text);
                ser13.Points.AddXY(2, valor13);  // x, high
            }

            if ((aus125vaOECheckBox.Checked == false) && (masc125vaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((aus125vaOECheckBox.Checked == true) && (masc125vaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((aus125vaOECheckBox.Checked == false) && (masc125vaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((masc125vaOECheckBox.Checked == true) && (aus125vaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName14 = "simbol250";
            Series ser14 = chartAudioOE.Series.Add(seriesName14);

            ser14.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser14.Name = seriesName14;
            ser14.ChartType = SeriesChartType.Point;

            if (va250oeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if (va250oeComboBox.Text != "")
            {
                int valor14;
                valor14 = Convert.ToInt32(va250oeComboBox.Text);
                ser14.Points.AddXY(4, valor14);  // x, high
            }

            if ((aus250vaOECheckBox.Checked == false) && (masc250vaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((aus250vaOECheckBox.Checked == true) && (masc250vaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((aus250vaOECheckBox.Checked == false) && (masc250vaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((masc250vaOECheckBox.Checked == true) && (aus250vaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            //**********

            string seriesName15 = "simbol500";
            Series ser15 = chartAudioOE.Series.Add(seriesName15);

            ser15.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser15.Name = seriesName15;
            ser15.ChartType = SeriesChartType.Point;

            if (va500oeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if (va500oeComboBox.Text != "")
            {
                int valor15;
                valor15 = Convert.ToInt32(va500oeComboBox.Text);
                ser15.Points.AddXY(6, valor15);  // x, high
            }

            if ((aus500vaOECheckBox.Checked == false) && (masc500vaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if ((aus500vaOECheckBox.Checked == true) && (masc500vaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if ((aus500vaOECheckBox.Checked == false) && (masc500vaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if ((masc500vaOECheckBox.Checked == true) && (aus500vaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            //********

            string seriesName16 = "simbol750";
            Series ser16 = chartAudioOE.Series.Add(seriesName16);

            ser16.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser16.Name = seriesName16;
            ser16.ChartType = SeriesChartType.Point;

            if (va750oeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if (va750oeComboBox.Text != "")
            {
                int valor16;
                valor16 = Convert.ToInt32(va750oeComboBox.Text);
                ser16.Points.AddXY(7.25, valor16);  // x, high
            }

            if ((aus750vaOECheckBox.Checked == false) && (masc750vaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if ((aus750vaOECheckBox.Checked == true) && (masc750vaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if ((aus750vaOECheckBox.Checked == false) && (masc750vaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if ((masc750vaOECheckBox.Checked == true) && (aus750vaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName17 = "simbol1k";
            Series ser17 = chartAudioOE.Series.Add(seriesName17);

            ser17.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser17.Name = seriesName17;
            ser17.ChartType = SeriesChartType.Point;

            if (va1koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if (va1koeComboBox.Text != "")
            {
                int valor17;
                valor17 = Convert.ToInt32(va1koeComboBox.Text);
                ser17.Points.AddXY(8, valor17);  // x, high
            }

            if ((aus1kvaOECheckBox.Checked == false) && (masc1kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if ((aus1kvaOECheckBox.Checked == true) && (masc1kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if ((aus1kvaOECheckBox.Checked == false) && (masc1kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if ((masc1kvaOECheckBox.Checked == true) && (aus1kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            //***********

            string seriesName18 = "simbol1,5k";
            Series ser18 = chartAudioOE.Series.Add(seriesName18);

            ser18.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser18.Name = seriesName18;
            ser18.ChartType = SeriesChartType.Point;

            if (va1e5koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if (va1e5koeComboBox.Text != "")
            {
                int valor18;
                valor18 = Convert.ToInt32(va1e5koeComboBox.Text);
                ser18.Points.AddXY(9.25, valor18);  // x, high
            }

            if ((aus1_5kvaOECheckBox.Checked == false) && (masc1_5kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if ((aus1_5kvaOECheckBox.Checked == true) && (masc1_5kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if ((aus1_5kvaOECheckBox.Checked == false) && (masc1_5kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if ((masc1_5kvaOECheckBox.Checked == true) && (aus1_5kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            //************

            string seriesName19 = "simbol2k";
            Series ser19 = chartAudioOE.Series.Add(seriesName19);

            ser19.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser19.Name = seriesName19;
            ser19.ChartType = SeriesChartType.Point;

            if (va2koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if (va2koeComboBox.Text != "")
            {
                int valor19;
                valor19 = Convert.ToInt32(va2koeComboBox.Text);
                ser19.Points.AddXY(10, valor19);  // x, high
            }

            if ((aus2kvaOECheckBox.Checked == false) && (masc2kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if ((aus2kvaOECheckBox.Checked == true) && (masc2kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if ((aus2kvaOECheckBox.Checked == false) && (masc2kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if ((masc2kvaOECheckBox.Checked == true) && (aus2kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName20 = "simbol3k";
            Series ser20 = chartAudioOE.Series.Add(seriesName20);

            ser20.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser20.Name = seriesName20;
            ser20.ChartType = SeriesChartType.Point;

            if (va3koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if (va3koeComboBox.Text != "")
            {
                int valor20;
                valor20 = Convert.ToInt32(va3koeComboBox.Text);
                ser20.Points.AddXY(11.25, valor20);  // x, high
            }

            if ((aus3kvaOECheckBox.Checked == false) && (masc3kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if ((aus3kvaOECheckBox.Checked == true) && (masc3kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if ((aus3kvaOECheckBox.Checked == false) && (masc3kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if ((masc3kvaOECheckBox.Checked == true) && (aus3kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            //********

            string seriesName21 = "simbol4k";
            Series ser21 = chartAudioOE.Series.Add(seriesName21);

            ser21.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser21.Name = seriesName21;
            ser21.ChartType = SeriesChartType.Point;

            if (va4koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if (va4koeComboBox.Text != "")
            {
                int valor21;
                valor21 = Convert.ToInt32(va4koeComboBox.Text);
                ser21.Points.AddXY(12, valor21);  // x, high
            }

            if ((aus4kvaOECheckBox.Checked == false) && (masc4kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if ((aus4kvaOECheckBox.Checked == true) && (masc4kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if ((aus4kvaOECheckBox.Checked == false) && (masc4kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if ((masc4kvaOECheckBox.Checked == true) && (aus4kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            //**********

            string seriesName22 = "simbol6k";
            Series ser22 = chartAudioOE.Series.Add(seriesName22);

            ser22.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser22.Name = seriesName22;
            ser22.ChartType = SeriesChartType.Point;

            if (va6koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if (va6koeComboBox.Text != "")
            {
                int valor22;
                valor22 = Convert.ToInt32(va6koeComboBox.Text);
                ser22.Points.AddXY(13.25, valor22);  // x, high
            }

            if ((aus6kvaOECheckBox.Checked == false) && (masc6kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if ((aus6kvaOECheckBox.Checked == true) && (masc6kvaOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if ((aus6kvaOECheckBox.Checked == false) && (masc6kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if ((masc6kvaOECheckBox.Checked == true) && (aus6kvaOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            //***********

            string seriesName23 = "simbol8k";
            Series ser23 = chartAudioOE.Series.Add(seriesName23);

            ser23.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser23.Name = seriesName23;
            ser23.ChartType = SeriesChartType.Point;

            if (va8koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser23.MarkerImage = caminhoVirtual;
            }

            else if (va8koeComboBox.Text != "")
            {
                int valor23;
                valor23 = Convert.ToInt32(va8koeComboBox.Text);
                ser23.Points.AddXY(14, valor23);  // x, high

                if ((aus8kvaOECheckBox.Checked == false) && (masc8kvaOECheckBox.Checked == false))
                {
                    // Caminho virtual da imagem (relativo à raiz do projeto)
                    string caminhoVirtual = "~/Images/vaOEpresente.png";

                    // Define o caminho virtual da imagem como imagem do marcador
                    ser23.MarkerImage = caminhoVirtual;
                }

                else if ((aus8kvaOECheckBox.Checked == true) && (masc8kvaOECheckBox.Checked == false))
                {
                    // Caminho virtual da imagem (relativo à raiz do projeto)
                    string caminhoVirtual = "~/Images/vaOEausente.png";

                    // Define o caminho virtual da imagem como imagem do marcador
                    ser23.MarkerImage = caminhoVirtual;
                }

                else if ((aus8kvaOECheckBox.Checked == false) && (masc8kvaOECheckBox.Checked == true))
                {
                    // Caminho virtual da imagem (relativo à raiz do projeto)
                    string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                    // Define o caminho virtual da imagem como imagem do marcador
                    ser23.MarkerImage = caminhoVirtual;
                }

                else if ((masc8kvaOECheckBox.Checked == true) && (aus8kvaOECheckBox.Checked == true))
                {
                    // Caminho virtual da imagem (relativo à raiz do projeto)
                    string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                    // Define o caminho virtual da imagem como imagem do marcador
                    ser23.MarkerImage = caminhoVirtual;
                }
            }

            //********LIGAR A SIMBOLOGIA DA OE

            try
            {

                string seriesName24 = "liga 125_ 250 vaOE";
                Series ser24 = chartAudioOE.Series.Add(seriesName24);

                ser24.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser24.Name = seriesName24;
                ser24.ChartType = SeriesChartType.Line;

                if (liga125_250vaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va125oeComboBox.Text);
                    valorB = Convert.ToInt32(va250oeComboBox.Text);

                    ser24.Points.AddXY(2, valorA);
                    ser24.Points.AddXY(4, valorB);

                    ser24.BorderColor = Color.Transparent;
                    ser24.Color = Color.DodgerBlue;
                    ser24.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga125_250vaOECheckBox.Checked == false)
                {
                    ser24.Points.Clear();
                }

                //*******

                string seriesName25 = "liga 250_500 vaOE";
                Series ser25 = chartAudioOE.Series.Add(seriesName25);

                ser25.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser25.Name = seriesName25;
                ser25.ChartType = SeriesChartType.Line;

                if (liga250_500vaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va250oeComboBox.Text);
                    valorB = Convert.ToInt32(va500oeComboBox.Text);

                    ser25.Points.AddXY(4, valorA);
                    ser25.Points.AddXY(6, valorB);

                    ser25.BorderColor = Color.Transparent;
                    ser25.Color = Color.DodgerBlue;
                    ser25.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga250_500vaOECheckBox.Checked == false)
                {
                    ser25.Points.Clear();
                }

                //*******

                string seriesName26 = "liga 500_750 vaOE";
                Series ser26 = chartAudioOE.Series.Add(seriesName26);

                ser26.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser26.Name = seriesName26;
                ser26.ChartType = SeriesChartType.Line;

                if (liga500_750vaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va500oeComboBox.Text);
                    valorB = Convert.ToInt32(va750oeComboBox.Text);

                    ser26.Points.AddXY(6, valorA);
                    ser26.Points.AddXY(7.25, valorB);

                    ser26.BorderColor = Color.Transparent;
                    ser26.Color = Color.DodgerBlue;
                    ser26.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga500_750vaOECheckBox.Checked == false)
                {
                    ser26.Points.Clear();
                }

                //******

                string seriesName27 = "liga 750_1k OE";
                Series ser27 = chartAudioOE.Series.Add(seriesName27);

                ser27.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser27.Name = seriesName27;
                ser27.ChartType = SeriesChartType.Line;

                if (liga750_1kvaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va750oeComboBox.Text);
                    valorB = Convert.ToInt32(va1koeComboBox.Text);

                    ser27.Points.AddXY(7.25, valorA);
                    ser27.Points.AddXY(8, valorB);

                    ser27.BorderColor = Color.Transparent;
                    ser27.Color = Color.DodgerBlue;
                    ser27.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga750_1kvaOECheckBox.Checked == false)
                {
                    ser27.Points.Clear();
                }

                //******

                string seriesName28 = "liga 1k_1,5K vaOE";
                Series ser28 = chartAudioOE.Series.Add(seriesName28);

                ser28.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser28.Name = seriesName28;
                ser28.ChartType = SeriesChartType.Line;

                if (liga1k_1_5kvaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va1koeComboBox.Text);
                    valorB = Convert.ToInt32(va1e5koeComboBox.Text);

                    ser28.Points.AddXY(8, valorA);
                    ser28.Points.AddXY(9.25, valorB);

                    ser28.BorderColor = Color.Transparent;
                    ser28.Color = Color.DodgerBlue;
                    ser28.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga1k_1_5kvaOECheckBox.Checked == false)
                {
                    ser28.Points.Clear();
                }

                //******

                string seriesName29 = "liga 1,5k _ 2k vaOE";
                Series ser29 = chartAudioOE.Series.Add(seriesName29);

                ser29.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser29.Name = seriesName29;
                ser29.ChartType = SeriesChartType.Line;

                if (liga1_5k_2kvaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va1e5koeComboBox.Text);
                    valorB = Convert.ToInt32(va2koeComboBox.Text);

                    ser29.Points.AddXY(9.25, valorA);
                    ser29.Points.AddXY(10, valorB);

                    ser29.BorderColor = Color.Transparent;
                    ser29.Color = Color.DodgerBlue;
                    ser29.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga1_5k_2kvaOECheckBox.Checked == false)
                {
                    ser29.Points.Clear();
                }

                //******

                string seriesName30 = "liga 2k_3k vaOE";
                Series ser30 = chartAudioOE.Series.Add(seriesName30);

                ser30.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser30.Name = seriesName30;
                ser30.ChartType = SeriesChartType.Line;

                if (liga2k_3kvaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va2koeComboBox.Text);
                    valorB = Convert.ToInt32(va3koeComboBox.Text);

                    ser30.Points.AddXY(10, valorA);
                    ser30.Points.AddXY(11.25, valorB);

                    ser30.BorderColor = Color.Transparent;
                    ser30.Color = Color.DodgerBlue;
                    ser30.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga2k_3kvaOECheckBox.Checked == false)
                {
                    ser30.Points.Clear();
                }

                //******

                string seriesName31 = "liga 3k_4k vaOE";
                Series ser31 = chartAudioOE.Series.Add(seriesName31);

                ser31.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser31.Name = seriesName31;
                ser31.ChartType = SeriesChartType.Line;

                if (liga3k_4kvaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va3koeComboBox.Text);
                    valorB = Convert.ToInt32(va4koeComboBox.Text);

                    ser31.Points.AddXY(11.25, valorA);
                    ser31.Points.AddXY(12, valorB);

                    ser31.BorderColor = Color.Transparent;
                    ser31.Color = Color.DodgerBlue;
                    ser31.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga3k_4kvaOECheckBox.Checked == false)
                {
                    ser31.Points.Clear();
                }

                //******

                string seriesName32 = "liga 4k_6k vaOE";
                Series ser32 = chartAudioOE.Series.Add(seriesName32);

                ser32.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser32.Name = seriesName32;
                ser32.ChartType = SeriesChartType.Line;

                if (liga4k_6kvaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va4koeComboBox.Text);
                    valorB = Convert.ToInt32(va6koeComboBox.Text);

                    ser32.Points.AddXY(12, valorA);
                    ser32.Points.AddXY(13.25, valorB);

                    ser32.BorderColor = Color.Transparent;
                    ser32.Color = Color.DodgerBlue;
                    ser32.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga4k_6kvaODCheckBox.Checked == false)
                {
                    ser32.Points.Clear();
                }

                //******

                string seriesName33 = "liga 6k-8k vaOE";
                Series ser33 = chartAudioOE.Series.Add(seriesName33);

                ser33.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser33.Name = seriesName33;
                ser33.ChartType = SeriesChartType.Line;

                if (liga6k_8kvaOECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va6koeComboBox.Text);
                    valorB = Convert.ToInt32(va8koeComboBox.Text);

                    ser33.Points.AddXY(13.25, valorA);
                    ser33.Points.AddXY(14, valorB);

                    ser33.BorderColor = Color.Transparent;
                    ser33.Color = Color.DodgerBlue;
                    ser33.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga6k_8kvaOECheckBox.Checked == false)
                {
                    ser33.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                liga125_250vaOECheckBox.Checked = false;
                liga250_500vaOECheckBox.Checked = false;
                liga500_750vaOECheckBox.Checked = false;
                liga750_1kvaOECheckBox.Checked = false;
                liga1k_1_5kvaOECheckBox.Checked = false;
                liga1_5k_2kvaOECheckBox.Checked = false;
                liga2k_3kvaOECheckBox.Checked = false;
                liga3k_4kvaOECheckBox.Checked = false;
                liga4k_6kvaOECheckBox.Checked = false;
                liga6k_8kvaOECheckBox.Checked = false;
            }

            //*********
            //********** SIMBOLOGIA DE VO OE


            string seriesName34 = "simbol 250 voOE";
            Series ser34 = chartAudioOE.Series.Add(seriesName34);

            ser34.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser34.Name = seriesName34;
            ser34.ChartType = SeriesChartType.Point;

            if (vo250oeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            else if (vo250oeComboBox.Text != "")
            {
                int valor34;
                valor34 = Convert.ToInt32(vo250oeComboBox.Text);
                ser34.Points.AddXY(4, valor34);  // x, high
            }

            if ((aus250vo_OECheckBox.Checked == false) && (masc250vo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            else if ((aus250vo_OECheckBox.Checked == true) && (masc250vo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            else if ((aus250vo_OECheckBox.Checked == false) && (masc250vo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            else if ((masc250vo_OECheckBox.Checked == true) && (aus250vo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser34.MarkerImage = caminhoVirtual;
            }

            //**********

            string seriesName35 = "simbol500 voOE";
            Series ser35 = chartAudioOE.Series.Add(seriesName35);

            ser35.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser35.Name = seriesName35;
            ser35.ChartType = SeriesChartType.Point;

            if (vo500oeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            else if (vo500oeComboBox.Text != "")
            {
                int valor35;
                valor35 = Convert.ToInt32(vo500oeComboBox.Text);
                ser35.Points.AddXY(6, valor35);  // x, high
            }

            if ((aus500vo_OECheckBox.Checked == false) && (masc500vo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            else if ((aus500vo_OECheckBox.Checked == true) && (masc500vo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            else if ((aus500vo_OECheckBox.Checked == false) && (masc500vo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            else if ((masc500vo_OECheckBox.Checked == true) && (aus500vo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser35.MarkerImage = caminhoVirtual;
            }

            //********

            string seriesName36 = "simbol750 voOE";
            Series ser36 = chartAudioOE.Series.Add(seriesName36);

            ser36.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser36.Name = seriesName36;
            ser36.ChartType = SeriesChartType.Point;

            if (vo750oeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            else if (vo750oeComboBox.Text != "")
            {
                int valor36;
                valor36 = Convert.ToInt32(vo750oeComboBox.Text);
                ser36.Points.AddXY(7.25, valor36);  // x, high
            }

            if ((aus750vo_OECheckBox.Checked == false) && (masc750vo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            else if ((aus750vo_OECheckBox.Checked == true) && (masc750vo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            else if ((aus750vo_OECheckBox.Checked == false) && (masc750vo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            else if ((masc750vo_OECheckBox.Checked == true) && (aus750vo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser36.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName37 = "simbol1k voOE";
            Series ser37 = chartAudioOE.Series.Add(seriesName37);

            ser37.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser37.Name = seriesName37;
            ser37.ChartType = SeriesChartType.Point;

            if (vo1koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            else if (vo1koeComboBox.Text != "")
            {
                int valor37;
                valor37 = Convert.ToInt32(vo1koeComboBox.Text);
                ser37.Points.AddXY(8, valor37);  // x, high
            }

            if ((aus1kvo_OECheckBox.Checked == false) && (masc1kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            else if ((aus1kvo_OECheckBox.Checked == true) && (masc1kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            else if ((aus1kvo_OECheckBox.Checked == false) && (masc1kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            else if ((masc1kvo_OECheckBox.Checked == true) && (aus1kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser37.MarkerImage = caminhoVirtual;
            }

            //***********

            string seriesName38 = "simbol1,5k voOE";
            Series ser38 = chartAudioOE.Series.Add(seriesName38);

            ser38.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser38.Name = seriesName38;
            ser38.ChartType = SeriesChartType.Point;

            if (vo1e5koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            else if (vo1e5koeComboBox.Text != "")
            {
                int valor38;
                valor38 = Convert.ToInt32(vo1e5koeComboBox.Text);
                ser38.Points.AddXY(9.25, valor38);  // x, high
            }

            if ((aus1_5kvo_OECheckBox.Checked == false) && (masc1_5kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            else if ((aus1_5kvo_OECheckBox.Checked == true) && (masc1_5kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            else if ((aus1_5kvo_OECheckBox.Checked == false) && (masc1_5kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            else if ((masc1_5kvo_OECheckBox.Checked == true) && (aus1_5kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser38.MarkerImage = caminhoVirtual;
            }

            //************

            string seriesName39 = "simbol2k voOE";
            Series ser39 = chartAudioOE.Series.Add(seriesName39);

            ser39.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser39.Name = seriesName39;
            ser39.ChartType = SeriesChartType.Point;

            if (vo2koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            else if (vo2koeComboBox.Text != "")
            {
                int valor39;
                valor39 = Convert.ToInt32(vo2koeComboBox.Text);
                ser39.Points.AddXY(10, valor39);  // x, high
            }

            if ((aus2kvo_OECheckBox.Checked == false) && (masc2kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            else if ((aus2kvo_OECheckBox.Checked == true) && (masc2kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            else if ((aus2kvo_OECheckBox.Checked == false) && (masc2kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            else if ((masc2kvo_OECheckBox.Checked == true) && (aus2kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser39.MarkerImage = caminhoVirtual;
            }

            //*********

            string seriesName40 = "simbol3k voOE";
            Series ser40 = chartAudioOE.Series.Add(seriesName40);

            ser40.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser40.Name = seriesName40;
            ser40.ChartType = SeriesChartType.Point;

            if (vo3koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            else if (vo3koeComboBox.Text != "")
            {
                int valor40;
                valor40 = Convert.ToInt32(vo3koeComboBox.Text);
                ser40.Points.AddXY(11.25, valor40);  // x, high
            }

            if ((aus3kvo_OECheckBox.Checked == false) && (masc3kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            else if ((aus3kvo_OECheckBox.Checked == true) && (masc3kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            else if ((aus3kvo_OECheckBox.Checked == false) && (masc3kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            else if ((masc3kvo_OECheckBox.Checked == true) && (aus3kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser40.MarkerImage = caminhoVirtual;
            }

            //********

            string seriesName41 = "simbol4k voOE";
            Series ser41 = chartAudioOE.Series.Add(seriesName41);

            ser41.ChartArea = chartAudioOE.ChartAreas[0].Name;
            ser41.Name = seriesName41;
            ser41.ChartType = SeriesChartType.Point;

            if (vo4koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            else if (vo4koeComboBox.Text != "")
            {
                int valor41;
                valor41 = Convert.ToInt32(vo4koeComboBox.Text);
                ser41.Points.AddXY(12, valor41);  // x, high
            }

            if ((aus4kvo_OECheckBox.Checked == false) && (masc4kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            else if ((aus4kvo_OECheckBox.Checked == true) && (masc4kvo_OECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            else if ((aus4kvo_OECheckBox.Checked == false) && (masc4kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            else if ((masc4kvo_OECheckBox.Checked == true) && (aus4kvo_OECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/voOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser41.MarkerImage = caminhoVirtual;
            }

            //********LIGAR A SIMBOLOGIA DA OE (VO)

            try
            {
                //*******

                string seriesName42 = "liga 250_500 voOE";
                Series ser42 = chartAudioOE.Series.Add(seriesName42);

                ser42.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser42.Name = seriesName42;
                ser42.ChartType = SeriesChartType.Line;

                if (liga250_500vo_OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo250oeComboBox.Text);
                    valorB = Convert.ToInt32(vo500oeComboBox.Text);

                    ser42.Points.AddXY(4.25, valorA);
                    ser42.Points.AddXY(6.25, valorB);

                    ser42.BorderColor = Color.Transparent;
                    ser42.Color = Color.DodgerBlue;
                    ser42.BorderDashStyle = ChartDashStyle.Dash;
                    ser42.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga250_500vo_OECheckBox.Checked == false)
                {
                    ser42.Points.Clear();
                }

                //*******

                string seriesName43 = "liga 500_750 voOE";
                Series ser43 = chartAudioOE.Series.Add(seriesName43);

                ser43.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser43.Name = seriesName43;
                ser43.ChartType = SeriesChartType.Line;

                if (liga500_750vo_OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo500oeComboBox.Text);
                    valorB = Convert.ToInt32(vo750oeComboBox.Text);

                    ser43.Points.AddXY(6.25, valorA);
                    ser43.Points.AddXY(7.50, valorB);

                    ser43.BorderColor = Color.Transparent;
                    ser43.Color = Color.DodgerBlue;
                    ser43.BorderDashStyle = ChartDashStyle.Dash;
                    ser43.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga500_750vo_OECheckBox.Checked == false)
                {
                    ser43.Points.Clear();
                }

                //******

                string seriesName44 = "liga 750_1k voOE";
                Series ser44 = chartAudioOE.Series.Add(seriesName44);

                ser44.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser44.Name = seriesName44;
                ser44.ChartType = SeriesChartType.Line;

                if (liga750_1kvo_OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo750oeComboBox.Text);
                    valorB = Convert.ToInt32(vo1koeComboBox.Text);

                    ser44.Points.AddXY(7.50, valorA);
                    ser44.Points.AddXY(8.25, valorB);

                    ser44.BorderColor = Color.Transparent;
                    ser44.Color = Color.DodgerBlue;
                    ser44.BorderDashStyle = ChartDashStyle.Dash;
                    ser44.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga750_1kvo_OECheckBox.Checked == false)
                {
                    ser44.Points.Clear();
                }

                //******

                string seriesName45 = "liga 1k_1,5K voOE";
                Series ser45 = chartAudioOE.Series.Add(seriesName45);

                ser45.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser45.Name = seriesName45;
                ser45.ChartType = SeriesChartType.Line;

                if (liga1k_1_5kvo_OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo1koeComboBox.Text);
                    valorB = Convert.ToInt32(vo1e5koeComboBox.Text);

                    ser45.Points.AddXY(8.25, valorA);
                    ser45.Points.AddXY(9.50, valorB);

                    ser45.BorderColor = Color.Transparent;
                    ser45.Color = Color.DodgerBlue;
                    ser45.BorderDashStyle = ChartDashStyle.Dash;
                    ser45.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga1k_1_5kvo_OECheckBox.Checked == false)
                {
                    ser45.Points.Clear();
                }

                //******

                string seriesName46 = "liga 1,5k _ 2k voOE";
                Series ser46 = chartAudioOE.Series.Add(seriesName46);

                ser46.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser46.Name = seriesName46;
                ser46.ChartType = SeriesChartType.Line;

                if (liga1_5k_2kvo_OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo1e5koeComboBox.Text);
                    valorB = Convert.ToInt32(vo2koeComboBox.Text);

                    ser46.Points.AddXY(9.50, valorA);
                    ser46.Points.AddXY(10.25, valorB);

                    ser46.BorderColor = Color.Transparent;
                    ser46.Color = Color.DodgerBlue;
                    ser46.BorderDashStyle = ChartDashStyle.Dash;
                    ser46.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga1_5k_2kvo_OECheckBox.Checked == false)
                {
                    ser46.Points.Clear();
                }

                //******

                string seriesName47 = "liga 2k_3k voOE";
                Series ser47 = chartAudioOE.Series.Add(seriesName47);

                ser47.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser47.Name = seriesName47;
                ser47.ChartType = SeriesChartType.Line;

                if (liga2k_3kvo_OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo2koeComboBox.Text);
                    valorB = Convert.ToInt32(vo3koeComboBox.Text);

                    ser47.Points.AddXY(10.25, valorA);
                    ser47.Points.AddXY(11.50, valorB);

                    ser47.BorderColor = Color.Transparent;
                    ser47.Color = Color.DodgerBlue;
                    ser47.BorderDashStyle = ChartDashStyle.Dash;
                    ser47.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga2k_3kvo_OECheckBox.Checked == false)
                {
                    ser47.Points.Clear();
                }

                //******

                string seriesName48 = "liga 3k_4k voOE";
                Series ser48 = chartAudioOE.Series.Add(seriesName48);

                ser48.ChartArea = chartAudioOE.ChartAreas[0].Name;
                ser48.Name = seriesName48;
                ser48.ChartType = SeriesChartType.Line;

                if (liga3k_4kvo_OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(vo3koeComboBox.Text);
                    valorB = Convert.ToInt32(vo4koeComboBox.Text);

                    ser48.Points.AddXY(11.50, valorA);
                    ser48.Points.AddXY(12.25, valorB);

                    ser48.BorderColor = Color.Transparent;
                    ser48.Color = Color.DodgerBlue;
                    ser48.BorderDashStyle = ChartDashStyle.Dash;
                    ser48.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (liga3k_4kvo_OECheckBox.Checked == false)
                {
                    ser48.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                liga250_500vo_OECheckBox.Checked = false;
                liga500_750vo_OECheckBox.Checked = false;
                liga750_1kvo_OECheckBox.Checked = false;
                liga1k_1_5kvo_OECheckBox.Checked = false;
                liga1_5k_2kvo_OECheckBox.Checked = false;
                liga2k_3kvo_OECheckBox.Checked = false;
                liga3k_4kvo_OECheckBox.Checked = false;
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
            va125odComboBox.DataSource = DropdownData_VA.GetItems();//125Hz
            va125odComboBox.DataBind();

            va250odComboBox.DataSource = DropdownData_VA.GetItems();//250Hz
            va250odComboBox.DataBind();

            va500odComboBox.DataSource = DropdownData_VA.GetItems();//500Hz
            va500odComboBox.DataBind();

            va750odComboBox.DataSource = DropdownData_VA.GetItems();//750Hz
            va750odComboBox.DataBind();

            va1kodComboBox.DataSource = DropdownData_VA.GetItems();//1kHz
            va1kodComboBox.DataBind();

            va1e5kodComboBox.DataSource = DropdownData_VA.GetItems();//1,5kHz
            va1e5kodComboBox.DataBind();

            va2kodComboBox.DataSource = DropdownData_VA.GetItems();//2kHz
            va2kodComboBox.DataBind();

            va3kodComboBox.DataSource = DropdownData_VA.GetItems();//3kHz
            va3kodComboBox.DataBind();

            va4kodComboBox.DataSource = DropdownData_VA.GetItems();//4kHz
            va4kodComboBox.DataBind();

            va6kodComboBox.DataSource = DropdownData_VA.GetItems();//6kHz
            va6kodComboBox.DataBind();

            va8kodComboBox.DataSource = DropdownData_VA.GetItems();//8kHz
            va8kodComboBox.DataBind();

            //VO
            vo250odComboBox.DataSource = DropdownData_VO.GetItems();//250Hz
            vo250odComboBox.DataBind();

            vo500odComboBox.DataSource = DropdownData_VO.GetItems();//500Hz
            vo500odComboBox.DataBind();

            vo750odComboBox.DataSource = DropdownData_VO.GetItems();//750Hz
            vo750odComboBox.DataBind();

            vo1kodComboBox.DataSource = DropdownData_VO.GetItems();//1kHz
            vo1kodComboBox.DataBind();

            vo1e5kodComboBox.DataSource = DropdownData_VO.GetItems();//1,5kHz
            vo1e5kodComboBox.DataBind();

            vo2kodComboBox.DataSource = DropdownData_VO.GetItems();//2kHz
            vo2kodComboBox.DataBind();

            vo3kodComboBox.DataSource = DropdownData_VO.GetItems();//3kHz
            vo3kodComboBox.DataBind();

            vo4kodComboBox.DataSource = DropdownData_VO.GetItems();//4kHz
            vo4kodComboBox.DataBind();

            //para OE ######################################################
            //VA
            va125oeComboBox.DataSource = DropdownData_VA.GetItems();//125Hz
            va125oeComboBox.DataBind();

            va250oeComboBox.DataSource = DropdownData_VA.GetItems();//250Hz
            va250oeComboBox.DataBind();

            va500oeComboBox.DataSource = DropdownData_VA.GetItems();//500Hz
            va500oeComboBox.DataBind();

            va750oeComboBox.DataSource = DropdownData_VA.GetItems();//750Hz
            va750oeComboBox.DataBind();

            va1koeComboBox.DataSource = DropdownData_VA.GetItems();//1kHz
            va1koeComboBox.DataBind();

            va1e5koeComboBox.DataSource = DropdownData_VA.GetItems();//1,5kHz
            va1e5koeComboBox.DataBind();

            va2koeComboBox.DataSource = DropdownData_VA.GetItems();//2kHz
            va2koeComboBox.DataBind();

            va3koeComboBox.DataSource = DropdownData_VA.GetItems();//3kHz
            va3koeComboBox.DataBind();

            va4koeComboBox.DataSource = DropdownData_VA.GetItems();//4kHz
            va4koeComboBox.DataBind();

            va6koeComboBox.DataSource = DropdownData_VA.GetItems();//6kHz
            va6koeComboBox.DataBind();

            va8koeComboBox.DataSource = DropdownData_VA.GetItems();//8kHz
            va8koeComboBox.DataBind();

            //VO
            vo250oeComboBox.DataSource = DropdownData_VO.GetItems();//250Hz
            vo250oeComboBox.DataBind();

            vo500oeComboBox.DataSource = DropdownData_VO.GetItems();//500Hz
            vo500oeComboBox.DataBind();

            vo750oeComboBox.DataSource = DropdownData_VO.GetItems();//750Hz
            vo750oeComboBox.DataBind();

            vo1koeComboBox.DataSource = DropdownData_VO.GetItems();//1kHz
            vo1koeComboBox.DataBind();

            vo1e5koeComboBox.DataSource = DropdownData_VO.GetItems();//1,5kHz
            vo1e5koeComboBox.DataBind();

            vo2koeComboBox.DataSource = DropdownData_VO.GetItems();//2kHz
            vo2koeComboBox.DataBind();

            vo3koeComboBox.DataSource = DropdownData_VO.GetItems();//3kHz
            vo3koeComboBox.DataBind();

            vo4koeComboBox.DataSource = DropdownData_VO.GetItems();//4kHz
            vo4koeComboBox.DataBind();
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

        private void CarregaTesteWeber()
        {
            //para 500Hz
            weber500ComboBox.DataSource = DropdownData_TesteWeber.GetItems();
            weber500ComboBox.DataBind();

            //para 1kHz
            weber1kComboBox.DataSource = DropdownData_TesteWeber.GetItems();
            weber1kComboBox.DataBind();
            
            //para 2kHz
            weber2kComboBox.DataSource = DropdownData_TesteWeber.GetItems();
            weber2kComboBox.DataBind();
            
            //para 4kHz
            weber4kComboBox.DataSource = DropdownData_TesteWeber.GetItems();
            weber4kComboBox.DataBind();
        }

        private void CalculaMediaTritonal()
        { 
            //Para a OD #############################################
            try//no bloco de tratamento de erros
            {
                mEDIAodTextBox.Text = "";//limpa o txt média tritonal 

                if ((va500odComboBox.Text == "") || (va1kodComboBox.Text == "") || (va2kodComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média tritonal de 500Hz, 1kHz e 2kHZ da OD.');", true);
                }

                else//do contrário
                {
                    if ((aus500vaODCheckBox.Checked == true) || (aus1kvaODCheckBox.Checked == true) || (aus2kvaODCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        mEDIAodTextBox.Text = "Saída máxima";//atritui a frase à txt média
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, resultado;

                        valor1 = Convert.ToInt32(va500odComboBox.Text);
                        valor2 = Convert.ToInt32(va1kodComboBox.Text);
                        valor3 = Convert.ToInt32(va2kodComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3) / 3);

                        mEDIAodTextBox.Text = Convert.ToString(resultado);
                        lblMediaOD.Text = "Média Tritonal (dBNA):";
                    }
                }

                //Para a OE #######################################
                mEDIAoeTextBox.Text = "";//limpa o txt média tritonal 

                if ((va500oeComboBox.Text == "") || (va1koeComboBox.Text == "") || (va2koeComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média tritonal de 500Hz, 1kHz e 2kHZ da OE.');", true);
                }

                else//do contrário
                {
                    if ((aus500vaOECheckBox.Checked == true) || (aus1kvaOECheckBox.Checked == true) || (aus2kvaOECheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        mEDIAoeTextBox.Text = "Saída máxima";//atritui a frase à txt média com AASI
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, resultado;

                        valor1 = Convert.ToInt32(va500oeComboBox.Text);
                        valor2 = Convert.ToInt32(va1koeComboBox.Text);
                        valor3 = Convert.ToInt32(va2koeComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3) / 3);

                        mEDIAoeTextBox.Text = Convert.ToString(resultado);
                        lblMediaOE.Text = "Média Tritonal (dBNA):";
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
                mEDIAodTextBox.Text = "";//limpa o txt média tritonal

                if ((va500odComboBox.Text == "") || (va1kodComboBox.Text == "") || (va2kodComboBox.Text == "") || (va4kodComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média quadritonal de 500Hz, 1kHz, 2kHZ e 4kHz da OD.');", true);
                }

                else//do contrário
                {
                    if ((aus500vaODCheckBox.Checked == true) || (aus1kvaODCheckBox.Checked == true) || (aus2kvaODCheckBox.Checked == true) || (aus4kvaODCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        mEDIAodTextBox.Text = "Saída máxima";//atritui a frase à txt média
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, valor4, resultado;

                        valor1 = Convert.ToInt32(va500odComboBox.Text);
                        valor2 = Convert.ToInt32(va1kodComboBox.Text);
                        valor3 = Convert.ToInt32(va2kodComboBox.Text);
                        valor4 = Convert.ToInt32(va4kodComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3 + valor4) / 4);

                        mEDIAodTextBox.Text = Convert.ToString(resultado);
                        lblMediaOD.Text = "Média Quadritonal (dBNA):";
                    }
                }

                //Para a OE #######################################
                mEDIAoeTextBox.Text = "";//limpa o txt média tritonal

                if ((va500oeComboBox.Text == "") || (va1koeComboBox.Text == "") || (va2koeComboBox.Text == "") || (va4koeComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média quadritonal de 500Hz, 1kHz, 2kHZ e 4kHz da OE.');", true);
                }

                else//do contrário
                {
                    if ((aus500vaOECheckBox.Checked == true) || (aus1kvaOECheckBox.Checked == true) || (aus2kvaOECheckBox.Checked == true) || (aus4kvaOECheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        mEDIAoeTextBox.Text = "Saída máxima";//atritui a frase à txt média
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, valor4, resultado;

                        valor1 = Convert.ToInt32(va500oeComboBox.Text);
                        valor2 = Convert.ToInt32(va1koeComboBox.Text);
                        valor3 = Convert.ToInt32(va2koeComboBox.Text);
                        valor4 = Convert.ToInt32(va4koeComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3 + valor4) / 4);

                        mEDIAoeTextBox.Text = Convert.ToString(resultado);
                        lblMediaOE.Text = "Média Quadritonal (dBNA):";
                    }
                }
            }
            catch (Exception ex)//tratamento de erro
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocorreu um erro.');" + ex.Message, true);
            }
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
            PlotaDadosAudiogramaOD();
            PlotaDadosAudiogramaOE();

            chartAudioOD.SaveImage("C:\\users/public/documents/chartODAudioClinica.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            chartAudioOE.SaveImage("C:\\users/public/documents/chartOEAudioClinica.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);

            DadosRelatorioImpressao();

            // Define o URL para onde você deseja redirecionar
            string url = "RelatorioImpressaoAudioClinicaCompleta.aspx";

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