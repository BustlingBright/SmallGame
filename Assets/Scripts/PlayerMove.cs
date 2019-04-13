using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayMaker;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
    public class PlayerMove : FsmStateAction
    {
        public FsmOwnerDefault gameObject;
        private bl_Joystick _left;
        private bl_Joystick _right;

        private Camera _camera;
        private Vector3 _cameraOffect;

        GameObject _mygo;
        PlayMakerFSM _fsm;

        public FsmVector3 vDir = Vector3.zero;


        void Init()
        {
            _left = GameObject.Find("Canvas/JoystickLeft").GetComponent<bl_Joystick>();
            _right = GameObject.Find("Canvas/JoystickRight").GetComponent<bl_Joystick>();

            _mygo = Fsm.GetOwnerDefaultTarget(gameObject);
            _fsm = _mygo.GetComponent<PlayMakerFSM>();
            _camera = Camera.main;
            _cameraOffect = _camera.transform.position - _mygo.transform.position;

        }


        public override void Awake()
        {
            base.Awake();
            Init();
        }

        


        public override void OnUpdate()
        {
            base.OnUpdate();
            vDir.Value = new Vector3(_left.Horizontal,0, _left.Vertical);

        }


        public override void OnLateUpdate()
        {
            base.OnLateUpdate();
            _camera.transform.position = _mygo.transform.position + _cameraOffect;
        }
        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
        }
    }

}