using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    private int _hp;
    private int _score=0;

    private Text _personScoreUI;

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
        _score += 10;
        _personScoreUI = GameObject.Find("Canvas/Text").GetComponent<Text>();
        UiUpdate();
    }
	
    
    

	void Update () {
		
	}
}
