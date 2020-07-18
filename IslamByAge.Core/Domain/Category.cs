using IslamByAge.Core.Enums;
using IslamByAge.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IslamByAge.Core.Domain
{
    public class Category:BaseEntity,ITrackable
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public Status Status { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
    }
}
