using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private InputManager _inputManager;
    private Coroutine _countCoroutine;
    private int _currentCount = 0;

    private void OnEnable()
    {
        _inputManager = GetComponent<InputManager>();

        if (_inputManager != null)
            _inputManager._OnInputEntered += SwitchCountingState;
    }

    private void OnDisable()
    {
        if (_inputManager != null)
            _inputManager._OnInputEntered -= SwitchCountingState;
    }

    private void SwitchCountingState()
    {
        if(_countCoroutine == null)
        {
            _countCoroutine = StartCoroutine(CountCoroutine());
        }
        else
        {
            StopCoroutine(_countCoroutine);
            _countCoroutine = null;
        }
    }

    private IEnumerator CountCoroutine()
    {
        while (enabled)
        {
            _currentCount++;
            Debug.Log($"текущее число {_currentCount}");

            yield return new WaitForSeconds(_delay);
        }
    }
}
