using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeViewerExtractor
{
    public class Model
    {

        public DateTime ModifiedDate { get; set; }

        public int Version { get; set; }
        public List<Pattern> Patterns { get; set; }
        public List<Rule> Rules { get; set; }
    }

    public class Pattern
    {

        public DateTime ModifiedDate { get; set; }
        public Guid PatternId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        
        public int Category { get; set; }

        public int Severity { get; set; }

        public int Value { get; set; }

        public int PatternType { get; set; }

        public List<Rule> Rules { get; set; }

    }

    public class Rule
    {
        // "cat_lb_whyfix"
        //"cat_lb_level_ref"
        //"cat_lb_primarycategory"
        //"cat_lb_componenttype"
        public string Name { get; set; }
        public string Level { get; set; }
        public string PrimaryCategory { get; set; }
        public string ComponentType { get; set; }

        public string WhyFix { get; set; }

    }
}
