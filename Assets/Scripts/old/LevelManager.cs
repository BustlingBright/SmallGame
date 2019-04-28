using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            return instance;
        }
    }


    private LevelManager() { }


	public Transform player;
    public Transform skill2;
	private GameObject enemy0;
    private GameObject enemy1;
    private GameObject enemy2;
    private new Transform camera;
    private Transform mapCamera;
    private Vector3 _cameraOffect;
    private GameObject door;
    private bool doorOpen = false;

    public float rateTime1 = 0;
    public float rateTime2 = 0;
    public float rateTime3 = 0;

    private int levelId;
    private LevelConfig config;
    private List<GameObject> monsters = new List<GameObject>();
    private bool isCreate = false;

	void Awake ()
    {
        instance = this;
        TimeManger.Instance.Init();
        levelId = 10001;
        camera = Camera.main.transform;
        mapCamera = GameObject.Find("MapCamera").transform;
        Init();


	}

    void Init()
    {
        isCreate = false;
        config = ConfigManger.Instance.GetLevelConfig(levelId);
        
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
        enemy0 = Resources.Load("Role/" + config.mapName + "0") as GameObject;
        enemy1 = Resources.Load("Role/" + config.mapName + "1") as GameObject;
        enemy2 = Resources.Load("Role/" + config.mapName + "2") as GameObject;
        door = Resources.Load("Door/" + config.mapName) as GameObject;
        mapCamera.position = config.mapCameraPosition;
        camera.transform.position = config.cameraLastPosition;
        camera.transform.rotation = Quaternion.Euler(config.cameraLastRotation);

        _cameraOffect = camera.transform.position - player.transform.position;
        isCreate = true;
    }

    public void LevelUp()
    {
        isCreate = false;
        if(levelId<10005)
        {
            levelId++;
            Init();
        }

    }

    /// <summary>
    /// 设置传送门
    /// </summary>
    private void SetDoor()
    {
        Instantiate(door, config.doorPosition, Quaternion.identity);
    }

    private void FixedUpdate()
    {
       if(isCreate)
        {
            camera.transform.position = player.transform.position + _cameraOffect;
            TimeManger.Instance.Update(Time.deltaTime);
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
            if (TimeManger.Instance.NowGameTime > 60)
            {
                if(!doorOpen)
                {
                    doorOpen = true;
                    SetDoor();
                }
            }
    
        }
    }
}
