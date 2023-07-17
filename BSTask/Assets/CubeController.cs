using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class CubeController : MonoBehaviour
{

    private static CubeController _instance;

    public static CubeController Instance
    {
        get { return _instance; }
    }

    public float moveDistance = 1f;
    public float rotationAngle = 90f;
    public float tweenDuration = 0.3f;
    private Vector3 originalPosition;
    public bool isRotating = false;

    int index = 0;
    bool active = false;

    List<Action> actions = new List<Action>();

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

    private void Start()
    {
        originalPosition = transform.position;

        /*
        List<Action> list = new List<Action>();
        list.Add(Action.Forward);
        list.Add(Action.Backward);
        list.Add(Action.Rotate);
        list.Add(Action.Backward);
        list.Add(Action.Forward);

        StartSequence(list);
        */
    }



    public void Forward()
    {
        Vector3 forwardDirection = transform.forward;
        transform.DOMove(transform.position + forwardDirection * moveDistance, tweenDuration).OnComplete(() => NextAction());

    }

    public void Backward()
    {
        Vector3 backwardDirection = -transform.forward;
        transform.DOMove(transform.position + backwardDirection * moveDistance, tweenDuration).OnComplete(() => NextAction());

    }

    public void Rotate()
    {
        if (!isRotating)
        {
            isRotating = true;
            transform.DOLocalRotate(new Vector3(0f, transform.eulerAngles.y + rotationAngle, 0f), tweenDuration).OnComplete(() => isRotating = false).OnComplete(() => NextAction());
        }

    }

    public void ResetCube()
    {
        transform.position = originalPosition;
        transform.rotation = Quaternion.identity;

    }

    public void StartSequence(List<Action> a)
    {
        //actions.Clear();
        actions = a;
        index = 0;
        Debug.Log(a.Count+" "+actions.Count+" "+index);
        DoAction(actions[index]);

    }
    public void NextAction()
    {
        index++;

        if (index < actions.Count)
        {
            DoAction(actions[index]);
        }
        else
        {
            Debug.Log("Done Sequence");
        }

    }

    public void DoAction(Action action)
    {
        Debug.Log(action.ToString());
        switch (action)
        {
            case Action.Forward:
                Forward();
                break;

            case Action.Backward:
                Backward();
                break;

            case Action.Rotate:
                Rotate();
                break;

        }
    }


}
