using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    private AnimalCropDisplay _animalCropDisplay;

    private void Start()
    {
        ResourceManager.Instance.OnCoinsChange += SetGoldText;
        SetGoldText(ResourceManager.Instance.Coins);
        _animalCropDisplay = FindObjectOfType<AnimalCropDisplay>();
    }

    private void OnDestroy()
    {
        ResourceManager.Instance.OnCoinsChange -= SetGoldText;
    }

    private void SetGoldText(int amount)
    {
        goldText.SetText("Gold: {0}", amount);
    }

    public void Buy(Creature creature)
    {
        if (ResourceManager.Instance.SpendCoins(creature.Cost))
        {
            Creature newInstance = Instantiate<Creature>(creature);
            newInstance.Init();
            CreatureManager.Instance.Owned.Add(newInstance);
            _animalCropDisplay.AddCreature(newInstance);
        }
    }
}
