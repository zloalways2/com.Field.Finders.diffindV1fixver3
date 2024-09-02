using UnityEngine;

public class TimeOutView : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Progress _progress;

    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _lose;

    private void Awake()
    {
        _timer.Expired += Show;
    }

    private void Show()
    {
        var completed = _progress.Completed;

        _win.SetActive(completed);
        _lose.SetActive(!completed);
    }

    private void OnDestroy()
    {
        _timer.Expired -= Show;
    }
}