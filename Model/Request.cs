using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Model
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int From { get; set; }

        [Required]
        public int To { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public User ReqUser { get; set; }
    }
}
