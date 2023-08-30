<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AudiometriaClinica.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.AudiometriaClinica" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        .container {
            display: flex; /* Define o display como flex */
        }

        .box {
            flex: 1; /* Distribui o espaço igualmente entre as divs */
        }

        .custom-font {
    font-family: "Arial", arial; /* Especifica a fonte personalizada */
  }
    </style>
</head>
<body class="custom-font" style="background-color: lightslategray;">
    <form id="frmAudiometriaClinica" runat="server">
        <asp:Table ID="tbAudiometriaClinica" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
            <asp:TableHeaderRow Width="100%">
                <asp:TableHeaderCell BackColor="#ff0000" Font-Bold="true" Font-Size="14" ForeColor="White" Width="20%" Height="50px">Orelha Direita</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="18" Width="60%" Height="50px">Audiogramas</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#0033cc" Font-Bold="true" Font-Size="14" ForeColor="White" Width="20%" Height="50px">Orelha Esquerda</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell Width="20%" Height="100%" style="vertical-align: bottom">
                    <div id="dadosAudioOD" runat="server" >
                        <asp:Button ID="btnPlotarAudioOD" runat="server" Text="Plotar Gráfico OD" Width="100%" Height="10%" OnClick="btnPlotarAudioOD_Click" />
                    </div>
                </asp:TableCell>
                <asp:TableCell Width="60%" Height="100%">
                    <div class="container" style="text-align: center;">
                        <div class="box" id="audiogramaOD" runat="server">
                            <asp:Chart ID="chartAudioOD" runat="server" Height="416px" Width="467px" BackColor="MistyRose">
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
                        </div>
                        <div class="box" id="audiogramaOE" runat="server">
                            <asp:Chart ID="chartAudioOE" runat="server" Height="416px" Width="467px" BackColor="AliceBlue">
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
                        </div>
                    </div>
                </asp:TableCell>
                <asp:TableCell Width="20%" Height="100%" style="vertical-align: bottom">
                    <div id="dadosAudioOE" runat="server" >
                        <asp:Button ID="btnPlotarAudioOE" runat="server" Text="Plotar Gráfico OE" Width="100%" Height="10%" OnClick="btnPlotarAudioOE_Click" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </form>
</body>
</html>
