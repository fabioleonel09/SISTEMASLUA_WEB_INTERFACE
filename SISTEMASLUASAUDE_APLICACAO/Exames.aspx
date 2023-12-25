<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exames.aspx.cs" Inherits="SISTEMASLUASAUDE_APLICACAO.Exames" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script type="text/javascript">

</script>

    <title>Exames Audiológicos</title>
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

        .cantos-arredondados-alinhamento-center {
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            text-align: center; /* Centraliza horizontalmente */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
        }

        .btn-Audio-Convencional {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/AudioConvencional.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

            .btn-Audio-Convencional:hover {
                transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
            }

        .btn-Audio-Completa {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/AudioCompleta.jpg');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

            .btn-Audio-Completa:hover {
                transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
            }

        .btn-Audio-Comportamental {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/AudioComportamentalpng.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

            .btn-Audio-Comportamental:hover {
                transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
            }

        .btn-Audio-Campo {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/AudioCampo.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

            .btn-Audio-Campo:hover {
                transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
            }

        .btn-Audio-Campo-Conven {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/AudiometriaCampoConven.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

            .btn-Audio-Campo-Conven:hover {
                transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
            }

        .btn-Altas-frequencias {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/fones.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

            .btn-Altas-frequencias:hover {
                transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
            }

        .btn-Impepanciometria {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/impedanciometria.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

            .btn-Impepanciometria:hover {
                transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
            }

        .btn-Teste-Funcao-Tubaria {
            cursor: pointer; /* Altera o cursor para a forma de uma mão */
            border-radius: 10px; /* Valor do raio dos cantos arredondados */
            line-height: normal; /* Redefine a altura da linha para evitar alinhamento vertical inadequado */
            background-image: url('./Images/sondaImpedancio.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: contain; /* Ajuste o tamanho da imagem conforme necessário */
            transition: transform 0.3s; /* Adicione uma transição suave para o efeito de zoom */
        }

            .btn-Teste-Funcao-Tubaria:hover {
                transform: scale(1.2); /* Aumenta o tamanho em 10% quando o mouse passa por cima */
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
            background: linear-gradient(to right, red, #0074D9);
            border-color: #4B0082;
            color: white;
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
    <form id="form1" runat="server" style="width: 100%; height: 100%">
        <header>
            <b>Audiologia: Exames Audiológicos</b>
        </header>
        <div id="geral" runat="server" style="margin-top: 50px; margin-bottom: 50px; width: 100%; height: 100%; align-items: center; vertical-align: central">
            <div class="container" style="text-align: right; width: 100%;">
                <asp:Label ID="lblBoasVindas" runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large"></asp:Label>
            </div>
            <br />
            <asp:Table ID="tbGeral" runat="server" Width="100%" CssClass="alinhamento-text-center">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Width="100%">
                        <div style="width: 100%;">
                            <%--abas--%>
                            <div class="tab-button" style="width: 42%; border-style: solid; border-width: 1px; font-size: x-large;" onclick="showTab('tabAudio')">Audiometria</div>
                            <div class="tab-button" style="width: 42%; border-style: solid; border-width: 1px; font-size: x-large;" onclick="showTab('tabImp')">Impedanciometria</div>

                            <%--conteúdos das abas--%>
                            <div id="tabAudio" class="tab-content active-tab" style="width: 100%;">
                                <div style="width: 100%; background-color: white; text-align: center; vertical-align: bottom;">
                                    <asp:Label ID="lblTituloCabecalho" runat="server" Text="Audiometria" Font-Bold="true" Font-Size="22"></asp:Label>
                                </div>
                                <asp:Table ID="tbAplicativosExames" runat="server" Width="100%">
                                    <asp:TableHeaderRow Width="100%">
                                        <asp:TableHeaderCell Width="20%" Height="50px" BackColor="#cccccc" Font-Bold="true" Font-Size="18" CssClass="cantos-arredondados-alinhamento-center">Convencional</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px" BackColor="#cccccc" Font-Bold="true" Font-Size="18" CssClass="cantos-arredondados-alinhamento-center">Completa</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px" BackColor="#cccccc" Font-Bold="true" Font-Size="18" CssClass="cantos-arredondados-alinhamento-center">Comportamental</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px" BackColor="#cccccc" Font-Bold="true" Font-Size="18" CssClass="cantos-arredondados-alinhamento-center">Campo Livre</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px" BackColor="#cccccc" Font-Bold="true" Font-Size="18" CssClass="cantos-arredondados-alinhamento-center">Campo Livre Convencional</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                    <asp:TableRow Width="100%">
                                        <asp:TableCell Width="20%" Height="150px">
                                            <asp:Button ID="btnAudioConvencional" runat="server" Width="100%" Height="100%" OnClick="btnAudioConvencional_Click" CssClass="btn-Audio-Convencional" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                            <asp:Button ID="btnAudioCompleta" runat="server" Width="100%" Height="100%" OnClick="btnAudioCompleta_Click" CssClass="btn-Audio-Completa" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                            <asp:Button ID="btnAudioComportamental" runat="server" Width="100%" Height="100%" OnClick="btnAudioComportamental_Click" CssClass="btn-Audio-Comportamental" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                            <asp:Button ID="btnAudioCampoLivre" runat="server" Width="100%" Height="100%" OnClick="btnAudioCampoLivre_Click" CssClass="btn-Audio-Campo" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                            <asp:Button ID="btnAudioCampoConvencional" runat="server" Width="100%" Height="100%" OnClick="btnAudioCampoConvencional_Click" CssClass="btn-Audio-Campo-Conven" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                                <asp:Table ID="tbAplicativosExamesCont" runat="server" Width="100%">
                                    <asp:TableHeaderRow Width="100%">
                                        <asp:TableHeaderCell Width="20%" Height="50px" BackColor="#cccccc" Font-Bold="true" Font-Size="18" CssClass="cantos-arredondados-alinhamento-center">Altas Frequências</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px"></asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                    <asp:TableRow Width="100%">
                                        <asp:TableCell Width="20%" Height="150px">
                                            <asp:Button ID="btnAltasFrequencias" runat="server" Width="100%" Height="100%" OnClick="btnAltasFrequencias_Click" CssClass="btn-Altas-frequencias" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                            <div id="tabImp" class="tab-content" style="width: 100%;">
                                <div style="width: 100%; background-color: white; text-align: center; vertical-align: bottom;">
                                    <asp:Label ID="lblTituloImpedanciometria" runat="server" Text="Timpanometria e Pesquisa dos Reflexos do Músculo do Estapédio" Font-Bold="true" Font-Size="22"></asp:Label>
                                </div>
                                <asp:Table ID="tbImpedanciometria" runat="server" Width="100%">
                                    <asp:TableHeaderRow Width="100%">
                                        <asp:TableHeaderCell Width="20%" Height="50px" BackColor="#cccccc" Font-Bold="true" Font-Size="18" CssClass="cantos-arredondados-alinhamento-center">Impedanciometria</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px" BackColor="#cccccc" Font-Bold="true" Font-Size="18" CssClass="cantos-arredondados-alinhamento-center">Teste de Função Tubária</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%" Height="50px"></asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                    <asp:TableRow Width="100%">
                                        <asp:TableCell Width="20%" Height="150px">
                                            <asp:Button ID="btnImpedanciometia" runat="server" Width="100%" Height="100%" OnClick="btnImpedanciometria_Click" CssClass="btn-Impepanciometria" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                            <asp:Button ID="btnTesteFuncaoTubaria" runat="server" Width="100%" Height="100%" OnClick="btnTesteFuncaoTubaria_Click" CssClass="btn-Teste-Funcao-Tubaria" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                        </asp:TableCell>
                                        <asp:TableCell Width="20%" Height="150px">
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
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
