using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action { NONE = 0, ROCK = 1, PAPER = 2, SCISSORS = 3}

/// <summary>
/// RPS gameplay
/// - input R P or S to play
/// - the AI will select the action
/// - we log the result
/// </summary>
public class RockPaperScissors : MonoBehaviour {

    #region Statistics

    int nGames = 0;
    int nWon = 0;
    int nLost = 0;
    int nDraw = 0;

    #endregion

    public int maxGames = 100;

    public AIPlayer player1;
    public AIPlayer player2;

    void Start () {

        //player1 = gameObject.AddComponent<AIRandom>();
        //player2 = gameObject.AddComponent<AIRandom>();

    }
	
	void Update () {

        // Action chosenAction = Action.NONE; 

        // if (GetInput(out chosenAction))

        if (nGames < maxGames)
        {
            // You choose
            // Debug.Log("You choose: " + chosenAction);

            // AI chooses
            Action player1Action = Action.NONE; // Player, if any
            Action player2Action = Action.NONE; // AI only

            player1Action = player1.GetAction();
            if (player1Action == Action.NONE)
            {
                return;

            }
            
            player2Action = player2.GetAction();

            player1.ReceiveOpponentAction(player2Action);
            player2.ReceiveOpponentAction(player1Action);

            // Check who wins
            int diff = (int)player1Action - (int)player2Action;

            string play1Action_string = player1Action.ToString();
            string play2Action_string = player2Action.ToString();

            Debug.Log("P1 - " + play1Action_string + " / P2 - " + play2Action_string);

            if (diff == 1 || diff == -2)
            {
                nWon++;
                Debug.Log("Player 1 WINS !!");
                // Debug.Log("YOU WIN !!");
            }
            else if (diff == 2 || diff == -1)
            {
                nLost++;
                Debug.Log("Player 2 WINS !!");
                // Debug.Log("YOU LOSE !!");
            }
            else if (diff == 0)
            {
                nDraw++;
                Debug.Log("IT'S A DRAW !!");
            }

            nGames++;

            float myWinRate = nWon * 100 / (float)nGames;
            float aiWinRate = nLost * 100 / (float)nGames;
            Debug.Log("Player 1 winrate: " + myWinRate.ToString("0.00") + "%"
                + "    Player 2 winrate: " + aiWinRate.ToString("0.00") + "%"
                + "\n nGames: " + nGames + " P1Won: " + nWon + " P2Won: " + nLost + " nDraw: " + nDraw);
        }
	}

    private bool GetInput(out Action chosenAction)
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            chosenAction = Action.ROCK;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            chosenAction = Action.PAPER;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            chosenAction = Action.SCISSORS;
            return true;
        }

        chosenAction = Action.NONE;
        return false;

    }
}
