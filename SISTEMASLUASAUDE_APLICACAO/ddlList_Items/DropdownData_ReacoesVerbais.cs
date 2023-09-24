using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_ReacoesVerbais
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("Voz da mãe", "1"));
            items.Add(new ListItem("Voz do examinador", "2"));
            items.Add(new ListItem("Reação ao nome", "3"));

            return items;
        }
    }
}