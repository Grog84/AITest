using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : AIPlayer {

    public override Action GetAction()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            return Action.ROCK;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            return Action.PAPER;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            return Action.SCISSORS;
        }
        else
        {
            return Action.NONE;
        }
    }
}
