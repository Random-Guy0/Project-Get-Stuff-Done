using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text rewardsText;
    [SerializeField] private TMP_Text coinsText;

    private void Start()
    {
        rewardsText.SetText("Rewards Earned: {0} Coins", ResourceManager.Instance.RewardCoins);
        coinsText.SetText("Total Coins: {0} Coins", ResourceManager.Instance.Coins);
    }

    public void Confirm()
    {
        gameObject.SetActive(false);
    }
}
