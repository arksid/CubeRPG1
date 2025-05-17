using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float MoveDistansceMIn = 2;
    [SerializeField] private float MoveDistansceMax = 4;
    [SerializeField] private float MoveDelay = 1;

    [SerializeField] private float MoveSpeed = 1.5f;
    Vector3 pos;


    float spwanAreaHarfWidth;
    float spwanAreaHarfHeight;
    // Start is called before the first frame update
    void Start()
    {
        
        
        spwanAreaHarfWidth = GameManager.Instance.SpawnAreaHarfWidth;
        spwanAreaHarfHeight = GameManager.Instance.SpawnAreaHarfHeight;
        StartCoroutine(nameof(MoveEnemy));
    }

    void Update()
    {
        RotateEnemy();
    }
    IEnumerator MoveEnemy()
    {
        while (true)
        {
            float distance = Random.Range(MoveDistansceMIn, MoveDistansceMax);
            Vector2 randumCircle = Random.insideUnitCircle * distance;
            pos = transform.position;
            pos.x += randumCircle.x;
            pos.z += randumCircle.y;
                   //CLamp = 크기제한 / MIN, MAX
                   //스테이지의 크기만큼 제한
            pos.x = Mathf.Clamp(pos.x, -spwanAreaHarfWidth, spwanAreaHarfWidth);
            pos.z = Mathf.Clamp(pos.z, -spwanAreaHarfHeight, spwanAreaHarfHeight);

            float duration = distance / MoveSpeed;
            StartCoroutine(transform.Move(pos, distance));
            yield return new WaitForSeconds(duration + MoveDelay);
        }
    }
    void RotateEnemy()
    {
        Vector3 dir = (pos - transform.position).normalized;
        if (dir != Vector3.zero)
        {
            Quaternion TargetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, 70 * Time.deltaTime);
        }
    }
}
