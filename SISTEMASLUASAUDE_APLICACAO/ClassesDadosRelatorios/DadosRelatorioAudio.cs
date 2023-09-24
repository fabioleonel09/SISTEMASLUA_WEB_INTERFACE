using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISTEMASLUASAUDE_APLICACAO.ClassesDadosRelatorios
{
    public class DadosRelatorioAudio
    {
        public string nomePaciente { get; set; } 
        public string nomeSocialPaciente { get; set; }
        public string idadePaciente { get; set;}
        public string dataNascimento { get; set;}

        //PARA A AUDIOMETRIA CLINICA COMPLETA OU CONVENCIONAL***************************
        //para a fala da OD
        public string monOD { get; set;}
        public string dissOD { get; set;}
        public string srtOD { get; set;}
        public string sdtOD { get; set;}

        public string mediaOD { get; set;}

        //para a fala da OE
        public string monOE { get; set; }
        public string dissOE { get; set; }
        public string srtOE { get; set; }
        public string sdtOE { get; set; }
        public string mediaOE { get; set; }

        //para o mascaramento
        public string mascaramento { get; set; }

        //para o teste de Weber
        public string weber500Hz { get; set; }
        public string weber1kHz { get; set; }
        public string weber2kHz { get; set; }
        public string weber4kHz { get; set; }

        //para o laudo OD
        public string curvaAudioNormalOD { get; set;}
        public string doTipoOD { get; set;}
        public string deGrauOD { get; set;}
        public string deConfigOD { get; set; }
        public string deAudioVocalOD { get; set; }

        //para o laudo OE
        public string curvaAudioNormalOE { get; set; }
        public string doTipoOE { get; set; }
        public string deGrauOE { get; set; }
        public string deConfigOE { get; set; }
        public string deAudioVocalOE { get; set; }

        //para os autores do laudo
        public string autoresLaudo { get; set; }

        //para os demais dados
        public string comentarios { get; set; }
        public string examidador { get; set; }
        public string audiometro { get; set; }
        public string dataCalibracao { get; set; }

        //PARA A AUDIOMETRIA COMPORTAMENTAL *************************
        //localiza fonte sonora OD
        public string guizo1OD { get; set; }
        public string guizo2OD { get;set; }
        public string sinoOD { get; set; }
        public string blackblackOD { get; set; }
        public string agogoPeqOD { get; set; }
        public string agogoGranOD { get; set; }
        public string chocalhoOD { get; set; }
        public string trianguloOD { get; set; }
        public string pratoOD { get; set; }
        public string tamborOD { get; set; }

        //localiza fonte sonora OE
        public string guizo1OE { get; set; }
        public string guizo2OE { get; set; }
        public string sinoOE { get; set; }
        public string blackblackOE { get; set; }
        public string agogoPeqOE { get; set; }
        public string agogoGranOE { get; set; }
        public string chocalhoOE { get; set; }
        public string trianguloOE { get; set; }
        public string pratoOE { get; set; }
        public string tamborOE { get; set; }

        //demais avaliações
        public string comportamentoAuditivo { get; set; }
        public string reacoesVerbais { get; set; }
        public string ordensSimples { get; set; }

        public string conclusoesComportamentais { get; set; }
        public string observacoesComportamentais { get; set; }
    }
}