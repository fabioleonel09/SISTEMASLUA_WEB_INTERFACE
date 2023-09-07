using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_ConfigTipo
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("Ascendente", "1"));
            items.Add(new ListItem("Horizontal", "2"));
            items.Add(new ListItem("Descendente leve", "3"));
            items.Add(new ListItem("Descendente acentuada", "4"));
            items.Add(new ListItem("Em rampa", "5"));
            items.Add(new ListItem("Em U", "6"));
            items.Add(new ListItem("Em U invertido", "7"));
            items.Add(new ListItem("Em entalhe", "8"));
            items.Add(new ListItem("De configuração não definida", "9"));

            return items;
        }
    }
}