using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewHackhaThon.Models;

namespace NewHackhaThon.Data
{
    public class PupilData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Pupil.Any())
            {
                context.Pupil.AddRange(
                    new Pupils
                    {
                        Pupils_Name = "Петр",
                        Pupils_Surname = "Иванов",
                        Pupils_School = "Школа №25",
                        Pupils_Class = 9,
                        Pupils_City = "Самара"

                    },
                    new Pupils
                    {
                        Pupils_Name = "Иван",
                        Pupils_Surname = "Петров",
                        Pupils_School = "Школа №4",
                        Pupils_Class = 11,
                        Pupils_City = "Москва"
                    });

            }

        }
    }
}