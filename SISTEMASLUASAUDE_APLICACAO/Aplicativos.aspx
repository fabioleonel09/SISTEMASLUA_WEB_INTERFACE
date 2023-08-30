<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aplicativos.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.Aplicativos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnlAplicativos" runat="server" BackColor="#78899D" BorderColor="#003399" BorderStyle="Solid" Width="100%" Height="50%" BorderWidth="1px">
                <div style="align-items: center;">
                    <asp:Button ID="btnAgenda" runat="server" Text="Agenda" OnClick="btnAgenda_Click" />
                    <asp:Button ID="btnProntuario" runat="server" Text="Prontuário" OnClick="btnProntuario_Click" />
                    <asp:Button ID="btnExames" runat="server" Text="Exames" OnClick="btnExames_Click" />
                </div>
                
            </asp:Panel>
        </div>
    </form>
</body>
</html>
