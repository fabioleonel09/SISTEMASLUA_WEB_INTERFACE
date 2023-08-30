<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color: lightslategray; background-image: url('./Images/luaRecolorida2.png'); background-repeat: no-repeat; background-size: 60%; background-position: right top;">
    <form id="frmLogin" runat="server" style="width: 100%; height: 100%">
        <div id="geral" runat="server" style="width: 100%; height: 100%;">
            <asp:Panel ID="pnlLogin" runat="server" BackColor="#78899D" BorderColor="#003399" BorderStyle="Solid" Width="50%" Height="50%" BorderWidth="1px">
                <asp:Image ID="imgUsuarios" runat="server" ImageUrl="~/Images/usuariosMaior.png" />
                <br />
                <label>Segmento Saúde</label>
                <br />
                <br />
                <label>Usuário:</label>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                <br />
                <br />
                <label>Senha:</label>
                <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />

            </asp:Panel>
        </div>
    </form>
</body>
</html>
