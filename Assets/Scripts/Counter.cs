using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private InputController _inputController;

    private Coroutine _countCoroutine;
    private int _currentCount = 0;

    private void Awake()
    {
        if (_inputController == null)
            _inputController = GetComponent<InputController>();
    }

    private void OnEnable()
    {
        if (_inputController != null)
        {
            _inputController.InputEntered += StartCounting;
            _inputController.InputEntered += StopCounting;
        }
    }

    private void OnDisable()
    {
        if (_inputController != null)
        {
            _inputController.InputEntered -= StartCounting;
            _inputController.InputEntered -= StopCounting;
        }
    }

    private void StartCounting()
    {
        if (_countCoroutine == null)
        {
            _countCoroutine = StartCoroutine(CountCoroutine());
        }
    }

    private void StopCounting()
    {
        if ( _countCoroutine != null)
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
