<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.login" %>

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

        .alinhamento-text-center {
            text-align: center; /* Centraliza horizontalmente */
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

        .cantos-arredondados-alinhamento-imagem {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            text-align: right; /* Centraliza horizontalmente */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/Vai.png');
            background-repeat: no-repeat;
            background-position: left left;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
        }
    </style>
</head>
<body class="custom-font" style="background-color: lightslategray; background-image: url('./Images/luaRecolorida2.png'); background-repeat: no-repeat; background-size: 80%; background-position: right top">
    <form id="frmLogin" runat="server" style="width: 100%; height: 100%">
        <header>
            <b>Sistemas Lua - Saúde: Audiologia</b>
        </header>
        <div id="geral" runat="server" style="margin-top: 50px; margin-bottom: 50px; width: 100%; height: 100%; align-items: stretch; vertical-align: central">
            <asp:Table ID="tbLogin" runat="server" Width="100%" CssClass="alinhamento-text-center">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Width="50%">
                        <asp:Image ID="imgUsuarios" runat="server" ImageUrl="~/Images/usuariosMaior.png" Width="35%" />
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="50%"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell Width="50%">
                        <asp:TextBox ID="txtUsuario" runat="server" TextMode="SingleLine" placeholder="Digite o usuário..." Width="50%" Height="50px" Font-Bold="true" Font-Size="14" BorderColor="lightslategray" BorderStyle="Solid" BorderWidth="1" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="txtRegistroConselho" runat="server" TextMode="SingleLine" placeholder="Registro no Conselho Regional?" Width="50%" Height="50px" Font-Bold="true" Font-Size="14" BorderColor="lightslategray" BorderStyle="Solid" BorderWidth="1" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" placeholder="Digite a senha..." Width="50%" Height="50px" Font-Bold="true" Font-Size="14" BorderColor="lightslategray" BorderStyle="Solid" BorderWidth="1" CssClass="cantos-arredondados-alinhamento"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" Width="30%" Height="50px" BackColor="#00cc66" ForeColor="Black" Font-Bold="true" Font-Size="14" BorderColor="Black" BorderStyle="Solid" BorderWidth="2" CssClass="cantos-arredondados-alinhamento-imagem" OnClick="btnEntrar_Click" />
                    </asp:TableCell>
                    <asp:TableCell Width="50%"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <footer>
            <b>Sistemas Lua de Gerenciamento EIRELI. CNPJ: 34.648.108/0001-07. Todos os direitos reservados. 2023.</b>
        </footer>
    </form>
</body>
</html>
