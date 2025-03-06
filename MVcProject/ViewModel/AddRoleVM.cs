using System.ComponentModel.DataAnnotations;

namespace MVcProject.ViewModel
{
    public class AddRoleVM
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
