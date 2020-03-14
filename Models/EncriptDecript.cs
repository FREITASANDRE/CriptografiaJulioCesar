using System;
using System.Security.Cryptography;
using System.Text;

namespace ConvertCriptJulioCesar
{
    public static class EncriptDecript
    {
        public static string GenerateHashSha1(string pStringToHash)
        {
            using (SHA1Managed lSHA1Managed = new SHA1Managed())
            {
                var lHash = lSHA1Managed.ComputeHash(Encoding.ASCII.GetBytes(pStringToHash));
                StringBuilder lStringBuilder = new StringBuilder(lHash.Length * 2);

                foreach (byte lByte in lHash)
                {
                    lStringBuilder.Append(lByte.ToString("x2"));
                }

                return lStringBuilder.ToString();
            }
        }
        public static string DecriptMessage(string pTextToDecript, int pNumberToChange)
        {
            string lTextDescripted = "";
            int lDifferenceByAscii = 0;
            int lNumberAsciiToChar = 0;

            foreach (char lLetterOrCharacter in pTextToDecript)
            {
                if (!(Convert.ToInt32(lLetterOrCharacter) < 97 || Convert.ToInt32(lLetterOrCharacter) > 122))
                {
                    char lNextCharacter = Convert.ToChar(lLetterOrCharacter - pNumberToChange);
                    int lNextCharacterAscii = Convert.ToInt32(lNextCharacter);

                    if (lNextCharacterAscii > 122)
                    {
                        lDifferenceByAscii = 97 + lNextCharacterAscii;
                        lNumberAsciiToChar = lDifferenceByAscii - 123;
                    }
                    else
                        lNumberAsciiToChar = lNextCharacterAscii;

                    lTextDescripted += Convert.ToChar(lNumberAsciiToChar);

                }
                else
                    lTextDescripted += lLetterOrCharacter.ToString();

            }

            return lTextDescripted;
        }
    }
}
