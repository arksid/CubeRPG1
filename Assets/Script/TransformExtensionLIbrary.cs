using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensionLIbrary
{
    public static IEnumerator Move(this Transform transform, Vector3 pos, float duration)
    {

        float startTime = 0;
        Vector3 startPos = transform.position;
        while (startTime < duration)
        {
            
            startTime += Time.deltaTime;//시간이 얼마만큼 지났는지
            //            3     /    5    60퍼센트 맥스  5/5 = 1 =100퍼센트
            float t = startTime / duration;
            //Time 제어


            //Lerp
            transform.position = Vector3.Lerp(startPos, pos, t); //시작위치 목표위치 목표값 0.0 ~ 1.0f


            yield return null;//1프레임 아주잠깐 대기

 
        }


    }
}
