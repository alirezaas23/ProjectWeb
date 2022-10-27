using ProjectWeb.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.ViewModels.Ticket
{
    public class SendTicketViewModel
    {
        public long UserId { get; set; }

        [Display(Name = "عنوان تیکت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد.")]
        public string TicketSubject { get; set; }

        [Display(Name = "متن تیکت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DataType(DataType.MultilineText)]
        //[AllowHtml]
        public string TicketContent { get; set; }
    }
}
