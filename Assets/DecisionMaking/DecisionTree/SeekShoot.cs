using AI.Movement;

namespace AI.DecisionTree
{
    public class SeekShoot : Action
    {
        public SeekBehaviour seekBe;
        public FleeBehaviour fleeBe;

        public ShootAction shootAction;

        public override void MakeDecision()
        {
            
            seekBe.weight = 1;
            fleeBe.weight = 0;

            Agent m_agent = GetComponent<Agent>();
            m_agent.maximumLinearVelocity = 0f;

            var allAgents = FindObjectsOfType<Agent>();
            foreach (var agent in allAgents)
            {
                if (agent != GetComponent<Agent>() && agent.GetComponent<HealthState>().team != GetComponent<HealthState>().team)
                {
                    seekBe.targetTransform = agent.transform;
                    break;
                }
            }

            shootAction.Shoot();

        }
    }

}

