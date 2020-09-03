using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace BlockTrack.Models
{
    [Serializable]
    public class Block
    {
        #region Properties
        private Guid Id { get; set; }
        private int Nounce { get; set; }
        private string Hash { get; set; }
        private string PreviousHash { get; set; }
        private HashSet<string> Metadata { get; set; }
        private DateTime TimeStamp { get; set; }
        #endregion
        
        #region Getters
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
        #endregion

        internal Block(HashSet<string> metadata, string previousHash)
        {
            Id = Guid.NewGuid();
            Metadata = metadata;
            PreviousHash = previousHash;
            Nounce = 0;
            TimeStamp = DateTime.Now;
            MineSelf();
        }

        /// <summary>
        /// In the current block, sets the nounce and generates the HASH
        /// hard coded to only accept HASHES starting with 3 zeros
        /// Don't really know if in this scenario we need proof-of-work
        /// </summary>
        internal void MineSelf() 
        {
            string hash = string.Empty;
            //just for statistics
            int tries = 0; 
            while (!hash.StartsWith("000")) //check if the generated hash is OK
            {
                //updates the block's current nounce
                this.Nounce += 1; 
                
                //generate new HASH
                hash = GetHash(this);
                tries++;
            }
            
            //update the block's current HASH
            this.Hash = hash;
        }

        /// <summary>
        /// Generates a HASH based on SHA256
        /// Adapted from Microsoft Example
        /// https://docs.microsoft.com/pt-br/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=netcore-3.1       
        /// If you need to Generate a HASH with this algorithm but with a different input you need to be sure the object is [Serializable]
        /// </summary>
        /// <param name="input">Block class</param>
        /// <returns>HASH of the inputed object</returns>
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
