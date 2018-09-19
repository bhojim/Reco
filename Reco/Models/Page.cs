using System;
using System.Collections.Generic;

namespace Reco.Models
{
    public partial class Page
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int PageNumber { get; set; }
        public string Content { get; set; }

        public Document Document { get; set; }
    }
}
