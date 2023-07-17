using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 startPosition;
    public Transform currentParent;

    public bool inside = false;

    private void Start()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;

        Debug.Log("Begin Drag");
        currentParent = transform.parent;

    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        //Debug.Log(startPosition + "    " + transform.position);

        if (RectTransformUtility.RectangleContainsScreenPoint(StartBlock.Instance.GetRect(), eventData.position))
        {
            Debug.Log("Dropped inside Start");
            
            StartBlock.Instance.AddAction(transform,inside);

            
            inside = true;



        }
        else
        {
            Debug.Log("Dropped outside Start");
            if(inside)
            {
                StartBlock.Instance.RemoveAction();

            }

            inside = false;

            transform.SetParent(StartBlock.Instance.puzzlePanel.transform);




        }


        // transform.position = startPosition;


    }
}
