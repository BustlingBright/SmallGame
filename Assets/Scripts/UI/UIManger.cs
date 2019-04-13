using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger
{
    private static UIManger _instance;

    /// <summary>
    /// UI管理类的单例模式(防止随意实例化，保证全局只有一个)
    /// </summary>
    public static UIManger Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = new UIManger();
            }
            return _instance;
        }
    }
    private UIManger() { }

    /// <summary>
    /// 窗口容器
    /// </summary>
    private Dictionary<string, BaseWnd> _windows = new Dictionary<string, BaseWnd>();

    /// <summary>
    /// 窗口打开
    /// </summary>
    /// <typeparam name="T">窗口类型</typeparam>
    /// <param name="windName">窗口名字</param>
    /// <returns></returns>
    public T Open<T>(string windName) where T : BaseWnd, new()
    {
        if(_windows.ContainsKey(windName))
        {
            _windows[windName].Init();
            return _windows[windName] as T;
        }
        else
        {
            T _newWind = new T();
            _newWind.Init();
            return _newWind;
        }
    }
    /// <summary>
    /// 窗口回收
    /// </summary>
    /// <typeparam name="T">窗口类型</typeparam>
    /// <param name="wind">窗口实例</param>
    public void Close<T>(T wind) where T:BaseWnd
    {
        wind.CloseWnd();
        if (!_windows.ContainsKey(wind.GetType().ToString()))
        {
            _windows.Add(wind.GetType().ToString(), wind);
        }
    }



}
