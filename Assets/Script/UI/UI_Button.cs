using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    [SerializeField]
    Text _text;

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

        GetText((int)Texts.ScoreText).text = "Binding";

    }

    int score = 0;
    public void OnButtonClick()
    {

        score++;
        _text.text = $"���� : {score}";
    }
}
