using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_TesteWeber
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("D", "1"));
            items.Add(new ListItem("E", "2"));
            items.Add(new ListItem("I", "3"));

            return items;
        }
    }
}