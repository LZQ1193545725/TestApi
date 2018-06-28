using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi.Models
{
    public class PersonView
    {

        public System.Guid Id { get; set; }
        public string UserName { get; set; }
        public System.Guid DepartMentId { get; set; }
        public int MemberType { get; set; }
        public string Role { get; set; }
        public System.Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemType { get; set; }
    }
}