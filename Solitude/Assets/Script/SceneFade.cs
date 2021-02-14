using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    [HideInInspector]
    public bool isBlack = false;
    [HideInInspector]
    public float fadeSpeed = 2f;
    public RawImage rawImage;
    public RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        rawImage.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBlack)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
            if (rawImage.color.a < 0.1f)
            {
                rawImage.color = Color.clear;
            }
        }
        else if (isBlack)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.black, Time.deltaTime * fadeSpeed);
            if (rawImage.color.a > 0.9f)
            {
                rawImage.color = Color.black;
            }
        }
    }

    public void BackGroundControl(bool black)
    {
        if (black)
            isBlack = true;
        else
            isBlack = false;
    }

}
