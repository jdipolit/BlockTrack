using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace BlockTrack.Models
{
    [Serializable]
    public class Block
    {
        private Guid Id { get; set; }
        private int Nounce { get; set; }
        private string Hash { get; set; }
        private string PreviousHash { get; set; }
        private HashSet<string> Metadata { get; set; }
        private DateTime TimeStamp { get; set; }

        internal Block(HashSet<string> metadata, string previousHash)
        {
            Id = Guid.NewGuid();
            Metadata = metadata;
            PreviousHash = previousHash;
            Nounce = 0;
            TimeStamp = DateTime.Now;
            MineSelf();
        }

        public string GetHash()
        {
            return Hash;
        }

        public string GetId()
        {
            return Id.ToString();
        }

        public string GetPreviousHash()
        {
            return PreviousHash;
        }

        public string GetTimeStamp()
        {
            return TimeStamp.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public string GetNounce()
        {
            return Nounce.ToString();
        }
        public string GetMetadata()
        {
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", Metadata);
        }

        internal void MineSelf()
        {
            string hash = string.Empty;
            int tries = 0;
            while (!hash.StartsWith("000"))
            {
                this.Nounce += 1;
                hash = GetHash(this);
                tries++;
            }
            this.Hash = hash;
        }

        /// <summary>
        /// adaptado de microsoft 
        /// https://docs.microsoft.com/pt-br/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=netcore-3.1
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static string GetHash(Block input)
        {
            HashAlgorithm hashAlgorithm = SHA256.Create();

            //Convert the block object to a byte[]
            byte[] inputBytes;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, input);
                inputBytes = ms.ToArray();
            }

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(inputBytes);

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            hashAlgorithm.Dispose();

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
