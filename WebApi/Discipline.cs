using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi
{
    public class Discipline
    {
        public string CaseId { get; set; }

        public string StudentId { get; set; }

        public string StudentName { get; set; }

        public string Description { get; set; }

        public string CaseDate { get; set; }

        public string Verdict { get; set; }

        public string VerdictDate { get; set; }
    }
}
