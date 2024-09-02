using System;
using UnityEngine;

public class Progress : MonoBehaviour
{
    private const int Goal = 12;

    public Action<int> Changed;

    [SerializeField] private Gamefield _gamefield;

    public int Value { get; private set; }
    public int Target => Goal * Level.Value;

    public bool Completed => Value >= Target;

    private void Start()
    {
        Value = 0;

        foreach (var itemView in _gamefield.Items)
            itemView.Item.Clicked += Increase;
    }

    private void Increase()
    {
        Value++;
        Changed?.Invoke(Value);
    }

    private void OnDestroy()
    {
        foreach (var itemView in _gamefield.Items)
            itemView.Item.Clicked += Increase;
    }
}