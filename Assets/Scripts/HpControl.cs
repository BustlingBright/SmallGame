using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpControl : MonoBehaviour {



    void Init()
    {
    }

	void Start ()
    {
        Init();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {

        }
    }
    
    void Update ()
    {
		
	}
}
