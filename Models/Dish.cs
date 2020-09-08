using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 菜品实体类（可用工具生成）
    /// </summary>
    [Serializable] //序列化方法：安全和传输方便
    public class Dish
    {
        public int  DishId { get; set; }
        public string DishName { get; set; }
        public int UnitPrice { get; set; }
        public int CategoryId { get; set; }

        //扩展属性
        public string CategoryName { get; set; }
    }
}
