using UnityEngine;

public class TimerView : TextView<int>
{
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.Updated += UpdateText;
        UpdateText(_timer.Value);
    }

    private void OnDisable()
    {
        _timer.Updated -= UpdateText;
    }
}