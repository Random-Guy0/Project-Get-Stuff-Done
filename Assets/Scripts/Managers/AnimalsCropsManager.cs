using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsCropsManager : MonoBehaviour
{
    public static AnimalsCropsManager Instance { get; private set; }

    public List<Creature> Owned { get; private set; } = new List<Creature>();
    
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
