using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;

    private void Start()
    {
        ResourceManager.Instance.OnCoinsChange += SetGoldText;
    }

    private void OnDestroy()
    {
        ResourceManager.Instance.OnCoinsChange -= SetGoldText;
    }

    private void SetGoldText(int amount)
    {
        goldText.SetText("Gold: {0}", amount);
    }
}
