using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isSafePoint;
    public bool isGoalPoint;
    [SerializeField] List<Piece> pieces = new List<Piece>();

    [Header("Stack Settings")]
    [SerializeField] float minScale = 0.75f;
    [SerializeField] float offsetRadius = 0.2f;
    [SerializeField] int maxPiece = 4;

    public List<Piece> GetPieces()
    {
        return pieces;
    }

    public void AddPiece(Piece piece)
    {
        if (!pieces.Contains(piece))
        {
            pieces.Add(piece);
            RearrangePieces();
        }
    }

    public void RemovePiece(Piece piece)
    {
        if (pieces.Remove(piece))
        {
            RearrangePieces();
        }
    }

    void RearrangePieces()
    {
        int count = pieces.Count;
        if (count == 0) return;
        
        float scale = Mathf.Lerp(1f, minScale, (count - 1) / maxPiece);

        for (int i = 0; i < count; i++)
        {
            Piece piece = pieces[i];
            Vector2 offset = Vector2.zero;

            if (count > 1)
            {
                float angle = (360f / count) * i * Mathf.Deg2Rad;
                offset = new Vector2( Mathf.Cos(angle), Mathf.Sin(angle)) * offsetRadius;
            }

            piece.transform.position = (Vector2)transform.position + offset;
            piece.transform.localScale = Vector3.one * scale;
        }
    }

}
