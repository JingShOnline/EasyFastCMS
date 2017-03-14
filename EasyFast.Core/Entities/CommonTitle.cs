using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Core.Entities
{
    public class CommonTitle : Entity
    {
        public int ColumnId { get; set; }

        public int ItemId { get; set; }

        public int ModelId { get; set; }
        public string TableName { get; set; }

        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string ShortTitle { get; set; }

        public int Hits { get; set; }
        public int DayHits { get; set; }
        public int WeekHits { get; set; }
        public int MonthHits { get; set; }

        public string DefaultPicUrl { get; set; }
        
    }
}
