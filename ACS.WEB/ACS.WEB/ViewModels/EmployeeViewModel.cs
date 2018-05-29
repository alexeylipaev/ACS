using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public partial class EmployeeViewModel : EntityViewModel
    {

        [Display(Name = "ID")]
        public string FName { get; set; }
        [Display(Name = "Фамилия")]
        public string LName { get; set; }
        [Display(Name = "Имя")]
        public string MName { get; set; }
        [Display(Name = "Отчество")]
        public string Email { get; set; }
        [Display(Name = "ФИО")]
        public string FullName
        { get; set; }

        public Guid? Guid1C { get; set; }
        public int? ApplicationUserId { get; set; }
    }
    //public class SelectedEmployeeViewModel
    //{

    //    public SelectedEmployeeViewModel()
    //    {
    //        SelectedId = new HashSet<int>();
    //        if(Collection == null)
    //        Collection = new List<EmployeeViewModel>();
    //    }
    //    public int id { get; set; }

    //    static public List<EmployeeViewModel> Collection { get; set; }
    //    public ICollection<int> SelectedId { get; set; }
    //}
  
}