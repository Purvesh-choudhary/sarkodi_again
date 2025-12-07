using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] Transform[] safePoints;
    [SerializeField] Piece[] pieces;
    [SerializeField] Dice dice;

    [SerializeField] int currentTurn = 0;

    bool canPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canPlay)
        {
            StartCoroutine(Play());
        }
    }

    IEnumerator Play()
    {
        canPlay = false;
        yield return StartCoroutine(dice.Roll());
        StartCoroutine(pieces[currentTurn].TakeSteps(dice.diceValue));
        currentTurn++;
        if (currentTurn > 3)
        {
            currentTurn = 0;
        }
        canPlay = true;
    }
}
