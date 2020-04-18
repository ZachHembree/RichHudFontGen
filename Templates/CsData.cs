using System.Collections.Generic;
using System.Drawing;

namespace HudLibFontGen.Templates
{
    public partial class CsDataTemplate
    {
        public FontGenForm form;
        public List<FontData> styles;

        public CsDataTemplate(FontGenForm form, List<FontData> styles)
        {
            this.form = form;
            this.styles = styles;
        }
    }
}