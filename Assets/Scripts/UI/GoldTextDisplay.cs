using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldTextDisplay : MonoBehaviour
{
    private TMP_Text _goldText;

    private void Start()
    {
        _goldText = GetComponent<TMP_Text>();
        SetGoldText(ResourceManager.Instance.Coins);
        ResourceManager.Instance.OnCoinsChange += SetGoldText;
    }

    private void OnDestroy()
    {
        ResourceManager.Instance.OnCoinsChange -= SetGoldText;
    }

    private void SetGoldText(int amount)
    {
        _goldText.SetText("Coins: {0}", amount);
    }
}
