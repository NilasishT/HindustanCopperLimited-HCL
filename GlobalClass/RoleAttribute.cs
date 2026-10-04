using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using System.Web.Routing;
using Hindustancopperlimited.Models;

namespace Hindustancopperlimited.GlobalClass
{
    public class UserRightAttribute : ActionFilterAttribute
    {

        public string Directories { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool hasCommonActionAttribute =
                filterContext.ActionDescriptor.GetCustomAttributes(typeof(CommonActionAttribute), false).Any();

            var session = HttpContext.Current.Session;

            var userId = session["UserId"];
            if (session["NewUserID"] != null)
            {
                userId = session["NewUserID"];
            }
            var userName = session["UserName"];
            var moduleId = session["ModuleId"];
            var moduleName = session["ModuleName"];
            var userType = session["UserType"];
            var strMenuRightID = session["strMenuRightID"];

            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var lstCommonControllers = new List<string>() { "Home", "JQueryDatatable", "BPSOnlineData", "Admin" };

            //if (controllerName.ToLower() == "login" || controllerName.ToLower() == "bpsonlinedata" || controllerName.ToLower() == "jquerydatatable" ) return;
            if (controllerName.ToLower() == "payment") return;
            if (controllerName.ToLower() == "return") return;
            if (controllerName.ToLower() == "admin" && actionName.ToLower() == "login") return;
            if (controllerName.ToLower() == "home") return;
            if (controllerName.ToLower() == "page") return;
            if (controllerName.ToLower() == "vigilance") return;
            if (controllerName.ToLower() == "hindivigilance") return;
            if (controllerName.ToLower() == "hindipage") return;
            if (controllerName.ToLower() == "vendorregistration") return;
            if (controllerName.ToLower() == "contractlabour") return;
            if (controllerName.ToLower() == "averagepayment") return;
            if (controllerName.ToLower() == "dengue") return;
            if (controllerName.ToLower() == "recruitmentcareer") return;
            if (controllerName.ToLower() == "recruitment") return;
            if (controllerName.ToLower() == "recruitmentnew") return;
            if (controllerName.ToLower() == "itiapplication") return;
            if (controllerName.ToLower() == "itiapplicationnew") return;
            if (controllerName.ToLower() == "graduateapprentice") return;
            if (controllerName.ToLower() == "spotbooking") return;
            if (controllerName.ToLower() == "region" && actionName.ToLower() == "login") return;
            if (controllerName.ToLower() == "vigilance") return;
            if (controllerName.ToLower() == "recruitmentnewlogin") return;
            if (controllerName.ToLower() == "services") return;
            if (controllerName.ToLower() == "recruitmentnewadv") return;
            if (controllerName.ToLower() == "recruitmentnew1") return;
            if (controllerName.ToLower() == "kccrecruitmentnew") return;
            if (controllerName.ToLower() == "recruitmenttranslator") return;
            if (controllerName.ToLower() == "recruitmentnew1login") return;
            if (controllerName.ToLower() == "recruitmenthindiandsteno") return;
            if (controllerName.ToLower() == "recruitmentdraft") return;
            if (controllerName.ToLower() == "recruitmentadv") return;
            if (controllerName.ToLower() == "recruitmentenglish") return;
            if (controllerName.ToLower() == "recruitmentdraftlogin") return;
            
            if (userId == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } }).WithNotification(NotificationStatus.Error, "Access Denied or Session Expired");
                return;
            }

            if (hasCommonActionAttribute) return;

            if (controllerName.ToLower() == "users" && actionName.ToLower() == "changepassword") return;

            if (lstCommonControllers.Exists(x => x.ToLower() == controllerName.ToLower()))
            {
                return;
            }

            if (userType.ToString() != "Admin" && userType.ToString() != "VENDOR" && userType.ToString() != "CONTRACTOR" && userType.ToString() != "Super Admin" && userType.ToString() != "Candidate")
            {
                List<MenuModel> lstPermission = GetMenuWithFullMenuPath(userId, moduleId, session["UserType"], strMenuRightID.ToString());

                lstPermission = lstPermission.ToList();

                if (lstPermission.Exists(x => x.bitViewRight == 1 && x.strMenuAction.ToLower() == actionName.ToLower() && x.strMenuController.ToLower() == controllerName.ToLower()))
                {
                    return;
                }
                else
                {
                    //throw new Exception("Access Denied for menu : " + controllerName + "/" + actionName);
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } }).WithNotification(NotificationStatus.Error, "Access Denied for menu : " + controllerName + "/" + actionName);
                }

            }
            return;
        }

        private List<MenuModel> GetMenuWithFullMenuPath(object userId, object moduleId, object userType, object strMenuRightID)
        {
            if (userId == null)
            {
                return new List<MenuModel>();
            }
            var db = new AdminLoginContext();
            var menus = db.GetUserRightList(Convert.ToInt32(userId), userType.ToString(), strMenuRightID.ToString()).ToDictionary(r => r.pk_intMenuId);
            //var menus = db.usersMenu(Convert.ToInt32(userId), Convert.ToInt32(moduleId)).ToDictionary(r => r.pk_intMenuId);
            //var menus = db.tbl_mstmenu.ToDictionary(r => r.pk_intMenuId);

            Func<MenuModel, IEnumerable<MenuModel>> traverseUp = null;
            traverseUp = r =>
            {
                var rs = new[] { r, };
                if (r.intMenuParentId == 0)
                {
                    return rs;
                }
                else
                {
                    return traverseUp(menus[r.intMenuParentId]).Concat(rs);
                }
            };

            //var breadcrumb = string.Join(" > ", traverseUp(menu).Select(r=>r.strMenuText));
            var menuList = db.GetUserRightList(Convert.ToInt32(userId), userType.ToString(), strMenuRightID.ToString());
            //var menuList = db.usersMenu(Convert.ToInt32(userId), Convert.ToInt32(moduleId));
            var menuModelList = new List<MenuModel>();
            foreach (var objMenu in menuList)
            {
                var model = new MenuModel();
                //objMenu.CopyPropertiesTo(model);
                model.strMenuFullpath = string.Join(" / ", traverseUp(objMenu).Select(r => r.strMenuText));
                menuModelList.Add(model);
            }
            return menuModelList;

        }
    }

    public class CommonActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            return;
        }
    }
}