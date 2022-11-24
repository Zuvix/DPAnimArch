using System;
using System.Collections.Generic;
using System.Linq;

namespace OALProgramControl
{
    public class EXEExecutionStackParallel
    {
        private List<EXEExecutionStackParallelThread> Threads;

        public EXEExecutionStackParallel(List<EXEScope> threads)
        {
            this.Threads = new List<EXEExecutionStackParallelThread>();

            EXEExecutionStackParallelThread ThreadWrap;
            foreach (EXEScope thread in threads)
            {
                ThreadWrap
                    = new EXEExecutionStackParallelThread()
                    {
                        CommandStack = new EXEExecutionStack(),
                        WaitingCommand = null,
                        IsFinished = false
                    };
                ThreadWrap.CommandStack.Enqueue(thread);
                thread.CommandStack = ThreadWrap.CommandStack;

                this.Threads.Add(ThreadWrap);
            }
        }

        public bool HasNext()
        {
            if (this.Threads.Count == 0)
            {
                return false;
            }

            List<EXEExecutionStackParallelThread> emptyThreads
                = this.Threads.Where(thread => !thread.IsFinished && !thread.IsWaiting && !thread.CommandStack.HasNext()).ToList();
            foreach (EXEExecutionStackParallelThread thread in emptyThreads)
            {
                thread.IsFinished = true;
            }

            List<EXEExecutionStackParallelThread> activeThreads
                = this.Threads.Where(thread => !thread.IsFinished).ToList();

            if (activeThreads.Count == 0)
            {
                return false;
            }

            List<EXEExecutionStackParallelThread> nonEmptyThreads
                = activeThreads.Where(thread => thread.IsWaiting || thread.CommandStack.HasNext()).ToList();

            return nonEmptyThreads.Count > 0;
        }

        public EXECommand Next()
        {
            // We might have parallel block with no threads.
            if (this.Threads.Count == 0)
            {
                return null;
            }

            // If all threads are finished, parallel block ends.
            List<EXEExecutionStackParallelThread> activeThreads
                = this.Threads.Where(thread => !thread.IsFinished).ToList();

            if (activeThreads.Count == 0)
            {
                return null;
            }

            // Make sure we have updated the finished flag.
            List<EXEExecutionStackParallelThread> emptyThreads
                = activeThreads.Where(thread => !thread.IsWaiting && !thread.CommandStack.HasNext()).ToList();
            foreach (EXEExecutionStackParallelThread thread in emptyThreads)
            {
                thread.IsFinished = true;
            }

            activeThreads = this.Threads.Where(thread => !thread.IsFinished).ToList();

            // If the flag update lead to all discovering that all threads are inactive, the parallel block is over.
            if (activeThreads.Count <= 0)
            {
                return null;
            }

            // Let's check threads that are not waiting to synchronize the method call commands.
            List<EXEExecutionStackParallelThread> notWaitingThreads
                = activeThreads.Where(thread => !thread.IsWaiting).ToList();

            foreach (EXEExecutionStackParallelThread thread in notWaitingThreads)
            {
                EXECommand currentCommand = thread.CommandStack.Next();

                // This thread should wait.
                if (typeof(EXECommandCall).Equals(currentCommand.GetType()))
                {
                    thread.WaitingCommand = currentCommand;
                }
                // This thread can execute now.
                else
                {
                    return currentCommand;
                }
            }

            // If we are here. We have some active threads and they are all waiting. Let us execute the parallel animation now
            List<EXECommandCall> callCommands = new List<EXECommandCall>();

            foreach (EXEExecutionStackParallelThread thread in activeThreads)
            {
                callCommands.Add((EXECommandCall)thread.WaitingCommand);
                thread.WaitingCommand = null;
            }

            return new EXECommandMultiCall(callCommands);
        }
    }
}