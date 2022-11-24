using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace OALProgramControl
{
    public class EXEScopeParallel : EXEScope
    {
        private List<EXEScope> Threads { get; }
        private object MyThreadEndSyncer { get; }
        private int ActiveThreadCount;
        public EXEScopeParallel() : base()
        {
            this.Threads = new List<EXEScope>();
            this.MyThreadEndSyncer = new object();
            this.ActiveThreadCount = 0;
        }
        public EXEScopeParallel(EXEScope[] Threads) : base()
        {
            this.Threads = new List<EXEScope>();
            foreach (EXEScope Thread in Threads)
            {
                this.AddThread(Thread);
            }
            this.MyThreadEndSyncer = new object();
            this.ActiveThreadCount = 0;
        }

        public void AddThread(EXEScope Thread)
        {
            Thread.SetSuperScope(this);
            this.Threads.Add(Thread);
        }
        protected override Boolean Execute(OALProgram OALProgram)
        {
            this.CommandStack.Fork(this.Threads);

            return true;
        }

        public override String ToCode(String Indent = "")
        {
            String Result = Indent + "par\n";
            if (this.Threads != null)
            {
                foreach (EXEScope Thread in this.Threads)
                {
                    Result += Indent + "\tthread\n";
                    foreach (EXECommand Command in Thread.Commands)
                    {
                        Result += Command.ToCode(Indent + "\t\t");
                    }
                    Result += Indent + "\tend thread;\n";
                }
            }
            Result += Indent + "end par;\n";
            return Result;
        }

        protected override EXEScope CreateDuplicateScope()
        {
            return new EXEScopeParallel(Threads.Select(x => (EXEScope)x.CreateClone()).ToArray());
        }
    }
}