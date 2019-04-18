using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	static public LevelManager Im;
	public Transform player;
	public GameObject enemy;
    public GameObject ememyNomal;
    public GameObject enemyBig;

	public float rateTime = 2;
	float myTime;

	void Awake () {
		Im = this;
	}
	
    void CreateEnemy(float time,GameObject monster)
    {
        time += Time.deltaTime;
        if (time > rateTime)
        {

            Vector2 r = Random.insideUnitCircle.normalized * 400;
            Instantiate(monster, new Vector3(r.x, 20, r.y), Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360.0f), 0)));
            time -= rateTime;
        }
    }

	// Update is called once per frame
	void Update () {
        CreateEnemy(2, enemy);
        CreateEnemy(4, ememyNomal);
        CreateEnemy(6, enemyBig);
    }
}
