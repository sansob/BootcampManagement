using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootcampManagement.Client.ViewModels
{
    public class BatchVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}