<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Página Inicial</title>
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
            background: linear-gradient(to right, #0074D9, #2ECC40);
            color: white;
            padding: 10px 20px;
        }

        .cantos-arredondados-alinhamento-imagem-como-usar {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            text-align: left; /* Centraliza horizontalmente */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */           
            background: linear-gradient(to right, #2ECC40, #0074D9);
            color: white;
            padding: 10px 20px;
        }
    </style>
</head>
<body class="custom-font" style="background-color: lightslategray; background-image: url('./Images/luaRecolorida2.png'); background-repeat: no-repeat; background-size: 80%; background-position: right top">
    <form id="frmLogin" runat="server" style="width: 100%; height: 100%">
        <header>
            <b>Sistemas Lua - Saúde: Audiologia</b>
        </header>
        <div id="geral" runat="server" style="margin-top: 40px; margin-bottom: 50px; width: 100%; height: 100%; align-items: stretch; vertical-align: central">
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
                        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" Width="35%" Height="50px" ForeColor="Black" Font-Bold="true" Font-Size="14" BorderColor="Black" BorderStyle="Solid" BorderWidth="2" CssClass="cantos-arredondados-alinhamento-imagem" OnClick="btnEntrar_Click" />
                        <br />
                        <br />
                        <asp:Button ID="btnInstrucoes" runat="server" Text="Como usar?" Width="35%" Height="50px" BackColor="AliceBlue" ForeColor="Black" Font-Bold="true" Font-Size="14" BorderColor="Black" BorderStyle="Solid" BorderWidth="2" CssClass="cantos-arredondados-alinhamento-imagem-como-usar" OnClick="btnInstrucoes_Click" />
                    </asp:TableCell>
                    <asp:TableCell Width="50%"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <footer>
            <b>Sistemas Lua de Gerenciamento EIRELI. CNPJ: 34.648.108/0001-07. Todos os direitos reservados. 2023. <a href="http://lattes.cnpq.br/5576683103146306" style="color: yellow; text-decoration: none;">Sobre o desenvolvedor.</a><a>&nbsp;&nbsp;&nbsp;</a><a href="https://www.linkedin.com/in/f%C3%A1bio-leonel-do-nascimento-0442b215b/" style="color: yellow; text-decoration: none;">Contato.</a></b>
        </footer>
    </form>
</body>
</html>
