using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_OrdensSimples
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("Nível I (de 09 a 12 meses)", "1"));
            items.Add(new ListItem("Nivel II (de 12 a 15 meses)", "2"));
            items.Add(new ListItem("Nível III (de 15 a 18 meses)", "3"));

            return items;
        }
    }
}