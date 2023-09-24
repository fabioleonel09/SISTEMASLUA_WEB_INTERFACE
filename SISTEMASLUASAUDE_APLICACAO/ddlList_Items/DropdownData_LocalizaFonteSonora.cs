using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_LocalizaFonteSonora
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("PF", "1"));
            items.Add(new ListItem("LI b", "2"));
            items.Add(new ListItem("LI c", "3"));
            items.Add(new ListItem("LL", "4"));
            items.Add(new ListItem("LD b", "5"));
            items.Add(new ListItem("LD c", "6"));
            items.Add(new ListItem("RCP", "7"));
            items.Add(new ListItem("Startle", "8"));
            items.Add(new ListItem("Atenção", "9"));
            items.Add(new ListItem("Nenhuma reação", "10"));
            
            return items;
        }
    }
}