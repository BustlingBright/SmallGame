using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	void OnMouseUp()                 //鼠标点击时调用，触发按钮事件

	{


		Invoke("Jump",0.5F);       //0.5秒，调用jump方法



	}

	void Jump()

	{

		Application.LoadLevel("loading");//“loading”是所要跳转的目标场景名称

	}
}
