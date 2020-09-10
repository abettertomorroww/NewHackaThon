using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NewHackhaThon.Data;

namespace NewHackhaThon.Models
{
    public class Profiles
    {
        /// <summary>
        /// id проф
        /// </summary>
        [Required]
        public int ProfilesId { get; set; }

        [Required(ErrorMessage = "Укажите ваше имя")]

        [StringLength(10, MinimumLength = 2, ErrorMessage = "Недопустимая длина имени")]
        [Display(Name = "Имя")]
        public string Profile_Name { get; set; }

        [Required(ErrorMessage = "Укажите вашу фамилию")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Недопустимая длина фамилии")]
        [Display(Name = "Фамилия")]
        public string Profile_Surname { get; set; }

        [Required(ErrorMessage = "Укажите город в котором вы обучаетесь")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Недопустимая длина города")]
        [Display(Name = "Город в котором обучаетесь")]
        public string Profile_City { get; set; }

        [Required(ErrorMessage = "Выберете")]
        [Display(Name = "Кем являетесь")]
        [Valid(new string[] { "Школьник", "Студент" }, ErrorMessage = "Неккоректные данные")]
        public string Profile_Who { get; set; }

        [Required(ErrorMessage = "Укажите ваше учебное заведение")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Недопустимая длина")]
        [Display(Name = "Ваше учебное заведение")]
        public string Profile_College { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Недопустимая длина")]
        [Display(Name = "Ваша специальность")]
        public string Profile_Specialty { get; set; }

        [Required]
        [Range(1, 11, ErrorMessage = "Недопустимое число")]
        [Display(Name = "В каком классе/курсе Вы обучаетесь")]
        public int Profile_Course { get; set; }
    }
}
