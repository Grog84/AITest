using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AINgram : AIPlayer {

    public int nGamesBeforePrediction = 20;

    private int nGames;

    Dictionary<string, int[]> ngramTable;
    List<Action> actionWindow;

    public void Awake()
    {
        ngramTable = new Dictionary<string, int[]>();

        // Create the pairs
        for (int i = 1; i <= 3 ; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                var key = i + "" + j;
                var value = new int[3];
                ngramTable.Add(key, value);
            }
        }

        actionWindow = new List<Action>();
    }

    public override void ReceiveOpponentAction(Action a)
    {
        if (actionWindow.Count >= 2)
        {
            Action a0 = actionWindow[0];
            Action a1 = actionWindow[1];

            var key = (int)a0 + "" +  (int)a1;
            ngramTable[key][(int)a - 1] += 1;

        }

        // Add to the history
        actionWindow.Add(a);
        if (actionWindow.Count == 3)
        {
            actionWindow.RemoveAt(0);
        }
    }

    public override Action GetAction()
    {
        nGames++;

        if (nGames < nGamesBeforePrediction)
        {
            return (Action)Random.Range(1, 4);
        }
        else
        {
            Action a0 = actionWindow[0];
            Action a1 = actionWindow[1];

            var key = (int)a0 + "" + (int)a1;
            int[] opponentActionCounts = ngramTable[key];

            int totalOpponentActions = opponentActionCounts.Sum();

            float[] ourActionProbabilities = new float[3];
            ourActionProbabilities[(int)Action.ROCK - 1] = opponentActionCounts[(int)Action.SCISSORS - 1] / (float)totalOpponentActions;
            ourActionProbabilities[(int)Action.PAPER - 1] = opponentActionCounts[(int)Action.ROCK - 1] / (float)totalOpponentActions;
            ourActionProbabilities[(int)Action.SCISSORS - 1] = opponentActionCounts[(int)Action.PAPER - 1] / (float)totalOpponentActions;

            float randomChoice = Random.value;
            if (randomChoice <= ourActionProbabilities[(int)Action.ROCK - 1])
                return Action.ROCK;
            else if (randomChoice <= ourActionProbabilities[(int)Action.ROCK - 1] + ourActionProbabilities[(int)Action.PAPER - 1])
                return Action.PAPER;
            else
                return Action.SCISSORS;

        }
    }
}
