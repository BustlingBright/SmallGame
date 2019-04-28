using UnityEngine;
using System.Collections;


public class FCtrl : MonoBehaviour {
	private Transform player;
	public float rotSpeed;
	public Vector3 vc; 
	private GameObject blood;
    private int hp;

	void Start () {
        hp = ConfigManger.Instance.GetRoleConfig(gameObject.name).hp;
        player = GameObject.Find("PlayerBlue").transform;
        blood = Resources.Load("Things/Blood") as GameObject;
    }


	// Update is called once per frame
	void Update () {
        Vector3 targetDir = player.position - transform.position;
		float step = rotSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, new Vector3(targetDir.x,0, targetDir.z), step, 0.0f);
		transform.rotation = Quaternion.LookRotation (newDir);

		transform.Translate (Vector3.forward * Time.deltaTime * 80);

	}

	public void Hurt(int attack)
    {
	    if(hp<=0)
        {
            Destroy(gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
        else
        {
            hp-=attack;
        }
	}	
}
