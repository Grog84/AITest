using UnityEngine;
using AI.Movement;

namespace AI.BT
{
    public class Flee : Task
    {
        public override TaskState Run()
        {
            SeekBehaviour seekBe = m_Agent.GetComponent<SeekBehaviour>();
            FleeBehaviour fleeBe = m_Agent.GetComponent<FleeBehaviour>();

            m_Agent.maximumLinearVelocity = 1f;

            Transform baseTransform = FindObjectOfType<Base>().transform;

            seekBe.weight = 0;
            fleeBe.weight = 1;

            fleeBe.targetTransform = baseTransform;

            return TaskState.SUCCESS;
        }
    }

}
