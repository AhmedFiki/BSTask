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

    }



    public void Forward()
    {
        Vector3 forwardDirection = transform.forward;
        transform.DOMove(transform.position + forwardDirection * moveDistance, tweenDuration);

    }

    public void Backward()
    {
        Vector3 backwardDirection = -transform.forward;
        transform.DOMove(transform.position + backwardDirection * moveDistance, tweenDuration);

    }

    public void Rotate()
    {
        if (!isRotating)
        {
            isRotating = true;
            transform.DOLocalRotate(new Vector3(0f, transform.eulerAngles.y + rotationAngle, 0f), tweenDuration).OnComplete(() => isRotating = false);
        }

    }

    public void ResetCube()
    {
        transform.position = originalPosition;
        transform.rotation = Quaternion.identity;

    }

}
