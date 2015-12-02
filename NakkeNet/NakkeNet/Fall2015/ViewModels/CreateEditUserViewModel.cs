using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NakkeNet.Models;
using NakkeNet.Repositories;

namespace NakkeNet.ViewModels
{
    public class CreateEditUserViewModel
    {
        public User User { get; set; }
        public List<CompetencyHeader> CompetencyHeaders { get; set; }
        //public List<Competency> Competencies { get; set; }
        //public IEnumerable<Competency> Competencies { get; set; }
        //public ICollection<Competency> Competencies { get; set; }
        


    }
}