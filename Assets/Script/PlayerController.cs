using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;




    void Update()
    {

        //transform.rotation = Quaternion.Euler(new Vector3(0.0f, Angle, 0.0f));

       // transform.rotation = Quaternion.Euler(new Vector3(0.0f, Angle, 0.0f));

        // transform.Rotate(new Vector3(0.0f,Angle, 0.0f));        
        //transform.TransformDirection => LocalÁÂÇ¥->WorldÁÂÇ¥·Î º¯È¯ 
        //InverseTransformDirection => WorldÁÂÇ¥->LocalÁÂÇ¥·Î º¯È¯
  
    }




    void Start()
    {
       
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
    }



    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);

            transform.position += (Vector3.forward.normalized * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);

            transform.position += (Vector3.back.normalized * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);

            transform.position += (Vector3.left.normalized * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);

            transform.position += (Vector3.right.normalized * Time.deltaTime * speed);
        }

    }
}
