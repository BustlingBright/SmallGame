using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

    private Transform _gunPoint;
    private GameObject _gunPointPartic;
    private float _cdTime = 0.5f;
    private float _nowTime = 0f;
    private AudioSource _audio;
    //子弹预制体
    private GameObject _buttleClone;

    Ray _hitRay;

    void Awake()
    {
        _gunPoint = transform.Find("gunPoint");
        _gunPointPartic = _gunPoint.Find("gunP").gameObject;
        _gunPointPartic.SetActive(false);
        _audio = GetComponent<AudioSource>();
    }

    void Init()
    {
        _nowTime = 0;
    }
    void Start () {
		
	}
	/// <summary>
    /// 开枪
    /// </summary>
    void GunFire()
    {
        if(!_gunPointPartic.activeSelf)
        {
            _gunPointPartic.SetActive(true);
            _gunPointPartic.GetComponentInChildren<ParticleSystem>().Play();
            _audio.Play();
           
        }

    }

	void Update ()
    {
        if (_nowTime < _cdTime)
        {
            _nowTime += Time.deltaTime;
            if (_nowTime > 0.1f)
            {
                _gunPointPartic.SetActive(false);
            }
            else
            {
                RaycastHit hitInfo;
                _hitRay = new Ray(_gunPoint.position, _gunPoint.forward * 800);
                Debug.DrawRay(_gunPoint.position, _gunPoint.forward * 800, Color.black);
                if (Physics.Raycast(_hitRay, out hitInfo))
                {
                    if (hitInfo.collider.tag == "Enemy")
                    {
                        hitInfo.collider.GetComponent<FCtrl>().Hurt();
                        GameObject.Find("PlayerBlue").GetComponent<PlayerControl>().ScoreAdd(10);
                    }
                }
            }

        }
        else
        {
            _nowTime = 0;
            GunFire();
        }
       
    }
}
