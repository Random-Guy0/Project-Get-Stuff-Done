using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplayUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text shieldText;

    private Quaternion _originalRotation;

    public void SetHealthText(int amount)
    {
        healthText.SetText("Health: {0}", amount);
    }

    public void SetShieldText(int amount)
    {
        if (amount <= 0)
        {
            shieldText.gameObject.SetActive(false);
        }
        else
        {
            shieldText.gameObject.SetActive(true);
        }
        
        shieldText.SetText("Shield: {0}", amount);
    }

    private void Start()
    {
        _originalRotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation * _originalRotation;
    }
}
