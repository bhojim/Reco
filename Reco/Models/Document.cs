using System;
using System.Collections.Generic;

namespace Reco.Models
{
    public partial class Document
    {
        public Document()
        {
            Page = new HashSet<Page>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public DateTime ReceivedDate { get; set; }

        public virtual ICollection<Page> Page { get; set; }

    }
}
