using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml.Linq;

namespace SchoolManagementSystem.GlobalClass
{
    public static class ExtensionMethods
    {
        public static void CopyPropertiesTo(this Object source,object destination)
        {
            var sourceType = source.GetType();
            var sourceProperties = sourceType.GetProperties();
            var destinationType = destination.GetType();
            var destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                
                var destinationProperty = destinationType.GetProperty(sourceProperty.Name);
                if (destinationProperty != null)
                {
                    var sourceValue = sourceProperty.GetValue(source, null);
                    var sourcePropertyType = sourceProperty.PropertyType;
                    if (sourcePropertyType == typeof(int?))
                    {
                        if (sourceValue == null)
                        {
                            sourceValue = 0;
                        }
                    }
                    destinationProperty.SetValue(destination, sourceValue, null);
                }

            }
        }

        public static string AddServerVarriablesToDatatable(this HtmlHelper htmlHelper, NameValueCollection serverVarriables)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("function(  aoData ) {");
            foreach (var key in serverVarriables.AllKeys)
            {
                stringBuilder.Append("aoData.push({name:'" + key + "', value:'" + serverVarriables[key] + "'}); ");
            }
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("}");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public static MvcHtmlString CalenderTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object additionalViewdata = null)
        {
            //var mvcHtmlString = System.Web.Mvc.Html.InputExtensions.TextBoxFor(htmlHelper, expression, htmlAttributes ?? new { @class = "text-box single-line displayDate" });
            var mvcHtmlString = EditorExtensions.EditorFor(htmlHelper, expression, additionalViewdata);
            var xDoc = XDocument.Parse(mvcHtmlString.ToHtmlString().Replace("class=\"text-box single-line\"", "class=\"text-box single-line displayDate\"").Replace("class=\"input-validation-error text-box single-line\"", "class=\"input-validation-error text-box single-line displayDate\""));
            return new MvcHtmlString(xDoc.ToString());
        }

        public static string AddDrawCallbackWtaxDatatable(this HtmlHelper htmlHelper)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("function(  oSettings ) {");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("var accNoIds = $('#hidComaseparatedAccId').val().split(',');");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("$(accNoIds).each(function( index ) {");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("$('#table-id_wrapper').find($('#chkDenad_' + accNoIds[index])).attr('checked','checked');");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("});");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public static string AddDrawCallbackTradeRenewalDatatable(this HtmlHelper htmlHelper)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("function(  oSettings ) {");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("var licNos = $('#hidComaseparatedLicNo').val().split(',');");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("$(licNos).each(function( index ) {");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("$('#table-id_wrapper').find($('#chkRenew_' + licNos[index])).attr('checked','checked');");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("});");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public static string AddDrawCallbackBPSSendSMSDatatable(this HtmlHelper htmlHelper)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("function(  oSettings ) {");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("var licNos = $('#hidSMSBPS1List').val().split(',');");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("$(licNos).each(function( index ) {");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("$('#table-id_wrapper').find(\"input[type='checkbox'][premisesno='\" + licNos[index] + \"']\").attr('checked','checked');");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("});");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public static DataSet ToDataset<T>(this List<T> list)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Table1";
            if(list.Count!=0)
            foreach (PropertyInfo property in list[0].GetType().GetProperties())
            {
                var type = property.PropertyType;
                var underlyingType = Nullable.GetUnderlyingType(type);
                var returnType = underlyingType ?? type;

                dt.Columns.Add(new DataColumn(property.Name, returnType));
            }

            foreach (var obj in list)
            {
                DataRow newRow = dt.NewRow();
                foreach (PropertyInfo property in obj.GetType().GetProperties())
                {
                    newRow[property.Name] = obj.GetType().GetProperty(property.Name).GetValue(obj, null) ?? DBNull.Value;
                }
                dt.Rows.Add(newRow);
            }
            ds.Tables.Add(dt);
            return ds;
        }
    }
}