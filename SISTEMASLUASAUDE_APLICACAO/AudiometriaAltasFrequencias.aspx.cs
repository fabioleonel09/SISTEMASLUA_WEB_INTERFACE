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
    public partial class AudiometriaAltasFrequencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaProfissional();

                CarregaDadosPaciente();

                CarregaAudiogramaAltasFreqOD();
                CarregaAudiogramaAltasFreqOE();

                CarregaDDLaudioTonalVA();
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
            PlotaDadosAudiogramaOD();
            PlotaDadosAudiogramaOE();
        }

        protected void btnMediaQuadritonal_Click(object sender, EventArgs e)
        {
            PlotaDadosAudiogramaOD();
            PlotaDadosAudiogramaOE();
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimeAudiograma();
        }

        private void CarregaAudiogramaAltasFreqOD()
        {
            chartAltOD.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 9;

            chartAltOD.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAltOD.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string seriesName1 = "grade1";
            Series ser1 = chartAltOD.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2";
            Series ser2 = chartAltOD.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(3, -10);  // x, high
            ser2.Points.AddXY(3, 120);

            string seriesName3 = "grade3";
            Series ser3 = chartAltOD.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(5, -10);  // x, high
            ser3.Points.AddXY(5, 120);

            string seriesName4 = "grade4";
            Series ser4 = chartAltOD.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.Points.AddXY(6, -10);  // x, high
            ser4.Points.AddXY(6, 120);

            string seriesName5 = "grade5";
            Series ser5 = chartAltOD.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(7, -10);  // x, high
            ser5.Points.AddXY(7, 120);

            string seriesName6 = "grade6";
            Series ser6 = chartAltOD.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.Points.AddXY(8, -10);  // x, high
            ser6.Points.AddXY(8, 120);

            string seriesName7 = "grade7";
            Series ser7 = chartAltOD.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(9, -10);  // x, high
            ser7.Points.AddXY(9, 120);

            string seriesName7a = "grade12_5k";
            Series ser7a = chartAltOD.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(4.25, -10);  // x, high
            ser7a.Points.AddXY(4.25, 120);
        }

        private void CarregaAudiogramaAltasFreqOE()
        {
            chartAltOE.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 9;

            chartAltOE.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAltOE.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string seriesName1 = "grade1";
            Series ser1 = chartAltOE.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2";
            Series ser2 = chartAltOE.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(3, -10);  // x, high
            ser2.Points.AddXY(3, 120);

            string seriesName3 = "grade3";
            Series ser3 = chartAltOE.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(5, -10);  // x, high
            ser3.Points.AddXY(5, 120);

            string seriesName4 = "grade4";
            Series ser4 = chartAltOE.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.Points.AddXY(6, -10);  // x, high
            ser4.Points.AddXY(6, 120);

            string seriesName5 = "grade5";
            Series ser5 = chartAltOE.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(7, -10);  // x, high
            ser5.Points.AddXY(7, 120);

            string seriesName6 = "grade6";
            Series ser6 = chartAltOE.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.Points.AddXY(8, -10);  // x, high
            ser6.Points.AddXY(8, 120);

            string seriesName7 = "grade7";
            Series ser7 = chartAltOE.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(9, -10);  // x, high
            ser7.Points.AddXY(9, 120);

            string seriesName7a = "grade12_5k";
            Series ser7a = chartAltOE.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(4.25, -10);  // x, high
            ser7a.Points.AddXY(4.25, 120);
        }

        private void PlotaDadosAudiogramaOD()
        {
            chartAltOD.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 9;

            chartAltOD.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAltOD.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string seriesName1 = "grade1";
            Series ser1 = chartAltOD.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2";
            Series ser2 = chartAltOD.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(3, -10);  // x, high
            ser2.Points.AddXY(3, 120);

            string seriesName3 = "grade3";
            Series ser3 = chartAltOD.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(5, -10);  // x, high
            ser3.Points.AddXY(5, 120);

            string seriesName4 = "grade4";
            Series ser4 = chartAltOD.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.Points.AddXY(6, -10);  // x, high
            ser4.Points.AddXY(6, 120);

            string seriesName5 = "grade5";
            Series ser5 = chartAltOD.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(7, -10);  // x, high
            ser5.Points.AddXY(7, 120);

            string seriesName6 = "grade6";
            Series ser6 = chartAltOD.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.Points.AddXY(8, -10);  // x, high
            ser6.Points.AddXY(8, 120);

            string seriesName7 = "grade7";
            Series ser7 = chartAltOD.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(9, -10);  // x, high
            ser7.Points.AddXY(9, 120);

            string seriesName7a = "grade12_5k";
            Series ser7a = chartAltOD.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(4.25, -10);  // x, high
            ser7a.Points.AddXY(4.25, 120);

            //***PARA A SIMBOLOGIA***

            //***

            string seriesName8 = "simbol_9k";
            Series ser8 = chartAltOD.Series.Add(seriesName8);

            ser8.ChartArea = chartAltOD.ChartAreas[0].Name;
            ser8.Name = seriesName8;
            ser8.ChartType = SeriesChartType.Point;

            if (va9kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }

            else if (va9kodComboBox.Text != "")
            {
                int valor8;
                valor8 = Convert.ToInt32(va9kodComboBox.Text);
                ser8.Points.AddXY(2, valor8);  // x, high
            }

            if ((chkAusente9kODCheckBox.Checked == false) && (chkMasc9kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente9kODCheckBox.Checked == true) && (chkMasc9kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente9kODCheckBox.Checked == false) && (chkMasc9kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc9kODCheckBox.Checked == true) && (chkAusente9kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName9 = "simbol_10k";
            Series ser9 = chartAltOD.Series.Add(seriesName9);

            ser9.ChartArea = chartAltOD.ChartAreas[0].Name;
            ser9.Name = seriesName9;
            ser9.ChartType = SeriesChartType.Point;

            if (va10kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }

            else if (va10kodComboBox.Text != "")
            {
                int valor9;
                valor9 = Convert.ToInt32(va10kodComboBox.Text);
                ser9.Points.AddXY(3, valor9);  // x, high
            }

            if ((chkAusente10kODCheckBox.Checked == false) && (chkMasc10kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente10kODCheckBox.Checked == true) && (chkMasc10kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente10kODCheckBox.Checked == false) && (chkMasc10kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc10kODCheckBox.Checked == true) && (chkAusente10kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName10 = "simbol_12_5k";
            Series ser10 = chartAltOD.Series.Add(seriesName10);

            ser10.ChartArea = chartAltOD.ChartAreas[0].Name;
            ser10.Name = seriesName10;
            ser10.ChartType = SeriesChartType.Point;

            if (va12e5kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }

            else if (va12e5kodComboBox.Text != "")
            {
                int valor10;
                valor10 = Convert.ToInt32(va12e5kodComboBox.Text);
                ser10.Points.AddXY(4.25, valor10);  // x, high
            }

            if ((chkAusente12_5kODCheckBox.Checked == false) && (chkMasc12_5kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente12_5kODCheckBox.Checked == true) && (chkMasc12_5kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente12_5kODCheckBox.Checked == false) && (chkMasc12_5kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc12_5kODCheckBox.Checked == true) && (chkAusente12_5kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName11 = "simbol_14k";
            Series ser11 = chartAltOD.Series.Add(seriesName11);

            ser11.ChartArea = chartAltOD.ChartAreas[0].Name;
            ser11.Name = seriesName11;
            ser11.ChartType = SeriesChartType.Point;

            if (va14kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }

            else if (va14kodComboBox.Text != "")
            {
                int valor11;
                valor11 = Convert.ToInt32(va14kodComboBox.Text);
                ser11.Points.AddXY(5, valor11);  // x, high
            }

            if ((chkAusente14kODCheckBox.Checked == false) && (chkMasc14kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente14kODCheckBox.Checked == true) && (chkMasc14kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente14kODCheckBox.Checked == false) && (chkMasc14kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc14kODCheckBox.Checked == true) && (chkAusente14kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName12 = "simbol_16k";
            Series ser12 = chartAltOD.Series.Add(seriesName12);

            ser12.ChartArea = chartAltOD.ChartAreas[0].Name;
            ser12.Name = seriesName12;
            ser12.ChartType = SeriesChartType.Point;

            if (va16kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }

            else if (va16kodComboBox.Text != "")
            {
                int valor12;
                valor12 = Convert.ToInt32(va16kodComboBox.Text);
                ser12.Points.AddXY(6, valor12);  // x, high
            }

            if ((chkAusente16kODCheckBox.Checked == false) && (chkMasc16kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente16kODCheckBox.Checked == true) && (chkMasc16kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente16kODCheckBox.Checked == false) && (chkMasc16kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc16kODCheckBox.Checked == true) && (chkAusente16kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName13 = "simbol_18k";
            Series ser13 = chartAltOD.Series.Add(seriesName13);

            ser13.ChartArea = chartAltOD.ChartAreas[0].Name;
            ser13.Name = seriesName13;
            ser13.ChartType = SeriesChartType.Point;

            if (va18kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if (va18kodComboBox.Text != "")
            {
                int valor13;
                valor13 = Convert.ToInt32(va18kodComboBox.Text);
                ser13.Points.AddXY(7, valor13);  // x, high
            }


            if ((chkAusente18kODCheckBox.Checked == false) && (chkMasc18kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente18kODCheckBox.Checked == true) && (chkMasc18kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente18kODCheckBox.Checked == false) && (chkMasc18kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc18kODCheckBox.Checked == true) && (chkAusente18kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName14 = "simbol_20k";
            Series ser14 = chartAltOD.Series.Add(seriesName14);

            ser14.ChartArea = chartAltOD.ChartAreas[0].Name;
            ser14.Name = seriesName14;
            ser14.ChartType = SeriesChartType.Point;

            if (va20kodComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if (va20kodComboBox.Text != "")
            {
                int valor14;
                valor14 = Convert.ToInt32(va20kodComboBox.Text);
                ser14.Points.AddXY(8, valor14);  // x, high
            }


            if ((chkAusente20kODCheckBox.Checked == false) && (chkMasc20kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente20kODCheckBox.Checked == true) && (chkMasc20kODCheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente20kODCheckBox.Checked == false) && (chkMasc20kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc20kODCheckBox.Checked == true) && (chkAusente20kODCheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaODmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }


            //***SEQUÊNCIA PARA LIGAR SIMBOLOGIA

            try
            {
                string seriesName15 = "liga 9k_10K";
                Series ser15 = chartAltOD.Series.Add(seriesName15);

                ser15.ChartArea = chartAltOD.ChartAreas[0].Name;
                ser15.Name = seriesName15;
                ser15.ChartType = SeriesChartType.Line;

                if (chkliga9_10ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va9kodComboBox.Text);
                    valorB = Convert.ToInt32(va10kodComboBox.Text);

                    ser15.Points.AddXY(2, valorA);
                    ser15.Points.AddXY(3, valorB);

                    ser15.BorderColor = Color.Transparent;
                    ser15.Color = Color.Red;
                    ser15.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga9_10ODCheckBox.Checked == false)
                {
                    ser15.Points.Clear();
                }

                //*******

                string seriesName16 = "liga 10k_12_5K";
                Series ser16 = chartAltOD.Series.Add(seriesName16);

                ser16.ChartArea = chartAltOD.ChartAreas[0].Name;
                ser16.Name = seriesName16;
                ser16.ChartType = SeriesChartType.Line;

                if (chkliga10_12_5ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va10kodComboBox.Text);
                    valorB = Convert.ToInt32(va12e5kodComboBox.Text);

                    ser16.Points.AddXY(3, valorA);
                    ser16.Points.AddXY(4.25, valorB);

                    ser16.BorderColor = Color.Transparent;
                    ser16.Color = Color.Red;
                    ser16.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga10_12_5ODCheckBox.Checked == false)
                {
                    ser16.Points.Clear();
                }

                //******


                string seriesName17 = "liga 12_5k_14K";
                Series ser17 = chartAltOD.Series.Add(seriesName17);

                ser17.ChartArea = chartAltOD.ChartAreas[0].Name;
                ser17.Name = seriesName17;
                ser17.ChartType = SeriesChartType.Line;

                if (chkliga12_5_14ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va12e5kodComboBox.Text);
                    valorB = Convert.ToInt32(va14kodComboBox.Text);

                    ser17.Points.AddXY(4.25, valorA);
                    ser17.Points.AddXY(5, valorB);

                    ser17.BorderColor = Color.Transparent;
                    ser17.Color = Color.Red;
                    ser17.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga12_5_14ODCheckBox.Checked == false)
                {
                    ser17.Points.Clear();
                }

                //*****

                string seriesName18 = "liga 14k_16K";
                Series ser18 = chartAltOD.Series.Add(seriesName18);

                ser18.ChartArea = chartAltOD.ChartAreas[0].Name;
                ser18.Name = seriesName18;
                ser18.ChartType = SeriesChartType.Line;

                if (chkliga14_16ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va14kodComboBox.Text);
                    valorB = Convert.ToInt32(va16kodComboBox.Text);

                    ser18.Points.AddXY(5, valorA);
                    ser18.Points.AddXY(6, valorB);

                    ser18.BorderColor = Color.Transparent;
                    ser18.Color = Color.Red;
                    ser18.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga14_16ODCheckBox.Checked == false)
                {
                    ser18.Points.Clear();
                }


                //******

                string seriesName19 = "liga 16k_18K";
                Series ser19 = chartAltOD.Series.Add(seriesName19);

                ser19.ChartArea = chartAltOD.ChartAreas[0].Name;
                ser19.Name = seriesName19;
                ser19.ChartType = SeriesChartType.Line;

                if (chkliga16_18ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va16kodComboBox.Text);
                    valorB = Convert.ToInt32(va18kodComboBox.Text);

                    ser19.Points.AddXY(6, valorA);
                    ser19.Points.AddXY(7, valorB);

                    ser19.BorderColor = Color.Transparent;
                    ser19.Color = Color.Red;
                    ser19.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga16_18ODCheckBox.Checked == false)
                {
                    ser19.Points.Clear();
                }

                //******

                string seriesName20 = "liga 18k_20K";
                Series ser20 = chartAltOD.Series.Add(seriesName20);

                ser20.ChartArea = chartAltOD.ChartAreas[0].Name;
                ser20.Name = seriesName20;
                ser20.ChartType = SeriesChartType.Line;

                if (chkliga18_20ODCheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va18kodComboBox.Text);
                    valorB = Convert.ToInt32(va20kodComboBox.Text);

                    ser20.Points.AddXY(7, valorA);
                    ser20.Points.AddXY(8, valorB);

                    ser20.BorderColor = Color.Transparent;
                    ser20.Color = Color.Red;
                    ser20.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga18_20ODCheckBox.Checked == false)
                {
                    ser20.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                chkliga9_10ODCheckBox.Checked = false;
                chkliga10_12_5ODCheckBox.Checked = false;
                chkliga12_5_14ODCheckBox.Checked = false;
                chkliga14_16ODCheckBox.Checked = false;
                chkliga16_18ODCheckBox.Checked = false;
                chkliga18_20ODCheckBox.Checked = false;
            }
        }

        private void PlotaDadosAudiogramaOE()
        {
            chartAltOE.Series.Clear();// limpa o chart

            //***PARA MONTAR O GRÁFICO***

            int iniciar = 1;
            int finalizar = 9;

            chartAltOE.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAltOE.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            string seriesName1 = "grade1";
            Series ser1 = chartAltOE.Series.Add(seriesName1);

            ser1.IsVisibleInLegend = false;
            ser1.ChartType = SeriesChartType.Line;

            ser1.BorderWidth = 1;
            ser1.Color = Color.Black;
            ser1.MarkerStyle = MarkerStyle.None;
            ser1.Points.AddXY(2, -10);  // x, high
            ser1.Points.AddXY(2, 120);


            string seriesName2 = "grade2";
            Series ser2 = chartAltOE.Series.Add(seriesName2);

            ser2.IsVisibleInLegend = false;
            ser2.ChartType = SeriesChartType.Line;

            ser2.BorderWidth = 1;
            ser2.Color = Color.Black;
            ser2.MarkerStyle = MarkerStyle.None;
            ser2.Points.AddXY(3, -10);  // x, high
            ser2.Points.AddXY(3, 120);

            string seriesName3 = "grade3";
            Series ser3 = chartAltOE.Series.Add(seriesName3);

            ser3.IsVisibleInLegend = false;
            ser3.ChartType = SeriesChartType.Line;

            ser3.BorderWidth = 1;
            ser3.Color = Color.Black;
            ser3.MarkerStyle = MarkerStyle.None;
            ser3.Points.AddXY(5, -10);  // x, high
            ser3.Points.AddXY(5, 120);

            string seriesName4 = "grade4";
            Series ser4 = chartAltOE.Series.Add(seriesName4);

            ser4.IsVisibleInLegend = false;
            ser4.ChartType = SeriesChartType.Line;

            ser4.BorderWidth = 1;
            ser4.Color = Color.Black;
            ser4.MarkerStyle = MarkerStyle.None;
            ser4.Points.AddXY(6, -10);  // x, high
            ser4.Points.AddXY(6, 120);

            string seriesName5 = "grade5";
            Series ser5 = chartAltOE.Series.Add(seriesName5);

            ser5.IsVisibleInLegend = false;
            ser5.ChartType = SeriesChartType.Line;

            ser5.BorderWidth = 1;
            ser5.Color = Color.Black;
            ser5.MarkerStyle = MarkerStyle.None;
            ser5.Points.AddXY(7, -10);  // x, high
            ser5.Points.AddXY(7, 120);

            string seriesName6 = "grade6";
            Series ser6 = chartAltOE.Series.Add(seriesName6);

            ser6.IsVisibleInLegend = false;
            ser6.ChartType = SeriesChartType.Line;

            ser6.BorderWidth = 1;
            ser6.Color = Color.Black;
            ser6.MarkerStyle = MarkerStyle.None;
            ser6.Points.AddXY(8, -10);  // x, high
            ser6.Points.AddXY(8, 120);

            string seriesName7 = "grade7";
            Series ser7 = chartAltOE.Series.Add(seriesName7);

            ser7.IsVisibleInLegend = false;
            ser7.ChartType = SeriesChartType.Line;

            ser7.BorderWidth = 1;
            ser7.Color = Color.Black;
            ser7.MarkerStyle = MarkerStyle.None;
            ser7.Points.AddXY(9, -10);  // x, high
            ser7.Points.AddXY(9, 120);

            string seriesName7a = "grade12_5k";
            Series ser7a = chartAltOE.Series.Add(seriesName7a);

            ser7a.IsVisibleInLegend = false;
            ser7a.ChartType = SeriesChartType.Line;

            ser7a.BorderDashStyle = ChartDashStyle.Dash;
            ser7a.BorderWidth = 1;
            ser7a.Color = Color.Black;
            ser7a.MarkerStyle = MarkerStyle.None;
            ser7a.Points.AddXY(4.25, -10);  // x, high
            ser7a.Points.AddXY(4.25, 120);

            //PARA A SIMBOLOGIA OE
            //****

            string seriesName8 = "simbol_9k";
            Series ser8 = chartAltOE.Series.Add(seriesName8);

            ser8.ChartArea = chartAltOE.ChartAreas[0].Name;
            ser8.Name = seriesName8;
            ser8.ChartType = SeriesChartType.Point;

            if (va9koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }

            else if (va9koeComboBox.Text != "")
            {
                int valor8;
                valor8 = Convert.ToInt32(va9koeComboBox.Text);
                ser8.Points.AddXY(2, valor8);  // x, high
            }

            if ((chkAusente9kOECheckBox.Checked == false) && (chkMasc9kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente9kOECheckBox.Checked == true) && (chkMasc9kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente9kOECheckBox.Checked == false) && (chkMasc9kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc9kOECheckBox.Checked == true) && (chkAusente9kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser8.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName9 = "simbol_10k";
            Series ser9 = chartAltOE.Series.Add(seriesName9);

            ser9.ChartArea = chartAltOE.ChartAreas[0].Name;
            ser9.Name = seriesName9;
            ser9.ChartType = SeriesChartType.Point;

            if (va10koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }

            else if (va10koeComboBox.Text != "")
            {
                int valor9;
                valor9 = Convert.ToInt32(va10koeComboBox.Text);
                ser9.Points.AddXY(3, valor9);  // x, high
            }

            if ((chkAusente10kOECheckBox.Checked == false) && (chkMasc10kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente10kOECheckBox.Checked == true) && (chkMasc10kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente10kOECheckBox.Checked == false) && (chkMasc10kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc10kOECheckBox.Checked == true) && (chkAusente10kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser9.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName10 = "simbol_12_5k";
            Series ser10 = chartAltOE.Series.Add(seriesName10);

            ser10.ChartArea = chartAltOE.ChartAreas[0].Name;
            ser10.Name = seriesName10;
            ser10.ChartType = SeriesChartType.Point;

            if (va12e5koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }

            else if (va12e5koeComboBox.Text != "")
            {
                int valor10;
                valor10 = Convert.ToInt32(va12e5koeComboBox.Text);
                ser10.Points.AddXY(4.25, valor10);  // x, high
            }

            if ((chkAusente12_5kOECheckBox.Checked == false) && (chkMasc12_5kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente12_5kOECheckBox.Checked == true) && (chkMasc12_5kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente12_5kOECheckBox.Checked == false) && (chkMasc12_5kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc12_5kOECheckBox.Checked == true) && (chkAusente12_5kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser10.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName11 = "simbol_14k";
            Series ser11 = chartAltOE.Series.Add(seriesName11);

            ser11.ChartArea = chartAltOE.ChartAreas[0].Name;
            ser11.Name = seriesName11;
            ser11.ChartType = SeriesChartType.Point;

            if (va14koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }

            else if (va14koeComboBox.Text != "")
            {
                int valor11;
                valor11 = Convert.ToInt32(va14koeComboBox.Text);
                ser11.Points.AddXY(5, valor11);  // x, high
            }

            if ((chkAusente14kOECheckBox.Checked == false) && (chkMasc14kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente14kOECheckBox.Checked == true) && (chkMasc14kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente14kOECheckBox.Checked == false) && (chkMasc14kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc14kOECheckBox.Checked == true) && (chkAusente14kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser11.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName12 = "simbol_16k";
            Series ser12 = chartAltOE.Series.Add(seriesName12);

            ser12.ChartArea = chartAltOE.ChartAreas[0].Name;
            ser12.Name = seriesName12;
            ser12.ChartType = SeriesChartType.Point;

            if (va16koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }

            else if (va16koeComboBox.Text != "")
            {
                int valor12;
                valor12 = Convert.ToInt32(va16koeComboBox.Text);
                ser12.Points.AddXY(6, valor12);  // x, high
            }

            if ((chkAusente16kOECheckBox.Checked == false) && (chkMasc16kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente16kOECheckBox.Checked == true) && (chkMasc16kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente16kOECheckBox.Checked == false) && (chkMasc16kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc16kOECheckBox.Checked == true) && (chkAusente16kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser12.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName13 = "simbol_18k";
            Series ser13 = chartAltOE.Series.Add(seriesName13);

            ser13.ChartArea = chartAltOE.ChartAreas[0].Name;
            ser13.Name = seriesName13;
            ser13.ChartType = SeriesChartType.Point;

            if (va18koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if (va18koeComboBox.Text != "")
            {
                int valor13;
                valor13 = Convert.ToInt32(va18koeComboBox.Text);
                ser13.Points.AddXY(7, valor13);  // x, high
            }


            if ((chkAusente18kOECheckBox.Checked == false) && (chkMasc18kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente18kOECheckBox.Checked == true) && (chkMasc18kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente18kOECheckBox.Checked == false) && (chkMasc18kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc18kOECheckBox.Checked == true) && (chkAusente18kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser13.MarkerImage = caminhoVirtual;
            }


            //***
            string seriesName14 = "simbol_20k";
            Series ser14 = chartAltOE.Series.Add(seriesName14);

            ser14.ChartArea = chartAltOE.ChartAreas[0].Name;
            ser14.Name = seriesName14;
            ser14.ChartType = SeriesChartType.Point;

            if (va20koeComboBox.Text == "")
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vazio.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if (va20koeComboBox.Text != "")
            {
                int valor14;
                valor14 = Convert.ToInt32(va20koeComboBox.Text);
                ser14.Points.AddXY(8, valor14);  // x, high
            }


            if ((chkAusente20kOECheckBox.Checked == false) && (chkMasc20kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEpresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente20kOECheckBox.Checked == true) && (chkMasc20kOECheckBox.Checked == false))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEausente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((chkAusente20kOECheckBox.Checked == false) && (chkMasc20kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascPresente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }

            else if ((chkMasc20kOECheckBox.Checked == true) && (chkAusente20kOECheckBox.Checked == true))
            {
                // Caminho virtual da imagem (relativo à raiz do projeto)
                string caminhoVirtual = "~/Images/vaOEmascAusente.png";

                // Define o caminho virtual da imagem como imagem do marcador
                ser14.MarkerImage = caminhoVirtual;
            }


            //***SEQUÊNCIA PARA LIGAR SIMBOLOGIA

            try
            {

                string seriesName15 = "liga 9k_10K";
                Series ser15 = chartAltOE.Series.Add(seriesName15);

                ser15.ChartArea = chartAltOE.ChartAreas[0].Name;
                ser15.Name = seriesName15;
                ser15.ChartType = SeriesChartType.Line;

                if (chkliga9_10OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va9koeComboBox.Text);
                    valorB = Convert.ToInt32(va10koeComboBox.Text);

                    ser15.Points.AddXY(2, valorA);
                    ser15.Points.AddXY(3, valorB);

                    ser15.BorderColor = Color.Transparent;
                    ser15.Color = Color.DodgerBlue;
                    ser15.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga9_10OECheckBox.Checked == false)
                {
                    ser15.Points.Clear();
                }

                //*******

                string seriesName16 = "liga 10k_12_5K";
                Series ser16 = chartAltOE.Series.Add(seriesName16);

                ser16.ChartArea = chartAltOE.ChartAreas[0].Name;
                ser16.Name = seriesName16;
                ser16.ChartType = SeriesChartType.Line;

                if (chkliga10_12_5OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va10koeComboBox.Text);
                    valorB = Convert.ToInt32(va12e5koeComboBox.Text);

                    ser16.Points.AddXY(3, valorA);
                    ser16.Points.AddXY(4.25, valorB);

                    ser16.BorderColor = Color.Transparent;
                    ser16.Color = Color.DodgerBlue;
                    ser16.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga10_12_5OECheckBox.Checked == false)
                {
                    ser16.Points.Clear();
                }

                //******


                string seriesName17 = "liga 12_5k_14K";
                Series ser17 = chartAltOE.Series.Add(seriesName17);

                ser17.ChartArea = chartAltOE.ChartAreas[0].Name;
                ser17.Name = seriesName17;
                ser17.ChartType = SeriesChartType.Line;

                if (chkliga12_5_14OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va12e5koeComboBox.Text);
                    valorB = Convert.ToInt32(va14koeComboBox.Text);

                    ser17.Points.AddXY(4.25, valorA);
                    ser17.Points.AddXY(5, valorB);

                    ser17.BorderColor = Color.Transparent;
                    ser17.Color = Color.DodgerBlue;
                    ser17.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga12_5_14OECheckBox.Checked == false)
                {
                    ser17.Points.Clear();
                }

                //*****

                string seriesName18 = "liga 14k_16K";
                Series ser18 = chartAltOE.Series.Add(seriesName18);

                ser18.ChartArea = chartAltOE.ChartAreas[0].Name;
                ser18.Name = seriesName18;
                ser18.ChartType = SeriesChartType.Line;

                if (chkliga14_16OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va14koeComboBox.Text);
                    valorB = Convert.ToInt32(va16koeComboBox.Text);

                    ser18.Points.AddXY(5, valorA);
                    ser18.Points.AddXY(6, valorB);

                    ser18.BorderColor = Color.Transparent;
                    ser18.Color = Color.DodgerBlue;
                    ser18.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga14_16OECheckBox.Checked == false)
                {
                    ser18.Points.Clear();
                }


                //******

                string seriesName19 = "liga 16k_18K";
                Series ser19 = chartAltOE.Series.Add(seriesName19);

                ser19.ChartArea = chartAltOE.ChartAreas[0].Name;
                ser19.Name = seriesName19;
                ser19.ChartType = SeriesChartType.Line;

                if (chkliga16_18OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va16koeComboBox.Text);
                    valorB = Convert.ToInt32(va18koeComboBox.Text);

                    ser19.Points.AddXY(6, valorA);
                    ser19.Points.AddXY(7, valorB);

                    ser19.BorderColor = Color.Transparent;
                    ser19.Color = Color.DodgerBlue;
                    ser19.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga16_18OECheckBox.Checked == false)
                {
                    ser19.Points.Clear();
                }

                //******

                string seriesName20 = "liga 18k_20K";
                Series ser20 = chartAltOE.Series.Add(seriesName20);

                ser20.ChartArea = chartAltOE.ChartAreas[0].Name;
                ser20.Name = seriesName20;
                ser20.ChartType = SeriesChartType.Line;

                if (chkliga18_20OECheckBox.Checked == true)
                {
                    int valorA, valorB;

                    valorA = Convert.ToInt32(va18koeComboBox.Text);
                    valorB = Convert.ToInt32(va20koeComboBox.Text);

                    ser20.Points.AddXY(7, valorA);
                    ser20.Points.AddXY(8, valorB);

                    ser20.BorderColor = Color.Transparent;
                    ser20.Color = Color.DodgerBlue;
                    ser20.BorderWidth = Convert.ToInt32(1.5);
                }

                else if (chkliga18_20OECheckBox.Checked == false)
                {
                    ser20.Points.Clear();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Não é possível ligar a simbologia!');", true);

                chkliga9_10OECheckBox.Checked = false;
                chkliga10_12_5OECheckBox.Checked = false;
                chkliga12_5_14OECheckBox.Checked = false;
                chkliga14_16OECheckBox.Checked = false;
                chkliga16_18OECheckBox.Checked = false;
                chkliga18_20OECheckBox.Checked = false;
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
            

            //VO
            

        }

        private void ImprimeAudiograma()
        {
            PlotaDadosAudiogramaOD();
            PlotaDadosAudiogramaOE();

            chartAltOD.SaveImage("C:\\users/public/documents/chartAltOD.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
            chartAltOE.SaveImage("C:\\users/public/documents/chartAltOE.png", System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);

            DadosRelatorioImpressao();

            // Define o URL para onde você deseja redirecionar
            string url = "RelatorioImpressaoAudioAltasFrequencias.aspx";

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