using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    bool moveToDest = false;
    Vector3 destPos;


    void Update()
    {

        if (moveToDest)
        {
            Vector3 dir = destPos - transform.position; //방향을 찾는다
            if (dir.magnitude < 0.001f)
            {
                moveToDest = false;
            }
            else
            {
                float moveDist = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += dir.normalized * moveDist;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.5f * Time.deltaTime);
                transform.LookAt(destPos);//쳐다보는 방향
            }
        }

        //transform.rotation = Quaternion.Euler(new Vector3(0.0f, Angle, 0.0f));

        // transform.rotation = Quaternion.Euler(new Vector3(0.0f, Angle, 0.0f));

        // transform.Rotate(new Vector3(0.0f,Angle, 0.0f));        
        //transform.TransformDirection => Local좌표->World좌표로 변환 
        //InverseTransformDirection => World좌표->Local좌표로 변환

    }




    void Start()
    {

        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.mouseAction -= OnMouseClicked;
        Managers.Input.mouseAction += OnMouseClicked;
    }

    void OnMouseClicked(Define.MouseEvent Evt)
    {
        if (Evt != Define.MouseEvent.Click)
        {
            return;
        }
        Debug.Log("마우스클릭");



        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 2.0f);


        //ayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"); //레이어 사용

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Wall")))
        {
            destPos = hit.point;
            moveToDest = true;

            //Debug.Log($"명중{hit.collider.gameObject.name}");
        }

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
        moveToDest = false;
    }
}
