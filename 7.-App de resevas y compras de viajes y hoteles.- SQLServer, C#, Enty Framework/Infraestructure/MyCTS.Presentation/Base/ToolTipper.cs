using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using System.Windows.Forms;

namespace MyCTS.Presentation.Base
{
    public abstract class ToolTipper : IToolTippeable
    {
        /// <summary>
        /// 
        /// </summary>
        private ToolTipController _toolTipController;

        /// <summary>
        /// Gets the tool tipper.
        /// </summary>
        private ToolTipController ToolTipperManager
        {
            get { return _toolTipController ?? (_toolTipController = new ToolTipController()); }
        }


        #region Miembros de IToolTippeable

        public void SetToolTip(Control control, string message, ToolTipIconType type)
        {
            ToolTipperManager.SetToolTip(control, message.ToUpper());
            ToolTipperManager.SetToolTipIconType(control, type);


        }

        #endregion
    }
}
