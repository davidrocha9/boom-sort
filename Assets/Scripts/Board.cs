using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Dictionary<Transform, int> childCounts = new Dictionary<Transform, int>();
    private int piecesCnt = 24;
    public GameObject restartButton;
    public Tile[] tiles;
    public PieceSpawner pieceSpawner;

    void Start()
    {
        pieceSpawner.DropPieceEvent += OnPieceDropped;
    }

    void Update()
    {
        foreach (Transform child in transform)
        {
            if (childCounts.TryGetValue(child, out int lastCount))
            {
                if (child.childCount > lastCount)
                {
                    piecesCnt--;
                    if (piecesCnt == 0)
                    {
                        Debug.Log("GAME OVER - RESTARTING...");
                        restartButton.SetActive(true);
                    }
                }
                childCounts[child] = child.childCount;
            }
            else
            {
                childCounts[child] = child.childCount;
            }
        }
    }

    void OnPieceDropped(object sender, DropPieceEventArgs e)
    {
        float xCoord = e.XCoord;
        float yCoord = e.YCoord;
        Chunk[] chunks = e.chunks;

        Tile chosenTileToDropPiece = tiles[Mathf.RoundToInt(6 * xCoord + yCoord)];
        chosenTileToDropPiece.FillPiece(chunks);
    }

    private void DestroyAllChildrenFromChildren()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform grandchild in child)
            {
                Destroy(grandchild.gameObject);
            }
        }
    }
}
