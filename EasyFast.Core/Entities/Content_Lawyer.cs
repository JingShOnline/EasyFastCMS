using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Core.Entities
{
    public class Content_Lawyer : Entity
    {
        public string Keyword { get; set; }
        public string Description { get; set; }

        public string Avatar { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public string Content { get; set; }
    }
}
