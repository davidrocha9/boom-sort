using System;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{   
    public Piece[] pieces;
    public event EventHandler<DropPieceEventArgs> DropPieceEvent;
    private int currentNumberOfPieces = 3;
    
    private void Awake()
    {
        // Subscribing to piece dropped event
        for (int x = 0; x < pieces.Length; x++) {
            pieces[x].PieceDroppedEvent += OnPieceDropped;
        }

        // Generating initial pieces
        GeneratePieces();
    }

    private void GeneratePieces() {
        for (int x = 0; x < pieces.Length; x++) {
            pieces[x].Init();
            pieces[x].rectTransform.anchoredPosition = Constants.SPAWN_COORDS[x];
        }
    }
    
    private Boolean CheckIfPiecePlaceholderEmpty() {
        return currentNumberOfPieces == 0;
    }
    
    private void OnPieceDropped(object sender, DropPieceEventArgs e)
    {
        float xCoord = e.XCoord;
        float yCoord = e.YCoord;
        Chunk[] chunks = e.chunks;

        DropPieceEvent?.Invoke(this, new DropPieceEventArgs(xCoord, yCoord, chunks));

        currentNumberOfPieces--;

        if (CheckIfPiecePlaceholderEmpty()) {
            GeneratePieces();
        }
    }
}
