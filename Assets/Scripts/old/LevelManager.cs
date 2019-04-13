using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	static public LevelManager Im;
	public Transform player;
	public GameObject enemy;

	public float rateTime = 2;
	float myTime;

	void Awake () {
		Im = this;
	}
	
	// Update is called once per frame
	void Update () {
		myTime += Time.deltaTime;
		if (myTime > rateTime) {

			Vector2 r = Random.insideUnitCircle.normalized * 400;
			Instantiate (enemy,new Vector3(r.x,40,r.y ), Quaternion.Euler (new Vector3 (0, Random.Range (0.0f, 360.0f),0)));
			myTime -= rateTime;
		}
	}
}
