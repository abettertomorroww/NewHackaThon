using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewHackhaThon.Data
{
    public class ValidAttribute : ValidationAttribute
    {
        private string[] profile_Who;
        public ValidAttribute(string[] profilewho)
        {
            profile_Who = profilewho;
        }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string strval = value.ToString();
                for (int i = 0; i < profile_Who.Length; i++)
                {
                    if (strval == profile_Who[i])
                        return true;
                }
            }
            return false;
        }
    }
}