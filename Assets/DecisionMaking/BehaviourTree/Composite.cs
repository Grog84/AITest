using System.Collections.Generic;

namespace AI.BT
{
    public abstract class Composite : Task
    {
        public List<Task> children;
    }

}
