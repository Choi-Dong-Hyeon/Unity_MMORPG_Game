using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    public Action KeyAction = null; // 리스너 패턴

   public void OnUpdate()
    {
        if (Input.anyKey == false)
        {
            return;
        }
        if(KeyAction != null)
        {
            KeyAction.Invoke();
        }
        
    }
}
