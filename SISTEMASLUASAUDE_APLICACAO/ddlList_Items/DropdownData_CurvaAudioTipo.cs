using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_CurvaAudioTipo
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("Sensorioneural", "1"));
            items.Add(new ListItem("Condutiva", "2"));
            items.Add(new ListItem("Mista", "3"));

            return items;
        }
    }
}