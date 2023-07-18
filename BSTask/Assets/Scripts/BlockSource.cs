using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSource : MonoBehaviour
{
    public Action sourceAction;

    GameObject sourcePrefab;

    public GameObject forwardPrefab;
    public GameObject backwardPrefab;
    public GameObject rotatePrefab;


    private void Awake()
    {

    }
    private void Start()
    {
        PickPrefab();
    }

    private void Update()
    {
        if(transform.childCount == 0)
        {
            InstantiateBlock();

        }
    }

    void PickPrefab()
    {
        switch (sourceAction)
        {
            case Action.Forward:
                sourcePrefab = forwardPrefab; break;
            case Action.Backward:
                sourcePrefab = backwardPrefab; break;
            case Action.Rotate:
                sourcePrefab = rotatePrefab; break;

        }
    }

    public void InstantiateBlock()
    {

        GameObject block = Instantiate(sourcePrefab, GetComponent<RectTransform>().position, GetComponent<RectTransform>().rotation);

        block.transform.SetParent(transform);
        block.transform.localScale = Vector3.one;
    }




}
