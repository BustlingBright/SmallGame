using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public Transform player;
    public Transform skill2;
	private GameObject enemy0;
    private GameObject enemy1;
    private GameObject enemy2;
    private new Transform camera;
    private Transform mapCamera; 

	public float rateTime1 = 0;
    public float rateTime2 = 0;
    public float rateTime3 = 0;

    private int levelId;
    private Config config;
    private List<GameObject> monsters = new List<GameObject>();
    private bool isCreate = false;
	void Awake ()
    {
        levelId = 1001;
        config = ConfigManger.Instance.GetConfig(levelId);
        camera = Camera.main.transform;
        mapCamera = GameObject.Find("MapCamera").transform;
        Init();
	}

    void Init()
    {
        isCreate = false;
        for (int i = 0; i < monsters.Count; i++)
        {
            if(monsters[i]!=null)
            {
                Destroy(monsters[i]);
            }
        }
        ///玩家位置
        player.position = config.playerPosition;
        player.rotation = Quaternion.identity;
        ///玩家武器位置
        skill2.position = config.playerSkillPosition;
        skill2.rotation = Quaternion.identity;
        ///怪物类型
        enemy0 = Resources.Load("Role/" + config.mapName + "/0") as GameObject;
        enemy1 = Resources.Load("Role/" + config.mapName + "/1") as GameObject;
        enemy2 = Resources.Load("Role/" + config.mapName + "/2") as GameObject;
        mapCamera.position = config.mapCameraPosition;
        isCreate = true;
    }

    public void LevelUp()
    {
        isCreate = false;
        if(levelId<1005)
        {
            levelId++;
            Init();
        }

    }

	
    void CreateEnemy1(float time,GameObject monster)
    {
        rateTime1 += Time.deltaTime;
        if (rateTime1 > time)
        {
            Vector2 r = Random.insideUnitCircle.normalized * 400;
            GameObject g= Instantiate(monster, new Vector3(r.x+config.monsterPosition.x, config.monsterPosition.y, r.y+config.monsterPosition.z), Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360.0f), 0)));
            rateTime1 =0;
            monsters.Add(g);
        }
    }
    void CreateEnemy2(float time, GameObject monster)
    {
        rateTime2 += Time.deltaTime;
        if (rateTime2 > time)
        {
            Vector2 r = Random.insideUnitCircle.normalized * 400;
            GameObject g= Instantiate(monster, new Vector3(r.x + config.monsterPosition.x, config.monsterPosition.y, r.y + config.monsterPosition.z), Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360.0f), 0))); rateTime2 = 0;
            rateTime2 = 0;
            monsters.Add(g);
        }
    }
    void CreateEnemy3(float time, GameObject monster)
    {
        rateTime3 += Time.deltaTime;
        if (rateTime3 > time)
        {
            Vector2 r = Random.insideUnitCircle.normalized * 400;
            GameObject g= Instantiate(monster, new Vector3(r.x + config.monsterPosition.x, config.monsterPosition.y, r.y + config.monsterPosition.z), Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360.0f), 0)));
            rateTime3 = 0;
            monsters.Add(g);
        }
    }

    // Update is called once per frame
    void Update () {
        if(isCreate)
        {
            CreateEnemy1(2, enemy0);
            CreateEnemy2(4, enemy1);
            CreateEnemy3(6, enemy2);
        }
    }
}
