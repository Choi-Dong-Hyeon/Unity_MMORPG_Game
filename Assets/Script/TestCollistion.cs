using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TestCollistion : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�ݸ���");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ʈ����");

    }





    void Start()
    {

    }


    void Update()
    {
        //local ��ǥ -> world ��ǥ -> Screan(ȭ��)
        //���� ������ ��ǥ�� world��ǥ  �׾ȿ��ִ� ��ü���� ��ǥ��local��ǥ��� �մϴ�

        //  Debug.Log(Input.mousePosition); //Screen ��ǥ  ǥ��
        //��ũ�� ��ǥ�� �˾����� ������ǥ�� ��ȯ�ϴ� ����� �ʿ��մϴ�

        //Ŭ���� ������ ������ǥ ���ϱ�!  ScreenToWorldPoint -> ��ũ������ ��������Ʈ�� �Ű��ִ� ��Ȱ
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red,2.0f);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log($"����{hit.collider.gameObject.name}");
            }
        }

    }
}



      // Vector3 mousePos= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));


    







      //  Vector3 look = transform.TransformDirection(Vector3.forward);

      //  Debug.DrawRay(transform.position+Vector3.up, look*40, Color.red);  //�ð������� ���̰� �׽�Ʈ�ϱ����� �������߻�

      // RaycastHit[] hits;

      //hits =  Physics.RaycastAll(transform.position + Vector3.up, look, 40);

      //  foreach(RaycastHit hit in hits)
      //  {
      //      Debug.Log($"�����ɽ�Ʈ{hit.collider.gameObject.name}");
      //  }


        //RaycastHit[] hit;
        //if ( Physics.Raycast(transform.position+Vector3.up, look,out hit,40))
        //{
        //    Debug.Log($"�����ɽ�Ʈ{hit.collider.gameObject.name}");
        //}
 