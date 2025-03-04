using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const int StartValue = 30;

    public Action<int> Updated;
    public Action Expired;

    public int Value { get; private set; }

    private void Awake()
    {
        Value = StartValue;
        StartCoroutine(DecreaseLoop());
    }

    private IEnumerator DecreaseLoop()
    {
        var wait = new WaitForSecondsRealtime(1);
        var waitPause = new WaitWhile(() => Pause.IsPaused);

        while(Value > 0)
        {
            yield return waitPause;
            Value--;
            Updated?.Invoke(Value);
            yield return wait;
        }

        Expired?.Invoke();
    }
}