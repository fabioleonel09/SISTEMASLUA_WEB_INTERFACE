﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Impedanciometria.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.Impedanciometria" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Impedanciometria</title>

    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (
                (charCode >= 48 && charCode <= 57) || // Números de 0 a 9
                charCode === 44 || // Vírgula (,)
                charCode === 43 || // Sinal de mais (+)
                charCode === 45 // Sinal de menos (-)
            ) {
                return true;
            }
            return false;
        }

        function validateInput(input) {
            var value = input.value;
            if (!/\d/.test(value)) {
                document.getElementById('errorMsgODp').style.display = 'block';
                document.getElementById('errorMsgODc').style.display = 'block';
                document.getElementById('errorMsgODf').style.display = 'block';
                document.getElementById('errorMsgOEp').style.display = 'block';
                document.getElementById('errorMsgOEc').style.display = 'block';
                document.getElementById('errorMsgOEf').style.display = 'block';
            } else {
                document.getElementById('errorMsgODp').style.display = 'none';
                document.getElementById('errorMsgODc').style.display = 'none';
                document.getElementById('errorMsgODf').style.display = 'none';
                document.getElementById('errorMsgOEp').style.display = 'none';
                document.getElementById('errorMsgOEc').style.display = 'none';
                document.getElementById('errorMsgOEf').style.display = 'none';
            }
        }
    </script>

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
            background-color: transparent;
            border: 1px solid #363636;
            color: #333;
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
            background-color: transparent;
            border: 1px solid #363636;
            color: #333;
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
            background-color: transparent;
            border: 1px solid #363636;
            color: #333;
        }
    </style>
