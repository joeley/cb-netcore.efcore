using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{

    /*
     * 二级菜单表
     * */
    public class SecondMenuT
    {
        [Key]
        [StringLength(50)]
        public string SecondMenu_Id { get; set; }//菜单编号
        [StringLength(50)]
        public string SecondMenu_Name { get; set; }//菜单名称
        [StringLength(50)]
        public string MainMenu_Id { get; set; }//父菜单名称

        public int? node_index { get; set; }//排序
        [StringLength(100)]
        public string node_targeturl { get; set; }//地址

    }
}
