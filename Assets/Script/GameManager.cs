using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //싱글톤
    //이게임을 진행하면서 단하나만 필요할때
    //어디서든지 편하게 접근하게함
    public static GameManager Instance;

    [Header("플레이어")]
    [SerializeField] private GameObject PlyerPref;

    [Header("몬스터")]
    [SerializeField] private GameObject EnemyPref;//플레이어 오브젝트 
    [SerializeField] private int MonsterSPcount = 10;

    [SerializeField] private float spawnAreaWidth = 40;
    [SerializeField] private float spawnAreaHeight = 40;
    [SerializeField] private float spawnAreaMargin = 2; //스폰시 여유공간
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> Enemyies = new List<GameObject>();
    private float spawnAreaHarfWidth;
    private float spawnAreaHarfHeight;

    public float SpawnAreaHarfWidth => spawnAreaHarfWidth;
    public float SpawnAreaHarfHeight => spawnAreaHarfHeight;//프라이빗 접근 하는방법 프로퍼티
    private void Awake()
    {
        Instance = this; //싱글톤 사용할때 해줘야하는것
        spawnAreaHarfWidth = (spawnAreaWidth / spawnAreaMargin) - 1;
        spawnAreaHarfHeight = (spawnAreaHeight / spawnAreaMargin) - 1;

    }
    private void Start()
    {


        
        SpawnPlyer();
        SpawnMonster();


    }
    void SpawnPlyer()
    {
        player = Instantiate(PlyerPref);
    }
    void SpawnMonster()
    {
        

        for (int i = 0; i < MonsterSPcount; i++)
        {
            float spwanPosX = Random.Range(-spawnAreaHarfWidth, spawnAreaHarfWidth);
            float spwanPosZ = Random.Range(-spawnAreaHarfHeight, spawnAreaHarfHeight);

            float spawnRoty = Random.Range(0, 360);

            Vector3 spawnPos = new Vector3(spwanPosX, EnemyPref.transform.position.y, spwanPosZ);
            Quaternion spawnRot = Quaternion.Euler(0, spawnRoty, 0);
            GameObject enemy = Instantiate(EnemyPref, spawnPos, spawnRot);
            Enemyies.Add(enemy);


        }
    }
}
 
