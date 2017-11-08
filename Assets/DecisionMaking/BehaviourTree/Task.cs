using System.Collections;
using UnityEngine;
using AI.Movement;

namespace AI.BT
{
    public enum TaskState { FAILURE, SUCCESS, WAIT}

    public abstract class Task : MonoBehaviour
    {
        public Agent m_Agent;
        public BTDM btdm; // for blackboard access

        public abstract TaskState Run();
    }

}
