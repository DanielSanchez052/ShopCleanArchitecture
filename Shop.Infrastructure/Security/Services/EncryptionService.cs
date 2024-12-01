using Shop.Application.Security.Services;
using System.Security.Cryptography;
using System.Text;

namespace Shop.Infrastructure.Security.Services;

public class EncryptionService : IEncryptionService
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public EncryptionService(string key, string iv)
    {
        if (key.Length != 32 || iv.Length != 16)
        {
            throw new ArgumentException("La clave debe tener 32 caracteres y el IV 16 caracteres.");
        }
        _key = Encoding.UTF8.GetBytes(key);
        _iv = Encoding.UTF8.GetBytes(iv);
    }

    public string Encrypt(string plainText)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = _key;
            aes.IV = _iv;

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var writer = new StreamWriter(cs))
                {
                    writer.Write(plainText);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public string Decrypt(string encryptedText)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = _key;
            aes.IV = _iv;

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var reader = new StreamReader(cs))
            {
                return reader.ReadToEnd();
            }
        }
    }
}