using AI.Movement;

namespace AI.BT
{
    public class ShootEnemy : Task
    {
        public override TaskState Run()
        {
            SeekBehaviour seekBe = m_Agent.GetComponent<SeekBehaviour>();
            FleeBehaviour fleeBe = m_Agent.GetComponent<FleeBehaviour>();

            m_Agent.maximumLinearVelocity = 0f;

            var allAgents = FindObjectsOfType<Agent>();
            
            if (btdm.currentEnemy != null)
            {
                seekBe.weight = 1;
                fleeBe.weight = 0;
                seekBe.targetTransform = btdm.currentEnemy.transform;
                m_Agent.GetComponent<ShootAction>().Shoot();
                return TaskState.SUCCESS;
            }

            return TaskState.FAILURE;
        }
    }

}
