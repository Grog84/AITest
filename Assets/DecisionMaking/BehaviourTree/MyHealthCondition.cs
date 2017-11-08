namespace AI.BT
{
    public class MyHealthCondition : Task
    {
        public float minHealth = 5;

        public override TaskState Run()
        {
            var myHealth = m_Agent.GetComponent<HealthState>().health;
            return myHealth >= minHealth ? TaskState.SUCCESS : TaskState.FAILURE;
        }
    }

}
