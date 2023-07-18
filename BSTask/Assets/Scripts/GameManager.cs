using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CubeController cubeController;
    public StartBlock startBlock;

    public void StartNow()
    {
        cubeController.StartSequence(startBlock.actions);
    }

    public void ResetNow()
    {
        cubeController.ResetCube();
        startBlock.ResetActions();
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
