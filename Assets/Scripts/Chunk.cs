using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chunk : MonoBehaviour
{
    public Image image;
    
    public void Init()
    {
        Color _color;
        int randomColorIndex = Random.Range(0, Constants.AVAILABLE_COLORS.Count);

        ColorUtility.TryParseHtmlString(Constants.AVAILABLE_COLORS[randomColorIndex], out _color);
        image.color = _color;

        //gameObject.SetActive(true);
    }

    public void SetColor(Color color)
    {
        if (color == Color.white)
        {
            return;
        }

        image.color = color;
        //gameObject.SetActive(true);
    }

    public void Reset()
    {
        image.color = Color.white;
        //gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}