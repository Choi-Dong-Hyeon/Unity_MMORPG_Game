using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler  ,IDragHandler
{
   public Action<PointerEventData> OnClickHandler = null;
   public Action<PointerEventData> OnDragHandler = null;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null)
        {
            OnClickHandler.Invoke(eventData);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
       // transform.position = eventData.position; 드래그해서 위치이동
        Debug.Log("OnDrag");
        if(OnDragHandler != null)
        {
            OnDragHandler.Invoke(eventData);
        }

    }

}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    Debug.Log("OnBeginDrag");
    //    if(OnBeginDragHandler != null)
    //    {
    //        OnBeginDragHandler.Invoke(eventData);
    //    }
    //}