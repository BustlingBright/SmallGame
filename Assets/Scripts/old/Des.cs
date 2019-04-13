using UnityEngine;
using System.Collections;

public class Des : MonoBehaviour
{
	public float lifeTime = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, lifeTime);
	}
}
