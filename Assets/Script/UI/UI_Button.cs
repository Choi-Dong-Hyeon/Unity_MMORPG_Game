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
    TextMeshProUGUI _text;
    int score = 0;

    Dictionary<Type, UnityEngine.Object[]> _object = new Dictionary<Type, UnityEngine.Object[]>();

    enum Buttons
    {
        PointButton
    }
    enum Texts
    {
        PointText,
        ScoreText
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
       string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _object.Add(typeof(T), objects);

        for(int i=0; i < names.Length; i++)
        {
            objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }
    private void Start()
    {
        Bind<Button>(typeof(Buttons));  //Buttons이름의 컴포넌트에 접근해서 <원하는컴포넌트>에 접근
        Bind<TextMeshProUGUI>(typeof(Texts));

    }



    public void OnButtonClick()
    {

        score++;
        _text.text = $"점수 : {score}";
    }
}
