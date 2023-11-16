using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_Text))]
public class CreditsLinkHandler : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text _creditsText;

    private void Start()
    {
        _creditsText = GetComponent<TMP_Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(eventData.position.x, eventData.position.y);

        int linkTaggedText = TMP_TextUtilities.FindIntersectingLink(_creditsText, mousePosition, null);
        
        if (linkTaggedText != -1)
        {
            TMP_LinkInfo linkInfo = _creditsText.textInfo.linkInfo[linkTaggedText];
            
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}
