using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    [SerializeField] private Transform[] playerPositions = new Transform[3];
    [SerializeField] private Transform[] enemyPositions = new Transform[3];

    [SerializeField] private Button button1;
    [SerializeField] private Button button2;

    [SerializeField] private Monster monsterBase;

    [SerializeField] private HealthDisplayUI healthDisplay;

    private int _numPlayers = 0;
    private int _numEnemies = 1;

    private Creature _selectedPlayerCreature;
    private BattleSceneClickHandler _clickHandler;

    private bool _selectedOption2;

    private int _playerAttacksLeft;

    private int _wave = 1;
    private int _monsterUpgrade = 2;

    private MonsterContainer[] _enemies = new MonsterContainer[3];
    
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        _clickHandler = GetComponent<BattleSceneClickHandler>();
        
        SpawnPlayerCreatures();
        SpawnEnemyCreatures();
    }

    private void SpawnPlayerCreatures()
    {
        if (CreatureManager.Instance.Party[2] == CreatureManager.Instance.Party[1] ||
            CreatureManager.Instance.Party[2] == CreatureManager.Instance.Party[0])
        {
            CreatureManager.Instance.Party[2] = null;
        }

        if (CreatureManager.Instance.Party[1] == CreatureManager.Instance.Party[0])
        {
            CreatureManager.Instance.Party[1] = null;
        }

        for (int i = 0; i < CreatureManager.Instance.Party.Length; i++)
        {
            if (CreatureManager.Instance.Party[i] == null)
            {
                continue;
            }

            _numPlayers++;

            if (CreatureManager.Instance.Party[i] is Animal animal)
            {
                AnimalContainer newAnimal = Instantiate<AnimalContainer>(animal.Prefab, playerPositions[i].position, Quaternion.identity);
                newAnimal.Creature = animal;
                HealthDisplayUI newHealthDisplay = Instantiate<HealthDisplayUI>(healthDisplay, newAnimal.transform);
                animal.OnHealthChanged += newHealthDisplay.SetHealthText;
                newHealthDisplay.SetHealthText(animal.Health);
                animal.OnShieldChanged += newHealthDisplay.SetShieldText;
                newHealthDisplay.SetShieldText(animal.Shield);
            }
            else if (CreatureManager.Instance.Party[i] is Crop crop)
            {
                CropContainer newCrop = Instantiate<CropContainer>(crop.Prefab, playerPositions[i].position, Quaternion.identity);
                newCrop.Creature = crop;
                HealthDisplayUI newHealthDisplay = Instantiate<HealthDisplayUI>(healthDisplay, newCrop.transform);
                crop.OnHealthChanged += newHealthDisplay.SetHealthText;
                newHealthDisplay.SetHealthText(crop.Health);
                crop.OnShieldChanged += newHealthDisplay.SetShieldText;
                newHealthDisplay.SetShieldText(crop.Shield);
            }
        }

        _playerAttacksLeft = _numPlayers;
    }

    private void SpawnEnemyCreatures()
    {
        _numEnemies = Mathf.Clamp(_wave, 1, 3);
        for (int i = 0; i < _numEnemies; i++)
        {
            Monster newMonster = Instantiate<Monster>(monsterBase);
            newMonster.Init();
            newMonster.OnDeath += RemoveMonster;
            _enemies[i] = Instantiate<MonsterContainer>(newMonster.Prefab, enemyPositions[i].position, Quaternion.identity);
            _enemies[i].Creature = newMonster;
            HealthDisplayUI newHealthDisplay = Instantiate<HealthDisplayUI>(healthDisplay, _enemies[i].transform);
            newMonster.OnHealthChanged += newHealthDisplay.SetHealthText;
            newHealthDisplay.SetHealthText(newMonster.Health);
            newMonster.OnShieldChanged += newHealthDisplay.SetShieldText;
            newHealthDisplay.SetShieldText(newMonster.Shield);
        }
    }

    private void RemoveMonster()
    {
        _numEnemies--;
    }

    public void SelectPlayerCreature(Creature creature)
    {
        if (creature.HasAttacked)
        {
            return;
        }
        
        _selectedPlayerCreature = creature;

        if (creature is Animal)
        {
            button1.GetComponentInChildren<TMP_Text>().SetText("Attack");
            button2.GetComponentInChildren<TMP_Text>().SetText("Defend");
        }
        else if (creature is Crop)
        {
            button1.GetComponentInChildren<TMP_Text>().SetText("Defend");
            button2.GetComponentInChildren<TMP_Text>().SetText("Heal");
        }
        
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
    }

    public void SelectTarget(Creature creature)
    {
        if (creature == _selectedPlayerCreature)
        {
            return;
        }
        
        _selectedPlayerCreature.HasAttacked = true;

        if (_selectedPlayerCreature is Animal animal)
        {
            if (!_selectedOption2)
            {
                animal.Attack(creature);
            }
            else
            {
                animal.Defend(creature);
            }
        }
        else if (_selectedPlayerCreature is Crop crop)
        {
            if (!_selectedOption2)
            {
                crop.Defend(creature);
            }
            else
            {
                crop.Heal(creature);
            }
        }

        _playerAttacksLeft--;
        if (_playerAttacksLeft == 0)
        {
            DoEnemyAttacks();
        }
    }

    public void Button1Action()
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        _clickHandler.BattleClickMode = BattleClickMode.SelectTarget;
        _selectedOption2 = false;
    }

    public void Button2Action()
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        _clickHandler.BattleClickMode = BattleClickMode.SelectTarget;
        _selectedOption2 = true;
    }

    private void DoEnemyAttacks()
    {
        
    }
}
