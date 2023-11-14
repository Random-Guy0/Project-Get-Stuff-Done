using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalCropDisplay : MonoBehaviour
{
    [SerializeField] private Vector2 animalAreaMin;
    [SerializeField] private Vector2 animalAreaMax;
    [SerializeField] private Vector2 cropAreaMin;
    [SerializeField] private Vector2 cropAreaMax;
    [SerializeField] private int cropLanes = 4;
    
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
        float randomX = Random.Range(animalAreaMin.x, animalAreaMax.x);
        float randomZ = Random.Range(animalAreaMin.y, animalAreaMax.y);

        AnimalContainer newAnimal = Instantiate<AnimalContainer>(animal.Prefab);
        Vector3 position = newAnimal.transform.position;
        position.x = randomX;
        position.z = randomZ;
        newAnimal.transform.position = position;
        newAnimal.Creature = animal;
    }

    public void AddCrop(Crop crop)
    {
        int cropLane = Random.Range(0, cropLanes);
        float cropLaneSize = (cropAreaMax.x - cropAreaMin.x) / (float)(cropLanes - 1);
        float randomX = cropAreaMin.x + cropLane * cropLaneSize;
        float randomZ = Random.Range(cropAreaMin.y, cropAreaMax.y);
        
        CropContainer newCrop = Instantiate<CropContainer>(crop.Prefab);
        Vector3 position = newCrop.transform.position;
        position.x = randomX;
        position.z = randomZ;
        newCrop.transform.position = position;
        newCrop.Creature = crop;
    }
}
