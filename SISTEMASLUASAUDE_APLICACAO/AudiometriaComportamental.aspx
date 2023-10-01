<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AudiometriaComportamental.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.AudiometriaComportamental" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Audiometria Comportamental</title>

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
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            text-align: center; /* Centraliza horizontalmente */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */           
            background: linear-gradient(to right, red, #0074D9);
            color: white;
            padding: 10px 20px
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
                <div class="box" style="width: 34%; font-size: 20px;">
                    <b>Audiometria Comportamental</b>
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
                    <asp:Table ID="tbAudiometriaComportGeral" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px"></asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="16" Width="60%" Height="50px">Avaliação do Comportamento Auditivo</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px"></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell Width="20%" Height="100%" Style="vertical-align: bottom">
                                <div id="dadosAudioOD" runat="server">
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="60%" Height="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box" id="audiometriaComport" runat="server">
                                        <asp:Panel ID="pnlAudioComport" runat="server">
                                            <asp:Table ID="audioComportPrimeiraParte" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Instrumento/Intensidade" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" Text="Orelha Direita" BackColor="Red" Font-Bold="true" Font-Size="12" ForeColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" Text="Orelha Esquerda" BackColor="Blue" Font-Bold="true" Font-Size="12" ForeColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Guizo 1 (60 dBNPS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="guizo1odComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="guizo1oeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Guizo 2 (75 dBNPS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="guizo2odComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="guizo2oeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Sino (85 dBNPS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="sinoodComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="sinooeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Black-black (90 dBNPS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="blackblackodComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="blackblackoeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Agogô pequeno (95 dBNPS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="agogoPeqodComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="agogoPeqoeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Agogô grande (100 dBNPS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="agogoGranodComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="agogoGranoeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Chocalho (90 dBNPS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="chocalhoodComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="chocalhooeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Triângulo (90 dBNPS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="trianguloodComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="triangulooeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Prato (95 dBNPS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="pratoodComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="pratooeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Tambor (100 dBPNS):" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="tamborodComboBox" runat="server" Width="100%" Height="40px" BorderColor="Red" BackColor="MistyRose" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="tamboroeComboBox" runat="server" Width="100%" Height="40px" BorderColor="Blue" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <br />
                            </asp:TableCell>
                            <asp:TableCell Width="20%" Height="100%" Style="vertical-align: bottom">
                                <div id="dadosAudioOE" runat="server">
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="AudiometriaComportDemaisAvaliacoes" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px"></asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="16" Width="60%" Height="50px">Demais Avaliações</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px"></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell Width="20%" Height="100%"></asp:TableCell>
                            <asp:TableCell Width="60%" Height="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box">
                                        <asp:Panel ID="pnlAvaliacoesCompletmentares" runat="server" Width="100%">
                                            <asp:Table ID="tbAvaliacoesComplementares" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                                                <asp:TableHeaderRow Width="100%">
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Comportamento Auditivo" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Reações Verbais" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="34%" Height="45px" Text="Ordens Simples" BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="Black" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow>
                                                    <asp:TableHeaderCell Width="34%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="comportamentoAuditComboBox" runat="server" Width="100%" Height="40px" BorderColor="Black" BackColor="White" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="reacoesVerbaisComboBox" runat="server" Width="100%" Height="40px" BorderColor="Black" BackColor="White" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="45px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ordensSimplesComboBox" runat="server" Width="100%" Height="40px" BorderColor="Black" BackColor="White" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" CssClass="cantos-arredondados-alinhamento"></asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="20%" Height="100%"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="tbLegenda" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="16" Width="60%" Height="50px">Legenda</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="40%" Height="50px"></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell Width="60%" Height="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box">
                                        <asp:Panel ID="pnlLegenda" runat="server" Width="100%">
                                            <asp:Image ID="imgLegenda" runat="server" ImageUrl="~/Images/legendaAudioComportamental.png" AlternateText="A imagem da legenda não carregou." Width="100%" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="40%" Height="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box">
                                        <asp:Panel ID="pnlComportamentoAuditivo" runat="server" Width="100%">
                                            <asp:Image ID="imgComportamentoAuditivo" runat="server" ImageUrl="~/Images/comportamentoAuditivo.png" AlternateText="A imagem do comportamento auditivo não carregou." Width="100%" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="tbOutrosDados" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell Text="Conclusões: " Width="20%" Height="50px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Width="80%" Height="50px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                <asp:DropDownList ID="ddlConclusões" runat="server" Width="98.7%" Height="50px" ForeColor="Black" BorderColor="Black"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento-left">
                                </asp:DropDownList>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell Text="Observações e/ou Comentários: " Width="20%" Height="50px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
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
                                                        <asp:TextBox ID="txtAudiometro" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" Enabled="false" ToolTip="Campo não habilitado para esta avaliação." CssClass="cantos-arredondados-alinhamento-left "></asp:TextBox>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="30px">
                                                    <asp:TableHeaderCell Text="Data de Calibração:" Width="50%" Height="30px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="30px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="txtDataCalibracao" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" Enabled="false" ToolTip="Campo não habilitado para esta avaliação." CssClass="cantos-arredondados-alinhamento-left "></asp:TextBox>
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
