<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AudiometriaClinica.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.AudiometriaClinica" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        body {
            overflow-y: scroll; /* Isso permite a rolagem vertical */
            display: flex; /* Define o display como flex */
        }

        .container {
            display: flex; /* Define o display como flex */
        }

        .box {
            flex: 1; /* Distribui o espaço igualmente entre as divs */
        }

        .custom-font {
            font-family: "Arial", arial; /* Especifica a fonte personalizada */
        }

        .cantos-arredondados-hand {
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
        }

        .cantos-arredondados-alinhamento {
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            text-align: center; /* Centraliza horizontalmente */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
        }

        .alinhamento-text-center {
            text-align: center; /* Centraliza horizontalmente */
        }
    </style>
</head>
<body class="custom-font" style="background-color: lightslategray;">
    <form id="frmAudiometriaClinica" runat="server">
        <asp:Table ID="tbAudiometriaClinica" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
            <asp:TableHeaderRow Width="100%">
                <asp:TableHeaderCell BackColor="#ff0000" Font-Bold="true" Font-Size="14" ForeColor="White" Width="20%" Height="50px">Orelha Direita</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="18" Width="60%" Height="50px">Audiometria Tonal</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#0033cc" Font-Bold="true" Font-Size="14" ForeColor="White" Width="20%" Height="50px">Orelha Esquerda</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell Width="20%" Height="100%" Style="vertical-align: bottom">
                    <div id="dadosAudioOD" runat="server">
                    </div>
                </asp:TableCell>
                <asp:TableCell Width="60%" Height="100%">
                    <div class="container" style="text-align: center;">
                        <div class="box" id="audiogramaOD" runat="server">
                            <asp:Chart ID="chartAudioOD" runat="server" Height="416px" Width="467px" BackColor="MistyRose" BorderColor="Red" BorderStyle="Solid" BorderWidth="1">
                                <Series>
                                    <asp:Series ChartArea="ChartArea4" Name="Series1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea4">
                                        <AxisY Crossing="Min" Interval="10" IsReversed="True" Maximum="120" Minimum="-10" TextOrientation="Rotated270" Title="Gráfico ISO/64 frequência (Hz) por decibel nível de audição (dBNA)">
                                        </AxisY>
                                        <AxisX Maximum="15" Minimum="1" TextOrientation="Horizontal" Title="      125            250             500     750  1k     1,5k  2k        3k   4k       6k   8k" TitleAlignment="Near">
                                            <MajorTickMark Enabled="False" />
                                            <LabelStyle Enabled="False" />
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                            <asp:RadioButtonList ID="rbBananaFalaODClinica" runat="server" RepeatDirection="Horizontal" ForeColor="Red" BackColor="MistyRose" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12" Width="467px">
                                <asp:ListItem Text="Exibe a Banana da Fala" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Oculta a Banana da Fala" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="box" id="audiogramaOE" runat="server">
                            <asp:Chart ID="chartAudioOE" runat="server" Height="416px" Width="467px" BackColor="AliceBlue" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1">
                                <Series>
                                    <asp:Series ChartArea="ChartArea5" Name="Series1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea5">
                                        <AxisY Crossing="Min" Interval="10" IsReversed="True" Maximum="120" Minimum="-10" TextOrientation="Rotated270" Title="Gráfico ISO/64 frequência (Hz) por decibel nível de audição (dBNA)">
                                        </AxisY>
                                        <AxisX Maximum="15" Minimum="1" TextOrientation="Horizontal" Title="      125            250             500     750  1k     1,5k  2k        3k   4k       6k   8k" TitleAlignment="Near">
                                            <MajorTickMark Enabled="False" />
                                            <LabelStyle Enabled="False" />
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                            <asp:RadioButtonList ID="rbBananaFalaOEClinica" runat="server" RepeatDirection="Horizontal" ForeColor="Blue" BackColor="AliceBlue" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12" Width="467px">
                                <asp:ListItem Text="Exibe a Banana da Fala" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Oculta a Banana da Fala" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <br />
                    <div id="btnPlotaTodos" runat="server" style="text-align: center;">
                        <asp:Button ID="btnPlotaGeral" runat="server" Text="Plotar" BackColor="#00cc99" BorderColor="Green" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnPlotarGeral_Click" />
                    </div>
                </asp:TableCell>
                <asp:TableCell Width="20%" Height="100%" Style="vertical-align: bottom">
                    <div id="dadosAudioOE" runat="server">
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table ID="AudiometriaVocalClinica" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
            <asp:TableHeaderRow Width="100%">
                <asp:TableHeaderCell BackColor="#ff0000" Font-Bold="true" Font-Size="14" ForeColor="White" Width="20%" Height="50px">Orelha Direita</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="18" Width="60%" Height="50px">Audiometria Vocal</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#0033cc" Font-Bold="true" Font-Size="14" ForeColor="White" Width="20%" Height="50px">Orelha Esquerda</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell Width="20%" Height="100%"></asp:TableCell>
                <asp:TableCell Width="60%" Height="100%">
                    <div class="container" style="text-align: center;">
                        <div class="box">
                            <asp:Panel ID="pnlAudioVocalOD" runat="server" Width="100%" BackColor="MistyRose" BorderColor="Red" BorderStyle="Solid" BorderWidth="1">
                                <div style="text-align: center;">
                                    <br />
                                    <label style="color: red;"><b>Média:</b></label>
                                    <asp:TextBox ID="txtMediaOD" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                    <br />
                                    <br />
                                    <label style="color: red;"><b>I. P. R. F.</b></label>
                                    <asp:DropDownList ID="ddlIPRFod" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" Width="98%" Height="45px" CssClass="cantos-arredondados-alinhamento">
                                        <asp:ListItem Text="" Value="0" />
                                        <asp:ListItem Text="100%" Value="1" />
                                        <asp:ListItem Text="96%" Value="2" />
                                        <asp:ListItem Text="92%" Value="3" />
                                        <asp:ListItem Text="88%" Value="4" />
                                        <asp:ListItem Text="84%" Value="5" />
                                        <asp:ListItem Text="80%" Value="6" />
                                        <asp:ListItem Text="76%" Value="7" />
                                        <asp:ListItem Text="72%" Value="8" />
                                        <asp:ListItem Text="68%" Value="9" />
                                        <asp:ListItem Text="64%" Value="10" />
                                        <asp:ListItem Text="60%" Value="11" />
                                        <asp:ListItem Text="56%" Value="12" />
                                        <asp:ListItem Text="52%" Value="13" />
                                        <asp:ListItem Text="48%" Value="14" />
                                        <asp:ListItem Text="44%" Value="15" />
                                        <asp:ListItem Text="40%" Value="16" />
                                        <asp:ListItem Text="36%" Value="17" />
                                        <asp:ListItem Text="32%" Value="18" />
                                        <asp:ListItem Text="28%" Value="19" />
                                        <asp:ListItem Text="24%" Value="20" />
                                        <asp:ListItem Text="20%" Value="21" />
                                        <asp:ListItem Text="16%" Value="22" />
                                        <asp:ListItem Text="12%" Value="23" />
                                        <asp:ListItem Text="8%" Value="24" />
                                        <asp:ListItem Text="4%" Value="25" />
                                        <asp:ListItem Text="0%" Value="26" />
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <label style="color: red;"><b>S. R. T.</b></label>
                                    <asp:TextBox ID="txtSRTOD" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                    <br />
                                    <br />
                                    <label style="color: red;"><b>S. D. T.</b></label>
                                    <asp:TextBox ID="txtSDTOD" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="box">
                            <asp:Panel ID="pnlAudioVocalOE" runat="server" Width="100%" BackColor="AliceBlue" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1">
                                <div style="text-align: center;">
                                    <br />
                                    <label style="color: blue;"><b>Média:</b></label>
                                    <asp:TextBox ID="txtMediaOE" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                    <br />
                                    <br />
                                    <label style="color: blue;"><b>I. P. R. F.</b></label>
                                    <asp:DropDownList ID="ddlIPRFoe" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="12" Width="98%" Height="45px" CssClass="cantos-arredondados-alinhamento">
                                        <asp:ListItem Text="" Value="0" />
                                        <asp:ListItem Text="100%" Value="1" />
                                        <asp:ListItem Text="96%" Value="2" />
                                        <asp:ListItem Text="92%" Value="3" />
                                        <asp:ListItem Text="88%" Value="4" />
                                        <asp:ListItem Text="84%" Value="5" />
                                        <asp:ListItem Text="80%" Value="6" />
                                        <asp:ListItem Text="76%" Value="7" />
                                        <asp:ListItem Text="72%" Value="8" />
                                        <asp:ListItem Text="68%" Value="9" />
                                        <asp:ListItem Text="64%" Value="10" />
                                        <asp:ListItem Text="60%" Value="11" />
                                        <asp:ListItem Text="56%" Value="12" />
                                        <asp:ListItem Text="52%" Value="13" />
                                        <asp:ListItem Text="48%" Value="14" />
                                        <asp:ListItem Text="44%" Value="15" />
                                        <asp:ListItem Text="40%" Value="16" />
                                        <asp:ListItem Text="36%" Value="17" />
                                        <asp:ListItem Text="32%" Value="18" />
                                        <asp:ListItem Text="28%" Value="19" />
                                        <asp:ListItem Text="24%" Value="20" />
                                        <asp:ListItem Text="20%" Value="21" />
                                        <asp:ListItem Text="16%" Value="22" />
                                        <asp:ListItem Text="12%" Value="23" />
                                        <asp:ListItem Text="8%" Value="24" />
                                        <asp:ListItem Text="4%" Value="25" />
                                        <asp:ListItem Text="0%" Value="26" />
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <label style="color: blue;"><b>S. R. T.</b></label>
                                    <asp:TextBox ID="txtSRTOE" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                    <br />
                                    <br />
                                    <label style="color: blue;"><b>S. D. T.</b></label>
                                    <asp:TextBox ID="txtSDTOE" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div style="text-align: center;">
                        <br />
                        <div class="box" id="audioVocalOD" runat="server">
                            <asp:Button ID="btnMediaTritonal" runat="server" Text="Média Tritonal (X/3)" BackColor="#00cc99" BorderColor="Green" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnMediaTritonal_Click" />
                        </div>
                        <br />
                        <div class="box" id="audioVocalOE" runat="server">
                            <asp:Button ID="btnMediaQuadritonal" runat="server" Text="Média Quadritonal (X/4)" BackColor="#00cc99" BorderColor="Green" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnMediaQuadritonal_Click" />
                        </div>
                    </div>
                </asp:TableCell>
                <asp:TableCell Width="20%" Height="100%"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
