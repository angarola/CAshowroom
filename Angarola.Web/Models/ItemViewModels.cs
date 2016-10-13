using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Angarola.Web.Domain;

namespace Angarola.Web.Models
{
    public class ItemViewModel<T>
    {
        public T Item { get; set; }
    }
}