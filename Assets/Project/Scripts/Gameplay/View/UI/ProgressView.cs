using UnityEngine;

public class ProgressView : TextView<int>
{
    [SerializeField] private Progress _progress;

    private void OnEnable()
    {
        _progress.Changed += Show;
    }

    private void Show(int value)
    {
        UpdateText(value, _progress.Target);
    }

    private void Start()
    {
        UpdateText(_progress.Value, _progress.Target);
    }

    private void OnDisable()
    {
        _progress.Changed -= Show;
    }
}