using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiResources.Extension
{
    public enum ColorScheme
    {
        [Description("主颜色")]
        Primary,
        [Description("次颜色")]
        Secondary,
        [Description("主前景色")]
        PrimaryForeground,
        [Description("次前景色")]
        SecondaryForeground
    }

}
