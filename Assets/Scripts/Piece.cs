using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        Piece[] pieces = MatchManager.Instance.pieces;
        foreach(Piece p in pieces)
        {
            if(p.GetCurrentPosition() == GetCurrentPosition() && p.team != team && !IsInSafePos())
            {
                Debug.Log($"same pos - Kill");
                p.Kill();
            }
        }
    }

    IEnumerator Move(int moveTo)
    {
        yield return new WaitForSeconds(moveSpeed);
        transform.position = path[moveTo].position;       
    }

    void Kill()
    {
        currentLoc = 0;
        StartCoroutine(Move(currentLoc));
    }



    public Transform GetCurrentPosition()
    {
        return path[currentLoc];
    }

    public bool IsInSafePos()
    {

        foreach(Transform t in MatchManager.Instance.safePoints)
        {
            if(t == GetCurrentPosition());
                return true;
        }
        return false;       
    }
}
