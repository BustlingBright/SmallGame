using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

struct LevelConfig
{
    public int id;
    public string mapName;
    public Vector3 playerPosition;
    public Vector3 playerSkillPosition;
    public Vector3 monsterPosition;
    public Vector3 cameraFirstPosition;
    public Vector3 cameraFirstRotation;
    public Vector3 cameraLastPosition;
    public Vector3 cameraLastRotation;
    public Vector3 mapCameraPosition;
    public Vector3 doorPosition;
}
class RoleConfig
{
    public string roleName;
    public int hp;
    public int skill1Attack;
    public bool isChunGe;//无敌
    public int skill2ShowTime;  //技能二锤子
    public int skill2Attack;
    public int skill2CD;
    public int skill3ShowTime;  //技能三加速
    public int skill3CD;
    public int monsterScore;
}

class LevelSetJson
{
    public int nowtargetID;
    public int targetLevelID;
}




class ConfigManger
{
    private static ConfigManger instance;
    public static ConfigManger Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new ConfigManger();
            }
            return instance;
        }
    }

    private string levelConfigPath = "levelConfig.txt";
    private string roleConfigPath = "roleConfig.txt";
    private string levelSetPath = "levelSet.json";
    Dictionary<int, LevelConfig> levelConfig = new Dictionary<int, LevelConfig>();
    Dictionary<string, RoleConfig> roleConfig = new Dictionary<string, RoleConfig>();
    Dictionary<int, LevelSetJson> levelSetConfig = new Dictionary<int, LevelSetJson>();

    private ConfigManger() {
        Init();
    }

    void Init()
    {
        if(File.Exists(levelSetPath))
        {
            StreamReader sr = new StreamReader(levelSetPath);
            string str;
            while ((str = sr.ReadLine()) != null)
            {
                LevelSetJson temp = JsonUtility.FromJson(str, typeof(LevelSetJson)) as LevelSetJson;
                levelSetConfig.Add(temp.nowtargetID, temp);
            }
            sr.Dispose();
        }

        if (File.Exists(levelConfigPath))
        {
            StreamReader sr = new StreamReader(levelConfigPath);
            string str;
            while ((str= sr.ReadLine())!=null)
            {
                string[] tempConfig = str.Split(new char[] { ' ' });
                LevelConfig _config;
                _config.id = int.Parse(tempConfig[0]);
                _config.mapName = tempConfig[1];
                _config.playerPosition = new Vector3(float.Parse(tempConfig[2]), float.Parse(tempConfig[3]), float.Parse(tempConfig[4]));
                _config.playerSkillPosition= new Vector3(float.Parse(tempConfig[5]), float.Parse(tempConfig[6]), float.Parse(tempConfig[7]));
                _config.monsterPosition= new Vector3(float.Parse(tempConfig[8]), float.Parse(tempConfig[9]), float.Parse(tempConfig[10]));
                _config.cameraFirstPosition= new Vector3(float.Parse(tempConfig[11]), float.Parse(tempConfig[12]), float.Parse(tempConfig[13]));
                _config.cameraFirstRotation= new Vector3(float.Parse(tempConfig[14]), float.Parse(tempConfig[15]), float.Parse(tempConfig[16]));
                _config.cameraLastPosition= new Vector3(float.Parse(tempConfig[17]), float.Parse(tempConfig[18]), float.Parse(tempConfig[19])); 
                _config.cameraLastRotation= new Vector3(float.Parse(tempConfig[20]), float.Parse(tempConfig[21]), float.Parse(tempConfig[22]));
                _config.mapCameraPosition= new Vector3(float.Parse(tempConfig[23]), float.Parse(tempConfig[24]), float.Parse(tempConfig[25]));
                _config.doorPosition= new Vector3(float.Parse(tempConfig[26]), float.Parse(tempConfig[27]), float.Parse(tempConfig[28]));
                levelConfig.Add(_config.id, _config);
            }
            sr.Dispose();
        }

        if(File.Exists(roleConfigPath))
        {
            StreamReader sr = new StreamReader(roleConfigPath);
            string str;
            while ((str = sr.ReadLine()) != null)
            {
                string[] tempConfig = str.Split(new char[] { ' ' });
                RoleConfig _config=new RoleConfig();
                _config.roleName = tempConfig[0];
                _config.hp = int.Parse(tempConfig[1]);
                _config.skill1Attack = int.Parse(tempConfig[2]);
                _config.isChunGe = bool.Parse(tempConfig[3]);
                _config.skill2ShowTime = int.Parse(tempConfig[4]);
                _config.skill2Attack= int.Parse(tempConfig[5]);
                _config.skill2CD= int.Parse(tempConfig[6]);
                _config.skill3ShowTime= int.Parse(tempConfig[7]);
                _config.skill3CD= int.Parse(tempConfig[8]);
                _config.monsterScore= int.Parse(tempConfig[9]);
                roleConfig.Add(_config.roleName, _config);
            }
        }
    }

    public LevelConfig GetLevelConfig(int id)
    {
        if(levelConfig.ContainsKey(id))
        {
            return levelConfig[id];
        }
        return new LevelConfig();
    }

    public RoleConfig GetRoleConfig(string roleName)
    {
        if(roleConfig.ContainsKey(roleName))
        {
            return roleConfig[roleName];
        }
        return new RoleConfig();
    }

    public LevelSetJson GetLevelJson(int nowLevelID)
    {
        if(levelSetConfig.ContainsKey(nowLevelID))
        {
            return levelSetConfig[nowLevelID];
        }
        return new LevelSetJson();
    }

}


