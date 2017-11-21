using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovHubDb;
using MovHubDb.Model;

namespace HtmlReflect
{
    class MoviePropGetter : AbstractPropGetter
    {
        public override string GetHtmlString(object obj)
        {
            string res = "";
            Movie  m = (Movie)obj;
            string originalTitleValue = m.OriginalTitle;
            res += FormatNotIgnoreToHtml("originalTitle", originalTitleValue);
            return null;

        }

    }
}
