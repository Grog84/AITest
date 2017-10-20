using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHardRock : AIPlayer {

    public override Action GetAction()
    {
        return Action.ROCK;
    }
}
