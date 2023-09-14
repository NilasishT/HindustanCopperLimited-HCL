using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.GlobalClass
{
    public class DFSMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
              Type containerType, Func<object> modelAccessor,
              Type modelType, string propertyName)
        {
            var modelMetadata = base.CreateMetadata(attributes, containerType,
                    modelAccessor, modelType, propertyName);

            //if (attributes.OfType<MyDisplayAttribute>().ToList().Count > 0)
            //{
            //    modelMetadata.DisplayName = GetValueFromPropertyName(propertyName);
            //}
            if (String.IsNullOrEmpty(modelMetadata.DisplayName))
            {
                modelMetadata.DisplayName = GetValueFromPropertyName(propertyName);
            }

            return modelMetadata;
        }

        private string GetValueFromPropertyName(string val)
        {
            if (String.IsNullOrEmpty(val))
            {
                return "";
            }
            string returnValue = "";
            string spaceSeperatedString = Regex.Replace(val, "(?!^)([A-Z])", " $1");
            string[] arr = spaceSeperatedString.Split(' ');
            if (arr.Count() >= 2)
            {
                for (int i = 1; i < arr.Count(); i++)
                {
                    returnValue += arr[i] + " ";
                }
            }
            else
            {
                returnValue = val;
            }
            return returnValue;
        }
    }
}