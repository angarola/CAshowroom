using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angarola.Web.Models.Requests
{
    public class CalendarUpdateRequest : CalendarRequest
    {
        public int Id { get; set; }
    }
}