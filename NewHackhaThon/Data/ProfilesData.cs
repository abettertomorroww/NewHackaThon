using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewHackhaThon.Models;

namespace NewHackhaThon.Data
{
    public class ProfilesData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Profile.Any())
            {
                context.Profile.AddRange(
                    new Profiles
                    {
                        Profile_Name = "Петр",
                        Profile_Surname = "Иванов",
                        Profile_City = "МСКК",
                        Profile_College = "фыафаы",
                        Profile_Course = 5,
                        Profile_Who = "Школьник",
                        Profile_Specialty = "фыафа"

                    }
                    );

            }

        }
    }
}
