using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;

    private void OnEnable()
    {
        SetGoldText(ResourceManager.Instance.Coins);
    }

    private void OnBecameVisible()
    {
        SetGoldText(ResourceManager.Instance.Coins);
    }

    private void SetGoldText(int amount)
    {
        goldText.SetText("Gold: {0}", amount);
    }
}
