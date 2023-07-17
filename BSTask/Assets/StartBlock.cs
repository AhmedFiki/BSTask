using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour
{

    private static StartBlock _instance;

    public static StartBlock Instance
    {
        get { return _instance; }
    }

    public GameObject dropArea;
    public GameObject puzzlePanel;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public RectTransform GetRect()
    {
        return GetComponent<RectTransform>();
    }

    public void AddAction(Transform action,bool inside)
    {
        action.SetParent(puzzlePanel.transform);
        action.SetParent(dropArea.transform);
        action.SetAsLastSibling();
        RectTransform rect = GetComponent<RectTransform>();

        if(!inside)
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + 35);

        }

    }
    public void RemoveAction()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y - 35);
    }
}
