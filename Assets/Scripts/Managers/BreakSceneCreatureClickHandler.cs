using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSceneCreatureClickHandler : CreatureClickHandler
{
    public override void HandleClick(Creature clickedCreature)
    {
        if (clickedCreature is Animal animal)
        {
            Instantiate<UpgradeUI>(animal.UpgradeScreen).Init(animal);
        }
        else if (clickedCreature is Crop crop)
        {
            Instantiate<UpgradeUI>(crop.UpgradeScreen).Init(crop);
        }
    }
}
