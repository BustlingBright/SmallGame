using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayMaker.ConditionalExpression;

public class PlayerControl : MonoBehaviour {

    private int _hp;
    private int _score=0;

    private Text _personScoreUI;

    private GameObject _hurtUI;
    private Image _hpUI;

    /// <summary>
    /// 奔跑按钮
    /// </summary>
    private Button _runButton;
    private GameObject _runButtonTopCd;
    private bool isPlayCD = false;
    private float skill3CD;
    private float skill3NowCD = 0f;
    private float skill3ShowTime;

    private float skill2CD;
    private float skill2NowCD = 0f;
    private float skill2ShowTime;

    private bool isSkillCd = false;
    private Button _skillButton;
    private GameObject _skillButtonCd;
    private bool isChangeSkill = false;


    private PlayMakerFSM fsm;

    private GameObject skill1;
    private GameObject[] skill2=new GameObject[2];

    private Vector3 offect;


    public int Score
    {
        get
        {
            return _score;
        }
    }
    
    public void ScoreAdd(int score)
    {
        _score += score;
        UiUpdate();
    }

    void UiUpdate()
    {
        _personScoreUI.text = "分数：" + _score;
    }

    void Start ()
    {
        skill3CD = ConfigManger.Instance.GetRoleConfig("player").skill3CD;
        skill3NowCD = 0;
        skill3ShowTime = ConfigManger.Instance.GetRoleConfig("player").skill3ShowTime;
        skill2CD = ConfigManger.Instance.GetRoleConfig("player").skill2CD;
        skill2NowCD = 0;
        skill2ShowTime = ConfigManger.Instance.GetRoleConfig("player").skill2ShowTime;


        _hp = ConfigManger.Instance.GetRoleConfig("player").hp;
        _score = 0;
        _hpUI = transform.Find("Canvas111/Hp/hpUI").GetComponent<Image>();
        _personScoreUI = GameObject.Find("Canvas/Text").GetComponent<Text>();
        _hurtUI = transform.Find("Canvas111/hurtUI").gameObject;
        fsm = GetComponent<PlayMakerFSM>();

        skill1 = GameObject.Find("PlayerBlue/gun");
        skill2[0] = GameObject.Find("PlayerBlue/1");
        skill2[1] = GameObject.Find("skill222");

        skill2[1].transform.SetParent(skill1.transform);


        for (int i = 0; i < skill2.Length; i++)
        {
            skill2[i].SetActive(false);
        }

        _runButton = GameObject.Find("Canvas/GameObject/button").GetComponent<Button>();
        _runButtonTopCd= GameObject.Find("Canvas/GameObject/topUI").gameObject;
        _runButtonTopCd.SetActive(false);

        _skillButton=GameObject.Find("Canvas/skill2/button").GetComponent<Button>();
        _skillButtonCd= GameObject.Find("Canvas/skill2/topUI").gameObject;
        _skillButtonCd.SetActive(false);

        _skillButton.onClick.AddListener(() =>
        {
            skill2NowCD = 0;
            isSkillCd = true;
            isChangeSkill = true;
            _skillButton.gameObject.SetActive(false);
            _skillButtonCd.SetActive(true);

            ChangeSkill(false);
        });

        _runButton.onClick.AddListener(() =>
        {
            skill3NowCD = 0;
            isPlayCD = true;
            fsm.SendEvent("Run");
        });
        UiUpdate();
    }


    void ChangeSkill(bool isSkill)
    {
        if(isSkill)
        {
            skill1.SetActive(true);
            for (int i = 0; i < skill2.Length; i++)
            {
                skill2[i].SetActive(false);
            }
            skill2[1].transform.SetParent(skill1.transform);
        }
        else
        {
            skill1.SetActive(false);
            for (int i = 0; i < skill2.Length; i++)
            {
                skill2[i].SetActive(true);
            }
            /////////////////////////////////////////////
            //////////////////////////////////////////////
            /////////////////////////////////////////////
            /////////////////////////////////////////////有问题。武器切换。位置不对
            skill2[1].transform.SetParent(null);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            BeHurt(ConfigManger.Instance.GetRoleConfig(other.name).skill1Attack);
        }
    }


    void BeHurt(int attack)
    {
        if (_hp>1)
        {
            _hp-=attack;
            _hpUI.fillAmount = (float)_hp / ConfigManger.Instance.GetRoleConfig("player").hp;
            _hurtUI.SetActive(true);
            _hurtUI.GetComponent<Animation>().Play("play");
        }
        else
        {
            ////////////游戏结束
        }

    }

    void PlayRunCd()
    {

        if (skill3NowCD < skill3CD)
        {
            if (!_runButtonTopCd.activeSelf)
            {
                _runButton.gameObject.SetActive(false);
                _runButtonTopCd.SetActive(true);
            }
            skill3NowCD += Time.deltaTime;
            _runButtonTopCd.GetComponent<Image>().fillAmount = skill3NowCD / skill3CD;
        }
        else
        {
            _runButtonTopCd.SetActive(false);
            _runButton.gameObject.SetActive(true);
            fsm.SendEvent("Walk");
            isPlayCD = false;
        }
        
    }
    

    void Update ()
    {
		if(isPlayCD)
        {
            PlayRunCd();
        }
        if (isSkillCd)
        {
            ////////////////武器更换
            skill2NowCD += Time.deltaTime;
            if(skill2NowCD>skill2ShowTime&&isChangeSkill)
            {
                isChangeSkill = false;
                ChangeSkill(true);
            }
            if (skill2NowCD > skill2CD)
            {
                skill2NowCD = 0;
                _skillButton.gameObject.SetActive(true);
                _skillButtonCd.SetActive(false);
            }
            else
            {
                _skillButtonCd.GetComponent<Image>().fillAmount = skill2NowCD / skill2CD;
            }
        }
    }
}
