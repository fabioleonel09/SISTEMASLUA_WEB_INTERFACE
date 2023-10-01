<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroInicial.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.CadastroInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.1/moment.min.js"></script>

    <title>Aplicativos</title>
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
            left: 0; /* Certifique-se de que o rodapé comece da borda esquerda */
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
            display: flex; /* Define o display como flex */
        }

        .custom-font {
            font-family: "Arial", arial; /* Especifica a fonte personalizada */
        }

        .cantos-arredondados-alinhamento {
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            text-align: left; /* Centraliza horizontalmente */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
        }

        .btn-Caracol {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/caracolFundo.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

        .btn-Caracol:hover {
            transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
        }
    </style>
</head>
<body class="custom-font" style="background-color: lightslategray;">
    <form id="form1" runat="server" style="width: 100%; height: 100%">
        <header>
            <b>Audiologia: Cadastro Inicial</b>
        </header>
        <div id="geral" runat="server" style="margin-top: 50px; margin-bottom: 50px; width: 100%; height: 100%; align-items: center; vertical-align: central">
            <br />
            <div class="container" style="text-align: right; width: 100%;">
                <asp:Label ID="lblBoasVindas" runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large"></asp:Label>
            </div>
            <br />
            <div style="width: 100%; background-color: white; text-align: center; vertical-align: bottom;">
                <asp:Label ID="lblTituloCabecalho" runat="server" Text="Dados do Paciente" Font-Bold="true" Font-Size="18" ></asp:Label>
            </div>
            <br />
            <asp:Table ID="tbDadosPacientePrimeiraParte" runat="server" Width="100%">
                <asp:TableHeaderRow Width="100%">
                    <asp:TableHeaderCell Text="Nome do Paciente:" Width="20%" Height="40px" BackColor="#cccccc" Font-Bold="true" Font-Size="14" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                    <asp:TableheaderCell Width="45%" Height="40px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                        <asp:TextBox ID="txtNomePaciente" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="99%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                    </asp:TableheaderCell>
                    <asp:TableHeaderCell Text="Idade:" Width="10%" Height="40px" BackColor="#cccccc" Font-Bold="true" Font-Size="14" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="25%" Height="40px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                        <asp:TextBox ID="txtIdade" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="40px" ToolTip="Digite a D.N. para calcular a idade." ClientIDMode="Static" CssClass="cantos-arredondados-alinhamento" ></asp:TextBox>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Table ID="tbDadosPacienteNomeSocial" runat="server" Width="100%">
                <asp:TableHeaderRow Width="100%">
                    <asp:TableHeaderCell Text="Nome Social: " Width="20%" Height="40px" BackColor="#cccccc" Font-Bold="true" Font-Size="14" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="80%" Height="40px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                        <asp:TextBox ID="txtNomeSocial" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="99.5%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Table ID="tbDadosPacienteSegundaParte" runat="server" Width="100%">
                <asp:TableHeaderRow Width="100%">
                    <asp:TableHeaderCell Text="D. N.:" Width="10%" Height="40px" BackColor="#cccccc" Font-Bold="true" Font-Size="14" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="40px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                        <asp:TextBox ID="txtDataNasc" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="40px" ClientIDMode="Static" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Data:" Width="10%" Height="40px" BackColor="#cccccc" Font-Bold="true" Font-Size="14" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="40px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                        <asp:TextBox ID="txtDataHoje" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="40px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Inspeção do M.A.E.:" Width="15%" Height="40px" BackColor="#cccccc" Font-Bold="true" Font-Size="14" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="25%" Height="40px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                        <asp:TextBox ID="txtInspecaoMAE" runat="server" TextMode="MultiLine" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="98%" Height="38px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Table ID="tbDadosPacienteTerceiraParte" runat="server" Width="100%">
                <asp:TableHeaderRow Width="100%">
                    <asp:TableHeaderCell Text="Queixa (s) Clínica (s)" Width="20%" Height="38px" BackColor="#cccccc" Font-Bold="true" Font-Size="14" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="80%" Height="40px" BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1">
                        <asp:TextBox ID="txtQueixasClinicas" runat="server" TextMode="MultiLine" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1" ForeColor="Black" Font-Bold="true" Font-Size="12" Width="99.5%" Height="38px" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <br />
            <asp:Table ID="tbBotaoVai" runat="server" Width="100%">
                <asp:TableHeaderRow Width="100%">
                    <asp:TableHeaderCell Width="20%" ></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="50px" ></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="50px" ></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="50px" ></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20%" Height="50px" ></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow Width="100%">
                    <asp:TableCell Width="20%" Height="150px">
                    </asp:TableCell>
                    <asp:TableCell Width="20%" Height="150px">
                    </asp:TableCell>
                    <asp:TableCell Width="20%" Height="150px">
                        <asp:Button ID="btnVai" runat="server" Width="100%" Height="100%" OnClick="btnVai_Click" CssClass="btn-Caracol" ToolTip="Vai!" />
                    </asp:TableCell>
                    <asp:TableCell Width="20%" Height="150px">
                    </asp:TableCell>
                    <asp:TableCell Width="20%" Height="150px">
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <footer>
            <b>Sistemas Lua de Gerenciamento EIRELI. CNPJ: 34.648.108/0001-07. Todos os direitos reservados. 2023. <a href="http://lattes.cnpq.br/5576683103146306" style="color: yellow; text-decoration: none;">Sobre o desenvolvedor.</a><a>&nbsp;&nbsp;&nbsp;</a><a href="https://www.linkedin.com/in/f%C3%A1bio-leonel-do-nascimento-0442b215b/" style="color: yellow; text-decoration: none;">Contato.</a></b>
        </footer>
    </form>

    <%--Para o cálculo da idade od paciente--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtDataNasc').change(function () {
                var dataNascimentoStr = $('#txtDataNasc').val();
                var dataNascimento = moment(dataNascimentoStr, 'DD/MM/YYYY', true); // Parse a data com Moment.js

                if (dataNascimento.isValid()) {
                    var hoje = moment();
                    var anos = hoje.diff(dataNascimento, 'years'); // Diferença em anos
                    dataNascimento.add(anos, 'years'); // Avança o ponteiro de data em anos

                    var meses = hoje.diff(dataNascimento, 'months'); // Diferença em meses
                    dataNascimento.add(meses, 'months'); // Avança o ponteiro de data em meses

                    var dias = hoje.diff(dataNascimento, 'days'); // Diferença em dias

                    $('#txtIdade').val(anos + ' ano (s), ' + meses + ' mês (es), ' + dias + ' dia (s)');
                } else {
                    alert('Por favor, insira uma data de nascimento válida no formato dd/MM/yyyy.');
                }
            });
        });
    </script>

    <%--Para a exibição da data atual--%>
    <script type="text/javascript">
        $(document).ready(function () {
            // Obtém a data atual
            var dataAtual = new Date();

            // Formata a data no formato desejado (dd/MM/yyyy)
            var dia = String(dataAtual.getDate()).padStart(2, '0');
            var mes = String(dataAtual.getMonth() + 1).padStart(2, '0'); // Adiciona 1 ao mês, pois os meses são baseados em zero
            var ano = dataAtual.getFullYear();

            var dataFormatada = dia + '/' + mes + '/' + ano;

            // Exibe a data atual no TextBox
            $('#txtDataHoje').val(dataFormatada);
        });
    </script>
</body>
</html>
