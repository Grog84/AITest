using UnityEngine;

namespace AI.Movement
{
    public abstract class SteeringBehaviour : MonoBehaviour
    {
        [Range(0, 1f)]
        public float weight = 1.0f;

        [HideInInspector]
        public float magnitude = 1.0f;

        public abstract SteeringOutput GetSteering();
    }

}

