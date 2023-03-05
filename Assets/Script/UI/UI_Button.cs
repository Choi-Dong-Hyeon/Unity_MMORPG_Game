using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
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
    enum Images
    {
        ItemIcon,
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));  //Buttons�̸��� ������Ʈ�� �����ؼ� <���ϴ�������Ʈ>�� ����
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

      
        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);


        GameObject go = GetImage((int)Images.ItemIcon).gameObject;

        AddUIEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position; }, Define.UIEvent.Drag);

       
    }

    int score = 0;
    public void OnButtonClicked(PointerEventData data)
    {

        score++;
         GetText((int)Texts.ScoreText).text = $"���� : {score}";
    }
}
