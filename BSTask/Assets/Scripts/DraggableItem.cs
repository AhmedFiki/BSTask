using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action action;
    public Transform currentParent;
    public bool inside = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(StartBlock.Instance.GetRect(), eventData.position))
        {
            StartBlock.Instance.AddAction(transform,inside);
            inside = true;
        }
        else
        {
            if(inside)
            {
                StartBlock.Instance.RemoveAction(transform);
            }
            inside = false;
            transform.SetParent(StartBlock.Instance.puzzlePanel.transform);
        }
    }
}

