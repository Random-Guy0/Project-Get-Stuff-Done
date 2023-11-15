using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    public static CreatureManager Instance { get; private set; }

    public ObservableCollection<Creature> Owned { get; private set; } = new ObservableCollection<Creature>();
    public Creature[] Party { get; private set; } = new Creature[3];
    
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
