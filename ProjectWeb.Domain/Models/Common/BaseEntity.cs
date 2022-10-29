using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.Models.Common
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;
    }
}
