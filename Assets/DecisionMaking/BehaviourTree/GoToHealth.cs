using AI.Movement;

namespace AI.BT
{
    public class GoToHealth : Task
    {
        public override TaskState Run()
        {
            SeekBehaviour seekBe = m_Agent.GetComponent<SeekBehaviour>();
            FleeBehaviour fleeBe = m_Agent.GetComponent<FleeBehaviour>();

            m_Agent.maximumLinearVelocity = 1f;

            var pickups = FindObjectsOfType<HealthPickup>();
            foreach (var pickup in pickups)
            {
                if (pickup.isEnabled)
                {
                    seekBe.weight = 1;
                    fleeBe.weight = 0;
                    seekBe.targetTransform = pickup.transform;
                    return TaskState.SUCCESS;
                }
            }

            return TaskState.FAILURE;
        }
    }

}
