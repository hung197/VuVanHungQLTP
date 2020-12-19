﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.Service
{
    public class thamsoPhanTrang
    {
        const int maxPageSize = 50;
        public int currentPage { get; set; } = 1;
        public int _pagesize = 4;
        public int PageSize
        {
            get
            {
                return _pagesize;
            }
            set
            {
                _pagesize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
