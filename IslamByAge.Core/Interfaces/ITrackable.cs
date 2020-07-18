using System;
using System.Collections.Generic;
using System.Text;

namespace IslamByAge.Core.Interfaces
{
    public interface ITrackable
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
    }
}
