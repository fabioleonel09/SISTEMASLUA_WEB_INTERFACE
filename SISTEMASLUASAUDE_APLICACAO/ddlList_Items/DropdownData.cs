using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("100%", "100"));
            items.Add(new ListItem("96%", "96"));
            items.Add(new ListItem("92%", "92"));
            items.Add(new ListItem("88%", "88"));
            items.Add(new ListItem("84%", "84"));
            items.Add(new ListItem("80%", "80"));
            items.Add(new ListItem("76%", "76"));
            items.Add(new ListItem("72%", "72"));
            items.Add(new ListItem("68%", "68"));
            items.Add(new ListItem("64%", "64"));
            items.Add(new ListItem("60%", "60"));
            items.Add(new ListItem("56%", "56"));
            items.Add(new ListItem("52%", "52"));
            items.Add(new ListItem("48%", "48"));
            items.Add(new ListItem("44%", "44"));
            items.Add(new ListItem("40%", "40"));
            items.Add(new ListItem("36%", "36"));
            items.Add(new ListItem("32%", "32"));
            items.Add(new ListItem("28%", "28"));
            items.Add(new ListItem("24%", "24"));
            items.Add(new ListItem("20%", "20"));
            items.Add(new ListItem("16%", "16"));
            items.Add(new ListItem("12%", "12"));
            items.Add(new ListItem("8%", "8"));
            items.Add(new ListItem("4%", "4"));
            items.Add(new ListItem("0%", "0"));

            return items;
        }
    }
}