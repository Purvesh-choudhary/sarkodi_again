using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum Team
{
    red,
    green,
    blue,
    yellow
}

public class Player : MonoBehaviour
{
    public Team team;

    [SerializeField] List<Piece> pieces;
    public Transform[] path;
    public float moveSpeed = 0.3f;


    public int stepsCanTake;
    public bool canPlay;

    void Start()
    {
        // pieces = GetComponentsInChildren<Piece>();
        // foreach(Piece p in pieces)
        // {
        //     p.player = this;
        // }
    }
 
    public void StartTurn(int steps)
    {
        stepsCanTake = steps;
        
        // To avoid Overlays on pieces
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        foreach(Piece p in pieces)
        {
            p.GetComponent<SpriteRenderer>().sortingOrder = 1;    
        }
        canPlay = true;
    }

    public void EndTurn()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        foreach(Piece p in pieces)
        {
            p.GetComponent<SpriteRenderer>().sortingOrder = 0;    
        }
        canPlay = false;
    }

    public void ReachedGoal(Piece piece)
    {
        if (pieces.Contains(piece))
        {
            pieces.Remove(piece);
        }
    }

}
