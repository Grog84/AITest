using AI.Movement;

namespace AI.DecisionTree
{
    public class EnemyCloseCondition : Decision
    {
        public float minDistance = 1f;

        public override bool CheckCondition()
        {
            var allAgents = FindObjectsOfType<Agent>();
            foreach (var agent in allAgents)
            {
                if (agent != GetComponent<Agent>() && agent.GetComponent<HealthState>().team != GetComponent<HealthState>().team)
                {
                    if ((agent.transform.position - this.transform.position).sqrMagnitude < minDistance * minDistance)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

}

