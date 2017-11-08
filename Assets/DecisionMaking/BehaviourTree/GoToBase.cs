using UnityEngine;
using AI.Movement;

namespace AI.BT
{
    public class GoToBase : Task
    {
        public override TaskState Run()
        {
            SeekBehaviour seekBe = m_Agent.GetComponent<SeekBehaviour>();
            FleeBehaviour fleeBe = m_Agent.GetComponent<FleeBehaviour>();

            m_Agent.maximumLinearVelocity = 1f;

            Transform baseTransform = FindObjectOfType<Base>().transform;

            seekBe.weight = 1;
            fleeBe.weight = 0;

            seekBe.targetTransform = baseTransform;

            return TaskState.SUCCESS;
        }
    }

}
