using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ball : MonoBehaviour {

    private void Start()
    {
    }

    void OnTriggerEnter(Collider coll){
		if (coll.tag == "Enemy")
        {
            coll.GetComponent<FCtrl>().Hurt(ConfigManger.Instance.GetRoleConfig("player").skill2Attack);
        }
	}


}
