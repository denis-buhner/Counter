using UnityEngine;

[RequireComponent(typeof(Counter))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void Awake()
    {
        if (_counter == null)
            _counter = GetComponent<Counter>();
    }

    private void OnEnable()
    {
        if (_counter != null)
            _counter.CounterUpdated += DisplayCounter;
    }

    private void OnDisable()
    {
        if (_counter != null)
            _counter.CounterUpdated -= DisplayCounter;
    }

    private void DisplayCounter()
    {
        Debug.Log(_counter.CurrentCount);
    }
}
