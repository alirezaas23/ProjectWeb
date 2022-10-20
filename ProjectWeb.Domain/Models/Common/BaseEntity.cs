using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Models.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;
    }
}
