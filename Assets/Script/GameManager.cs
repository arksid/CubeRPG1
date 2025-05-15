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
        Debug.Log("스타트함수시작");
        //StartCoroutine(nameof(Cubefalse), 2); //매개변수 넘기기 단 1개이상은안됨
        coroutine1 = StartCoroutine(Cubefalse(2, 3));//여러개 매개변수 넘기기 스톱코루틴의 내임오브로 정지가안됨
        StartCoroutine(nameof(CubeTure));
        Debug.Log("스타트함수종료");
    }

    // Update is called once per frame
    IEnumerator Cubefalse(float delay1, float delay2)//코루틴
    {
        Debug.Log("코루틴시작");
        yield return new WaitForSeconds(delay1);

        cube1.SetActive(false);

        yield return new WaitForSeconds(delay2);

        cube2.SetActive(false);


        //yield return null;//1프레임 아주잠깐 

        Debug.Log("코루틴 종료");

    }
    IEnumerator CubeTure()//코루틴
    {
        Debug.Log("코루틴시작");
        yield return new WaitForSeconds(2);

        cube1.SetActive(true);

        yield return new WaitForSeconds(3);//3초

        cube2.SetActive(true);


        //yield return null;//1프레임 아주잠깐 

        Debug.Log("코루틴 종료");

    }

    public void Stop()
    {
        StopCoroutine(coroutine1);

        StopAllCoroutines();
        Debug.Log("코루틴  멈춰");
    }


}
 
