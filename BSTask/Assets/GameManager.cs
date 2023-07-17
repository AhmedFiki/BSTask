using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CubeController cubeController;
    public StartBlock startBlock;


    private void Awake()
    {
 
    }

    public void StartNow()
    {
        Debug.Log("sba: "+startBlock.actions.Count);
        cubeController.StartSequence(startBlock.actions);

    }
    public void ResetNow()
    {
        cubeController.ResetCube();
        startBlock.ResetActions();
    }

}
