﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HtmlReflect
{ 
    public class Htmlect
    {
        public string ToHtml(object obj)
        {
            PropertyInfo[] fs = obj.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='list-group'>");
            foreach (PropertyInfo p in fs)
            {
                object[] attrs = p.GetCustomAttributes(typeof(HtmlIgnoreAttribute), true);
                if (attrs.Length != 0) continue;
                HtmlAsAttribute attribute = (HtmlAsAttribute)p.GetCustomAttribute(typeof(HtmlAsAttribute)); // extrair para variável local
                if(attribute != null)
                {
                    sb.Append(attribute.htmlRef.Replace("{name}", p.Name).Replace("{value}", p.GetValue(obj).ToString()));
                    continue;
                }
                sb.Append(
                    String.Format("<li class='list-group-item'><strong>{0}</strong>:{1}</li>", p.Name, p.GetValue(obj)));
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        public string ToHtml(object[] arr)
        {
            if (arr==null || arr.Length == 0) return null;

            StringBuilder tableHeader = new StringBuilder();
            StringBuilder tableContent = new StringBuilder();

            LinkedList<PropertyInfo> notIgnoredProperties = new LinkedList<PropertyInfo>();

            //table header 
            tableHeader.Append("<table class ='table table-hover'> <thead> <tr>");
            foreach (PropertyInfo currProperty in arr[0].GetType().GetProperties())
            {
                object[] attrs = currProperty.GetCustomAttributes(typeof(HtmlIgnoreAttribute), true);
                if (attrs.Length != 0)continue;
                notIgnoredProperties.AddLast(currProperty);
                tableHeader.Append("<th>" + currProperty.Name+"</th>");  
            }
            tableHeader.Append("</tr> </thead>");

            //table content
            tableContent.Append("<tbody>");
            //each object is a table row starts at <tr> ends in </tr>
            foreach (object currObject in arr)
            {
                tableContent.Append("<tr>");

                //each property is table data in the current row starts at <td> ends in </td>
                foreach (PropertyInfo currObjectProperty in notIgnoredProperties)
                {
                    HtmlAsAttribute attribute = (HtmlAsAttribute)currObjectProperty.GetCustomAttribute(typeof(HtmlAsAttribute));
                    if(attribute != null)
                    {
                        tableContent.Append(attribute.htmlRef.Replace("{name}", currObjectProperty.Name).Replace("{value}", currObjectProperty.GetValue(currObject).ToString()));
                        continue;
                    }           
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
        public string htmlRef {get; set;}
        public HtmlAsAttribute(string htmlRef)
        {
            this.htmlRef= htmlRef;
        }

    }
}
