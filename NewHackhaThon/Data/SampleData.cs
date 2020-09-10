using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewHackhaThon.Models;

namespace NewHackhaThon.Data
{
 
        public static class SampleData
        {
            public static void Initialize(ApplicationDbContext context)
            {
                if (!context.Student.Any())
                {
                context.Student.AddRange(
                    new Students
                    {
                        Student_Name = "Иван",
                        Student_Surname = "Иванов",
                        Student_College = "ДИТИ НИЯУ МИФИ",
                        Student_City = "Димиторовград",
                        Student_Specialty = "СЭФ",
                        Student_Course = 4

                    },
                    new Students
                    {
                        Student_Name = "Петр",
                        Student_Surname = "Петров",
                        Student_College = "НИЯУ МИФИ",
                        Student_City = "Москва",
                        Student_Specialty = "ИТФ",
                        Student_Course = 5
                    });
 
                    }
           
            }
            }
            }
 

