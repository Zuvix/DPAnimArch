using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OALProgramControl
{
    public class EXEExecutionStack
    {
        private LinkedList<EXECommand> CommandsToBeCalled;
        private Stack<EXECommand> CommandsThatHaveBeenCalled;
        private EXEExecutionStackParallel ParallelChild;

        public EXEExecutionStack()
        {
            this.CommandsToBeCalled = new LinkedList<EXECommand>();
            this.CommandsThatHaveBeenCalled = new Stack<EXECommand>();
            this.ParallelChild = null;
        }

        public void Enqueue(EXECommand Command)
        {
            if (Command == null)
            {
                throw new Exception("Tried to add NULL to stack of commands to be called");
            }

            CommandsToBeCalled.AddFirst(Command);
        }

        public void Enqueue(IEnumerable<EXECommand> Commands)
        {
            if (Commands == null)
            {
                throw new Exception("Tried to add NULL to stack of commands to be called");
            }

            foreach (EXECommand Command in Commands.Reverse())
            {
                Enqueue(Command);
            }
        }

        public bool HasNext()
        {
            if (ParallelChild != null)
            {
                if (ParallelChild.HasNext())
                {
                    return true;
                }
                else
                {
                    ParallelChild = null;
                }
            }

            return CommandsToBeCalled.Any();
        }

        public EXECommand Next()
        {
            EXECommand Result;

            if (ParallelChild != null)
            {
                if (ParallelChild.HasNext())
                {
                    return ParallelChild.Next();
                }
                else
                {
                    ParallelChild = null;
                }
            }

            if (!HasNext())
            {
                return null;
            }

            Result = CommandsToBeCalled.First.Value;
            CommandsToBeCalled.RemoveFirst();

            CommandsThatHaveBeenCalled.Push(Result);

            return Result;
        }

        public void Fork(List<EXEScope> threads)
        {
            this.ParallelChild = new EXEExecutionStackParallel(threads);
        }
    }
}
