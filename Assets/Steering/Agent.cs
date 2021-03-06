﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Movement
{

    public class Agent : MonoBehaviour
    {
        //Parameters
        public float maximumLinearVelocity = 1f;
        public float maximumAngularVelocity = 90f;

        public float maximumLinearAcceleration = 1f;
        public float maximumLinearDeceleration = 1f;

        public float maximumAngularAcceleration = 90f;

        private float linearAcceleration = 1f;
        private float angularAcceleration = 90f;

        // State
        private Vector2 linearVelocity;
        private float angularVelocity;
        private SpriteRenderer m_SpriteRenderer;

        // public SteeringBehaviour steeringBehaviour;
        private float currentLinearVelocity;

        private SteeringBehaviour[] steeringBehaviours;

        public bool setRandomPosition = true;

        private HealthState m_HealthState;

        private void Awake()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_HealthState = GetComponent<HealthState>();
            if (m_HealthState)
            {
                int team = m_HealthState.team;
                if (team == 0)
                    m_SpriteRenderer.color = Color.red;
                if (team == 1)
                    m_SpriteRenderer.color = Color.blue;
                if (team == 2)
                    m_SpriteRenderer.color = Color.green;
                if (team == 10)
                    m_SpriteRenderer.color = Color.black;
           
            }
            else
                m_SpriteRenderer.color = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));

            if(setRandomPosition)
                transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-5f, 5f));
        }

        // Use this for initialization
        void Start () {


            steeringBehaviours = gameObject.GetComponents<SteeringBehaviour>();

            //linearVelocity = new Vector2(1, 0);
            //angularVelocity = 20f;

        }
	
	    // Update is called once per frame
	    void Update ()
        {
            Vector2 totalSteering = Vector2.zero;
            float totalWeight = 0;

            // Get the steering output
            foreach (SteeringBehaviour i_steering in steeringBehaviours)
            {
                totalSteering += i_steering.GetSteering().targetLinearVelocityPercent * i_steering.weight * i_steering.magnitude;
                totalWeight += i_steering.weight;
            }

            totalSteering = totalSteering / totalWeight;

            //SteeringOutput steering = steeringBehaviour.GetSteering();
            //var targetVelocityPercent = steering.targetLinearVelocityPercent;

            var targetVelocityPercent = totalSteering;
            var targetVelocity = targetVelocityPercent * maximumLinearVelocity;

            if (targetVelocity.sqrMagnitude > currentLinearVelocity * currentLinearVelocity)
            {
                linearAcceleration = maximumLinearAcceleration;
            }
            else if (targetVelocity.sqrMagnitude < currentLinearVelocity * currentLinearVelocity)
            {
                linearAcceleration -= maximumLinearDeceleration;
            }
            else
            {
                linearAcceleration = 0f;
            }

            Vector3 crossVector = Vector3.Cross(transform.right, targetVelocity);
            float angle = Vector3.Angle(targetVelocityPercent, transform.right);
            int rotationDirection = (int)Mathf.Sign(crossVector.z);

            float accelerationRatio = Mathf.Clamp(angle, 0f, 5f) / 5.0f;

            angularAcceleration = rotationDirection * maximumAngularAcceleration * accelerationRatio;

            //linearVelocity = steering.targetLinearVelocity;
            //linearVelocity += (Vector2)transform.right * linearAcceleration * Time.deltaTime;
            //if (linearVelocity.sqrMagnitude > maximumLinearVelocity * maximumLinearVelocity)
            //{
            //    linearVelocity = linearVelocity.normalized * maximumLinearVelocity;
            //}

            // Velocity Update
            currentLinearVelocity += linearAcceleration * Time.deltaTime;
            currentLinearVelocity = Mathf.Clamp(currentLinearVelocity, 0f, maximumLinearVelocity);

            linearVelocity = (Vector2)transform.right * currentLinearVelocity;

            angularVelocity += angularAcceleration * Time.deltaTime;
            angularVelocity = Mathf.Clamp(angularVelocity, -maximumAngularVelocity, maximumAngularVelocity);
            angularVelocity *= accelerationRatio;

            // Position Update
            transform.position += (Vector3)(linearVelocity * Time.deltaTime);
            transform.localEulerAngles += Vector3.forward * angularVelocity * Time.deltaTime; // V0ector3 forward is z 
		
            // Debug.DrawLine(transform.position, transform.position + (Vector3)linearVelocity, Color.red);

            // Debug.DrawLine(transform.position, transform.position + (Vector3)totalSteering, Color.green);

            if (Mathf.Abs(transform.position.y) > 5.2f)
                transform.position = new Vector2(transform.position.x, - transform.position.y);
            if (Mathf.Abs(transform.position.x) > 8.9f)
                transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
    }

}

