using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BordoProject.Models
{
    public class Answer
    {


        [Key]
        public int AnswerId { get; set; } // Birincil anahtar olarak AnswerId ekleyin

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; } // Employee ile ilişkilendirme

        [ForeignKey("TimeId")]
        public Time? Time { get; set; }

        public string? Bolum1 { get; set; }
       

        public string? Bolum3 { get; set; }
        public string? Bolum2 { get; set; }

        public string? Bolum4{ get;  set; }

        public string? Day { get; set; }

        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public double? TotalHours { get; set; }

        public bool? NonWorkingDay { get; set; }

        public DateTime? DateFilled { get; set; }



    }
}

