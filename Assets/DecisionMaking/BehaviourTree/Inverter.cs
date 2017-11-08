namespace AI.BT
{
    public class Inverter : Composite
    {
        public override TaskState Run()
        {
            TaskState childState = children[0].Run();

            if (childState == TaskState.FAILURE)
                return TaskState.SUCCESS;
            else if (childState == TaskState.SUCCESS)
                return TaskState.FAILURE;
            
            return childState;
        }
    }

}
