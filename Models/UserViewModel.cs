using Microsoft.AspNetCore.Mvc.Rendering;

namespace MainApp.Models
{
    public class UserViewModel
    {
        public IEnumerable<SelectListItem> UserList { get; set; }

        //for first dropdown selected value
        public string SelectedUser { get; set; }

    }
}



