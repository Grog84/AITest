using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;

public class GMController : MonoBehaviour {

    public bool initializeRandom = false;
    public GameObject[] myAgents;

    // Use this for initialization
    void Start () {
        if (initializeRandom)
        {
            foreach (var agent in myAgents)
            {
                SteeringBehaviour[] mySteerBehav = agent.GetComponents<SteeringBehaviour>();
                foreach (var sb in mySteerBehav)
                {
                    sb.weight = Random.value;
                }
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
