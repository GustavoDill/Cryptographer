using System.Reflection;

namespace Cryptographer
{
    public class CryptographyInfo<TInput, TCrypterOutput> where TInput : class where TCrypterOutput : class
    {
        public CryptographyInfo(string name, MethodInfo encrypt, MethodInfo decrypt, object cryptorObject)
        {
            Name = name;
            Encrypt = encrypt;
            Decrypt = decrypt;
            CryptorObject = cryptorObject;
        }
        public TCrypterOutput InvokeEncrypt(params TInput[] input)
        {
            return (TCrypterOutput)Encrypt.Invoke(CryptorObject, input);
        }
        public TInput InvokeDecrypt(params TCrypterOutput[] encrypted)
        {
            return (TInput)Decrypt.Invoke(CryptorObject, encrypted);
        }
        public string Name { get; }
        public MethodInfo Encrypt { get; }
        public MethodInfo Decrypt { get; }
        public object CryptorObject { get; }
    }
}