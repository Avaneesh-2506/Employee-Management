using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechProjectHub.App_Code
{
    public class Cyptography
    {
        internal string EncryptMyPassword(string PlainText)
        {
            string EncryptedText = "";
            int ASCIIValue, x;
            char ch, newCh;
            for (x = 0; x < PlainText.Length; x++)
            {
                ch = PlainText[x];
                ASCIIValue = (int)ch;
                if (ASCIIValue >= 65 && ASCIIValue <= 90)
                    ASCIIValue = 65 + 90 - ASCIIValue;
                else if (ASCIIValue >= 97 && ASCIIValue <= 122)
                    ASCIIValue = ASCIIValue - 90 + 65;
                else if (ASCIIValue >= 48 && ASCIIValue <= 57)
                    ASCIIValue = ASCIIValue + 1;
                newCh = (char)ASCIIValue;
                EncryptedText = EncryptedText + newCh;
            }
            return EncryptedText;
        }
    }
}