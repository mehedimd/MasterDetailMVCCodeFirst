using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMasterDetail.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string StudentName {  get; set; }
        public string Address { get; set; }
        [ForeignKey("Faculty")]
        public int FacultyID {  get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}