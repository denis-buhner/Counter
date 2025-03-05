using System;
using UnityEngine;

public class InputReader : MonoBehaviour
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
