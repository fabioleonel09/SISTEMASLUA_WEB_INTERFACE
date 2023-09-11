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