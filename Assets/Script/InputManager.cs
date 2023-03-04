using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> mouseAction = null;

    bool pressd=false;
    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }


        if(mouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                mouseAction.Invoke(Define.MouseEvent.Press);
                pressd = true;
            }
            else
            {
                if (pressd)
                {
                    mouseAction.Invoke(Define.MouseEvent.Click);
                    pressd = false;
                }
            }
        }




    }
}
