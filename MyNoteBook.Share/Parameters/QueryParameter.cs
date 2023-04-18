﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Share.Parameters
{
    public class QueryParameter
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public string? Search { get; set; }
    }
}
