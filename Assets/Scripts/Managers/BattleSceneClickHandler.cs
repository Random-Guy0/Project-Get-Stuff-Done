using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneClickHandler : CreatureClickHandler
{
    public BattleClickMode BattleClickMode { get; set; } = BattleClickMode.SelectInitial;
    
    public override void HandleClick(Creature clickedCreature)
    {
        switch (BattleClickMode)
        {
            case BattleClickMode.SelectInitial:
                BattleManager.Instance.SelectPlayerCreature(clickedCreature);
                break;
            case BattleClickMode.SelectTarget:
                BattleManager.Instance.SelectTarget(clickedCreature);
                break;
        }
    }
}

public enum BattleClickMode
{
    SelectInitial,
    SelectTarget
}
