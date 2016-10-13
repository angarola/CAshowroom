using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angarola.Web.Domain
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string LookbookURL { get; set; }
        public string LinesheetURL { get; set; }
    }
}