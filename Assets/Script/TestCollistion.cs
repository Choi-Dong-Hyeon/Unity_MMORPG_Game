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


        Vector3 look = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position+Vector3.up, look*40, Color.red);  //�ð������� ���̰� �׽�Ʈ�ϱ����� �������߻�

       RaycastHit[] hits;

      hits =  Physics.RaycastAll(transform.position + Vector3.up, look, 40);

        foreach(RaycastHit hit in hits)
        {
            Debug.Log($"�����ɽ�Ʈ{hit.collider.gameObject.name}");
        }


        //RaycastHit[] hit;
        //if ( Physics.Raycast(transform.position+Vector3.up, look,out hit,40))
        //{
        //    Debug.Log($"�����ɽ�Ʈ{hit.collider.gameObject.name}");
        //}
    }
}
