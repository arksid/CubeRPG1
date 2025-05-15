using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Transform cube;
    //목표값 속도
    [SerializeField] private float MoveSpeed = 4;
    [SerializeField] private float RotSpeed = 4;
    [SerializeField] private float ScaieSpeed = 4;

    private Image img;

    //목표값 시간 (duration)
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(img.ChaingeColor(Color.green, 2));
        //코루틴으로 Transform 제어
        //간단한 애니메이션 효과

        StartCoroutine(nameof(CubeMove));
        StartCoroutine(nameof(CubeRotate));
        //StartCoroutine(nameof(CubeScale));
    }
     float startTime;
    [SerializeField] float duration = 5;
    [SerializeField] float goalPosX = 5;
    [SerializeField] float goalRotY = 100;


   
   

    IEnumerator CubeMove()
    {
       
        
        while (true)
        {
            startTime += Time.deltaTime;//시간이 얼마만큼 지났는지
            //            3     /    5    60퍼센트 맥스  5/5 = 1 =100퍼센트
            float t = startTime / duration;
            //Time 제어


            //Lerp
            cube.position = Vector3.Lerp(new Vector3(0,0,0), new Vector3(goalPosX,0,0),t); //시작위치 목표위치 목표값 0.0 ~ 1.0f


            yield return null;//1프레임 아주잠깐 대기

            if (t > 1)
            {
                break;
            }
        }

        
    }

    IEnumerator CubeRotate()
    {

        while (true)
        {
            startTime += Time.deltaTime;
            float t = startTime / duration;

            cube.eulerAngles = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, goalRotY, 0), t);
          

            yield return null;  //1프레임 아주잠깐 대기

            if (t > 1)   
            {
                break;
            }
        }


    }
    IEnumerator CubeScale()
    {
        float scale = 1;

        while (true)
        {
            cube.localScale = new Vector3(scale, scale, scale); //스케일은 localScale 사용
            scale += 0.1f * ScaieSpeed;

            yield return null;  //1프레임 아주잠깐 대기

            if (scale > 2.2f)   //100도까지
            {
                break;
            }
        }
        while (true)
        {
            cube.localScale = new Vector3(scale, scale, scale); //스케일은 localScale 사용
            scale -= 0.1f * ScaieSpeed;

            yield return null;  //1프레임 아주잠깐 대기

            if (scale < 2)   //100도까지
            {
                break;
            }
        }

    }
}
