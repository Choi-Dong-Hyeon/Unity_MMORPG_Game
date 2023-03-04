using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TestCollistion : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("콜리젼");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거");

    }





    void Start()
    {
        
    }

   
    void Update()
    {


        Vector3 look = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position+Vector3.up, look*40, Color.red);  //시각적은로 보이게 테스트하기위한 레이저발사

       RaycastHit[] hits;

      hits =  Physics.RaycastAll(transform.position + Vector3.up, look, 40);

        foreach(RaycastHit hit in hits)
        {
            Debug.Log($"레이케스트{hit.collider.gameObject.name}");
        }


        //RaycastHit[] hit;
        //if ( Physics.Raycast(transform.position+Vector3.up, look,out hit,40))
        //{
        //    Debug.Log($"레이케스트{hit.collider.gameObject.name}");
        //}
    }
}
