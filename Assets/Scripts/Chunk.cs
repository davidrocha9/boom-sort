using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chunk : MonoBehaviour
{
    public Image image;
    
    private int GenerateRandomColorIndex()
    {
        return Random.Range(0, Constants.AVAILABLE_COLORS.Count);
    }

    public void GenerateRandomChunk()
    {
        Color _color;

        int randomColorIndex = GenerateRandomColorIndex();

        ColorUtility.TryParseHtmlString(Constants.AVAILABLE_COLORS[randomColorIndex], out _color);
        image.color = _color;
    }

    public void SetColor(Color color)
    {
        image.color = color;
    }
}