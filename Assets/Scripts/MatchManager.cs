using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    public Player[] player;
    [SerializeField] Dice dice;

    [SerializeField] int currentTurn = 0;
    [SerializeField] bool isDebugDice; 

    bool canRoll = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canRoll)
        {
            StartCoroutine(Play());
        }
    }

    IEnumerator Play()
    {
        Debug.Log("Current Turn - "+ player[currentTurn].team);
        canRoll = false;
        if(!isDebugDice) yield return StartCoroutine(dice.Roll());

        player[currentTurn].StartTurn(dice.diceValue);
    }

    public void ChangeTurn()
    {
        currentTurn++;
        if (currentTurn >= player.Length)
        {
            currentTurn = 0;
        }
        canRoll = true;  
    }
}
