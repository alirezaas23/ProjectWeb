using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ProjectWeb.Application.ViewModels.Common;

namespace ProjectWeb.Application.ViewModels
{
    public class TicketViewModels : GoogleReCaptchaViewModel
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

    public class MyTicketsViewModel
    {
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public string TicketSubject { get; set; }
        public string TicketDateTime { get; set; }
        public string TicketText { get; set; }
    }
}
