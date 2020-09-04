using Asp.NetCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Model.Business
{
    public class Menu
    {
        public MainMenuT mainMenu { get; set; }//主菜单

        public List<SecondMenuT> secondMenu { get; set; }//二级菜单
    }
}
