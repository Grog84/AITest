using UnityEngine;

namespace AI.Movement
{
    public class SeekBehaviour : SteeringBehaviour
    {
        public Transform targetTransform;

        public override SteeringOutput GetSteering()
        {
            SteeringOutput steering = new SteeringOutput();
            steering.targetLinearVelocityPercent = (targetTransform.position - transform.position).normalized;
            return steering;
        }
    }

}

