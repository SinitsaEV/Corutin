using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private int _count = 0;
    private bool _isActive = false;

    public Action<int> ChangedCount;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isActive = !_isActive;

            if (_isActive)
            {
                StartCoroutine(Change());
            }
            else
            {
                StopAllCoroutines();
            }
        }        
    }

    private IEnumerator Change()
    {
        while (_count < int.MaxValue)
        {
            WaitForSeconds time = new WaitForSeconds(_delay);

            yield return time;

            _count++;
            ChangedCount?.Invoke(_count);
        }
    }
}
