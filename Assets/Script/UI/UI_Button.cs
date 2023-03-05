using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [SerializeField]
    Text _text;
    int score = 0;

    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    enum Buttons
    {
        PointButton
    }
    enum Texts
    {
        PointText,
        ScoreText
    }
    enum GameObjects
    {
        TestObject,
    }
    
    private void Start()
    {
        Bind<Button>(typeof(Buttons));  //Buttons�̸��� ������Ʈ�� �����ؼ� <���ϴ�������Ʈ>�� ����
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        Get<Text>((int)Texts.ScoreText).text = "Binding";

    }


    void Bind<T>(Type type) where T : UnityEngine.Object
    {
       string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for(int i=0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {

                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);


                if (objects[i] == null)
                {
                    Debug.Log($"���ε� ����{names[i]}");
                }
            }
        }
    }



  

    ///ã���� �������� �۾�
    T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if(_objects.TryGetValue(typeof(T),out objects)==false)
        {
            return null;
        }
        else
        {
            return objects[idx] as T;
        }
    }




    public void OnButtonClick()
    {

        score++;
        _text.text = $"���� : {score}";
    }
}
