using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBiasedScroll : AIPlayer {

    [Range(0, 100f)]
    public float rockPerc = 100f / 3f;
    [Range(0, 100f)]
    public float paperPerc = 100f / 3f;
    [Range(0, 100f)]
    public float scissorsPerc = 100f / 3f;

    float lastRockVal = 100f / 3f;
    float lastPaperVal = 100f / 3f;
    float lastScissorsVal = 100f / 3f;
    int lastModified;
    
    void Start () {

        float initValue = 100f / 3f;
        rockPerc = initValue;
        paperPerc = initValue;
        scissorsPerc = initValue;

        lastRockVal = rockPerc;
        lastPaperVal = paperPerc;
        lastScissorsVal = scissorsPerc;

    }

    private void OnValidate()
    {
        if (rockPerc != lastRockVal)
        {
            float diff = rockPerc - lastRockVal;
            if ((scissorsPerc > 0f && paperPerc > 0f) || (scissorsPerc <= 0f && paperPerc <= 0f))
            {
                scissorsPerc -= diff / 2.0f;
                scissorsPerc = Mathf.Max(0f, scissorsPerc);
                paperPerc -= diff / 2.0f;
                paperPerc = Mathf.Max(0f, paperPerc);
            }
            else if (scissorsPerc <= 0f)
            {
                scissorsPerc = 0f;
                paperPerc -= diff;
                paperPerc = Mathf.Max(0f, paperPerc);
            }
            else if (paperPerc <= 0f)
            {
                scissorsPerc -= diff;
                scissorsPerc = Mathf.Max(0f, scissorsPerc);
                paperPerc = 0f;

            }
            

        }
        else if (paperPerc != lastPaperVal)
        {
            float diff = paperPerc - lastPaperVal;
            if ((scissorsPerc > 0f && rockPerc > 0f) || (scissorsPerc <= 0f && rockPerc <= 0f))
            {
                rockPerc -= diff / 2.0f;
                rockPerc = Mathf.Max(0f, rockPerc);
                scissorsPerc -= diff / 2.0f;
                scissorsPerc = Mathf.Max(0f, scissorsPerc);
            }
            else if (scissorsPerc <= 0f)
            {
                scissorsPerc = 0f;
                rockPerc -= diff;
                rockPerc = Mathf.Max(0f, rockPerc);
            }

            else if (rockPerc <= 0f)
            {
                rockPerc = 0f;
                scissorsPerc -= diff;
                scissorsPerc = Mathf.Max(0f, scissorsPerc);
            }

        }
        else
        {
            float diff = scissorsPerc - lastScissorsVal;
            if ((paperPerc > 0f && rockPerc > 0f) || (paperPerc <= 0f && rockPerc <= 0f))
            {
                rockPerc -= diff / 2.0f;
                rockPerc = Mathf.Max(0f, rockPerc);
                paperPerc -= diff / 2.0f;
                paperPerc = Mathf.Max(0f, paperPerc);
            }
            else if (paperPerc <= 0f)
            {
                paperPerc = 0f;
                rockPerc -= diff;
                rockPerc = Mathf.Max(0f, rockPerc);
            }

            else if (rockPerc <= 0f)
            {
                rockPerc = 0f;
                paperPerc -= diff;
                paperPerc = Mathf.Max(0f, paperPerc);
            }
        }

        UpdateValues();
    }

    public override Action GetAction()
    {
        float randVal = Random.value;
        if (randVal <= rockPerc)
        {
            return Action.ROCK;
        }
        else if (randVal <= rockPerc + paperPerc)
        {
            return Action.PAPER;
        }
        else
            return Action.SCISSORS;


    }

    private void UpdateValues()
    {
        float varSum = rockPerc + paperPerc + scissorsPerc;
        rockPerc *= 100f / varSum;
        paperPerc *= 100f / varSum;
        scissorsPerc *= 100f / varSum;

        lastRockVal = rockPerc;
        lastPaperVal = paperPerc;
        lastScissorsVal = scissorsPerc;
    }
}
