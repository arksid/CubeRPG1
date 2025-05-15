using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIExtensionLibrary 
{
    public static IEnumerator ChaingeColor(this Image img, Color changeColor, float duration)
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
    public static IEnumerator Fade(this Image img, float fade, float duration)
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
