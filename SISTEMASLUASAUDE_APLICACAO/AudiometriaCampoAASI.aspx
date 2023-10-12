<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AudiometriaCampoAASI.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.AudiometriaCampoAASI" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Audiometria em Campo (AASI)</title>

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
            font-size: large;
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
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            text-align: center; /* Centraliza horizontalmente */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */           
            background: linear-gradient(to right, #696969, #C0C0C0);
            color: black;
            padding: 10px 20px;
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

        .cantos-arredondados-hand:hover {
            transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
        }

        .cantos-arredondados-alinhamento {
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            text-align: center; /* Centraliza horizontalmente */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
        }

        .cantos-arredondados-alinhamento-left {
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            text-align: left; /* Centraliza horizontalmente */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
        }

        .alinhamento-text-center {
            text-align: center; /* Centraliza horizontalmente */
        }

        .TextBox-Legenda {
            font-family: "Arial", arial; /* Especifica a fonte personalizada */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
        }

        .btn-Imprimir {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/imprimirMaior.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: auto; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

        .btn-Imprimir:hover {
            transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
        }

        .btn-Volta-Tela-Cadastro {
            width: 50px;
            height: 50px;
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/voltaTelaCadastro.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: 30px; /* Ajuste o tamanho da imagem conforme necessário */
            background-color: #333;
            border: 1px solid #363636;
            color: #333;
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

        .btn-Volta-Tela-Cadastro:hover {
            transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
        }

        .btn-Volta-Tela-Exames {
            width: 50px;
            height: 50px;
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */       
            background-image: url('./Images/voltaTelaExames.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: 30px; /* Ajuste o tamanho da imagem conforme necessário */
            background-color: #333;
            border: 1px solid #363636;
            color: #333;
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

        .btn-Volta-Tela-Exames:hover {
            transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
        }

        .btn-Volta-Tela-Aplicativos {
            width: 50px;
            height: 50px;
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */       
            background-image: url('./Images/voltaTelaAplicativos.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: 30px; /* Ajuste o tamanho da imagem conforme necessário */
            background-color: #333;
            border: 1px solid #363636;
            color: #333;
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

        .btn-Volta-Tela-Aplicativos:hover {
            transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
        }
    </style>
</head>
<body class="custom-font" style="background-color: lightslategray;">
    <form id="frmAudiometriaClinica" runat="server" style="width: 100%;">
        <header>
            <div class="container" style="width: 100%;">
                <div class="box" style="width: 33%;">
                    <asp:Button id="voltaTelaAplicativos" runat="server" OnClick="btnVoltaTelaAplicativos" ToolTip="Volta à tela de Aplicativos" CssClass="btn-Volta-Tela-Aplicativos"/>
                    <asp:Button id="voltaTelaCadastro" runat="server" OnClick="btnVoltaTelaCadastro" ToolTip="Volta à tela de Cadastro" CssClass="btn-Volta-Tela-Cadastro"/>
                    <asp:Button id="voltaTelaExames" runat="server" OnClick="btnVoltaTelaExames" ToolTip="Volta à tela de Exames" CssClass="btn-Volta-Tela-Exames"/>
                </div>
                <div class="box" style="width: 34%;">
                    <b>Audiometria em Campo (Ganho Funcional)</b>
                </div>
                <div class="box" style="width: 33%;"></div>
            </div>
        </header>
        <br />
        <div id="geral" runat="server" style="margin-top: 50px; margin-bottom: 50px; width: 100%; height: 100%; align-items: stretch; vertical-align: central">
            <asp:Label ID="lblBoasVindas" runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large"></asp:Label>
            <div class="container" style="text-align: center; width: 100%;">
                <div class="box">
                    <br />
                    <div style="width: 100%; background-color: white; text-align: left; vertical-align: bottom;">
                        <asp:Label ID="lblNomePaciente" runat="server" Font-Bold="true" Font-Size="14"></asp:Label>
                        <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                        <asp:Label ID="lblIdadePaciente" runat="server" Font-Bold="true" Font-Size="14"></asp:Label>
                        <br />
                        <asp:Label ID="lblNomeSocialPaciente" runat="server" Font-Bold="true" Font-Size="14"></asp:Label>
                        <br />
                        <asp:Label ID="lblDataHoje" runat="server" Font-Bold="true" Font-Size="14"></asp:Label>
                    </div>
                    <asp:Table ID="tbAudiometriaClinica" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px"></asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="18" Width="60%" Height="50px">Audiometria Tonal</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px"></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell Width="20%" Height="100%" Style="vertical-align: bottom">
                                <div id="dadosAudioOD" runat="server">
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="60%" Height="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box" id="audiogramaAASI" runat="server">
                                        <asp:Chart ID="chartAudioEmCampo" runat="server" Height="416px" Width="467px" BackColor="#c0c0c0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1">
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
                                        <asp:RadioButtonList ID="rbBananaFalaEmCampo" runat="server" RepeatDirection="Horizontal" ForeColor="Black" BackColor="#cccccc" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12" Width="100%">
                                            <asp:ListItem Text="Exibe a Banana da Fala" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Oculta a Banana da Fala" Value="1"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <br />
                                <div class="container" style="text-align: center;">
                                    <div class="box">
                                        <asp:Panel ID="pnlGridDadosOD" runat="server" Width="100%" BackColor="#cccccc" BorderColor="Black" BorderStyle="Solid" BorderWidth="1">
                                            <asp:Table ID="tbDadosOD" runat="server" Width="100%">
                                                <asp:TableHeaderRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14">
                                                    <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Hz</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Com AASI (dBNPS)</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">M</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">L</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">A</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Sem AASI (dBNPS)</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">M</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">L</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">A</asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14" Enabled="false">
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">125</asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14">
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
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14">
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">500</asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="com500ComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente500comCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="sem500ComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente500semCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14" Enabled="false">
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
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14">
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">1k</asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="com1kComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chbLiga500_1k_comCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente1kcomCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="sem1kComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chbLiga500_1k_semCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente1ksemCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14" Enabled="false">
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
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14">
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">2k</asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="com2KComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chbLiga1k_2k_comCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente2kcomCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="sem2KComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chbLiga1k_2k_semCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente2ksemCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14">
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">3k</asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="com3kComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chbLiga2k_3k_comCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente3kcomCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="sem3kComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chbLiga2k_3k_semCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente3ksemCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14">
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">4k</asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="com4kComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chbLiga3k_4k_comCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente4kcomCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="15%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="sem4kComboBox" runat="server" Width="100%" Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chbLiga3k_4k_semCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="10%" Height="30px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="chkAusente4ksemCheckBox" runat="server" />
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14">
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
                                                <asp:TableRow Width="100%" ForeColor="Black" Font-Bold="true" Font-Size="14">
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
                                <asp:Panel ID="pnlLegenda" runat="server" Width="99.6%" HorizontalAlign="Justify">
                                    <asp:TextBox ID="txtLegenda" runat="server" Width="99.6%" Height="100%" TextMode="MultiLine" Text="Legenda: <br /> Hz = Hertz; VA = Via Aérea; VO = Via Óssea; M = simbologia de mascaramento; L = liga simbologia;              A = simbologia de ausência de resposta." Enabled="false" CssClass="TextBox-Legenda"></asp:TextBox>
                                </asp:Panel>
                                <br />
                                <div id="btnPlotaTodos" runat="server" style="text-align: center;">
                                    <asp:Button ID="btnPlotaGeral" runat="server" Text="Plotar" BorderColor="black" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnPlotarGeral_Click" />
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
                    <asp:Table ID="AudiometriaVocalEmCampo" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="12" Width="20%" Height="50px">Com AASI</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="18" Width="60%" Height="50px">Audiometria Vocal</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="12" Width="20%" Height="50px">Sem AASI</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell Width="20%" Height="100%"></asp:TableCell>
                            <asp:TableCell Width="60%" Height="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box">
                                        <asp:Panel ID="pnlAudioVocalComAASI" runat="server" Width="100%" BackColor="#cccccc" BorderColor="Black" BorderStyle="Solid" BorderWidth="1">
                                            <div style="text-align: center;">
                                                <br />
                                                <asp:Label ID="lblMediaComAASI" runat="server" Text="Média:" ForeColor="Black" Font-Bold="true"></asp:Label>
                                                <asp:TextBox ID="comMEDIATextBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                                <br />
                                                <br />
                                                <label style="color: black;"><b>I. P. R. F. (%)</b></label><br />
                                                <div class="box">
                                                    <div style="float: left; width: 50%">
                                                        <asp:Panel ID="pnlIPRFmomComAASI" runat="server" Width="100%">
                                                            <label style="color: black;"><b>MON.:</b></label><br />
                                                            <asp:DropDownList ID="comMONComboBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" Width="93%" Height="45px" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                        </asp:Panel>
                                                    </div>
                                                    <div style="float: left; width: 50%">
                                                        <asp:Panel ID="pnlIPRFdissComAASI" runat="server" Width="100%">
                                                            <label style="color: black;"><b>DISS.:</b></label><br />
                                                            <asp:DropDownList ID="comDISSComboBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" Width="93%" Height="45px" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                        </asp:Panel>
                                                        <br />
                                                    </div>
                                                </div>
                                                <label style="color: black;"><b>S. R. T. (dBNA)</b></label>
                                                <asp:TextBox ID="comSRTTextBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                                <br />
                                                <br />
                                                <label style="color: black;"><b>S. D. T. (dBNA)</b></label>
                                                <asp:TextBox ID="comSDTTextBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                                <br />
                                                <br />
                                            </div>
                                        </asp:Panel>
                                    </div>
                                    <div class="box">
                                        <asp:Panel ID="pnlAudioVocalSemAASI" runat="server" Width="100%" BackColor="#cccccc" BorderColor="Black" BorderStyle="Solid" BorderWidth="1">
                                            <div style="text-align: center;">
                                                <br />
                                                <asp:Label ID="lblMediaSemAASI" runat="server" Text="Média:" ForeColor="Black" Font-Bold="true"></asp:Label>
                                                <asp:TextBox ID="semMEDIATextBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                                <br />
                                                <br />
                                                <label style="color: black;"><b>I. P. R. F. (%)</b></label>
                                                <div class="box">
                                                    <div style="float: left; width: 50%">
                                                        <asp:Panel ID="pnlIPRFmonSemAASI" runat="server" Width="100%">
                                                            <label style="color: black;"><b>MON.:</b></label><br />
                                                            <asp:DropDownList ID="semMONComboBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="93%" Height="45px" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                        </asp:Panel>
                                                    </div>
                                                    <div style="float: left; width: 50%">
                                                        <asp:Panel ID="pnlIPRFdisSemAASI" runat="server" Width="100%">
                                                            <label style="color: black;"><b>DISS.:</b></label><br />
                                                            <asp:DropDownList ID="semDISSComboBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="93%" Height="45px" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                        </asp:Panel>
                                                        <br />
                                                    </div>
                                                </div>
                                                <label style="color: black;"><b>S. R. T. (dBNA)</b></label>
                                                <asp:TextBox ID="semSRTTextBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                                <br />
                                                <br />
                                                <label style="color: black;"><b>S. D. T. (dBNA)</b></label>
                                                <asp:TextBox ID="semSDTTextBox" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                                <br />
                                                <br />
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div style="text-align: center;">
                                    <br />
                                    <div class="box" id="audioVocalOD" runat="server">
                                        <asp:Button ID="btnMediaTritonal" runat="server" Text="Média Tritonal (X/3)" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnMediaTritonal_Click" />
                                    </div>
                                    <br />
                                    <div class="box" id="audioVocalOE" runat="server">
                                        <asp:Button ID="btnMediaQuadritonal" runat="server" Text="Média Quadritonal (X/4)" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnMediaQuadritonal_Click" />
                                    </div>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="20%" Height="100%"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="tbOutrosDados" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell Text="Comentários: " Width="20%" Height="50px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Width="80%" Height="50px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                <asp:TextBox ID="txtComentariosGerais" runat="server" TextMode="MultiLine" BackColor="#ffff99" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" CssClass="cantos-arredondados-alinhamento-left "></asp:TextBox>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="tbDadosComplementares" runat="server"  Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell Width="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box">
                                        <asp:Panel ID="pnlDadosComplementaresPrimeiro" runat="server" Width="100%">
                                            <asp:Table ID="tbDadosComplementaresPrimeiro" runat="server" Width="100%">
                                                <asp:TableHeaderRow Width="100%" Height="30px">
                                                    <asp:TableHeaderCell Text="Audiômetro:" Width="50%" Height="30px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="30px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="txtAudiometro" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" CssClass="cantos-arredondados-alinhamento-left "></asp:TextBox>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="30px">
                                                    <asp:TableHeaderCell Text="Data de Calibração:" Width="50%" Height="30px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="30px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="txtDataCalibracao" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" CssClass="cantos-arredondados-alinhamento-left "></asp:TextBox>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </asp:Panel>
                                    </div>
                                    <div class="box">
                                        <asp:Panel ID="pnlDadosComplementaresSegundo" runat="server" Width="100%">
                                            <asp:Table ID="tbDadosComplementaresSegundo" runat="server" Width="100%">
                                                <asp:TableHeaderRow Width="100%" Height="30px">
                                                    <asp:TableHeaderCell Text="Examinador:" Width="20%" Height="30px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="80%" Height="30px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="txtExaminador" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" CssClass="cantos-arredondados-alinhamento-left "></asp:TextBox>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="30px">
                                                    <asp:TableHeaderCell Text="Data de hoje:" Width="20%" Height="30px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="80%" Height="30px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="txtDataHoje" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" CssClass="cantos-arredondados-alinhamento-left "></asp:TextBox>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="tbImprimir" runat="server" Width="100%">
                <asp:TableHeaderRow Width="100%">
                    <asp:TableHeaderCell Width="20%" Height="150px"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="150px"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="150px">
                        <asp:Button ID="btnImprimir" runat="server" Width="100%" Height="100%" OnClick="btnImprimir_Click" CssClass="btn-Imprimir" />
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="150px"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="150px"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                        </asp:Table>
                </div>
            </div>
        </div>
        <footer>
            <b>Sistemas Lua de Gerenciamento EIRELI. CNPJ: 34.648.108/0001-07. Todos os direitos reservados. 2023. <a href="http://lattes.cnpq.br/5576683103146306" style="color: yellow; text-decoration: none;">Sobre o desenvolvedor.</a><a>&nbsp;&nbsp;&nbsp;</a><a href="https://www.linkedin.com/in/f%C3%A1bio-leonel-do-nascimento-0442b215b/" style="color: yellow; text-decoration: none;">Contato.</a></b>
        </footer>
    </form>
</body>

</html>
