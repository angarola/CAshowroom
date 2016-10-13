﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angarola.Web.Models.Responses
{
    public class ItemsResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}