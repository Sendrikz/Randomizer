using System;
using System.ComponentModel.DataAnnotations;

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
