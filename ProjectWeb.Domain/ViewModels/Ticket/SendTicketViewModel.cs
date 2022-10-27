using ProjectWeb.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.ViewModels.Ticket
{
    public class SendTicketViewModel
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "لطفا عنوان تیکت را وارد کنید")]
        [Display(Name = "عنوان تیکت")]
        public string TicketSubject { get; set; }

        [Required(ErrorMessage = "لطفا متن تیکت را وارد کنید")]
        [Display(Name = "متن تیکت")]
        [DataType(DataType.MultilineText)]
        //[AllowHtml]
        public string TicketContent { get; set; }
    }
}
