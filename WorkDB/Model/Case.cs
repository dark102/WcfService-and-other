using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDB.Model
{
    public class Case
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateOn { get; set; }
        public virtual Contact Contact { get; set; }
        [ForeignKey("Contact")]
        public Guid ContactId { get; set; }
        public virtual Account Account { get; set; }
        [ForeignKey("Account")]
        public Guid AccountId { get; set; }
    }
}
