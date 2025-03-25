using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private int _count = 0;
    private bool _isActive = false;
    private Coroutine _coroutine;
    private WaitForSeconds _time;

    public Action<int> ChangedCount;

    private void Start()
    {
        _time = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isActive = !_isActive;

            if (_isActive)
            {
                _coroutine = StartCoroutine(Change());
            }
            else
            {
                StopCoroutine(_coroutine);
            }
        }        
    }

    private IEnumerator Change()
    {
        while (_count < int.MaxValue)
        {
            yield return _time;

            _count++;
            ChangedCount?.Invoke(_count);
        }
    }
}
