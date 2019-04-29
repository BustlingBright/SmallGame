using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CanvasControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //string levelSetPath = "levelSet.json";
        //LevelSetJson ks = new LevelSetJson();
        //if (!File.Exists(levelSetPath))
        //{
        //    File.Create(levelSetPath);
        //}
        //StreamWriter sw = new StreamWriter(levelSetPath);
        //ks.nowtargetID = 10000;
        //ks.targetLevelID = 10001;
        //string json = JsonUtility.ToJson(ks);
        //sw.WriteLine(json);
        //sw.Dispose();
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Camera.main.transform.rotation;
    }
}
