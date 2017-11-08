namespace AI.BT
{
    public class HealthPickupsCondition : Task
    {
        public override TaskState Run()
        {
            var healthPickups = FindObjectsOfType<HealthPickup>();

            foreach (var hp in healthPickups)
            {
                if (hp.isEnabled)
                {
                    return TaskState.SUCCESS;
                }
            }

            return TaskState.FAILURE;
        }
    }

}
