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
    private float _cd = 5f;
    private float _nowCd = 0f;

    private float _skillCd = 20f;
    private float _skillNowCd = 0f;
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
        _hp = 5;
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
            _skillNowCd = 0;
            isSkillCd = true;
            isChangeSkill = true;
            _skillButton.gameObject.SetActive(false);
            _skillButtonCd.SetActive(true);

            ChangeSkill(false);
        });

        _runButton.onClick.AddListener(() =>
        {
            _nowCd = 0;
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
            BeHurt();
        }
    }


    void BeHurt()
    {
        if (_hp>1)
        {
            _hp--;
            _hpUI.fillAmount -= 0.2f;
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

        if (_nowCd < _cd)
        {
            if (!_runButtonTopCd.activeSelf)
            {
                _runButton.gameObject.SetActive(false);
                _runButtonTopCd.SetActive(true);
            }
            _nowCd += Time.deltaTime;
            _runButtonTopCd.GetComponent<Image>().fillAmount = _nowCd / _cd;
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
            _skillNowCd += Time.deltaTime;
            if(_skillNowCd>10&&isChangeSkill)
            {
                isChangeSkill = false;
                ChangeSkill(true);
            }
            if (_skillNowCd > _skillCd)
            {
                _skillNowCd = 0;
                _skillButton.gameObject.SetActive(true);
                _skillButtonCd.SetActive(false);
            }
            else
            {
                _skillButtonCd.GetComponent<Image>().fillAmount = _skillNowCd / _skillCd;
            }
        }
    }
}
