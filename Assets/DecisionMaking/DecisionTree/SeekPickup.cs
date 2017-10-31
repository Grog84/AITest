using AI.Movement;

namespace AI.DecisionTree
{
    public class SeekPickup : Action
    {
        public SeekBehaviour seekBe;
        public FleeBehaviour fleeBe;

        public override void MakeDecision()
        {
            Agent m_agent = GetComponent<Agent>();
            m_agent.maximumLinearVelocity = 1f;

            seekBe.weight = 1;
            fleeBe.weight = 0;

            seekBe.targetTransform = FindObjectOfType<HealthPickup>().transform;

        }
    }

}

