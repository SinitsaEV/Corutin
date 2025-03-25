using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _countText;

    private void OnEnable()
    {
        _counter.ChangedCount += OnChangedCount;
    }

    private void OnDisable()
    {
        _counter.ChangedCount -= OnChangedCount;
    }

    private void OnChangedCount(int currentCount)
    {
        _countText.text = currentCount.ToString();
    }
}
