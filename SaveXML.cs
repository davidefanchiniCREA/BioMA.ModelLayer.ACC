using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.ModelLayer.ACC
{
    internal class SaveXML
    {
         #region Constructor

        internal SaveXML(DataSet items)   // APIdefinition apidef)
        {
            //api = apidef;
            api_items = items;
        }

        #endregion

        private DataSet api_items;
        // private APIdefinition api;
    }
}
