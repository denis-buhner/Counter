using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Counter : MonoBehaviour
{
    [SerializeField][Min(0)] private float _delay = 0.5f;
    [SerializeField] private InputReader _inputController;

    public event Action CounterUpdated;
    private Coroutine _countCoroutine;
    private bool _isCounting;

    public int CurrentCount { get; private set; } = 0;

    private void Awake()
    {
        if (_inputController == null)
            _inputController = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        if (_inputController != null)
        {
            _inputController.InputEntered += ToggleCounting;
        }
    }

    private void OnDisable()
    {
        if (_inputController != null)
        {
            _inputController.InputEntered -= ToggleCounting;
        }
    }

    private void ToggleCounting()
    {
        if (_isCounting)
        {

            if (_countCoroutine != null)
            {
                StopCoroutine(_countCoroutine);
                _countCoroutine = null;
            }

            _isCounting = false;
        }
        else
        {
            _isCounting = true;

            if (_countCoroutine == null)
            {
                _countCoroutine = StartCoroutine(CountCoroutine());
            }
        }
    }

    private IEnumerator CountCoroutine()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (_isCounting)
        {
            CurrentCount++;
            CounterUpdated?.Invoke();

            yield return delay;
        }
    }
}
