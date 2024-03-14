using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPieceEventArgs : EventArgs
{
    public float XCoord { get; }
    public float YCoord { get; }
    public Chunk[] chunks { get; }

    public DropPieceEventArgs(float xCoord, float yCoord, Chunk[] _chunks)
    {
        XCoord = xCoord;
        YCoord = yCoord;
        chunks = _chunks;
    }
}

public class Piece : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public event EventHandler<DropPieceEventArgs> PieceDroppedEvent;

    public Chunk[] chunks;
    public RectTransform rectTransform;
    private Vector3 startPosition;

    void Awake()
    {
        for (int x = 0; x < chunks.Length; x++)
        {
            //chunks[x].gameObject.SetActive(false);
        }
    }

    public void Init()
    {
        Reset();
       
        int numberOfChunks = UnityEngine.Random.Range(1, Constants.MAX_NUMBER_OF_CHUNKS);
        
        Debug.Log("Number of chunks: " + numberOfChunks);

        startPosition = rectTransform.anchoredPosition;

        for (int x = 0; x < numberOfChunks; x++)
        {
            Debug.Log("Init chunk");
            chunks[x].Init();
        }
    }

    public void Reset()
    {
        for (int x = 0; x < Constants.MAX_NUMBER_OF_CHUNKS; x++)
        {
            chunks[x].Reset();
        }
    }

    public void SetChunks(Chunk[] _chunks)
    {
        for (int x = 0; x < chunks.Length; x++)
        {
            chunks[x].SetColor(_chunks[x].image.color);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta * 3.5f * Constants.CANVAS_LOCAL_SCALE;
    }

    public void OnEndDrag(PointerEventData eventData)
    {   
        float XCoord = rectTransform.anchoredPosition.x;
        float YCoord = rectTransform.anchoredPosition.y;

        XCoord = Mathf.Floor(Mathf.Abs(Constants.MIN_X - XCoord) / Constants.UNIT);
        YCoord = Mathf.Floor(Mathf.Abs(Constants.MIN_Y - YCoord) / Constants.UNIT);

        rectTransform.anchoredPosition = startPosition;

        PieceDroppedEvent?.Invoke(this, new DropPieceEventArgs(XCoord, YCoord, chunks));
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
