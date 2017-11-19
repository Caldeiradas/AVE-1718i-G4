using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HtmlReflect
{
    interface IGetter
    {
        string GetPropertyName();
        string GetValueAsString(object target);
        string GetHtmlString();
    }

    class GetterObject : IGetter
    {
        PropertyInfo p;
        public GetterObject(PropertyInfo p)
        {
            this.p = p;
        }
        public string GetPropertyName()
        {
            return p.Name;
        }
        public string GetValueAsString(object target)
        {
            return p.GetValue(target) + "";
        }
        public string GetHtmlString() {
            HtmlAsAttribute attribute = (HtmlAsAttribute)p.GetCustomAttribute(typeof(HtmlAsAttribute));
            if (attribute != null)
                return attribute.htmlRef;

            return null;
        }
    }

    class GetterArray : IGetter
    {
        PropertyInfo p;
        public GetterArray(PropertyInfo p)
        {
            this.p = p;
        }
        public string GetPropertyName()
        {
            return p.Name;
        }
        public string GetValueAsString(object target)
        {
            object[] arr = (object[])p.GetValue(target);
            string str = p.Name + ": [";
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    str += Logger.ObjFieldsToString(arr[i]) + ", ";
            //}
            //return str + "]";
            return null;
        }

        public string GetHtmlString()
        {
            return null;
        }
    }





    public class HtlmReflect2
    {
        static Dictionary<Type, List<IGetter>> markedProps = new Dictionary<Type, List<IGetter>>();

        public string ToHtml(object obj)
        {
            List<IGetter> props = new List<IGetter>();
            props = GetPropsWithCustomAttrib(obj.GetType());

            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='list-group'>");

            foreach (IGetter getter in props)
            {
                string htmlRef = getter.GetHtmlString();
                if (htmlRef != null)
                {
                    sb.Append(htmlRef.Replace("{name}", getter.GetPropertyName()).Replace("{value}", getter.GetValueAsString(obj)));
                    continue;
                }

                sb.Append(String.Format("<li class='list-group-item'><strong>{0}</strong>:{1}</li>", getter.GetPropertyName(), getter.GetValueAsString(obj)));
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        //public string ToHtml(object[] arr)
        //{
        //    if (arr == null || arr.Length == 0) return null;

        //    StringBuilder tableHeader = new StringBuilder();
        //    StringBuilder tableContent = new StringBuilder();

        //    //List<PropertyInfo> props = GetFieldsWithCustomAttrib(arr[0].GetType());
        //    List<PropertyInfo> props = null;

        //    //table header 
        //    tableHeader.Append("<table class ='table table-hover'> <thead> <tr>");

        //    foreach (PropertyInfo currProperty in props)
        //    {
        //        tableHeader.Append("<th>" + currProperty.Name + "</th>");
        //    }
        //    tableHeader.Append("</tr> </thead>");

        //    //table content
        //    tableContent.Append("<tbody>");
        //    //each object is a table row starts at <tr> ends in </tr>
        //    foreach (object currObject in arr)
        //    {
        //        tableContent.Append("<tr>");

        //        //each property is table data in the current row starts at <td> ends in </td>
        //        foreach (PropertyInfo currObjectProperty in props)
        //        {
        //            string htmlRef = GetHtmlAsAttribStringRef(currObjectProperty);
        //            if (htmlRef != null)
        //            {
        //                tableContent.Append(htmlRef.Replace("{name}", currObjectProperty.Name).Replace("{value}", currObjectProperty.GetValue(currObject).ToString()));
        //                continue;
        //            }
        //            tableContent.Append("<td>" + currObjectProperty.GetValue(currObject) + "</td>");
        //        }
        //        tableContent.Append("</tr>");
        //    }
        //    tableContent.Append("</tbody> </table>");
        //    return tableHeader.ToString() + tableContent.ToString();
        //}




        /// <summary>
        ///  Receives a type and checks if it exists in cache(dictionary notIgnoredProperties) 
        ///  If it exists returns the value stored for that property. 
        ///  If the type isn't cached it will check each every property of the type for the IgnoreAttribute.
        ///  If a given property isn't marked with this attribute it is added to cache.
        ///  It is also added to the list that will be returned.
        /// </summary>
        /// <param name="klass">
        ///  Type in which to check list of properties.
        /// </param>
        /// <returns>
        ///  Returns a list of properties not marked with HtmlIgnoreAttribute.
        /// </returns>

        private List<IGetter> GetPropsWithCustomAttrib(Type klass)
        {
            List<IGetter> res;
            if (markedProps.TryGetValue(klass, out res)) return res;

            PropertyInfo[] props = klass.GetProperties();

            res = new List<IGetter>();
            foreach (PropertyInfo p in props)
            {
                object[] attrs = p.GetCustomAttributes(typeof(HtmlIgnoreAttribute), true);
                if (attrs.Length != 0) continue;
                if (p.PropertyType.IsArray)
                    res.Add(new GetterArray(p));
                else
                    res.Add(new GetterObject(p));
            }
            markedProps.Add(klass, res);
            return res;
        }
    }

 
}
