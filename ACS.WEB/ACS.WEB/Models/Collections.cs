using ACS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.Models
{
    public static class Collections
    {
        public static IEnumerable<FolderChancelleryViewModel> Folders { get; set; }
        public static IEnumerable<EmployeeViewModel> Empls { get; set; }
        public static IEnumerable<ExternalOrganizationViewModel> ExtlOrgs { get; set; }
        public static IEnumerable<JournalRegistrationsViewModel> Journals { get; set; }
    }
}