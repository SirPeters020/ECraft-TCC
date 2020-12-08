using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ecraft.Api.Models;
using Microsoft.Extensions.Options;

namespace Ecraft.Api.Data.Repositories.Cryptography
{
    public class AesCryptographyService
    {

        private readonly IConfiguration _config;
        private const string _iv = "ECraft-pbSnh2xh5";

        public AesCryptographyService(IConfiguration config)
        {
            _config = config;
        }

        // Encriptografa um valor especifico
        public string Encrypt(string dataToEncrypt)
        {
            var key = GetCryptoKey();
            var iv = Encoding.ASCII.GetBytes(_iv);
            byte[] encrypted;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStram = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sWhriter = new StreamWriter(cStram))
                        {
                            sWhriter.Write(dataToEncrypt);
                        }
                        encrypted = mStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        // Encriptografa props de um Objeto, exceto bool, Object e IList
        public dynamic Encrypt(Object obj)
        {
            string encryptValue;
            string value;
            foreach (var props in obj.GetType().GetProperties())
            {
                if(props.Name.Contains("Email") || props.Name.Contains("Password"))
                {
                    value = props.GetValue(obj, null).ToString();
                    encryptValue = Encrypt(value);
                    props.SetValue(obj, encryptValue);
                }
            }
            return obj;
        }

        // Encriptografa props de uma ILista de Obj
        public dynamic Encrypt(IList<Object> objList)
        {
            foreach (var obj in objList)
            {
                string encryptValue;
                string value;
                foreach (var props in obj.GetType().GetProperties())
                {
                    if (props.Name.Contains("Email") || props.Name.Contains("Password"))
                    {
                        value = props.GetValue(obj, null).ToString();
                        encryptValue = Encrypt(value);
                        props.SetValue(obj, encryptValue);
                    }
                }
            }
            return objList;
        }

        // Descriptografa um valor especifico
        public string Decrypt(string dataToDecrypt)
        {
            var key = GetCryptoKey();
            var iv = Encoding.ASCII.GetBytes(_iv);
            var byteToDecrypt = Convert.FromBase64String(dataToDecrypt);
            string dataDecrypt = null;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream mStram = new MemoryStream(byteToDecrypt))
                {
                    using (CryptoStream cStream = new CryptoStream(mStram, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sReader = new StreamReader(cStream))
                        {
                            dataDecrypt = sReader.ReadToEnd();
                        }
                    }
                }
            }
            return dataDecrypt;
        }

        // Descriptografa props de um Objeto, ignora bool, Object e IList
        public dynamic Decrypt(Object obj)
        {
            string decryptValue;
            string value;
            foreach (var props in obj.GetType().GetProperties())
            {
                if (props.Name.Contains("Email") || props.Name.Contains("Password"))
                {
                    value = props.GetValue(obj, null).ToString();
                    decryptValue = Decrypt(value);
                    props.SetValue(obj, decryptValue);
                }
            }
            return obj;
        }

        // Descriptografa props de uma IList de Obj
        public dynamic Decrypt(IList<Object> objList)
        {
            foreach (var obj in objList)
            {
                string decryptValue;
                string value;
                foreach (var props in obj.GetType().GetProperties())
                {
                    if (props.Name.Contains("Email") || props.Name.Contains("Password"))
                    {
                        value = props.GetValue(obj, null).ToString();
                        decryptValue = Decrypt(value);
                        props.SetValue(obj, decryptValue);
                    }
                }
            }
            return objList;
        }

        // Retorna chave privada
        private byte[] GetCryptoKey()
        {
            return Encoding.ASCII.GetBytes(_config.GetSection("CryptoKey").Value);
        }

    }
}
