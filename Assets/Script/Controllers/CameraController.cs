using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public Define.CameraMode mode = Define.CameraMode.QuarterView;
    [SerializeField]
    public Vector3 delta = new Vector3(0, 6, -5f);
    [SerializeField]
    public GameObject player = null;

    void Start()
    {

    }


    void LateUpdate()
    {
        if (mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if(Physics.Raycast(player.transform.position,delta,out hit, delta.magnitude, LayerMask.GetMask("Wall"))) //카메라가 벽에 가려지면
            {
                float dist = (hit.point - player.transform.position).magnitude * 1f;
                transform.position = player.transform.position+Vector3.up + delta.normalized * dist;//카메라위치 변경
            }
            else
            {
            transform.position = player.transform.position + delta;
            transform.LookAt(player.transform); // 주시하다

            }


        }

    }
    //
    public void SetQuaterView(Vector3 deltas)
    {
        mode=Define.CameraMode.QuarterView;
        delta = deltas;
    }
}
