using BlockTrack.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockTrack.Models
{
    public class BlockChain
    {
        private LinkedList<Block> Ledger;
        private int MetadataCountPerBlock = 1;
        private Queue<string> MetadataQueue;
        public BlockChain()
        {
            Block genesis = new Block(new HashSet<string>(), "000000GENESIS000000");
            genesis.MineSelf();

            Ledger = new LinkedList<Block>();
            Ledger.AddFirst(genesis);

            MetadataQueue = new Queue<string>();
        }

        public LinkedList<Block> GetLedger()
        {
            return new LinkedList<Block>(Ledger);
        }

        public bool EnQueueMetadata(string metadata)
        {
            if(SmartContract.Metadata_Add_Contract(metadata)) //if the contract allows me to add this
            {
                MetadataQueue.Enqueue(metadata); //put it on the queue
                
                if(MetadataQueue.Count == MetadataCountPerBlock) //if the queue peeked
                {
                    HashSet<string> blockMetadata = new HashSet<string>();

                    while (MetadataQueue.Count > 0)
                    {
                        string meta = MetadataQueue.Dequeue(); //dequeue the metadata
                        if(SmartContract.Block_Add_Contract(meta)) //check if it passes the contract
                            blockMetadata.Add(meta); //if so, add it to the set of metadata to be added to the block
                    }

                    //create a new block using the last added block as a father
                    //it will self mine once it is created
                    Block block = new Block(blockMetadata, Ledger.Last.Value.GetHash());
                    if (SmartContract.Block_Mined_Contract(block.GetHash())) //check if the mined block passes the contract
                    {
                        Ledger.AddLast(block); //add the block to the ledger
                        return true;
                    }
                } 
                else //if the contract was ok but queue isnt full yet
                {
                    return true;
                }
            }

            return false;
        }
    }
}
