using BlockTrack.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace BlockTrack.Models
{
    public class BlockChain
    {
        #region Properties
        private LinkedList<Block> Ledger;

        private int MetadataCountPerBlock = 1; //Amount of metadata inputed before a block can be crated and commited

        //after a certain time if the queue is not commited the timer will force the commit
        private int TimerInverval = 30000;//ms
        private Timer QueueCommitTimer;

        private Queue<string> MetadataQueue;

        private object QueueLock = new object();
        #endregion

        #region Getters
        public LinkedList<Block> GetLedger()
        {
            return new LinkedList<Block>(Ledger);
        }
        #endregion

        public BlockChain()
        {
            //Init all properties and the timer
            InitializePropertiesAndTimer();

            //Check if the new initialization was successful
            if (IsValid())
                SaveLedger(); //save the current legder in a file
        }        

        /// <summary>
        /// Initiates a BlockChain based on a ledger file
        /// </summary>
        /// <param name="path">Path of a file containing the leger. Must be a *.legder file</param>        
        public BlockChain(string path)
        {
            //I will only accept one kind of file
            if (path.EndsWith(".ledger")) 
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    reader.ReadLine();

                    //needs implementation
                };

                //if the loaded file did not create a valid ledger I will instaciate a new one and override the file
                if (!IsValid())
                {
                    InitializePropertiesAndTimer();

                    //check again if the new initialization was successful
                    if (IsValid())
                        SaveLedger(); //save the current legder in a file
                }
            }
        }

        /// <summary>
        /// Check if the Ledger is valid
        /// </summary>
        /// <returns>true if it's not empty and is a valid ledger</returns>
        public bool IsValid()
        {
            if(Ledger.Count > 0)
            {
                //cannot run on a check on a linked list so I transform it into an array
                Block[] arr = Ledger.ToArray(); 
                for (int i = 1; i < Ledger.Count; i++)
                {
                    //previous block HASH does not match the current block's PreviousHash property
                    if (arr[i - 1].GetHash() != arr[i].GetPreviousHash())
                        return false;

                    //current blck HASH is tempered
                    if (arr[i].GetHash() != Block.GetHash(arr[i]))
                        return false;                    
                }

                //No link errors were found
                return true;
            }

            //ledger is empty
            return false;
        }

        /// <summary>
        /// Initiate all properties of the object as empty
        /// create and commit a genesis block to the ledger 
        /// and starts the timer
        /// </summary>
        private void InitializePropertiesAndTimer()
        {
            //create a genesis block
            Block genesis = new Block(new HashSet<string>(), "000000GENESIS000000");
            genesis.MineSelf();

            //initiate the ledger
            Ledger = new LinkedList<Block>();
            
            //add the genesis to it
            Ledger.AddFirst(genesis);

            //initiate the queue
            MetadataQueue = new Queue<string>();

            //Set the timer to run
            QueueCommitTimer = new Timer(TimerInverval);
            QueueCommitTimer.Elapsed += QueueCommitTimer_Elapsed;
            QueueCommitTimer.Start();
        }
        
        private void QueueCommitTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //to prevent system from commiting the same thing twice at the same time
            lock (QueueLock)
            {
                //commit the current queue
                CommitQueueToLedger();
            };
        }

        /// <summary>
        /// Saves the runtime ledger in a .ledger file in the current folder
        /// </summary>
        /// <returns>true if all blocks were successfuly written</returns>
        private bool SaveLedger()
        {
            return true;
            //needs implementation
        }
        
        /// <summary>
        /// Commits the current MetadataQueue to the Ledger after calling the contracts
        /// Always lock the QueueLock before calling this method
        /// </summary>
        /// <returns>true if a block was successfully added to the ledger</returns>
        private bool CommitQueueToLedger()
        {
            HashSet<string> blockMetadata = new HashSet<string>();

            while (MetadataQueue.Count > 0)
            {
                //dequeue the metadata
                string meta = MetadataQueue.Dequeue();

                //check if it passes the contract
                if (SmartContract.Block_Add_Contract(meta))
                    blockMetadata.Add(meta); //if so, add it to the set of metadata to be added to the block
            }

            //create a new block using the last added block as a father
            //it will self mine once it is created
            Block block = new Block(blockMetadata, Ledger.Last.Value.GetHash());

            //check if the mined block passes the contract
            if (SmartContract.Block_Mined_Contract(block.GetHash()))
            {
                //add the block to the ledger
                Ledger.AddLast(block);

                if (IsValid()) //after adding the block, check if the ledger still valid
                {
                    //Save the updated ledger locally in a .ledger file
                    SaveLedger();
                }
                return true;
            }

            return false;
        }


        /// <summary>
        /// Enqueue your data to be processed
        /// Makes all the checks of contracts and block size and automatically add to the ledger if all rules succeed
        /// </summary>
        /// <param name="metadata">standard input</param>
        /// <returns>true if the inputed metadata passed all the contracts and false if it failed</returns>
        public bool EnQueueMetadata(string metadata)
        {
            //if the contract allows me to add this
            if (SmartContract.Metadata_Add_Contract(metadata)) 
            {
                //put it on the queue
                MetadataQueue.Enqueue(metadata);

                //if the queue peeked
                if (MetadataQueue.Count == MetadataCountPerBlock)
                {
                    //to prevent system from commiting the same thing twice at the same time
                    lock (QueueLock)
                    {
                        //commit the current queue
                        CommitQueueToLedger();
                    };
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
