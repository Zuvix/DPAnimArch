using UnityEditor;
using UnityEngine;

namespace OALProgramControl
{
    public class EXEExecutionStackParallelThread
    {
        public EXEExecutionStack CommandStack;
        public EXECommand WaitingCommand;
        public bool IsFinished;
        public bool IsWaiting
        {
            get
            {
                return WaitingCommand != null;
            }
        }
    }
}