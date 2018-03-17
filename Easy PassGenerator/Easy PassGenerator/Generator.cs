using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPasswordGenerator
{
    public static class Generator
    {
        private static Random _rand;

        static Generator()
        {

            _rand = new Random((int)DateTime.Now.Ticks);
        }

        public static string GetRandomPassword(int passwordlength, string template)
        {
            // create new charachter array to our new password
            char[] password = new char[passwordlength];


            // randomize template to get better randomize before starts creating the password 
            char[] chars = template.ToArray().OrderBy(s => (_rand.Next(2) % 2) == 0).ToArray();


            for (int i = 0; i < passwordlength; i++)
            {

                password[i] = chars[_rand.Next(0, chars.Length)];
            }
            return new string(password);
        }

        public static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }
         

    


    }
}
