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
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='list-group'>");
            PropertyInfo[] fs = obj.GetType().GetProperties();
            foreach (PropertyInfo p in fs)
            {
                object[] attrs = p.GetCustomAttributes(typeof(HtmlIgnoreAttribute), true);
                if (attrs.Length != 0) continue;
                if(HtmlAsAttributeExists(obj, p, sb))continue ;
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
                    if (HtmlAsAttributeExists(currObject, currObjectProperty, tableContent)) continue;
                    tableContent.Append("<td>" + currObjectProperty.GetValue(currObject) + "</td>");
                }
                tableContent.Append("</tr>");
            }
            tableContent.Append("</tbody> </table>");
            return tableHeader.ToString()+tableContent.ToString();
        }

        private bool HtmlAsAttributeExists(Object obj, PropertyInfo p, StringBuilder sb)
        {
            HtmlAsAttribute attribute = (HtmlAsAttribute)p.GetCustomAttribute(typeof(HtmlAsAttribute));
            if (attribute != null)
            {
                sb.Append(attribute.htmlRef.Replace("{name}", p.Name).Replace("{value}", p.GetValue(obj).ToString()));
                return true;
            }
            return false;
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
