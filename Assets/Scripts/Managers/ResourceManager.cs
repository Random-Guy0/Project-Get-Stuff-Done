using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    private int _coins;
    public int Coins
    {
        get => _coins;
        private set
        {
            _coins = value;
            OnCoinsChange?.Invoke(value);
        }
    }

    public delegate void OnCoinsChangeHandler(int coins);

    public event OnCoinsChangeHandler OnCoinsChange;
    
    public int RewardCoins { get; private set; }
    
    [SerializeField] private int coinsEarnedPerWorkChunk = 100;
    [SerializeField] private int coinsEarnedPerTask = 50;
    [SerializeField] private float coinsForFocusMultiplier = 1f;
    [SerializeField] private float coinsForInputMultiplier = 2f;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void CalculateRewards()
    {
        RewardCoins = coinsEarnedPerWorkChunk;
        WorkManager workManager = FindObjectOfType<WorkManager>();
        RewardCoins += (int)(workManager.SecondsInFocus * coinsForFocusMultiplier);
        RewardCoins += (int)(workManager.SecondsOfInput * coinsForInputMultiplier);
        Coins += RewardCoins;
    }

    public void CompleteTask()
    {
        Coins += coinsEarnedPerTask;
    }

    public bool SpendCoins(int amount)
    {
        bool canSpend = CanSpendCoins(amount);
        if (canSpend)
        {
            Coins -= amount;
        }

        return canSpend;
    }

    public bool CanSpendCoins(int amount)
    {
        return Coins >= amount;
    }
}
