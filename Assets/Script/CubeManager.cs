using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Transform cube;
    //��ǥ�� �ӵ�
    [SerializeField] private float MoveSpeed = 4;
    [SerializeField] private float RotSpeed = 4;
    [SerializeField] private float ScaieSpeed = 4;

    private Image img;

    //��ǥ�� �ð� (duration)
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(img.ChaingeColor(Color.green, 2));
        //�ڷ�ƾ���� Transform ����
        //������ �ִϸ��̼� ȿ��

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
            startTime += Time.deltaTime;//�ð��� �󸶸�ŭ ��������
            //            3     /    5    60�ۼ�Ʈ �ƽ�  5/5 = 1 =100�ۼ�Ʈ
            float t = startTime / duration;
            //Time ����


            //Lerp
            cube.position = Vector3.Lerp(new Vector3(0,0,0), new Vector3(goalPosX,0,0),t); //������ġ ��ǥ��ġ ��ǥ�� 0.0 ~ 1.0f


            yield return null;//1������ ������� ���

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
          

            yield return null;  //1������ ������� ���

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
            cube.localScale = new Vector3(scale, scale, scale); //�������� localScale ���
            scale += 0.1f * ScaieSpeed;

            yield return null;  //1������ ������� ���

            if (scale > 2.2f)   //100������
            {
                break;
            }
        }
        while (true)
        {
            cube.localScale = new Vector3(scale, scale, scale); //�������� localScale ���
            scale -= 0.1f * ScaieSpeed;

            yield return null;  //1������ ������� ���

            if (scale < 2)   //100������
            {
                break;
            }
        }

    }
}
