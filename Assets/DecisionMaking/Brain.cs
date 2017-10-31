using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecisionMaker : MonoBehaviour
{
    public abstract void MakeDecision();
}

public class Brain : MonoBehaviour {

    public float tickDelay = 1;

    public DecisionMaker decisionMaker;

    // Use this for initialization
    void Start () {

        InvokeRepeating("TickBrain", tickDelay, tickDelay);
		
	}

    void TickBrain()
    {
        decisionMaker.MakeDecision();
    }
}
