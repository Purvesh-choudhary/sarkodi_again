using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Piece : MonoBehaviour
{

    public Player player;

    [SerializeField] int currentLoc = 0;

    void Start()
    {
        RegisterPoint();
    }

    public IEnumerator TakeSteps(int totalStepsToTake)
    {
        UnregisterPoint();
        
        int stepsTaken = 0;
        while (stepsTaken <totalStepsToTake)
        {
            currentLoc++;
            yield return StartCoroutine(Move(currentLoc));
            stepsTaken++;
        }

        // Can Kill?
        if(!IsInSafePos()){
            List<Piece> pieces = GetCurrentPathPointPieces();
            foreach(Piece p in pieces) 
            {
                if(p.GetCurrentPosition() == GetCurrentPosition() && p.player.team != player.team)
                {
                    Debug.Log($"same pos - Kill");
                    p.Kill();
                    break;
                }
            }
        }

        
        
        RegisterPoint();
        MatchManager.Instance.ChangeTurn();
    }

    IEnumerator Move(int moveTo)
    {
        yield return new WaitForSeconds(player.moveSpeed);
        transform.position = player.path[moveTo].position;       
    }

    public void Kill()
    {
        currentLoc = 0;
        StartCoroutine(Move(currentLoc));
    }

    public void OnMouseDown()
    {
        Debug.Log($"CLicked");
        if(player.canPlay)
            StartCoroutine(TakeSteps(player.stepsCanTake));
        player.EndTurn();
    }



    // ------  Helpers Methods  ----- //

    public Transform GetCurrentPosition()
    {
        return player.path[currentLoc];
    }

    public bool IsInSafePos()
    {
        return GetCurrentPosition().GetComponent<Point>().isSafePoint;      
    }

    void RegisterPoint()
    {
        GetCurrentPosition().GetComponent<Point>().AddPiece(this);      
    }

    void UnregisterPoint()
    {
        GetCurrentPosition().GetComponent<Point>().RemovePiece(this);      
    }

    List<Piece> GetCurrentPathPointPieces()
    {
        return GetCurrentPosition().GetComponent<Point>().GetPieces();
    }
}
