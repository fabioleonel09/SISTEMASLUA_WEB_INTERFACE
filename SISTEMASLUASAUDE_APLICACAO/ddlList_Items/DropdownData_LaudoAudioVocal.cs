using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_LaudoAudioVocal
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("Com nenhuma dificuldade", "1"));
            items.Add(new ListItem("Com ligeira dificuldade", "2"));
            items.Add(new ListItem("Com moderada dificuldade", "3"));
            items.Add(new ListItem("Com acentuada dificuldade", "4"));
            items.Add(new ListItem("Com provável incapacidade auditiva", "5"));

            return items;
        }
    }
}