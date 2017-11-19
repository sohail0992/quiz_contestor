using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midterm
{
    class validation
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            } 
        }

        public long IsCnicValid(string cnic)
        {
            long cnic_num;
 
            if (long.TryParse(cnic, out cnic_num))
            {
                return cnic_num;
            }
            else
            {
                return 0;
            }
        }


        public bool IsNumber(string text)
        {
            return false;
        }


        public string generte_pass()
        {
            int lengthOfPassword = 8;
            string valid = "abcdefghijklmnozABCDEFGHIJKLMNOZ1234567890";
            StringBuilder strB = new StringBuilder(100);
            Random random = new Random();
            while (lengthOfPassword-- > 0)
            {
                strB.Append(valid[random.Next(valid.Length)]);
            }
            return strB.ToString();
        }
        
       
    }
}
