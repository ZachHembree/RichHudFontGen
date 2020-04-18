using System.Collections.Generic;
using System.Drawing;

namespace HudLibFontGen.Templates
{
    public partial class MatSbcTemplate
    {
        public FontGenForm form;
        public List<FontData> styles;

        public MatSbcTemplate(FontGenForm form, List<FontData> styles)
        {
            this.form = form;
            this.styles = styles;
        }
    }
}