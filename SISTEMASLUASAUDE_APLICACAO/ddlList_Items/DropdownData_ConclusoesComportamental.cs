using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_ConclusoesComportamental
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("Respostas adequadas para a idade.", "1"));
            items.Add(new ListItem("Respostas inadequadas para a idade.", "2"));
            
            return items;
        }
    }
}