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

                CarregaAudiogramaAASI();

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
            PlotaDadosAudiogramaAASI();
        }

        protected void btnMediaTritonal_Click(object sender, EventArgs e)
        {
            CalculaMediaTritonal();
            PlotaDadosAudiogramaAASI();
        }

        protected void btnMediaQuadritonal_Click(object sender, EventArgs e)
        {
            CalculaMediaQuadritonal();
            PlotaDadosAudiogramaAASI();
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimeAudiograma();
        }

        private void CarregaAudiogramaAASI()
        {
            chartAudioEmCampo.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartAudioEmCampo.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAudioEmCampo.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartAudioEmCampo.Series.Add(fundoChart);

            imgFundo.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaEmCampo.SelectedValue == "0")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/bananaCinza.png";

                // Define o caminho virtual da imagem como imagem do marcador
                imgFundo.Points.AddXY(7.50, 45);
                imgFundo.MarkerImage = caminhoVirtual;
            }
            else if (rbBananaFalaEmCampo.SelectedValue == "1")
            {
                chartAudioEmCampo.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1camp";
            Series ser1 = chartAudioEmCampo.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2camp";
            Series ser2 = chartAudioEmCampo.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3camp";
            Series ser3 = chartAudioEmCampo.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4camp";
            Series ser4 = chartAudioEmCampo.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5camp";
            Series ser5 = chartAudioEmCampo.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6camp";
            Series ser6 = chartAudioEmCampo.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7camp";
            Series ser7 = chartAudioEmCampo.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8camp";
            Series ser7a = chartAudioEmCampo.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9camp";
            Series ser9a = chartAudioEmCampo.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10camp";
            Series ser10a = chartAudioEmCampo.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11camp";
            Series ser11a = chartAudioEmCampo.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12camp";
            Series ser12a = chartAudioEmCampo.Series.Add(seriesName12a);

            ser12a.IsVisibleInLegend = false;
            ser12a.ChartType = SeriesChartType.Line;

            ser12a.BorderWidth = 1;
            ser12a.Color = Color.Black;
            ser12a.MarkerStyle = MarkerStyle.None;
            ser12a.Points.AddXY(15, -10);  // x, high
            ser12a.Points.AddXY(15, 120);
        }

        private void PlotaDadosAudiogramaAASI()
        {
            chartAudioEmCampo.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 15;

            chartAudioEmCampo.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAudioEmCampo.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string fundoChart = "fundoChartTransp";
            Series imgFundo = chartAudioEmCampo.Series.Add(fundoChart);

            imgFundo.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            imgFundo.Name = fundoChart;
            imgFundo.ChartType = SeriesChartType.Point;

            if (rbBananaFalaEmCampo.SelectedValue == "0")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/bananaCinza.png";

                // Define o caminho virtual da imagem como imagem do marcador
                imgFundo.Points.AddXY(7.50, 45);
                imgFundo.MarkerImage = caminhoVirtual;
            }
            else if (rbBananaFalaEmCampo.SelectedValue == "1")
            {
                chartAudioEmCampo.Series[fundoChart].Points.Clear();
            }

            string seriesName1 = "grade1camp";
            Series ser1 = chartAudioEmCampo.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2camp";
            Series ser2 = chartAudioEmCampo.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(4, -10);  // x, high
            ser2.Points.AddXY(4, 120);

            string seriesName3 = "grade3camp";
            Series ser3 = chartAudioEmCampo.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(6, -10);  // x, high
            ser3.Points.AddXY(6, 120);

            string seriesName4 = "grade4camp";
            Series ser4 = chartAudioEmCampo.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.BorderDashStyle = ChartDashStyle.Dash;
            ser4.Points.AddXY(7.25, -10);  // x, high
            ser4.Points.AddXY(7.25, 120);

            string seriesName5 = "grade5camp";
            Series ser5 = chartAudioEmCampo.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(8, -10);  // x, high
            ser5.Points.AddXY(8, 120);

            string seriesName6 = "grade6camp";
            Series ser6 = chartAudioEmCampo.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.BorderDashStyle = ChartDashStyle.Dash;
            ser6.Points.AddXY(9.25, -10);  // x, high
            ser6.Points.AddXY(9.25, 120);

            string seriesName7 = "grade7camp";
            Series ser7 = chartAudioEmCampo.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(10, -10);  // x, high
            ser7.Points.AddXY(10, 120);

            string seriesName7a = "grade8camp";
            Series ser7a = chartAudioEmCampo.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(11.25, -10);  // x, high
            ser7a.Points.AddXY(11.25, 120);

            string seriesName9a = "grade9camp";
            Series ser9a = chartAudioEmCampo.Series.Add(seriesName9a);

            ser9a.IsVisibleInLegend = false;
            ser9a.ChartType = SeriesChartType.Line;

            ser9a.BorderWidth = 1;
            ser9a.Color = Color.Black;
            ser9a.MarkerStyle = MarkerStyle.None;
            ser9a.Points.AddXY(12, -10);  // x, high
            ser9a.Points.AddXY(12, 120);

            string seriesName10a = "grade10camp";
            Series ser10a = chartAudioEmCampo.Series.Add(seriesName10a);

            ser10a.IsVisibleInLegend = false;
            ser10a.ChartType = SeriesChartType.Line;

            ser10a.BorderDashStyle = ChartDashStyle.Dash;
            ser10a.BorderWidth = 1;
            ser10a.Color = Color.Black;
            ser10a.MarkerStyle = MarkerStyle.None;
            ser10a.Points.AddXY(13.25, -10);  // x, high
            ser10a.Points.AddXY(13.25, 120);

            string seriesName11a = "grade11camp";
            Series ser11a = chartAudioEmCampo.Series.Add(seriesName11a);

            ser11a.IsVisibleInLegend = false;
            ser11a.ChartType = SeriesChartType.Line;

            ser11a.BorderWidth = 1;
            ser11a.Color = Color.Black;
            ser11a.MarkerStyle = MarkerStyle.None;
            ser11a.Points.AddXY(14, -10);  // x, high
            ser11a.Points.AddXY(14, 120);

            string seriesName12a = "grade12camp";
            Series ser12a = chartAudioEmCampo.Series.Add(seriesName12a);

            ser12a.IsVisibleInLegend = false;
            ser12a.ChartType = SeriesChartType.Line;

            ser12a.BorderWidth = 1;
            ser12a.Color = Color.Black;
            ser12a.MarkerStyle = MarkerStyle.None;
            ser12a.Points.AddXY(15, -10);  // x, high
            ser12a.Points.AddXY(15, 120);

            //*******SIMBOLOGIA*******
            //**** COM AASI *******

            string seriesName13 = "simbol_500com";
            Series ser13 = chartAudioEmCampo.Series.Add(seriesName13);

            ser13.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser13.Name = seriesName13;
            ser13.ChartType = SeriesChartType.Point;

            if (com500ComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if (com500ComboBox.Text != "")
            {
                int valor13;
                valor13 = Convert.ToInt32(com500ComboBox.Text);
                ser13.Points.AddXY(6, valor13);  // x, high
            }


            if (chkAusente500comCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente500comCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            //*****

            string seriesName14 = "simbol_1kcom";
            Series ser14 = chartAudioEmCampo.Series.Add(seriesName14);

            ser14.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser14.Name = seriesName14;
            ser14.ChartType = SeriesChartType.Point;

            if (com1kComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if (com1kComboBox.Text != "")
            {
                int valor14;
                valor14 = Convert.ToInt32(com1kComboBox.Text);
                ser14.Points.AddXY(8, valor14);  // x, high
            }


            if (chkAusente1kcomCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente1kcomCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            //*****

            string seriesName15 = "simbol_2kcom";
            Series ser15 = chartAudioEmCampo.Series.Add(seriesName15);

            ser15.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser15.Name = seriesName15;
            ser15.ChartType = SeriesChartType.Point;

            if (com2KComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if (com2KComboBox.Text != "")
            {
                int valor15;
                valor15 = Convert.ToInt32(com2KComboBox.Text);
                ser15.Points.AddXY(10, valor15);  // x, high
            }


            if (chkAusente2kcomCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente2kcomCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser15.MarkerImage = caminhoVirtual;
            }


            //*****

            string seriesName16 = "simbol_3kcom";
            Series ser16 = chartAudioEmCampo.Series.Add(seriesName16);

            ser16.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser16.Name = seriesName16;
            ser16.ChartType = SeriesChartType.Point;

            if (com3kComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if (com3kComboBox.Text != "")
            {
                int valor16;
                valor16 = Convert.ToInt32(com3kComboBox.Text);
                ser16.Points.AddXY(11.25, valor16);  // x, high
            }


            if (chkAusente3kcomCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente3kcomCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser16.MarkerImage = caminhoVirtual;
            }

            //******

            string seriesName17 = "simbol_4kcom";
            Series ser17 = chartAudioEmCampo.Series.Add(seriesName17);

            ser17.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser17.Name = seriesName17;
            ser17.ChartType = SeriesChartType.Point;

            if (com4kComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if (com4kComboBox.Text != "")
            {
                int valor17;
                valor17 = Convert.ToInt32(com4kComboBox.Text);
                ser17.Points.AddXY(12, valor17);  // x, high
            }


            if (chkAusente4kcomCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente4kcomCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoComAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser17.MarkerImage = caminhoVirtual;
            }


            //*******SIMBOLOGIA*******
            //**** SEM AASI *******

            string seriesName18 = "simbol_500sem";
            Series ser18 = chartAudioEmCampo.Series.Add(seriesName18);

            ser18.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser18.Name = seriesName18;
            ser18.ChartType = SeriesChartType.Point;

            if (sem500ComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if (sem500ComboBox.Text != "")
            {
                int valor18;
                valor18 = Convert.ToInt32(sem500ComboBox.Text);
                ser18.Points.AddXY(6, valor18);  // x, high
            }


            if (chkAusente500semCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente500semCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser18.MarkerImage = caminhoVirtual;
            }

            //*****

            string seriesName19 = "simbol_1ksem";
            Series ser19 = chartAudioEmCampo.Series.Add(seriesName19);

            ser19.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser19.Name = seriesName19;
            ser19.ChartType = SeriesChartType.Point;

            if (sem1kComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if (sem1kComboBox.Text != "")
            {
                int valor19;
                valor19 = Convert.ToInt32(sem1kComboBox.Text);
                ser19.Points.AddXY(8, valor19);  // x, high
            }


            if (chkAusente1ksemCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente1ksemCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser19.MarkerImage = caminhoVirtual;
            }

            //*****

            string seriesName20 = "simbol_2ksem";
            Series ser20 = chartAudioEmCampo.Series.Add(seriesName20);

            ser20.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser20.Name = seriesName20;
            ser20.ChartType = SeriesChartType.Point;

            if (sem2KComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if (sem2KComboBox.Text != "")
            {
                int valor20;
                valor20 = Convert.ToInt32(sem2KComboBox.Text);
                ser20.Points.AddXY(10, valor20);  // x, high
            }


            if (chkAusente2ksemCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente2ksemCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser20.MarkerImage = caminhoVirtual;
            }


            //*****

            string seriesName21 = "simbol_3ksem";
            Series ser21 = chartAudioEmCampo.Series.Add(seriesName21);

            ser21.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser21.Name = seriesName21;
            ser21.ChartType = SeriesChartType.Point;

            if (sem3kComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if (sem3kComboBox.Text != "")
            {
                int valor21;
                valor21 = Convert.ToInt32(sem3kComboBox.Text);
                ser21.Points.AddXY(11.25, valor21);  // x, high
            }


            if (chkAusente3ksemCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente3ksemCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser21.MarkerImage = caminhoVirtual;
            }

            //******

            string seriesName22 = "simbol_4ksem";
            Series ser22 = chartAudioEmCampo.Series.Add(seriesName22);

            ser22.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
            ser22.Name = seriesName22;
            ser22.ChartType = SeriesChartType.Point;

            if (sem4kComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if (sem4kComboBox.Text != "")
            {
                int valor22;
                valor22 = Convert.ToInt32(sem4kComboBox.Text);
                ser22.Points.AddXY(12, valor22);  // x, high
            }


            if (chkAusente4ksemCheckBox.Checked == true)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }

            else if (chkAusente4ksemCheckBox.Checked == false)
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/campoSemAASIpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser22.MarkerImage = caminhoVirtual;
            }


            //***SEQUÊNCIA PARA LIGAR SIMBOLOGIA COM AASSI

            try
            {

                string seriesName23 = "liga 500_1kcom";
                Series ser23 = chartAudioEmCampo.Series.Add(seriesName23);

                ser23.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
                ser23.Name = seriesName23;
                ser23.ChartType = SeriesChartType.Line;

                if (chbLiga500_1k_comCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(com500ComboBox.Text);
                    valorB = Convert.ToInt32(com1kComboBox.Text);

                    ser23.Points.AddXY(6, valorA);
                    ser23.Points.AddXY(8, valorB);

                    ser23.BorderColor = Color.Transparent;
                    ser23.Color = Color.Black;
                    ser23.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chbLiga500_1k_comCheckBox.Checked == false)
                {
                    ser23.Points.Clear();
                }

                //*******

                string seriesName24 = "liga 1k_2kcom";
                Series ser24 = chartAudioEmCampo.Series.Add(seriesName24);

                ser24.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
                ser24.Name = seriesName24;
                ser24.ChartType = SeriesChartType.Line;

                if (chbLiga1k_2k_comCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(com1kComboBox.Text);
                    valorB = Convert.ToInt32(com2KComboBox.Text);

                    ser24.Points.AddXY(8, valorA);
                    ser24.Points.AddXY(10, valorB);

                    ser24.BorderColor = Color.Transparent;
                    ser24.Color = Color.Black;
                    ser24.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chbLiga1k_2k_comCheckBox.Checked == false)
                {
                    ser24.Points.Clear();
                }

                //*******

                string seriesName25 = "liga 2k_3kcom";
                Series ser25 = chartAudioEmCampo.Series.Add(seriesName25);

                ser25.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
                ser25.Name = seriesName25;
                ser25.ChartType = SeriesChartType.Line;

                if (chbLiga2k_3k_comCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(com2KComboBox.Text);
                    valorB = Convert.ToInt32(com3kComboBox.Text);

                    ser25.Points.AddXY(10, valorA);
                    ser25.Points.AddXY(11.25, valorB);

                    ser25.BorderColor = Color.Transparent;
                    ser25.Color = Color.Black;
                    ser25.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chbLiga2k_3k_comCheckBox.Checked == false)
                {
                    ser25.Points.Clear();
                }

                //******

                string seriesName26 = "liga 3k_4kcom";
                Series ser26 = chartAudioEmCampo.Series.Add(seriesName26);

                ser26.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
                ser26.Name = seriesName26;
                ser26.ChartType = SeriesChartType.Line;

                if (chbLiga3k_4k_comCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(com3kComboBox.Text);
                    valorB = Convert.ToInt32(com4kComboBox.Text);

                    ser26.Points.AddXY(11.25, valorA);
                    ser26.Points.AddXY(12, valorB);

                    ser26.BorderColor = Color.Transparent;
                    ser26.Color = Color.Black;
                    ser26.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chbLiga3k_4k_comCheckBox.Checked == false)
                {
                    ser26.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                chbLiga500_1k_comCheckBox.Checked = false;
                chbLiga1k_2k_comCheckBox.Checked = false;
                chbLiga2k_3k_comCheckBox.Checked = false;
                chbLiga3k_4k_comCheckBox.Checked = false;
            }

            //***SEQUÊNCIA PARA LIGAR SIMBOLOGIA SEM AASSI

            try
            {

                string seriesName27 = "liga 500_1ksem";
                Series ser27 = chartAudioEmCampo.Series.Add(seriesName27);

                ser27.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
                ser27.Name = seriesName27;
                ser27.ChartType = SeriesChartType.Line;

                if (chbLiga500_1k_semCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(sem500ComboBox.Text);
                    valorB = Convert.ToInt32(sem1kComboBox.Text);

                    ser27.Points.AddXY(6, valorA);
                    ser27.Points.AddXY(8, valorB);

                    ser27.BorderColor = Color.Transparent;
                    ser27.Color = Color.Black;
                    ser27.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chbLiga500_1k_semCheckBox.Checked == false)
                {
                    ser27.Points.Clear();
                }

                //*******

                string seriesName28 = "liga 1k_2ksem";
                Series ser28 = chartAudioEmCampo.Series.Add(seriesName28);

                ser28.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
                ser28.Name = seriesName28;
                ser28.ChartType = SeriesChartType.Line;

                if (chbLiga1k_2k_semCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(sem1kComboBox.Text);
                    valorB = Convert.ToInt32(sem2KComboBox.Text);

                    ser28.Points.AddXY(8, valorA);
                    ser28.Points.AddXY(10, valorB);

                    ser28.BorderColor = Color.Transparent;
                    ser28.Color = Color.Black;
                    ser28.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chbLiga1k_2k_semCheckBox.Checked == false)
                {
                    ser28.Points.Clear();
                }

                //*******

                string seriesName29 = "liga 2k_3ksem";
                Series ser29 = chartAudioEmCampo.Series.Add(seriesName29);

                ser29.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
                ser29.Name = seriesName29;
                ser29.ChartType = SeriesChartType.Line;

                if (chbLiga2k_3k_semCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(sem2KComboBox.Text);
                    valorB = Convert.ToInt32(sem3kComboBox.Text);

                    ser29.Points.AddXY(10, valorA);
                    ser29.Points.AddXY(11.25, valorB);

                    ser29.BorderColor = Color.Transparent;
                    ser29.Color = Color.Black;
                    ser29.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chbLiga2k_3k_semCheckBox.Checked == false)
                {
                    ser29.Points.Clear();
                }

                //******

                string seriesName30 = "liga 3k_4ksem";
                Series ser30 = chartAudioEmCampo.Series.Add(seriesName30);

                ser30.ChartArea = chartAudioEmCampo.ChartAreas[0].Name;
                ser30.Name = seriesName30;
                ser30.ChartType = SeriesChartType.Line;

                if (chbLiga3k_4k_semCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(sem3kComboBox.Text);
                    valorB = Convert.ToInt32(sem4kComboBox.Text);

                    ser30.Points.AddXY(11.25, valorA);
                    ser30.Points.AddXY(12, valorB);

                    ser30.BorderColor = Color.Transparent;
                    ser30.Color = Color.Black;
                    ser30.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chbLiga3k_4k_semCheckBox.Checked == false)
                {
                    ser30.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                chbLiga500_1k_semCheckBox.Checked = false;
                chbLiga1k_2k_semCheckBox.Checked = false;
                chbLiga2k_3k_semCheckBox.Checked = false;
                chbLiga3k_4k_semCheckBox.Checked = false;
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
            

            

            //VO
            

            

            //para OE ######################################################
            //VA
            
        }

        private void CarregaDDLaudioVocal()
        {
            //para o IPRF da OD
            //monossílabos
            
        }

        private void CalculaMediaTritonal()
        { 
            try//no bloco de tratamento de erros
            {
                //Para COM AASI #############################################
                comMEDIATextBox.Text = "";//limpa o txt média tritonal 

                if ((com500ComboBox.Text == "") || (com1kComboBox.Text == "") || (com2KComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média tritonal de 500Hz, 1kHz e 2kHZ da OD.');", true);
                }

                else//do contrário
                {
                    if ((chkAusente500comCheckBox.Checked == true) || (chkAusente1kcomCheckBox.Checked == true) || (chkAusente2kcomCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        comMEDIATextBox.Text = "Saída máxima";//atritui a frase à txt média
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, resultado;

                        valor1 = Convert.ToInt32(com500ComboBox.Text);
                        valor2 = Convert.ToInt32(com1kComboBox.Text);
                        valor3 = Convert.ToInt32(com2KComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3) / 3);

                        comMEDIATextBox.Text = Convert.ToString(resultado);
                        lblMediaComAASI.Text = "Média Tritonal (dBNA):";
                    }
                }

                //Para SEM AASI #######################################
                semMEDIATextBox.Text = "";//limpa o txt média tritonal 

                if ((sem500ComboBox.Text == "") || (sem1kComboBox.Text == "") || (sem2KComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média tritonal de 500Hz, 1kHz e 2kHZ da OE.');", true);
                }

                else//do contrário
                {
                    if ((chkAusente500semCheckBox.Checked == true) || (chkAusente1ksemCheckBox.Checked == true) || (chkAusente2ksemCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        semMEDIATextBox.Text = "Saída máxima";//atritui a frase à txt média com AASI
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, resultado;

                        valor1 = Convert.ToInt32(sem500ComboBox.Text);
                        valor2 = Convert.ToInt32(sem1kComboBox.Text);
                        valor3 = Convert.ToInt32(sem2KComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3) / 3);

                        semMEDIATextBox.Text = Convert.ToString(resultado);
                        lblMediaSemAASI.Text = "Média Tritonal (dBNA):";
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
                //Para COM AASI #########################################
                comMEDIATextBox.Text = "";//limpa o txt média quadritonal

                if ((com500ComboBox.Text == "") || (com1kComboBox.Text == "") || (com2KComboBox.Text == "") || (com4kComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média quadritonal de 500Hz, 1kHz, 2kHZ e 4kHz da OD.');", true);
                }

                else//do contrário
                {
                    if ((chkAusente500comCheckBox.Checked == true) || (chkAusente1kcomCheckBox.Checked == true) || (chkAusente2kcomCheckBox.Checked == true) || (chkAusente4kcomCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        comMEDIATextBox.Text = "Saída máxima";//atritui a frase à txt média
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, valor4, resultado;

                        valor1 = Convert.ToInt32(com500ComboBox.Text);
                        valor2 = Convert.ToInt32(com1kComboBox.Text);
                        valor3 = Convert.ToInt32(com2KComboBox.Text);
                        valor4 = Convert.ToInt32(com4kComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3 + valor4) / 4);

                        comMEDIATextBox.Text = Convert.ToString(resultado);
                        lblMediaComAASI.Text = "Média Quadritonal (dBNA):";
                    }
                }

                //Para SEM AASI #######################################
                semMEDIATextBox.Text = "";//limpa o txt média tritonal

                if ((sem500ComboBox.Text == "") || (sem1kComboBox.Text == "") || (sem2KComboBox.Text == "") || (sem4kComboBox.Text == ""))//caso alguma das txt's de 500Hz, 1kHz e 2kHz estejam vazias
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, escolha os valores para a média quadritonal de 500Hz, 1kHz, 2kHZ e 4kHz da OE.');", true);
                }

                else//do contrário
                {
                    if ((chkAusente500semCheckBox.Checked == true) || (chkAusente1ksemCheckBox.Checked == true) || (chkAusente2ksemCheckBox.Checked == true) || (chkAusente4ksemCheckBox.Checked == true))//caso alguma das txt's de 500Hz, 1kHz ou 2kHz esteja com o texto AUS, de ausente
                    {
                        semMEDIATextBox.Text = "Saída máxima";//atritui a frase à txt média
                    }

                    else//caso contrário
                    {
                        int valor1, valor2, valor3, valor4, resultado;

                        valor1 = Convert.ToInt32(sem500ComboBox.Text);
                        valor2 = Convert.ToInt32(sem1kComboBox.Text);
                        valor3 = Convert.ToInt32(sem2KComboBox.Text);
                        valor4 = Convert.ToInt32(sem4kComboBox.Text);

                        resultado = ((valor1 + valor2 + valor3 + valor4) / 4);

                        semMEDIATextBox.Text = Convert.ToString(resultado);
                        lblMediaSemAASI.Text = "Média Quadritonal (dBNA):";
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
            PlotaDadosAudiogramaAASI();

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

            RelatorioDataSource.Comentarios = dadosRel.comentarios;

            RelatorioDataSource.Examinador = dadosRel.examidador;
            RelatorioDataSource.Audiometro = dadosRel.audiometro;
            RelatorioDataSource.DataCalibracao = dadosRel.dataCalibracao;

            // Chame o método GetDadosRelatorio
            DataSet dataSet = RelatorioDataSource.GetDadosRelatorio();
        }
    }
}