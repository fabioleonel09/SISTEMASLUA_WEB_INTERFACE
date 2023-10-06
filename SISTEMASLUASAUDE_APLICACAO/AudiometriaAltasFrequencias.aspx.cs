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