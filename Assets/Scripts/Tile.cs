using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, y;
    public Piece piece;

    public void AddPiece()
    {
        piece.Init();
    }

    public void FillPiece(Chunk[] chunks)
    {
        piece.SetChunks(chunks);
    }
}
