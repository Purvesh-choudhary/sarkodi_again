using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    red,
    green,
    blue,
    yellow
}

public class Piece : MonoBehaviour
{
    [SerializeField] Team team;
    [SerializeField] Transform[] path;
    [SerializeField] int currentLoc = 0;
    [SerializeField] float moveSpeed = 0.3f;

    public IEnumerator TakeSteps(int totalStepsToTake)
    {
        int stepsTaken = 0;
        while (stepsTaken <totalStepsToTake)
        {
            currentLoc++;
            yield return StartCoroutine(Move(currentLoc));
            stepsTaken++;
        }
    }

    IEnumerator Move(int moveTo)
    {
        yield return new WaitForSeconds(moveSpeed);
        transform.position = path[moveTo].position;       
    }

    public Transform GetCurrentPosition()
    {
        return path[currentLoc];
    }
}
