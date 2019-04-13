using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    Scene currentScene;
    [Tooltip("要读取的场景号！需要先将场景放入BuildSetting中，" +
             "需要选择不同场景的同学使用，用这个下面的参数就不要管了")]
    public int SceneNumber=1;
    [Tooltip("填入标签，碰到物体切换场景，这个物体的标签，是自定的！需要先将场景放入BuildSetting中，" +
             "给需要进行碰到物体进行跳转场景同学使用，用这个上面的参数就不要管了")] 
    public string ColTag;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    public void OnLoadNextScene()
    {
        int i = currentScene.buildIndex;
        int index = i+1;
        SceneManager.LoadScene(index);
    }
    public void OnLoadSceneWithNumber()
    {
        SceneManager.LoadScene(SceneNumber);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag==ColTag)
        {
            OnLoadNextScene();
        }
    }
    
}
