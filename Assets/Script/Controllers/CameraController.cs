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
            if(Physics.Raycast(player.transform.position,delta,out hit, delta.magnitude, LayerMask.GetMask("Wall"))) //ī�޶� ���� ��������
            {
                float dist = (hit.point - player.transform.position).magnitude * 1f;
                transform.position = player.transform.position+Vector3.up + delta.normalized * dist;//ī�޶���ġ ����
            }
            else
            {
            transform.position = player.transform.position + delta;
            transform.LookAt(player.transform); // �ֽ��ϴ�

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
