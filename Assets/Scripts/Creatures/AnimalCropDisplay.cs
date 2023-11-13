using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCropDisplay : MonoBehaviour
{
    [SerializeField] private Vector2 animalAreaMin;
    [SerializeField] private Vector2 animalAreaMax;
    [SerializeField] private Vector2 cropAreaMin;
    [SerializeField] private Vector2 cropAreaMax;
    [SerializeField] private float cropLanes = 4;
    
    private void Start()
    {
        foreach (Creature creature in CreatureManager.Instance.Owned)
        {
            AddCreature(creature);
        }
    }

    public void AddCreature(Creature creature)
    {
        if (creature is Animal animal)
        {
            AddAnimal(animal);
        }
        else if (creature is Crop crop)
        {
            AddCrop(crop);
        }
    }

    public void AddAnimal(Animal animal)
    {
        
    }

    public void AddCrop(Crop crop)
    {
        
    }
}
