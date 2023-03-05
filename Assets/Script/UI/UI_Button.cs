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
        Bind<Button>(typeof(Buttons));  //Buttons이름의 컴포넌트에 접근해서 <원하는컴포넌트>에 접근
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        GetText((int)Texts.ScoreText).text = "Binding";

    }

    int score = 0;
    public void OnButtonClick()
    {

        score++;
        _text.text = $"점수 : {score}";
    }
}
