using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 菜品分类
    /// </summary>
    [Serializable]
    public class DishCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
