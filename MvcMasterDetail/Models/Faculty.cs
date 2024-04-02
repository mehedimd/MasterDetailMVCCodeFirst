using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcMasterDetail.Models
{
    public class Faculty
    {
        public Faculty()
        {
            this.Students = new List<Student>();
        }
        public int ID {  get; set; }
        [Required]
        public string FacultyName { get; set; }
        [Required]
        public string CourseName {  get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CourseStartDate { get; set; }
        public string PicPath {  get; set; }
        [NotMapped]
        public HttpPostedFileBase Picture { get; set; }
        public virtual List<Student> Students {  get; set; }
    }
}