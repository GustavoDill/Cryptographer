using AndroidExtendedCommands.CSharp.Data.Cryptography;
using System.Collections.Generic;

namespace Cryptographer
{
    public static class Settings
    {
        public static int Cryptography { get; set; }
        private static List<object> crpts;
        public static List<object> AvaliableCryptographies
        {
            get
            {
                if (crpts == null)
                {
                    crpts = new List<object>();
                    var xorCryptor = new XORAlgorithm();
                    var base64 = new Base64Cryptor();
                    crpts.AddRange(new object[]
                    {
                        new CryptographyInfo<string, string>("XOR", xorCryptor.GetType().GetMethod("Encrypt"), xorCryptor.GetType().GetMethod("Decrypt"), xorCryptor),
                        new CryptographyInfo<string, string>("Base64", base64.GetType().GetMethod("Encode"), base64.GetType().GetMethod("Decode"), base64)
                    });
                }
                return crpts;
            }
        }
    }
}
