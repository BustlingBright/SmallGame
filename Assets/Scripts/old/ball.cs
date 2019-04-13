using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ball : MonoBehaviour {


    private void Awake()
    {
    }

    void OnTriggerEnter(Collider coll){
		if (coll.tag == "Enemy")
        {
            coll.GetComponent<FCtrl>().Hurt();
            GameObject.Find("PlayerBlue").GetComponent<PlayerControl>().ScoreAdd(10);

        }
	}


}
