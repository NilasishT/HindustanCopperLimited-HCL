using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq.Dynamic;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Web.Mvc;
using Hindustancopperlimited.Models;
using System.Collections.Specialized;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Helpers
{
    public class AuditableBase : IAuditable
    {
        ArrayList _objArrayListFieldName = new ArrayList();
        public object _oldObject { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        public string TableNamedfs { get; set; }
        public string TablePKFieldNamedfs { get; set; }
        public string TablePKValuedfs { get; set; }
        public string ClientIpdfs { get; set; }
        public string TransactionTypedfs { get; set; }
        ArrayList _ModifiedFields = new ArrayList();
        public ArrayList ModifiedFields
        {
            get
            {
                return this._ModifiedFields;
            }
            set
            {
                this._ModifiedFields = value;
            }
        }

        public void table_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            try
            {
                MethodInfo method = sender.GetType().GetMethod("Clone");
                object objectBeforepropertyChanged = method.Invoke(sender, null);
                sender.GetType().GetProperty("_oldObject").SetValue(sender, objectBeforepropertyChanged, null);
            }
            catch (Exception ex)
            {

            }

        }

        public void table_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            try
            {
                object oldObject = sender.GetType().GetProperty("_oldObject").GetValue(sender, null);
                object originalVal = oldObject.GetType().GetProperty(e.PropertyName).GetValue(oldObject, null);
                object newVal = sender.GetType().GetProperty(e.PropertyName).GetValue(sender, null);
                AuditValueObject objAuditValue = new AuditValueObject(e.PropertyName, originalVal, newVal);
                this.ModifiedFields.Add(objAuditValue);
                this.TableNamedfs = sender.GetType().Name;
                if (this.TablePKFieldNamedfs != null)
                {
                    this.TablePKValuedfs = Convert.ToString(sender.GetType().GetProperty(this.TablePKFieldNamedfs).GetValue(sender, null));
                }

            }
            catch (Exception ex)
            {

            }
        }

    }
    internal interface IAuditable
    {
        string CreatedBy { get; set; }
        Nullable<DateTime> CreatedOn { get; set; }
        string ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedOn { get; set; }
        string TableNamedfs { get; set; }
        string TablePKFieldNamedfs { get; set; }
        string TablePKValuedfs { get; set; }
        string ClientIpdfs { get; set; }
        string TransactionTypedfs { get; set; }
        ArrayList ModifiedFields { get; set; }
    }
    public class AuditValueObject
    {
        public string FieldName { get; set; }
        public object OriginalValue { get; set; }
        public object NewValue { get; set; }
        public AuditValueObject()
        {
            this.FieldName = "";
            this.OriginalValue = null;
            this.NewValue = null;
        }
        public AuditValueObject(string FieldName, object OriginalValue, object NewValue)
        {
            this.FieldName = FieldName;
            this.OriginalValue = OriginalValue;
            this.NewValue = NewValue;

        }
    }
   
}