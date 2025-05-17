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
            
            startTime += Time.deltaTime;//�ð��� �󸶸�ŭ ��������
            //            3     /    5    60�ۼ�Ʈ �ƽ�  5/5 = 1 =100�ۼ�Ʈ
            float t = startTime / duration;
            //Time ����


            //Lerp
            transform.position = Vector3.Lerp(startPos, pos, t); //������ġ ��ǥ��ġ ��ǥ�� 0.0 ~ 1.0f


            yield return null;//1������ ������� ���

 
        }


    }
}
