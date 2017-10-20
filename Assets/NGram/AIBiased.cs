using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBiased : AIPlayer {

    public Action myPreferredAction;
    [Range(0, 100f)]
    public float myBias = 33.0f;

    private Action otherAction1, otherAction2;

    public override Action GetAction()
    {
        if (myPreferredAction == 0)
        {
            return (Action)UnityEngine.Random.Range(1, 4);
        }
        else
        {
            otherAction1 = (Action)(((int)myPreferredAction + 1) % 4);
            otherAction2 = (Action)(((int)myPreferredAction + 2) % 4);

            if (otherAction1 == Action.NONE)
                otherAction1 = (Action)(1 + (((int)myPreferredAction + 1) % 4));
            if (otherAction2 == Action.NONE)
                otherAction2 = (Action)(1 + (((int)myPreferredAction + 2) % 4));

            float myRand = Random.Range(0, 100f);
            if (myRand <= myBias)
            {
                return myPreferredAction;
            }
            else
            {
                if ((int)myRand % 2 == 0)
                {
                    return otherAction1;
                }
                else
                {
                    return otherAction2;
                }
            }
        }


    }
}
