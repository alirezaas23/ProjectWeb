using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace ProjectWeb.Application.ViewModels.TicketAnswerViewModels
{
    public class AnswerTicketViewModel
    {
        public Ticket Ticket { get; set; }
        [Display(Name = "تاریخ ارسال پاسخ")]
        public string TicketAnswerDate { get; set; }

        [Required(ErrorMessage = "پاسخ تیکت را وارد کنید")]
        [Display(Name = "متن پاسخ")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string TicketAnswerText { get; set; }
    }
}
