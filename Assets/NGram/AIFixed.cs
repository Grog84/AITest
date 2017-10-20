using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFixed : AIPlayer {

    public Action selectedAction;

    public override Action GetAction()
    {
        return selectedAction;
    }
}
