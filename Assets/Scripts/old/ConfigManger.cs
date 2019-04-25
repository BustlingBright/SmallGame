using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

struct Config
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

    private string path = "levelConfig.txt";
    Dictionary<int, Config> config = new Dictionary<int, Config>();

    private ConfigManger() {
        Init();
    }

    void Init()
    {
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            string str;
            while ((str= sr.ReadLine())!=null)
            {
                string[] tempConfig = str.Split(new char[] { ' ' });
                Config _config;
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
                config.Add(_config.id, _config);
            }
        }
    }

    public Config GetConfig(int id)
    {
        if(config.ContainsKey(id))
        {
            return config[id];
        }
        return new Config();
    }

}


