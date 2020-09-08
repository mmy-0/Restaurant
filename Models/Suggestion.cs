using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 投诉类实体
    /// </summary>
    [Serializable]
    public class Suggestion
    {
        public int SuggestionId { get; set; }
        public string CustomerName  { get; set; }
        public string  ConsumeDesc { get; set; }
        public string SuggestionDesc { get; set; }
        public DateTime SuggestTime { get; set; }
        public string PhoneNumber { get; set; }
        public string Email  { get; set; }
        public int StatusId  { get; set; }
    }
}
