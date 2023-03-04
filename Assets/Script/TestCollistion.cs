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
        //local 좌표 -> world 좌표 -> Screan(화면)
        //게임 세상의 좌표가 world좌표  그안에있는 개체들의 좌표를local좌표라고 합니다

        //  Debug.Log(Input.mousePosition); //Screen 좌표  표시
        //스크린 좌표를 알았으니 월드좌표로 변환하는 방법이 필요합니다

        //클릭한 지점에 월드좌표 구하기!  ScreenToWorldPoint -> 스크린에서 월드포인트로 옮겨주는 역활
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red,2.0f);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log($"명중{hit.collider.gameObject.name}");
            }
        }

    }
}



      // Vector3 mousePos= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));


    







      //  Vector3 look = transform.TransformDirection(Vector3.forward);

      //  Debug.DrawRay(transform.position+Vector3.up, look*40, Color.red);  //시각적은로 보이게 테스트하기위한 레이저발사

      // RaycastHit[] hits;

      //hits =  Physics.RaycastAll(transform.position + Vector3.up, look, 40);

      //  foreach(RaycastHit hit in hits)
      //  {
      //      Debug.Log($"레이케스트{hit.collider.gameObject.name}");
      //  }


        //RaycastHit[] hit;
        //if ( Physics.Raycast(transform.position+Vector3.up, look,out hit,40))
        //{
        //    Debug.Log($"레이케스트{hit.collider.gameObject.name}");
        //}
 