using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewHackhaThon.Models
{
    public class Students
    {

        /// <summary>
        /// id студента
        /// </summary>
        public int StudentsId { get; set; }

        /// <summary>
        /// Средний балл студента
        /// </summary>
        [Required]
        [Display(Name = "Средний балл")]
        public string Student_Summ { get; set; }

        /// <summary>
        /// имя студента
        /// </summary>
        [Required]
        [Display(Name = "Имя")]
        public string Student_Name { get; set; }
        /// <summary>
        /// фамилия студента
        /// </summary>
        [Required]
        [Display(Name = "Фамилия")]
        public string Student_Surname { get; set; }
        /// <summary>
        /// институт
        /// </summary>
        [Required]
        [Display(Name = "Институт")]
        public string Student_College { get; set; }

        /// <summary>
        /// город
        /// </summary>
        [Required]
        [Display(Name = "Город обучения")]
        public string Student_City { get; set; }

        /// <summary>
        /// специальность на которую студент учится 
        /// </summary>
        [Required]
        [Display(Name = "Специальность")]
        public string Student_Specialty { get; set; }
        /// <summary>
        /// Курс 
        /// </summary>
        [Required]
        [Display(Name = "Курс")]
        public int Student_Course { get; set; }

    }
}
