using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBiasedSimple : AIPlayer {

    public Action myPreferredAction;
    [Range(0, 1f)]
    public float bias;

    public override Action GetAction()
    {
        float randNbr = Random.value;

        if (randNbr <= bias)
        {
            return myPreferredAction;
        }
        else
        {
            return (Action)Random.Range(1, 4);
        }
        
    }
}
