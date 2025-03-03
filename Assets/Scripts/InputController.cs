using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action InputEntered;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InputEntered?.Invoke();
        }
    }
}
