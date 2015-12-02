using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NakkeNet.Models;

namespace NakkeNet.ViewModels
{
    public class UserIndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<CompetencyHeader> CompetencyHeaders { get; set; }
    }
}