using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private Image uiImage;
    [SerializeField] private Image uiImage1;
    [SerializeField] private Image uiImage2;
    [SerializeField] private Image uiImage3;
    [SerializeField] private Image uiImage4;
    [SerializeField] private Image uiImage5;
    [SerializeField] private float duration;
    [SerializeField] private Color goalColor;
    // Start is called before the first frame update
    void Start()
    {
        //이미지
        //색
        StartCoroutine(ChaingeColor(uiImage, goalColor, duration));
        StartCoroutine(ChaingeColor(uiImage1, Color.blue, duration));
        StartCoroutine(ChaingeColor(uiImage2, Color.red, duration));
        StartCoroutine(ChaingeColor(uiImage3, Color.green, duration));
        //투명도
        StartCoroutine(Fade(uiImage4, 0, 2));
        StartCoroutine(Fade(uiImage5, 1, 2));
    }

    // Update is called once per frame
    IEnumerator ChaingeColor(Image img, Color changeColor, float duration)
    {
        float startTime = 0;
        Color startColor = img.color;
        while (startTime < duration)
        {
            //t
            startTime += Time.deltaTime;
            float t = startTime / duration;

            // Lerp
            img.color = Color.Lerp(startColor, changeColor, t);

            yield return null;


        }
    }

    IEnumerator Fade(Image img, float fade, float duration)
    {
        float startTime = 0;
        Color startColor = img.color;
        while (startTime < duration)
        {
            //t
            startTime += Time.deltaTime;
            float t = startTime / duration;
            // Lerp
            img.color = Color.Lerp(startColor, new Color(1, 1, 1, fade), t);
            yield return null;
        }

    }
}

