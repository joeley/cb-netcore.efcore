using Asp.NetCore.Business.Interface;
using Asp.NetCore.DBFactory;
using Asp.NetCore.IDal;
using Asp.NetCore.Model.Business;
using Asp.NetCore.Model.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asp.NetCore.Business.Service
{
    public class MenuService : BaseService, IMenuService
    {
        private readonly IMenuDal _IMenuDal;

        public MenuService(IMenuDal menuDal)
        {
            _IMenuDal = menuDal;
        }

        /// <summary>
        /// 获取当前用户下的授权菜单HTML代码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetMenu(long userId)
        {
            //获取菜单，生成导航栏
            string headStr = "<ul class=\"nav nav-main\">";
            string feetStr = "</ul>";
            string bodyStr = "";
            try
            {
                List<Menu> menu = QueryMenuInfoByUserId(userId);//菜单集合
                                                                        //遍历菜单,生成html
                for (int i = 0; i < menu.Count; i++)
                {
                    string url = "";
                    //主菜单存在url,不为空也不为“”
                    if (!string.IsNullOrEmpty(menu[i].mainMenu.node_targeturl))
                    {
                        url = string.Format("href=\"javascript:void(0)\" onclick=\"RedirectAjax(this)\" ");
                    }
                    string mainHead = "<li class=\"nav-parent\">";
                    //没有子菜单时采用另外的样式
                    if (menu[i].secondMenu.Count <= 0)
                    {
                        mainHead = "<li class=\"nav-active\">";
                    }
                    string mainFoot = "</li>";
                    string mainBody = string.Format("<a id=\"{0}\" name=\"{1}\" {2}> <i class=\"fa {3}\" aria-hidden=\"true\"></i> <span> {4} </span> </a>",
                         menu[i].mainMenu.MainMenu_Id,
                         menu[i].mainMenu.node_targeturl,
                         url,
                         menu[i].mainMenu.iconClass,
                         menu[i].mainMenu.MainMenu_Name);
                    string secondhead = "<ul class=\"nav nav-children\">";//二级菜单 <ul> 头
                    string secondfoot = "</ul>";//二级菜单</ul>
                    string secondbody = "";
                    for (int j = 0; j < menu[i].secondMenu.Count; j++)
                    {
                        string secondurl = string.Format(" href=\"javascript:void(0)\" onclick=\"RedirectAjax(this)\" ");
                        secondbody += string.Format("<li><a {0} id=\"{1}\" name= \"{2}\" >{3}</a></ li> ",
                            secondurl,
                            menu[i].secondMenu[j].SecondMenu_Id, //id
                            menu[i].secondMenu[j].node_targeturl,//url
                            menu[i].secondMenu[j].SecondMenu_Name);//name
                    }
                    bodyStr += mainHead + mainBody + secondhead + secondbody + secondfoot + mainFoot;
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error("查询Menu失败", ex);
            }
            bodyStr = headStr + bodyStr + feetStr;
            return bodyStr;
        }

        /// <summary>
        /// 查询用户授权菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Menu> QueryMenuInfoByUserId(long userId)
        {
            var menus = new List<Menu>();
            var mainMenus = _IMenuDal.QueryMainMenu(userId);
            var secondMenus = _IMenuDal.QuerySecondMenu(userId);

            for (int i = 0; i < mainMenus.Count; i++)
            {
                Menu m_menu = new Menu();
                m_menu.mainMenu = mainMenus[i];
                List<SecondMenuT> m_secondMenus = new List<SecondMenuT>();
                for (int j = 0; j < secondMenus.Count; j++)
                {
                    if (secondMenus[j].MainMenu_Id == mainMenus[i].MainMenu_Id)
                    {
                        m_secondMenus.Add(secondMenus[j]);
                    }
                }
                m_menu.secondMenu = m_secondMenus;
                menus.Add(m_menu);
            }

            return menus;
        }

    }
}
