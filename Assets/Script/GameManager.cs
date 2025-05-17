using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //�̱���
    //�̰����� �����ϸ鼭 ���ϳ��� �ʿ��Ҷ�
    //��𼭵��� ���ϰ� �����ϰ���
    public static GameManager Instance;

    [Header("�÷��̾�")]
    [SerializeField] private GameObject PlyerPref;

    [Header("����")]
    [SerializeField] private GameObject EnemyPref;//�÷��̾� ������Ʈ 
    [SerializeField] private int MonsterSPcount = 10;

    [SerializeField] private float spawnAreaWidth = 40;
    [SerializeField] private float spawnAreaHeight = 40;
    [SerializeField] private float spawnAreaMargin = 2; //������ ��������
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> Enemyies = new List<GameObject>();
    private float spawnAreaHarfWidth;
    private float spawnAreaHarfHeight;

    public float SpawnAreaHarfWidth => spawnAreaHarfWidth;
    public float SpawnAreaHarfHeight => spawnAreaHarfHeight;//�����̺� ���� �ϴ¹�� ������Ƽ
    private void Awake()
    {
        Instance = this; //�̱��� ����Ҷ� ������ϴ°�
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
 
