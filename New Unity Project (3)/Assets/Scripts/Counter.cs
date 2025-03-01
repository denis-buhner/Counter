using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    private Coroutine _countCoroutine;
    private int _currentCount = 0; 
    private bool _isCounting = false;

    private void Update()
    {
        TryStartCounting();
        TryCount();
    }

    private void TryCount()
    {
        if(_isCounting)
        {
            if(_countCoroutine == null)
            {
                _countCoroutine = StartCoroutine(CountCoroutine());
            }
        }
    }

    private void TryStartCounting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isCounting = !_isCounting;
        }
    }

    private IEnumerator CountCoroutine()
    {
        while (_isCounting)
        {
            _currentCount++;
            Debug.Log($"текущее число {_currentCount}");

            yield return new WaitForSeconds(_delay);
        }

        _countCoroutine = null;
    }
}
