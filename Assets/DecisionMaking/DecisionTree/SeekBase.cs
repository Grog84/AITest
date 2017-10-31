using UnityEngine;
using AI.Movement;

namespace AI.DecisionTree
{
    public class SeekBase : Action
    {
        public SeekBehaviour seekBe;
        public FleeBehaviour fleeBe;

        public Transform baseTransform;

        private void Awake()
        {
            baseTransform = GameObject.FindObjectOfType<Base>().transform;
        }

        public override void MakeDecision()
        {
            Agent m_agent = GetComponent<Agent>();
            m_agent.maximumLinearVelocity = 1f;

            seekBe.weight = 1;
            fleeBe.weight = 0;

            seekBe.targetTransform = baseTransform;

        }
    }

}

