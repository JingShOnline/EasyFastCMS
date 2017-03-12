using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Common.Dto
{
    public class EasyUIDataGridPager
    {
        #region 
        private int _page = 1;
        private int _rows = 20;
        private string _sort = "Id";
        private string _order = "desc";
        #endregion
        /// <summary>
        /// 页数
        /// </summary>
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
            }
        }

        /// <summary>
        /// 行数
        /// </summary>
        public int Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
            }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort
        {
            get
            {
                return _sort;
            }
            set
            {
                _sort = value ?? "Id";
            }
        }

        /// <summary>
        /// 排序方式 asc or desc
        /// </summary>
        public string Order
        {
            get
            {
                return _order;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _order = value == "desc" ? "desc" : "asc";
                }
            }
        }
    }
}
