using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDB.Model
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; } 
        public string Name{get;set;}
        public DateTime CreateOn { get;set;}
        public Guid ContactId { get;set;}
    }
}
