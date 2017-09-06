using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;

namespace MyCTS.Presentation.Base
{
    public interface IToolTippeable
    {

        void SetToolTip(Control control, string message, ToolTipIconType type);

    }
}
