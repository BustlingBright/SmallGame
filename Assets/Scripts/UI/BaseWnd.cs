using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWnd
{
    public BaseWnd()
    {

    }
    public abstract GameObject OpenWnd();
    public abstract void CloseWnd();
    public abstract void Init();

    

}