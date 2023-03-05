using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    Vector3 destPos;
    
    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
       
    }
    PlayerState state = PlayerState.Idle;

    void Start()
    {
        Managers.Input.mouseAction -= OnMouseClicked;
        Managers.Input.mouseAction += OnMouseClicked;

       // Managers.resource.Instantiate("UI/Canvas_Button");
    }
    void Update()
    {
        
        switch (state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;

            case PlayerState.Moving:
                UpdateMoving();
                break;

            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

    }


    void UpdateDie()
    {

    }
    void UpdateMoving()
    {
        Vector3 dir = destPos - transform.position; //������ ã�´�
        if (dir.magnitude < 0.001f)
        {
            state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.5f * Time.deltaTime);
            transform.LookAt(destPos);//�Ĵٺ��� ����
        }
        //�ִϸ��̼�
        Animator anim = GetComponent<Animator>();
        //���� ���ӻ��¿� ���� ������ �Ѱ��ش� 
        anim.SetFloat("speed", speed);
    }

    void OnRunEvent(int a)
    {
        Debug.Log($"�ѹ��ѹ�{a}");
    }

    void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0f);
    }

    void OnMouseClicked(Define.MouseEvent Evt)
    {
        if (state == PlayerState.Die)
        {
            return;
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 2.0f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Wall")))
            {
                destPos = hit.point;
                state = PlayerState.Moving;
            }
        }

    }
}

#region #������ WASD
//    void OnKeyboard()
//    {
//        if (Input.GetKey(KeyCode.W))
//        {

//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);

//            transform.position += (Vector3.forward.normalized * Time.deltaTime * speed);
//        }
//        if (Input.GetKey(KeyCode.S))
//        {

//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);

//            transform.position += (Vector3.back.normalized * Time.deltaTime * speed);
//        }
//        if (Input.GetKey(KeyCode.A))
//        {

//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);

//            transform.position += (Vector3.left.normalized * Time.deltaTime * speed);
//        }
//        if (Input.GetKey(KeyCode.D))
//        {

//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);

//            transform.position += (Vector3.right.normalized * Time.deltaTime * speed);
//        }
//        moveToDest = false;
//    }
//}

//transform.rotation = Quaternion.Euler(new Vector3(0.0f, Angle, 0.0f));

// transform.rotation = Quaternion.Euler(new Vector3(0.0f, Angle, 0.0f));

// transform.Rotate(new Vector3(0.0f,Angle, 0.0f));        
//transform.TransformDirection => Local��ǥ->World��ǥ�� ��ȯ 
//InverseTransformDirection => World��ǥ->Local��ǥ�� ��ȯ
//if (Evt != Define.MouseEvent.Click)
//{
//    return;
//}
//Debug.Log("���콺Ŭ��");
//ayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"); //���̾� ���
//  Managers.Input.KeyAction -= OnKeyboard;
// Managers.Input.KeyAction += OnKeyboard;
#endregion