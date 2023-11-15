using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureClickHandler : MonoBehaviour
{
    public static CreatureClickHandler Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public abstract void HandleClick(Creature clickedCreature);
}
