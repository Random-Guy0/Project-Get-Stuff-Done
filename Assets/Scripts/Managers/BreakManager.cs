using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BreakManager : MonoBehaviour
{
    [SerializeField] private Button battleButton;

    public void StartLongBreak()
    {
        battleButton.gameObject.SetActive(true);
    }

    public void EnterBattle()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
