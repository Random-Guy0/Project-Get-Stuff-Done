using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private AnimalCropDisplay _animalCropDisplay;

    private void Start()
    {
        _animalCropDisplay = FindObjectOfType<AnimalCropDisplay>();
    }

    public void Buy(Creature creature)
    {
        if (ResourceManager.Instance.SpendCoins(creature.CostOrScore))
        {
            Creature newInstance = Instantiate<Creature>(creature);
            newInstance.Init();
            CreatureManager.Instance.Owned.Add(newInstance);
            _animalCropDisplay.AddCreature(newInstance);
        }
    }
}
