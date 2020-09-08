using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 新闻分类实体类
    /// </summary>
    [Serializable]
    public class NewsCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
