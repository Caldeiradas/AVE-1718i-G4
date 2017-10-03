using System;


namespace HtmlReflect
{

    public class HtmlIgnoreAttribute : Attribute
    {
    }

    public class HtmlAsAttribute : Attribute
    {
        string Url;
        public HtmlAsAttribute(string Url) {
            Url = this.Url;
        }
    }

    public class Htmlect
    {
        public string ToHtml(object obj)
        {
            return "";
        }

        public string ToHtml(object[] arr)
        {
            return "";
        }
    }
}
