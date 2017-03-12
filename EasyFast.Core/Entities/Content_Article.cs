using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Core.Entities
{
    public class Content_Article : Entity
    {
        public string Keyword { get; set; }

        public string Description { get; set; }

        public string Info { get; set; }

        public string Content { get; set; }
    }
}
