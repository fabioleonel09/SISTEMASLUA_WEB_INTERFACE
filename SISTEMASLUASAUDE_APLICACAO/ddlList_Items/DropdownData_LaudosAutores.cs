using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SISTEMASLUASAUDE_APLICACAO.ddlList_Items
{
    public class DropdownData_LaudosAutores
    {
        public static List<ListItem> GetItems()
        {
            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("", "0"));
            items.Add(new ListItem("* ASHA, 1990; Segundo SILMAN e SILVERMAN, 1997; Segundo LLOYD e KAPLAN, 1978; Adap.de CARHART, 1945 e LLOYD e KAPLAN, 1978; Segundo NORTHERN e DOWNS, 1984; Segundo JERGER, SPEAKS e TRAMMELL, 1968.", "1"));
            items.Add(new ListItem("** ASHA, 1990; Segundo SILMAN e SILVERMAN, 1997; Segundo BIAP, 1996; Adap.de CARHART, 1945 e LLOYD e KAPLAN, 1978; Segundo JERGER, SPEAKS e TRAMMELL, 1968.", "2"));
            items.Add(new ListItem("*** ASHA, 1990; Segundo SILMAN e SILVERMAN, 1997; Segundo OMS, 2020; Adap.de CARHART, 1945 e LLOYD e KAPLAN, 1978; Segundo JERGER, SPEAKS e TRAMMELL, 1968.", "3"));
            items.Add(new ListItem("**** ASHA, 1990; Segundo SILMAN e SILVERMAN, 1997; Segundo OMS, 2014; Adap.de CARHART, 1945 e LLOYD e KAPLAN, 1978; Segundo JERGER, SPEAKS e TRAMMELL, 1968.", "4"));
           
            return items;
        }
    }
}