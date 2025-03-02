using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action _OnInputEntered;

    void Update()
    {
        TryGetInput();
    }

    private void TryGetInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _OnInputEntered?.Invoke();
        }
    }
}
