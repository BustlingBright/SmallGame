using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	static public LevelManager Im;
	public Transform player;
	public GameObject enemy;
    public GameObject ememyNomal;
    public GameObject enemyBig;

	public float rateTime1 = 0;
    public float rateTime2 = 0;
    public float rateTime3 = 0;
    float myTime;

	void Awake () {
		Im = this;
	}
	
    void CreateEnemy1(float time,GameObject monster)
    {
        rateTime1 += Time.deltaTime;
        if (rateTime1 > time)
        {
            Vector2 r = Random.insideUnitCircle.normalized * 400;
            Instantiate(monster, new Vector3(r.x, 20, r.y), Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360.0f), 0)));
            rateTime1 =0;
        }
    }
    void CreateEnemy2(float time, GameObject monster)
    {
        rateTime2 += Time.deltaTime;
        if (rateTime2 > time)
        {
            Vector2 r = Random.insideUnitCircle.normalized * 400;
            Instantiate(monster, new Vector3(r.x, 20, r.y), Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360.0f), 0)));
            rateTime2 = 0;
        }
    }
    void CreateEnemy3(float time, GameObject monster)
    {
        rateTime3 += Time.deltaTime;
        if (rateTime3 > time)
        {
            Vector2 r = Random.insideUnitCircle.normalized * 400;
            Instantiate(monster, new Vector3(r.x, 20, r.y), Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360.0f), 0)));
            rateTime3 = 0;
        }
    }

    // Update is called once per frame
    void Update () {
        CreateEnemy1(2, enemy);
        CreateEnemy2(4, ememyNomal);
        CreateEnemy3(6, enemyBig);
    }
}
