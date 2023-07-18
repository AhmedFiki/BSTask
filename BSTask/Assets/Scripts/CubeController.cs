using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{

    public static CubeController Instance;

    public float moveDistance = 1f;
    public float rotationAngle = 90f;
    public float tweenDuration = 0.3f;

    public bool isRotating = false;
    Vector3 originalPosition;
    int index = 0;
    List<Action> actions = new List<Action>();

    public Button startButton;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        originalPosition = transform.position;

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
        isRotating = true;
        transform.DORotate(new Vector3(0f, transform.eulerAngles.y + rotationAngle, 0f), tweenDuration).OnComplete(() => NextAction());

    }

    public void ResetCube()
    {
        transform.position = originalPosition;
        transform.rotation = Quaternion.identity;

    }

    public void StartSequence(List<Action> p_action)
    {
        actions = p_action;
        index = 0;
        if (actions.Count > 0)
        {
            DoAction(actions[index]);
            startButton.interactable = false;
        }

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
            startButton.interactable = true;
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
