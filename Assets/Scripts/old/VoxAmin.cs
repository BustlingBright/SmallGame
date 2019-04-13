using UnityEngine;
using System.Collections;

public class VoxAmin : MonoBehaviour
{
	public AnimationCurve ac;
	Vector3 s;
	public float playspeed = 3;
	float timeOffset =0;
	// Use this for initialization
	void Start () {
		s = transform.localScale;
		timeOffset = Random.value; 
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		timeOffset += Time.deltaTime;
		float r = ac.Evaluate (timeOffset * playspeed);
		transform.localScale = new Vector3 (s.x, s.y * r, s.z);
	}
}
	