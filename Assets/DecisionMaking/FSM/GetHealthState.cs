using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;

namespace AI.FSM
{
    public class GetHealthState : StateMachineBehaviour
    {

        public Agent m_agent;
        public SeekBehaviour seekBe;
        public FleeBehaviour fleeBe;
        public ShootAction shootAction;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_agent.maximumLinearVelocity = 1f;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            seekBe.weight = 1;
            fleeBe.weight = 0;

            seekBe.targetTransform = FindObjectOfType<HealthPickup>().transform;
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

    }
}
