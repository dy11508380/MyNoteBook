﻿using MyNoteBook.Common.Models;
using MyNoteBook.Share.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Service
{
    public class MemoService : BaseService<MemoDto>, IMemoService
    {
        public MemoService(HttpRestClient restClient) : base(restClient, "Memo")
        {

        }
    }
}
