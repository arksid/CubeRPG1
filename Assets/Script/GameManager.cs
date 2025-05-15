using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;

    Coroutine coroutine1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("��ŸƮ�Լ�����");
        //StartCoroutine(nameof(Cubefalse), 2); //�Ű����� �ѱ�� �� 1���̻����ȵ�
        coroutine1 = StartCoroutine(Cubefalse(2, 3));//������ �Ű����� �ѱ�� �����ڷ�ƾ�� ���ӿ���� �������ȵ�
        StartCoroutine(nameof(CubeTure));
        Debug.Log("��ŸƮ�Լ�����");
    }

    // Update is called once per frame
    IEnumerator Cubefalse(float delay1, float delay2)//�ڷ�ƾ
    {
        Debug.Log("�ڷ�ƾ����");
        yield return new WaitForSeconds(delay1);

        cube1.SetActive(false);

        yield return new WaitForSeconds(delay2);

        cube2.SetActive(false);


        //yield return null;//1������ ������� 

        Debug.Log("�ڷ�ƾ ����");

    }
    IEnumerator CubeTure()//�ڷ�ƾ
    {
        Debug.Log("�ڷ�ƾ����");
        yield return new WaitForSeconds(2);

        cube1.SetActive(true);

        yield return new WaitForSeconds(3);//3��

        cube2.SetActive(true);


        //yield return null;//1������ ������� 

        Debug.Log("�ڷ�ƾ ����");

    }

    public void Stop()
    {
        StopCoroutine(coroutine1);

        StopAllCoroutines();
        Debug.Log("�ڷ�ƾ  ����");
    }


}
 
