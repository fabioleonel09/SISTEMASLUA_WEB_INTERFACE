using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_GrauAudio
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("Normal", "1"));
            items.Add(new ListItem("Discreto", "2"));

            items.Add(new ListItem("", "3"));

            items.Add(new ListItem("Leve", "4"));
            items.Add(new ListItem("Moderado", "5"));
            items.Add(new ListItem("Moderadamente severo", "6"));
            items.Add(new ListItem("Severo", "7"));
            items.Add(new ListItem("Profundo", "8"));

            items.Add(new ListItem("", "9"));

            items.Add(new ListItem("Perda auditiva completa / surdo", "10"));

            items.Add(new ListItem("", "11"));

            items.Add(new ListItem("Deficiência auditiva leve", "12"));
            items.Add(new ListItem("Deficiência auditiva moderada - Grau I", "13"));
            items.Add(new ListItem("Deficiência auditiva moderada - Grau II", "14"));
            items.Add(new ListItem("Deficiência auditiva severa - Grau I", "15"));
            items.Add(new ListItem("Deficiência auditiva severa - Grau II", "16"));
            items.Add(new ListItem("Deficiência auditiva muito severa - Grau I", "17"));
            items.Add(new ListItem("Deficiência auditiva muito severa - Grau II", "18"));
            items.Add(new ListItem("Deficiência auditiva muito severa - Grau III", "19"));
            items.Add(new ListItem("Deficiência auditiva total / Cofose", "20"));

            return items;
        }
    }
}