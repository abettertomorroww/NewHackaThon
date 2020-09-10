using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewHackhaThon.Models
{
    public class Pupils
    {
        /// <summary>
        /// id школьника
        /// </summary>
        public int PupilsId { get; set; }

        /// <summary>
        /// Средний балл школьника
        /// </summary>
        [Required]
        [Display(Name = "Средний балл")]
        public string Pupils_Summ { get; set; }

        /// <summary>
        /// имя школьника
        /// </summary>
        [Required]
        [Display(Name = "Имя")]
        public string Pupils_Name { get; set; }
        /// <summary>
        /// фамилия школьника
        /// </summary>
        [Required]
        [Display(Name = "Фамилия")]
        public string Pupils_Surname { get; set; }
        /// <summary>
        /// школа школьника
        /// </summary>
        [Required]
        [Display(Name = "Школа/Колледж")]
        public string Pupils_School { get; set; }

        /// <summary>
        /// какой класс у школьника
        /// </summary>
        [Required]
        [Display(Name = "Класс/Курс")]
        public int Pupils_Class { get; set; }

        /// <summary>
        /// Город обучения школьника
        /// </summary>
        [Required]
        [Display(Name = "Город обучения")]
        public string Pupils_City { get; set; }
    }
}