</head>
<body class="custom-font" style="background-color: lightslategray;">
    <form id="frmAudiometriaClinica" runat="server" style="width: 100%;">
        <header>
            <div class="container" style="width: 100%;">
                <div class="box" style="width: 15%;">
                    <asp:Button ID="voltaTelaAplicativos" runat="server" OnClick="btnVoltaTelaAplicativos" ToolTip="Volta à tela de Aplicativos" CssClass="btn-Volta-Tela-Aplicativos" />
                    <asp:Button ID="voltaTelaCadastro" runat="server" OnClick="btnVoltaTelaCadastro" ToolTip="Volta à tela de Cadastro" CssClass="btn-Volta-Tela-Cadastro" />
                    <asp:Button ID="voltaTelaExames" runat="server" OnClick="btnVoltaTelaExames" ToolTip="Volta à tela de Exames" CssClass="btn-Volta-Tela-Exames" />
                </div>
                <div class="box" style="width: 70%;">
                    <b>Impedanciometria</b>
                </div>
                <div class="box" style="width: 15%;"></div>
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
                            <asp:TableHeaderCell BackColor="#ff0000" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px">Orelha Direita</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="18" Width="60%" Height="50px">Timpanometria</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#0033cc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px">Orelha Esquerda</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell Width="20%" Height="100%" Style="vertical-align: bottom">
                                <div id="dadosAudioOD" runat="server">
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="60%" Height="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box" id="impOD" runat="server">
                                        <asp:Chart ID="chartODimp" runat="server" BackImageAlignment="Center" Height="454px" Width="545px" BackColor="MistyRose" BorderColor="Red">
                                            <Series>
                                                <asp:Series BorderWidth="2" ChartType="Line" Color="Red" Name="OD">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea BackImageAlignment="Center" Name="ChartArea1">
                                                    <AxisY LineWidth="2" Maximum="2.5" Minimum="0" TextOrientation="Horizontal" Title="(ml) 2,5\n\n\n\n\n\n           2,0\n\n\n\n\n\n          1,5\n\n\n\n\n\n          1,0\n\n\n\n\n\n          0,5\n\n\n\n\n\n\n\n\n          " TitleAlignment="Near" TitleFont="Microsoft Sans Serif, 8.5pt">
                                                        <MajorGrid LineColor="Gray" LineDashStyle="Dash" />
                                                        <MajorTickMark Enabled="False" />
                                                        <LabelStyle Enabled="False" />
                                                    </AxisY>
                                                    <AxisX Crossing="0" Interval="100" LineWidth="2" Maximum="200" Minimum="-600" Title="Pressão (mml H2O = daPa)" TitleAlignment="Near">
                                                        <MajorGrid LineColor="Gray" LineDashStyle="Dash" />
                                                    </AxisX>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                    <div class="box" id="impOE" runat="server">
                                        <asp:Chart ID="chartOEimp" runat="server" BackImageAlignment="Center" Height="454px" Width="545px" BackColor="AliceBlue" BorderColor="Blue">
                                            <Series>
                                                <asp:Series BorderWidth="2" ChartType="Line" Color="Blue" Name="OE">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea BackImageAlignment="Center" Name="ChartArea1">
                                                    <AxisY LineWidth="2" Maximum="2.5" Minimum="0" TextOrientation="Horizontal" Title="(ml) 2,5\n\n\n\n\n\n           2,0\n\n\n\n\n\n          1,5\n\n\n\n\n\n          1,0\n\n\n\n\n\n          0,5\n\n\n\n\n\n\n\n\n          " TitleAlignment="Near" TitleFont="Microsoft Sans Serif, 8.5pt">
                                                        <MajorGrid LineColor="Gray" LineDashStyle="Dash" />
                                                        <MajorTickMark Enabled="False" />
                                                        <LabelStyle Enabled="False" />
                                                    </AxisY>
                                                    <AxisX Crossing="0" Interval="100" LineWidth="2" Maximum="200" Minimum="-600" Title="Pressão (mml H2O = daPa)" TitleAlignment="Near">
                                                        <MajorGrid LineColor="Gray" LineDashStyle="Dash" />
                                                    </AxisX>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                                <br />
                                <div class="container" style="text-align: center;">
                                    <div class="box">
                                        <asp:Panel ID="pnlGridDadosOD" runat="server" Width="100%" BackColor="MistyRose" BorderColor="Red" BorderStyle="Solid" BorderWidth="1">
                                            <asp:Table ID="tbDadosOD" runat="server" Width="100%">
                                                <asp:TableHeaderRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14">
                                                    <asp:TableHeaderCell Width="34%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Pressão (daPa):</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="pressaoodTextBox" runat="server" onkeypress="return isNumberKey(event)" onkeyup="validateInput(this)" Height="50px" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento">
                                                        </asp:TextBox>
                                                        <span id="errorMsgODp" style="color: red; display: none;">Por favor, insira pelo menos um número válido.</span>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>   
                                                </asp:TableHeaderRow>
                                                <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14" >
                                                    <asp:TableCell Width="34%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Complacência (ml):</asp:TableCell>
                                                    <asp:TableCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="complodTextBox" runat="server" onkeypress="return isNumberKey(event)" onkeyup="validateInput(this)" Height="50px" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento">
                                                        </asp:TextBox>
                                                        <span id="errorMsgODc" style="color: red; display: none;">Por favor, insira pelo menos um número válido.</span>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                    </asp:TableCell> 
                                                </asp:TableRow>
                                                <asp:TableRow Width="100%" ForeColor="Red" Font-Bold="true" Font-Size="14" >
                                                    <asp:TableCell Width="34%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Curva fecha em (daPa):</asp:TableCell>
                                                    <asp:TableCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="fechaodTextBox" runat="server" onkeypress="return isNumberKey(event)" onkeyup="validateInput(this)" Height="50px" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento">
                                                        </asp:TextBox>
                                                        <span id="errorMsgODf" style="color: red; display: none;">Por favor, insira pelo menos um número válido.</span>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="curvaBodCheckBox" runat="server" Text="curva tipo B"/>
                                                    </asp:TableCell> 
                                                </asp:TableRow>
                                            </asp:Table>
                                        </asp:Panel>
                                    </div>
                                    <div class="box">
                                        <asp:Panel ID="pnlGridDadosOE" runat="server" Width="100%" BackColor="AliceBlue" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1">
                                            <asp:Table ID="tbDadosOE" runat="server" Width="100%">
                                                <asp:TableHeaderRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14">
                                                    <asp:TableHeaderCell Width="34%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Pressão (daPa):</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="pressaooeTextBox" runat="server" onkeypress="return isNumberKey(event)" onkeyup="validateInput(this)" Height="50px" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento">
                                                        </asp:TextBox>
                                                        <span id="errorMsgOEp" style="color: red; display: none;">Por favor, insira pelo menos um número válido.</span>
                                                    </asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>   
                                                </asp:TableHeaderRow>
                                                <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14" >
                                                    <asp:TableCell Width="34%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Complacência (ml):</asp:TableCell>
                                                    <asp:TableCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="comploeTextBox" runat="server" onkeypress="return isNumberKey(event)" onkeyup="validateInput(this)" Height="50px" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento">
                                                        </asp:TextBox>
                                                        <span id="errorMsgOEc" style="color: red; display: none;">Por favor, insira pelo menos um número válido.</span>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                    </asp:TableCell> 
                                                </asp:TableRow>
                                                <asp:TableRow Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="14" >
                                                    <asp:TableCell Width="34%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">Curva fecha em (daPa):</asp:TableCell>
                                                    <asp:TableCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:TextBox ID="fechaoeTextBox" runat="server" onkeypress="return isNumberKey(event)" onkeyup="validateInput(this)" Height="50px" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" CssClass="cantos-arredondados-alinhamento">
                                                        </asp:TextBox>
                                                        <span id="errorMsgOEf" style="color: red; display: none;">Por favor, insira pelo menos um número válido.</span>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="33%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:CheckBox ID="curvaBoeCheckBox" runat="server" Text="curva tipo B"/>
                                                    </asp:TableCell> 
                                                </asp:TableRow>
                                            </asp:Table>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <br />
                                <div id="btnPlotaTodos" runat="server" style="text-align: center;">
                                    <asp:Button ID="btnPlotaGeral" runat="server" Text="Plotar" BorderColor="#4B0082" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnPlotarGeral_Click" />
                                </div>
                                <br />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="AudiometriaVocalClinica" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell BackColor="#ff0000" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px">Orelha Direita</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="18" Width="60%" Height="50px">Audiometria Vocal</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#0033cc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="20%" Height="50px">Orelha Esquerda</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell Width="20%" Height="100%"></asp:TableCell>
                            <asp:TableCell Width="60%" Height="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box">
                                        <asp:Panel ID="pnlAudioVocalOD" runat="server" Width="100%" BackColor="MistyRose" BorderColor="Red" BorderStyle="Solid" BorderWidth="1">
                                            <div style="text-align: center;">
                                                <br />
                                                <asp:Label ID="lblMediaOD" runat="server" Text="Média:" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                <asp:TextBox ID="mEDIAodTextBox" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
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
                                                <label style="color: red;"><b>S. R. T. (dBNA)</b></label>
                                                <asp:TextBox ID="txtSRTOD" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="1" ForeColor="Red" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                                <br />
                                                <br />
                                                <label style="color: red;"><b>S. D. T. (dBNA)</b></label>
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
                                                <asp:Label ID="lblMediaOE" runat="server" Text="Média:" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                                <asp:TextBox ID="mEDIAoeTextBox" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
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
                                                <label style="color: blue;"><b>S. R. T. (dBNA)</b></label>
                                                <asp:TextBox ID="txtSRTOE" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1" ForeColor="Blue" Font-Bold="true" Font-Size="14" Width="95%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                                                <br />
                                                <br />
                                                <label style="color: blue;"><b>S. D. T. (dBNA)</b></label>
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
                                        <asp:Button ID="btnMediaTritonal" runat="server" Text="Média Tritonal (X/3)" BorderColor="#4B0082" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnMediaTritonal_Click" />
                                    </div>
                                    <br />
                                    <div class="box" id="audioVocalOE" runat="server">
                                        <asp:Button ID="btnMediaQuadritonal" runat="server" Text="Média Quadritonal (X/4)" BorderColor="#4B0082" BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="18" Width="100%" Height="50px" CssClass="cantos-arredondados-hand" OnClick="btnMediaQuadritonal_Click" />
                                    </div>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="20%" Height="100%"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="tbLaudoParecer" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell BackColor="#ff0000" Font-Bold="true" Font-Size="12" ForeColor="White" Width="10%" Height="50px">Orelha Direita</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#cccccc" Font-Bold="true" Font-Size="18" Width="80%" Height="50px">Laudo ou Parecer Fonoaudiológicos</asp:TableHeaderCell>
                            <asp:TableHeaderCell BackColor="#0033cc" Font-Bold="true" Font-Size="12" ForeColor="White" Width="10%" Height="50px">Orelha Esquerda</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell Width="10%" Height="100%" Style="vertical-align: bottom"></asp:TableCell>
                            <asp:TableCell Width="80%" Height="100%">
                                <div class="container" style="text-align: center;">
                                    <div class="box" id="LaudoOD" runat="server">
                                        <asp:Panel ID="pnlLaudoOD" runat="server" Width="100%" BackColor="MistyRose" BorderColor="Red"
                                            BorderStyle="Solid" BorderWidth="1">
                                            <asp:Table ID="tbLaudoOD" runat="server" Width="100%">
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="Audição normal?" Width="50%" Height="50px" ForeColor="Red" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlAudicaoNormalOD" runat="server" Width="100%" Height="50px" ForeColor="Red" BorderColor="Red"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="Curva audiométrica do tipo:" Width="50%" Height="50px" ForeColor="Red" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlCurvaTipoOD" runat="server" Width="100%" Height="50px" ForeColor="Red" BorderColor="Red"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="De grau:" Width="50%" Height="50px" ForeColor="Red" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlDeGrauOD" runat="server" Width="100%" Height="50px" ForeColor="Red" BorderColor="Red"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="De configuração:" Width="50%" Height="50px" ForeColor="Red" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlDeConfigOD" runat="server" Width="100%" Height="50px" ForeColor="Red" BorderColor="Red"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="E audiometria vocal:" Width="50%" Height="50px" ForeColor="Red" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlEaudioVocalOD" runat="server" Width="100%" Height="50px" ForeColor="Red" BorderColor="Red"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </asp:Panel>
                                    </div>
                                    <div class="box" id="LaudoOE" runat="server">
                                        <asp:Panel ID="pnlLaudoOE" runat="server" Width="100%" BackColor="AliceBlue" BorderColor="Blue"
                                            BorderStyle="Solid" BorderWidth="1">
                                            <asp:Table ID="tbLaudoOE" runat="server" Width="100%">
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="Audição normal?" Width="50%" Height="50px" ForeColor="Blue" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlAudicaoNormalOE" runat="server" Width="100%" Height="50px" ForeColor="Blue" BorderColor="Blue"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="Curva audiométrica do tipo:" Width="50%" Height="50px" ForeColor="Blue" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlCurvaTipoOE" runat="server" Width="100%" Height="50px" ForeColor="Blue" BorderColor="Blue"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="De grau:" Width="50%" Height="50px" ForeColor="Blue" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlDeGrauOE" runat="server" Width="100%" Height="50px" ForeColor="Blue" BorderColor="Blue"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="De configuração:" Width="50%" Height="50px" ForeColor="Blue" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlDeConfigOE" runat="server" Width="100%" Height="50px" ForeColor="Blue" BorderColor="Blue"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                                <asp:TableHeaderRow Width="100%" Height="50px">
                                                    <asp:TableHeaderCell Text="E audiometria vocal:" Width="50%" Height="50px" ForeColor="Blue" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Width="50%" Height="50px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1">
                                                        <asp:DropDownList ID="ddlEaudioVocalOE" runat="server" Width="100%" Height="50px" ForeColor="Blue" BorderColor="Blue"
                                                            BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="12"
                                                            CssClass="cantos-arredondados-alinhamento">
                                                        </asp:DropDownList>
                                                    </asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="10%" Height="100%" Style="vertical-align: bottom"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="tbOutrosDados" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell Text="Mascaramento tonal/fala:" Width="20%" Height="50px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Width="80%" Height="50px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                <asp:TextBox ID="txtMascaramentoComent" runat="server" TextMode="MultiLine" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" CssClass="cantos-arredondados-alinhamento-left "></asp:TextBox>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell Text="Comentários: " Width="20%" Height="50px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Width="80%" Height="50px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                <asp:TextBox ID="txtComentariosGerais" runat="server" TextMode="MultiLine" BackColor="#ffff99" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" CssClass="cantos-arredondados-alinhamento-left "></asp:TextBox>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableHeaderRow Width="100%">
                            <asp:TableHeaderCell Text="Laudos/Autores: " Width="20%" Height="50px" BackColor="White" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Width="80%" Height="50px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                                <asp:DropDownList ID="ddlLaudos" runat="server" Width="98.7%" Height="50px" ForeColor="Black" BorderColor="Black"
                                    BorderStyle="Solid" BorderWidth="1" Font-Bold="true" Font-Size="8"
                                    CssClass="cantos-arredondados-alinhamento-left">
                                </asp:DropDownList>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="tbDadosComplementares" runat="server" Width="100%" BorderColor="#cccccc" BorderWidth="2px" BorderStyle="Solid">
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
