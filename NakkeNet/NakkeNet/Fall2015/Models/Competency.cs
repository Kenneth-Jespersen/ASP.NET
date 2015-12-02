using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NakkeNet.Models
{
    public class Competency
    {
        public int CompetencyId { get; set; }
        public String Name { get; set; }
        public int CompetencyHeaderId { get; set; }

        public CompetencyHeader CompetencyHeader { get; set; }

    }
}