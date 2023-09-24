using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISTEMASLUASAUDE_APLICACAO.ClassesDadosRelatorios
{
    public class RelatorioDataSource
    {
        public static string NomePaciente { get; set; }
        public static string NomeSocialPaciente { get; set; }
        public static string IdadePaciente { get; set; }
        public static string DataNascimento { get; set; }
        public static string MonOD { get; set; }
        public static string MonOE { get; set; }
        public static string DissOD { get; set; }
        public static string DissOE { get; set; }
        public static string SrtOD { get; set; }
        public static string SrtOE { get; set; }
        public static string SdtOD { get; set; }
        public static string SdtOE { get; set; }
        public static string MediaOD { get; set; }
        public static string MediaOE { get; set; }
        public static string Weber500Hz { get; set; }
        public static string Weber1kHz { get; set; }
        public static string Weber2kHz { get; set; }
        public static string Weber4kHz { get; set; }
        public static string Mascaramento { get; set; }
        public static string CurvaAudioNormalOD { get; set; }
        public static string CurvaAudioNormalOE { get; set; }
        public static string DoTipoOD { get; set; }
        public static string DoTipoOE { get; set; }
        public static string DeGrauOD { get; set; }
        public static string DeGrauOE { get; set; }
        public static string DeConfigOD { get; set; }
        public static string DeConfigOE { get; set; }
        public static string DeAudioVocalOD { get; set; }
        public static string DeAudioVocalOE { get; set; }
        public static string AutoresLaudo { get; set; }
        public static string Comentarios { get; set; }
        public static string Examinador { get; set; }
        public static string Audiometro { get; set; }
        public static string DataCalibracao { get; set; }

        public static DataSet GetDadosRelatorio()
        {
            // Crie um novo DataSet
            DataSet dataSet = new DataSet("DataSet1");

            // Crie uma DataTable para armazenar os dados
            DataTable dataTable = new DataTable("DadosRelatorioAudio");

            // Adicione as colunas à DataTable
            dataTable.Columns.Add("nomePaciente", typeof(string));
            dataTable.Columns.Add("nomeSocialPaciente", typeof(string));
            dataTable.Columns.Add("idadePaciente", typeof(string));
            dataTable.Columns.Add("dataNascimento", typeof(string));

            //audiometrias completa e convencional
            dataTable.Columns.Add("monossilaboOD", typeof(string));
            dataTable.Columns.Add("monossilaboOE", typeof(string));
            dataTable.Columns.Add("dissilaboOD", typeof(string));
            dataTable.Columns.Add("dissilaboOE", typeof(string));
            dataTable.Columns.Add("srtOD", typeof(string));
            dataTable.Columns.Add("srtOE", typeof(string));
            dataTable.Columns.Add("sdtOD", typeof(string));
            dataTable.Columns.Add("sdtOE", typeof(string));
            dataTable.Columns.Add("mediaOD", typeof(string));
            dataTable.Columns.Add("mediaOE", typeof(string));

            dataTable.Columns.Add("weber500Hz", typeof(string));
            dataTable.Columns.Add("weber1kHz", typeof(string));
            dataTable.Columns.Add("weber2kHz", typeof(string));
            dataTable.Columns.Add("weber4kHz", typeof(string));

            dataTable.Columns.Add("mascaramento", typeof(string));

            dataTable.Columns.Add("curvaAudioNormalOD", typeof(string));
            dataTable.Columns.Add("curvaAudioNormalOE", typeof(string));
            dataTable.Columns.Add("doTipoOD", typeof(string));
            dataTable.Columns.Add("doTipoOE", typeof(string));
            dataTable.Columns.Add("deGrauOD", typeof(string));
            dataTable.Columns.Add("deGrauOE", typeof(string));
            dataTable.Columns.Add("deConfigOD", typeof(string));
            dataTable.Columns.Add("deConfigOE", typeof(string));
            dataTable.Columns.Add("deAudioVocalOD", typeof(string));
            dataTable.Columns.Add("deAudioVocalOE", typeof(string));

            dataTable.Columns.Add("autoresLaudo", typeof(string));

            dataTable.Columns.Add("comentarios", typeof(string));

            dataTable.Columns.Add("examinador", typeof(string));
            dataTable.Columns.Add("audiometro", typeof(string));
            dataTable.Columns.Add("dataCalibracao", typeof(string));

            //audiometria comportamental


            // Crie uma nova linha e popule-a com os dados da classe DadosRelatorioAudio
            DataRow dataRow = dataTable.NewRow();
            DadosRelatorioAudio dadosRel = new DadosRelatorioAudio();
            // Popule cada coluna com os valores correspondentes da instância de DadosRelatorioAudio
            dataRow["nomePaciente"] = NomePaciente;
            dataRow["nomeSocialPaciente"] = NomeSocialPaciente;
            dataRow["idadePaciente"] = IdadePaciente;
            dataRow["dataNascimento"] = DataNascimento;

            //audiometrias completa e convencional
            dataRow["monossilaboOD"] = MonOD;
            dataRow["monossilaboOE"] = MonOE;
            dataRow["dissilaboOD"] = DissOD;
            dataRow["dissilaboOE"] = DissOE;
            dataRow["srtOD"] = SrtOD;
            dataRow["srtOE"] = SrtOE;
            dataRow["sdtOD"] = SdtOD;
            dataRow["sdtOE"] = SdtOE;
            dataRow["mediaOD"] = MediaOD;
            dataRow["mediaOE"] = MediaOE;

            dataRow["weber500Hz"] = Weber500Hz;
            dataRow["weber1kHz"] = Weber1kHz;
            dataRow["weber2kHz"] = Weber2kHz;
            dataRow["weber4kHz"] = Weber4kHz;

            dataRow["mascaramento"] = Mascaramento;

            dataRow["curvaAudioNormalOD"] = CurvaAudioNormalOD;
            dataRow["curvaAudioNormalOE"] = CurvaAudioNormalOE;
            dataRow["doTipoOD"] = DoTipoOD;
            dataRow["doTipoOE"] = DoTipoOE;
            dataRow["deGrauOD"] = DeGrauOD;
            dataRow["deGrauOE"] = DeGrauOE;
            dataRow["deConfigOD"] = DeConfigOD;
            dataRow["deConfigOE"] = DeConfigOE;
            dataRow["deAudioVocalOD"] = DeAudioVocalOD;
            dataRow["deAudioVocalOE"] = DeAudioVocalOE;

            dataRow["autoresLaudo"] = AutoresLaudo;

            dataRow["comentarios"] = Comentarios;

            dataRow["examinador"] = Examinador;
            dataRow["audiometro"] = Audiometro;
            dataRow["dataCalibracao"] = DataCalibracao;


            // Adicione a linha à DataTable
            dataTable.Rows.Add(dataRow);

            // Adicione a DataTable ao DataSet
            dataSet.Tables.Add(dataTable);

            return dataSet;
        }
    }
}