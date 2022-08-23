using ProjectWeb.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjectWeb.Application.ViewModels
{
    public class TicketViewModels
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "لطفا عنوان تیکت را وارد کنید")]
        [Display(Name = "عنوان تیکت")]
        public string TicketSubject { get; set; }

        [Display(Name = "تاریخ ارسال")]
        public string TicketDateTime { get; set; }

        [Required(ErrorMessage = "لطفا متن تیکت را وارد کنید")]
        [Display(Name = "متن تیکت")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string TicketText { get; set; }
    }

    public class TicketInfoViewModel
    {
        public int TicketId { get; set; }
        public string TicketSubject { get; set; }
        public string TicketDateTime { get; set; }
        public string TicketText { get; set; }
        public string UserId { get; set; }
    }

    public class TicketAnswerViewModel
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
