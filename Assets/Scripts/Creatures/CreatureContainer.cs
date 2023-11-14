using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureContainer<T> : MonoBehaviour where T : Creature
{
    [field: SerializeField] public T Creature { get; set; }
}
