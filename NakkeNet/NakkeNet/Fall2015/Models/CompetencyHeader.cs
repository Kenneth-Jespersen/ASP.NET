using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NakkeNet.Models
{
    public class CompetencyHeader
    {
        public int CompetencyHeaderId { get; set; }
        public String Name { get; set; }

        public ICollection<Competency> Competencies { get; set; }

    }
}