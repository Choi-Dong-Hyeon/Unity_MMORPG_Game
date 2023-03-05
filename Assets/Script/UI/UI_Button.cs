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
    int score=0;

   public void OnButtonClick()
    {
      
        score++;
        _text.text = $"Á¡¼ö : {score}";
    }
}
