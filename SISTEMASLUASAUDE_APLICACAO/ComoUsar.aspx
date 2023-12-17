<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComoUsar.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.ComoUsar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Como Usar?</title>
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

        .tab-content {
            display: none;
        }

        .active-tab {
            display: block;
        }

        .tab-button {
            cursor: pointer;
            padding: 10px;
            background: linear-gradient(to right, #2ECC40, #0074D9);
            border-color: black;
            display: inline-block;
            margin-right: 5px;
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

            .tab-button:hover{
                transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
            }
    </style>
</head>
<body class="custom-font" style="background-color: lightslategray;">
    <form id="frmLogin" runat="server" style="width: 100%; height: 100%">
        <header>
            <b>Sistemas Lua - Saúde: Como Usar?</b>
        </header>
        <div id="geral" runat="server" style="margin-top: 40px; margin-bottom: 50px; width: 100%; height: 100%; align-items: stretch; vertical-align: central">
            <asp:Table ID="tbComoUsar" runat="server" Width="100%" CssClass="alinhamento-text-center">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Width="100%">
                        <asp:Image ID="imgUsuarios" runat="server" ImageUrl="~/Images/usuariosMaior.png" Width="10%" />
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Width="100%">
                        <div style="width: 100%;">
                            <%--abas--%>
                            <div class="tab-button" style="width: 15%; border-style: solid; border-width: 1px; font-size: medium;" onclick="showTab('tabApres')">Apresentação</div>
                            <div class="tab-button" style="width: 15%; border-style: solid; border-width: 1px; font-size: medium;" onclick="showTab('tabCont')">Conteúdos</div>
                            <div class="tab-button" style="width: 15%; border-style: solid; border-width: 1px; font-size: medium;" onclick="showTab('tabManual')">Manual Geral</div>
                            <div class="tab-button" style="width: 15%; border-style: solid; border-width: 1px; font-size: medium;" onclick="showTab('tabReq')">Especificações</div>
                            <div class="tab-button" style="width: 15%; border-style: solid; border-width: 1px; font-size: medium;" onclick="showTab('tabSobreAutor')">Sobre o Autor</div>
                            <%--conteúdos das abas--%>
                            <div id="tabApres" class="tab-content active-tab" style="width: 100%;">
                                <p>Apresentação</p>
                            </div>
                            <div id="tabCont" class="tab-content" style="width: 100%;">
                                <p>Conteúdos</p>
                            </div>
                            <div id="tabManual" class="tab-content" style="width: 100%;">
                                <p>Manual geral</p>
                            </div>
                            <div id="tabReq" class="tab-content" style="width: 100%;">
                                <p>Requisitos</p>
                            </div>
                            <div id="tabSobreAutor" class="tab-content" style="width: 100%;">
                                <p>Sobre o autor</p>
                            </div>
                        </div>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <footer>
            <b>Sistemas Lua de Gerenciamento EIRELI. CNPJ: 34.648.108/0001-07. Todos os direitos reservados. 2023. <a href="http://lattes.cnpq.br/5576683103146306" style="color: yellow; text-decoration: none;">Sobre o desenvolvedor.</a><a>&nbsp;&nbsp;&nbsp;</a><a href="https://www.linkedin.com/in/f%C3%A1bio-leonel-do-nascimento-0442b215b/" style="color: yellow; text-decoration: none;">Contato.</a></b>
        </footer>
    </form>

    <script>
        function showTab(tabId) {
            // Esconder todas as abas
            var tabs = document.querySelectorAll('.tab-content');
            tabs.forEach(function (tab) {
                tab.classList.remove('active-tab');
            });

            // Mostrar a aba selecionada
            var selectedTab = document.getElementById(tabId);
            selectedTab.classList.add('active-tab');
        }
    </script>

</body>
</html>
