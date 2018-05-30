using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels.Input
{
    public class DeleteConfirmInput
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string GridId { get; set; }
    }
}