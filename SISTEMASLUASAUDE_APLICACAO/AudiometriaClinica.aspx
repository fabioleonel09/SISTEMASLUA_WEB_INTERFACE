<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AudiometriaClinica.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.AudiometriaClinica" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        footer {
            position: fixed;
            bottom: 0;
            left: 0; /* Certifique-se de que o rodapé comece da borda esquerda */
            width: 100%;
            margin: 0; /* Margem zero para evitar espaçamento indesejado */
            padding: 0; /* Preenchimento zero para evitar espaçamento indesejado */
            height: 50px; /* Defina a altura do rodapé conforme necessário */
            background-color: #333; /* Cor de fundo do rodapé */
            color: #fff; /* Cor do texto do rodapé */
            text-align: center;
            line-height: 50px; /* Centralizar verticalmente o conteúdo do rodapé */
            font-size: small;
            font-family: Arial;
        }

        header {
            position: fixed;
            top: 0;
            left: 0; /* Certifique-se de que o cabeçalho comece da borda esquerda */
            right: 0;
            width: 100%;
            margin: 0; /* Margem zero para evitar espaçamento indesejado */
            padding: 0; /* Preenchimento zero para evitar espaçamento indesejado */
            height: 50px; /* Defina a altura do rodapé conforme necessário */
            background-color: #333; /* Cor de fundo do rodapé */
            color: #fff; /* Cor do texto do rodapé */
            text-align: center;
            line-height: 50px; /* Centralizar verticalmente o conteúdo do rodapé */
            font-size: x-large;
            font-family: Arial;
        }

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
    <form id="frmAudiometriaClinica" runat="server" style="width: 100%;">
        <header>
            <b>Audiometria Clínica</b>
        </header>
        <br />
        <div id="geral" runat="server" style="margin-top: 50px; margin-bottom: 50px; width: 100%; height: 100%; align-items: center; vertical-align: central">
            <div class="container" style="text-align: right; width: 100%;">
                <asp:Label ID="lblBoasVindas" runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large"></asp:Label>
            </div>
            <br />
            <div style="width: 100%; background-color: white; text-align: left; vertical-align: bottom;">
                <asp:Label ID="lblNomePaciente" runat="server" Font-Bold="true" Font-Size="14" ></asp:Label>
                <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                <asp:Label ID="lblIdadePaciente" runat="server" Font-Bold="true" Font-Size="14" ></asp:Label>
                <br />
                <asp:Label ID="lblNomeSocialPaciente" runat="server" Font-Bold="true" Font-Size="14" ></asp:Label>
                <br />
                <asp:Label ID="lblDataHoje" runat="server" Font-Bold="true" Font-Size="14" ></asp:Label>
            </div>
            <asp:Table ID="tbAudiometriaClinica" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                <asp:TableHeaderRow Width="100%">
                    <asp:TableHeaderCell BackColor="#ff0000" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px">Orelha Direita</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="18" Width="60%" Height="50px">Audiometria Tonal</asp:TableHeaderCell>
                    <asp:TableHeaderCell BackColor="#0033cc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px">Orelha Esquerda</asp:TableHeaderCell>
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
                        <div class="container" style="text-align: center;">
                            <div class="box">
                                <asp:Panel ID="pnlGridDadosOD" runat="server" Width="100%" BackColor="MistyRose" BorderColor="Red" BorderStyle="Solid" BorderWidth="1">
                                    <asp:Table ID="tbDadosOD" runat="server" Width="100%">
                                        <asp:TableHeaderRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Hz</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">VA</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">M</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">L</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">A</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">VO</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">M</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">L</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">A</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">125</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                <asp:DropDownList ID="va125odComboBox" runat="server" Width="100%" Height="30px" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                            </asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                <asp:CheckBox ID="masc125vaODCheckBox" runat="server" />
                                            </asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                <asp:CheckBox ID="aus125vaODCheckBox" runat="server" />
                                            </asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">250</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">500</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">750</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">1k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">1,5k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">2k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">3k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">4k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">6k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">8k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:Panel>
                            </div>
                            <div class="box">
                                <asp:Panel ID="pnlGridDadosOE" runat="server" Width="100%" BackColor="AliceBlue" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1">
                                    <asp:Table ID="tbDadosOE" runat="server" Width="100%">
                                        <asp:TableHeaderRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Hz</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">VA</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">M</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">L</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">A</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">VO</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">M</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">L</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">A</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">125</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                <asp:DropDownList ID="va125oeComboBox" runat="server" Width="100%" Height="30px" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                            </asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                <asp:CheckBox ID="masc125vaOECheckBox" runat="server" />
                                            </asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                <asp:CheckBox ID="aus125vaOECheckBox" runat="server" />
                                            </asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">250</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">500</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">750</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">1k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">1,5k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">2k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">3k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">4k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">6k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">8k</asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                            <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:Panel>
                            </div>
                        </div>
                        <asp:Panel ID="pnlLegenda" runat="server" Width="99.6%" HorizontalAlign="Justify" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                            <asp:TextBox ID="txtLegenda" runat="server" Width="99.6%" Enabled="false">Legenda: Hz = Hertz; VA = Via Aérea; VO = Via Óssea; M = simbologia de mascaramento; L = liga simbologia; A = simbologia de ausência de resposta.</asp:TextBox>
                        </asp:Panel>
                        <br />
                        <div id="btnPlotaTodos" runat="server" style="text-align: center;">
                            <asp:Button ID="btnPlotaGeral" runat="server" Text="Plotar" BackColor="#00cc99" BorderColor="Green" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnPlotarGeral_Click" />
                        </div>
                        <br />
                        <asp:Panel ID="pnlSimbologiaAudiometrica" runat="server" Width="100%">
                            <asp:Image ID="imgSimbologiaAudiometrica" runat="server" ImageUrl="~/Images/Simbologia.png" AlternateText="A imagem da simbologia não carregou." Width="100%" />
                        </asp:Panel>
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
                                        <label style="color: red;"><b>I. P. R. F.</b></label><br />
                                        <div class="box">
                                            <div style="float: left; width: 50%">
                                                <asp:Panel ID="pnlIPRFmomOd" runat="server" Width="100%">
                                                    <label style="color: red;"><b>MON.:</b></label><br />
                                                    <asp:DropDownList ID="ddlIPRFmonOd" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" Width="93%" Height="45px" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                </asp:Panel>
                                            </div>
                                            <div style="float: left; width: 50%">
                                                <asp:Panel ID="pnlIPRFdissOd" runat="server" Width="100%">
                                                    <label style="color: red;"><b>DISS.:</b></label><br />
                                                    <asp:DropDownList ID="ddlIPRFdisOd" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" Width="93%" Height="45px" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                </asp:Panel>
                                                <br />
                                            </div>
                                        </div>
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
                                        <div class="box">
                                            <div style="float: left; width: 50%">
                                                <asp:Panel ID="pnlIPRFmonOe" runat="server" Width="100%">
                                                    <label style="color: blue;"><b>MON.:</b></label><br />
                                                    <asp:DropDownList ID="ddlIPRFmonOe" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="12" Width="93%" Height="45px" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                </asp:Panel>
                                            </div>
                                            <div style="float: left; width: 50%">
                                                <asp:Panel ID="pnlIPRFdisOe" runat="server" Width="100%">
                                                    <label style="color: blue;"><b>DISS.:</b></label><br />
                                                    <asp:DropDownList ID="ddlIPRFdisOe" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="12" Width="93%" Height="45px" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                </asp:Panel>
                                                <br />
                                            </div>
                                        </div>
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
        </div>
        <footer>
            <b>Sistemas Lua de Gerenciamento EIRELI. CNPJ: 34.648.108/0001-07. Todos os direitos reservados. 2023.</b>
        </footer>
    </form>
</body>

</html>
