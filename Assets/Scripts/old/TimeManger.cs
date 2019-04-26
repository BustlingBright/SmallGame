using System;
using System.Collections.Generic;
using UnityEngine;

class TimeManger
{
    private static TimeManger instance;

    public static TimeManger Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new TimeManger();
            }
            return instance;
        }
    }

    private TimeManger() { }

    private long dateTime=0;

    /// <summary>
    /// 游戏时间
    /// </summary>
    public long NowGameTime
    {
        get
        {
            return dateTime;
        }
    }


    private float tempTime = 0;
    private bool isRun = false;



    public void Init()
    {
        tempTime = 0;
        dateTime = 0;
        isRun = true;
    }

    public void Pause()
    {
        isRun = !isRun;
    }

    public void Update(float dt)
    {
      if(isRun)
        {
            tempTime += dt;
            if (tempTime > 1)
            {
                tempTime -= 1;
                dateTime += 1;
            }
        }
    }
}

