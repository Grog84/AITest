using UnityEngine;

namespace AI.Movement
{
    public class FleeBehaviour : SteeringBehaviour
    {
        public Transform targetTransform;

        public override SteeringOutput GetSteering()
        {
            SteeringOutput steering = new SteeringOutput();
            steering.targetLinearVelocityPercent = (transform.position - targetTransform.position).normalized;
            return steering;
        }
    }

}

