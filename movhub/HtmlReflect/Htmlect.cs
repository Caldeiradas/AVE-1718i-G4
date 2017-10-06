using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HtmlReflect
{


    public class Htmlect
    {
        public string ToHtml(object obj)
        {
            List<PropertyInfo> res;
            PropertyInfo[] fs = obj.GetType().GetProperties();
            res = new List<PropertyInfo>();
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='list-group'>");
            foreach (PropertyInfo p in fs)
            {
                object[] attrs = p.GetCustomAttributes(typeof(HtmlIgnoreAttribute), true);
                if (attrs.Length != 0) continue;
                Console.WriteLine("Property Name= {0}, Value = {1}", p.Name, p.GetValue(obj));
                sb.Append("<li class='list-group-item'><strong>");
                sb.Append(p.Name);
                sb.Append("</strong>:");
                sb.Append(p.GetValue(obj));
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        public string ToHtml(object[] arr)
        {
            StringBuilder tableHeader = new StringBuilder();
            StringBuilder tableContent = new StringBuilder();

            PropertyInfo[] allProperties = arr[0].GetType().GetProperties();
            LinkedList<PropertyInfo> notIgnoredProperties = new LinkedList<PropertyInfo>();


            //table header 
            tableHeader.Append("<table class ='table table-hover'> <thread> <tr>");
            foreach (PropertyInfo currProperty in allProperties)
            {
                object[] attrs = currProperty.GetCustomAttributes(typeof(HtmlIgnoreAttribute), true);
                

                if (attrs.Length != 0)
                {
                    
                    Console.WriteLine(attrs[0].ToString());
                    continue;
                }
                notIgnoredProperties.AddLast(currProperty);
                
                    tableHeader.Append("<th>" + currProperty.Name+"</th>");
                
            }
            tableHeader.Append("</tr> </thread>");


            //table content

            tableContent.Append("<tbody>");
            foreach (object currObject in arr)
            {

                tableContent.Append("<tr>");

                foreach (PropertyInfo currObjectProperty in notIgnoredProperties)
                {
                   
                        tableContent.Append("<td>" + currObjectProperty.GetValue(currObject) + "</td>");
                }

                tableContent.Append("</tr>");
            }
            tableContent.Append("</tbody> </table>");
            return tableHeader.ToString()+tableContent.ToString();
        }

    }

    public class HtmlIgnoreAttribute : Attribute
    {
    }

    public class HtmlAsAttribute : Attribute
    {
        string htmlRef {get; set;}
        public HtmlAsAttribute(string htmlRef)
        {
            htmlRef = this.htmlRef;
        }

    }
}
