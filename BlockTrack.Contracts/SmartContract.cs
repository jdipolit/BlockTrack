using System;

namespace BlockTrack.Contracts
{
    public class SmartContract
    {
        public static bool Metadata_Add_Contract(string metadata)
        {
            return true;
        }

        public static bool Block_Add_Contract(string metadata)
        {
            return true;
        }

        public static bool Block_Mined_Contract(string hash)
        {
            return true;
        }
    }
}
