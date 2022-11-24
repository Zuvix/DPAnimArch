using System.Collections.Generic;

namespace OALProgramControl
{
    public class EXECommandMultiCall : EXECommand
    {
        public List<EXECommandCall> CallCommands;

        public EXECommandMultiCall(List<EXECommandCall> callCommands)
        {
            this.CallCommands = callCommands;
        }

        public override EXECommand CreateClone()
        {
            throw new System.NotImplementedException();
        }

        protected override bool Execute(OALProgram OALProgram)
        {
            foreach (EXECommandCall callCommand in this.CallCommands)
            {
                if (!callCommand.PerformExecution(OALProgram))
                {
                    return false;
                }
            }

            return true;
        }
    }
}