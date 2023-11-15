using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSceneCreatureClickHandler : CreatureClickHandler
{
    public override void HandleClick(Creature clickedCreature)
    {
        if (clickedCreature is Animal animal)
        {
            Instantiate(animal.UpgradeScreen);
        }
        else if (clickedCreature is Crop crop)
        {
            Instantiate(crop.UpgradeScreen);
        }
    }
}
