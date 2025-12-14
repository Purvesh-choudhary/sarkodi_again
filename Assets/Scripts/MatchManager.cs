using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    public Player[] player;
    [SerializeField] Transform[] dicePos;
    [SerializeField] Dice dice;

    [SerializeField] int currentTurn = 0;
    [SerializeField] bool isDebugDice; 

    public bool canRoll = true;
    bool isDoubleChance;


    void Start()
    {
        if (Instance == null) {
            Instance = this;
        }
        dice.transform.position = dicePos[currentTurn].position;

    }

    public void PlayGame()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        Debug.Log("Current Turn - "+ player[currentTurn].team);
        canRoll = false;
        // dice.transform.position = dicePos[currentTurn].position;
        if(!isDebugDice) yield return StartCoroutine(dice.Roll());

        if(dice.diceValue == 4 || dice.diceValue == 8)
        {
            isDoubleChance = true;
        }
        else
        {
            isDoubleChance = false;
        }

        player[currentTurn].StartTurn(dice.diceValue);
    }

    public void ChangeTurn()
    {
        if (isDoubleChance)
        {
            canRoll = true;
            return;
        } 

        currentTurn++;
        if (currentTurn >= player.Length)
        {
            currentTurn = 0;
        }
        dice.transform.position = dicePos[currentTurn].position;
        canRoll = true;  
    }




}
