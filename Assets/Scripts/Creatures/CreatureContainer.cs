using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CreatureContainer<T> : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler where T : Creature
{
    [field: SerializeField] public T Creature { get; set; }

    private void Start()
    {
        Creature.OnDeath += Die;
    }

    private void OnDestroy()
    {
        Creature.OnDeath -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Renderer render = GetComponentInChildren<Renderer>();
        Material[] materials = render.materials;
        foreach (Material material in materials)
        {
            material.shader = Shader.Find("Custom/Outline");
            material.SetColor("_OutlineColor", new Color(1.0f, 1.0f, 0.0f));
            material.SetFloat("_OutlineWidth", 1.1f);
        }

        render.materials = materials;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Renderer render = GetComponentInChildren<Renderer>();
        Material[] materials = render.materials;
        foreach (Material material in materials)
        { 
            material.shader = Shader.Find("Standard");
        }
        
        render.materials = materials;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CreatureClickHandler.Instance.HandleClick(Creature);
    }
}
