using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    /*
     * 主菜单表
     * */
    public class MainMenuT
    {
        [Key]
        [StringLength(50)]
        public string MainMenu_Id { get; set; }//菜单编号
        [StringLength(50)]

        public string MainMenu_Name { get; set; }//菜单名称

        public int? node_index { get; set; }//排序
        [StringLength(50)]
        public string node_targeturl { get; set; }//地址
        [StringLength(64)]
        public string iconClass { get; set; }//icon 的CSS
    }
}
