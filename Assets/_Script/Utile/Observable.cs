using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable<T>
{
    [SerializeField] private T _value = default;
    public T Value
    {
        set
        {
            _value = value;
            OnChange();
        }
        get => _value;
    }

    public event System.Action OnChange = delegate { };
    public void Invoke()
    {
        OnChange();
    }
}
