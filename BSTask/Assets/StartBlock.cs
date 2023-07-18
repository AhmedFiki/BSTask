using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartBlock : MonoBehaviour
{


    public static StartBlock Instance
    ;

    public GameObject dropArea;
    public GameObject puzzlePanel;
    public List<Action> actions=new List<Action>();

    private void Awake()
    {
     

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public RectTransform GetRect()
    {
        return GetComponent<RectTransform>();
    }

    public void AddAction(Transform action,bool inside)
    {
        actions.Add(action.GetComponent<DraggableItem>().action);

        action.SetParent(puzzlePanel.transform);
        action.SetParent(dropArea.transform);
        action.SetAsLastSibling();
        RectTransform rect = GetComponent<RectTransform>();

        if(inside)
        {
            RemoveAction(action);

        }
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + 35);

        

    }
    public void RemoveAction(Transform action)
    {
        actions.Remove(action.GetComponent<DraggableItem>().action);
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y - 35);
    }

    public void ResetActions()
    {
        RectTransform rect = GetComponent<RectTransform>();

        actions.Clear();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, 80);

        DeleteChildren(dropArea.transform);
    }
     void DeleteChildren(Transform parent)
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Transform child = parent.GetChild(i);
            Destroy(child.gameObject);
        }
    }
}

[Serializable]
public enum Action
{
    Forward, Backward, Rotate, Start
}