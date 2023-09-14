using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Hindustancopperlimited.Models;

namespace Hindustancopperlimited.Controllers
{
    public class BaseController : Controller
    {
        //
        public BaseController()
        {

        }

        public List<MenuModel> BuildMenu(object userid)
        {
            List<MenuModel> lstMenu = new List<MenuModel>();

            if (userid == null)
                return lstMenu;

            using (var db = new AdminLoginContext())
            {
                //lstMenu = db.GetUserMenu(Convert.ToInt32(userid), Session["UserType"].ToString()).ToList();

                lstMenu = db.GetUserMenu(Convert.ToInt32(userid), Session["UserType"].ToString(), Session["strMenuRightID"].ToString()).ToList();
                return lstMenu;
            }
        }

        [HttpPost]
        public ActionResult ModuleChange(int intModuleId, string strModuleName)
        {
            string redirectUrl = "";
            string actionName = "Index";
            string controllerName = "Home";
            var routeValues = Request.RequestContext.RouteData.Values;
            if (routeValues != null)
            {
                if (routeValues.ContainsKey("controller"))
                {
                    controllerName = Request.RequestContext.RouteData.Values["controller"].ToString();
                }
                if (routeValues.ContainsKey("action"))
                {
                    actionName = Request.RequestContext.RouteData.Values["action"].ToString();
                }
            }




            Session["ModuleId"] = intModuleId;
            Session["ModuleName"] = strModuleName;
            var userId = Session["UserId"];

            Session["Menu"] = new JavaScriptSerializer().Serialize(BuildMenu(Convert.ToInt32(userId)));

            if (controllerName.ToLower() == "usermenu" && actionName.ToLower() == "index")
            {
                redirectUrl = new UrlHelper(Request.RequestContext).Action(actionName, controllerName);
            }
            else
            {
                redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Home");
            }

            //var redirectUrl = currentUrl;
            return Json(new { Url = redirectUrl });
        }

        public List<MenuModel> GetMenuWithFullMenuPath(object userId, object moduleId)
        {
            if (userId == null)
            {
                return new List<MenuModel>();
            }
            var db = new AdminLoginContext();
           // var menus = db.GetUserRightList(Convert.ToInt32(userId), Session["UserType"].ToString()).ToDictionary(r => r.pk_intMenuId);
            var menus = db.GetUserRightList(Convert.ToInt32(userId), Session["UserType"].ToString(), Session["strMenuRightID"].ToString()).ToDictionary(r => r.pk_intMenuId);
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
           // var menuList = db.GetUserRightList(Convert.ToInt32(userId), Session["UserType"].ToString());
            //var menuList = db.usersMenu(Convert.ToInt32(userId), Convert.ToInt32(moduleId));
            var menuList = db.GetUserRightList(Convert.ToInt32(userId), Session["UserType"].ToString(), Session["strMenuRightID"].ToString());
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
}
