using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PartyUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown[] partyDropdowns = new TMP_Dropdown[3];

    private void Start()
    {
        CreatureManager.Instance.Owned.CollectionChanged += UpdateDropdowns;
        UpdateDropdowns(null, null);
    }

    private void UpdateDropdowns(System.Object obj, NotifyCollectionChangedEventArgs eventArgs)
    {
        //thanks for this line jetbrains rider
        List<TMP_Dropdown.OptionData> options = (from creature in CreatureManager.Instance.Owned select creature.name into creatureName select creatureName.Replace("(Clone)", "") into creatureName select new TMP_Dropdown.OptionData(creatureName)).ToList();

        for (int i = 0; i < partyDropdowns.Length; i++)
        {
            int selected = CreatureManager.Instance.Owned.IndexOf(CreatureManager.Instance.Party[i]);
            partyDropdowns[i].ClearOptions();
            partyDropdowns[i].options = options;
            partyDropdowns[i].value = selected;
        }
    }

    public void Dropdown1Select(int selected)
    {
        CreatureManager.Instance.Party[0] = CreatureManager.Instance.Owned[selected];
    }

    public void Dropdown2Select(int selected)
    {
        CreatureManager.Instance.Party[1] = CreatureManager.Instance.Owned[selected];
    }

    public void Dropdown3Select(int selected)
    {
        CreatureManager.Instance.Party[2] = CreatureManager.Instance.Owned[selected];
    }
}
