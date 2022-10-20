using System;
using System.Collections.Generic;
using System.Text;
using ProjectWeb.Domain.Models.Common;

namespace ProjectWeb.Domain.Models.SiteSetting
{
    public class EmailSetting : BaseEntity
    {
        public string From { get; set; }
        public string Password { get; set; }
        public string SMTP { get; set; }
        public bool EnbaleSSL { get; set; }
        public bool IsDefault { get; set; }
        public string DisplayName { get; set; }
        public int Port { get; set; }
    }
}
