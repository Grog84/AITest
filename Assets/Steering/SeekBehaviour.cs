using UnityEngine;

namespace AI.Movement
{
    public class SeekBehaviour : SteeringBehaviour
    {
        public Transform targetTransform;

        public override SteeringOutput GetSteering()
        {
            SteeringOutput steering = new SteeringOutput();
            if (targetTransform == null) return steering;

            steering.targetLinearVelocityPercent = (targetTransform.position - transform.position);
            magnitude = Mathf.Clamp(steering.targetLinearVelocityPercent.magnitude, 0, 1);
            steering.targetLinearVelocityPercent = steering.targetLinearVelocityPercent.normalized;


            return steering;
        }
    }

}

