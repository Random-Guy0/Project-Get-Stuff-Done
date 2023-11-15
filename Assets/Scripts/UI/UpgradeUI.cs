using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    private Creature _creature;
    private Action<int> _attribute1UpgradeMethod;
    private Func<int> _attribute1Getter;
    private Action<int> _attribute2UpgradeMethod;
    private Func<int> _attribute2Getter;
    private Action<int> _attribute3UpgradeMethod;
    private Func<int> _attribute3Getter;

    public Creature Creature
    {
        get => _creature;
        private set
        {
            _creature = value;
            _attribute1UpgradeMethod = value.UpgradeHealth;
            _attribute1Getter = () => value.Health;

            if (value is Animal animal)
            {
                _attribute2UpgradeMethod = animal.UpgradeDamageAmount;
                _attribute2Getter = () => animal.DamageAmount;
                _attribute3UpgradeMethod = animal.UpgradeDefenseAmount;
                _attribute3Getter = () => animal.DefenseAmount;
            }
            else if (value is Crop crop)
            {
                _attribute2UpgradeMethod = crop.UpgradeDefenseAmount;
                _attribute2Getter = () => crop.DefenseAmount;
                _attribute3UpgradeMethod = crop.UpgradeHealAmount;
                _attribute3Getter = () => crop.HealAmount;
            }
        }
    }

    [SerializeField] private string creatureName;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private string attribute1Name;
    [SerializeField] private int attribute1UpgradeAmount = 5;
    [SerializeField] private TMP_Text attribute1Text;
    [SerializeField] private string attribute2Name;
    [SerializeField] private int attribute2UpgradeAmount = 5;
    [SerializeField] private TMP_Text attribute2Text;
    [SerializeField] private string attribute3Name;
    [SerializeField] private int attribute3UpgradeAmount = 5;
    [SerializeField] private TMP_Text attribute3Text;

    public void Init(Creature creature)
    {
        Creature = creature;
        nameText.SetText(creatureName);
        SetAttribute1Text(_attribute1Getter());
        SetAttribute2Text(_attribute2Getter());
        SetAttribute3Text(_attribute3Getter());
    }

    private void SetAttribute1Text(int amount)
    {
        attribute1Text.SetText(attribute1Name + ": {0}", amount);
    }

    private void SetAttribute2Text(int amount)
    {
        attribute2Text.SetText(attribute2Name + ": {0}", amount);
    }

    private void SetAttribute3Text(int amount)
    {
        attribute3Text.SetText(attribute3Name + ": {0}", amount);
    }
    
    public void UpgradeAttribute1()
    {
        _attribute1UpgradeMethod(attribute1UpgradeAmount);
        SetAttribute1Text(_attribute1Getter());
    }
    
    public void UpgradeAttribute2()
    {
        _attribute2UpgradeMethod(attribute2UpgradeAmount);
        SetAttribute2Text(_attribute2Getter());
    }
    
    public void UpgradeAttribute3()
    {
        _attribute3UpgradeMethod(attribute3UpgradeAmount);
        SetAttribute3Text(_attribute3Getter());
    }

    public void CloseMenu()
    {
        Destroy(gameObject);
    }
}
