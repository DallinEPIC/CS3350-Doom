using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSwitchBehaviour : MonoBehaviour
{
    public GameObject EndScreen;
    public void Exit()
    {
        EndScreen.SetActive(true);
    }
}
