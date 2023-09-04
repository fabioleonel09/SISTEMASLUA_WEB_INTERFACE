using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_VO
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "1"));
            items.Add(new ListItem("-10", "-10"));
            items.Add(new ListItem("-5", "-5"));
            items.Add(new ListItem("0", "0"));
            items.Add(new ListItem("5", "5"));
            items.Add(new ListItem("10", "10"));
            items.Add(new ListItem("15", "15"));
            items.Add(new ListItem("20", "20"));
            items.Add(new ListItem("25", "25"));
            items.Add(new ListItem("30", "30"));
            items.Add(new ListItem("35", "35"));
            items.Add(new ListItem("40", "40"));
            items.Add(new ListItem("45", "45"));
            items.Add(new ListItem("50", "50"));
            items.Add(new ListItem("55", "55"));
            items.Add(new ListItem("60", "60"));
            items.Add(new ListItem("65", "65"));
            items.Add(new ListItem("70", "70"));
            items.Add(new ListItem("75", "75"));

            return items;
        }
    }
}