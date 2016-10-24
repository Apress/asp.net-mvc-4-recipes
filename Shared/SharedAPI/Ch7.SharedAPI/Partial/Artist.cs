using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ch7.SharedAPI
{
    public partial class Artist
    {
        public string AvatarUrlSample
        {
            get
            {
                string pattern = "/Media/Avatars/Sample{0}.jpg";
                return string.Format(pattern, RndBetween1And20());
            }
        }


        private int RndBetween1And20()
        {
            byte[] randomNumber = new byte[1];
            randomNumber[0] = 21;
            while (randomNumber[0] > 20 || randomNumber[0] < 1)
            {
                RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
                
                rnd.GetBytes(randomNumber);
            }
            return Convert.ToInt32(randomNumber[0]);
        }
    }
}
