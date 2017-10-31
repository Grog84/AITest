using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Navmesh
{
    public class NavMeshAgentController : MonoBehaviour {

        public Transform targetTransform;

        NavMeshAgent agent;

        // Use this for initialization
        void Start () {

            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(targetTransform.position);
		
	    }
	
	    // Update is called once per frame
	    void Update () {
            agent.SetDestination(targetTransform.position);
		
	    }
    }

}
