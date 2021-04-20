using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            GameManager[] managers = FindObjectsOfType(typeof(GameManager)) as GameManager[];
            if (managers.Length == 0)
            {
                Debug.LogWarning("GameManager not present on the scene. Creating a new one.");
                GameManager manager = new GameObject("Game Manager").AddComponent<GameManager>();
                _instance = manager;
                return _instance;
            }
            else
            {
                return managers[0];
            }
        }
        set
        {
            if (_instance == null)
                _instance = value;
            else
            {
                Debug.LogError("You can only use one GameManager. Destroying the new one attached to the GameObject " + value.gameObject.name);
                Destroy(value);
            }
        }
    }
    private static GameManager _instance = null;
    #endregion

    public List<GameObject> gameEntityList; // List of all entities in game (Noun words, Adjective words & Objects)
    public List<GameObject> operatorList; // List of all operators in game (IS word)

    public List<NounDictionaryEntry> nounLibraryEntries; // List used in Inspector to build Dictionary: Noun word to object
    public List<AdjectiveDictionaryEntry> adjectiveLibraryEntries; // List used in Inspector to build Dictionary: Adjective word to Behaviour script
    public Dictionary<EntityType, EntityType> dictNounWord;
    public Dictionary<EntityType, System.Type> dictAdjectiveWord;

    private void Awake()
    {
        gameEntityList = new List<GameObject>();
        operatorList = new List<GameObject>();
        dictNounWord = new Dictionary<EntityType, EntityType>();
        dictAdjectiveWord = new Dictionary<EntityType, System.Type>();

        // Build Noun dictionary
        foreach (NounDictionaryEntry entry in nounLibraryEntries)
        {
            dictNounWord.Add(entry.word, entry.noun);
        }

        // Build Adjective dictionary
        foreach (AdjectiveDictionaryEntry entry in adjectiveLibraryEntries)
        {
            dictAdjectiveWord.Add(entry.word, Type.GetType(entry.ruleClass));
        }
    }

    private void Start()
    {
        // Get all entities and sort them in their respective list
        GameEntity[] allEntity = FindObjectsOfType<GameEntity>();
        foreach(GameEntity ge in allEntity)
        {
            if(ge.entityType == EntityType.WORD_IS)
            {
                operatorList.Add(ge.gameObject);
            }
            else
            {
                gameEntityList.Add(ge.gameObject);
            }
        }
    }
}

[System.Serializable]
public class NounDictionaryEntry
{
    public EntityType word;
    public EntityType noun;
}

[System.Serializable]
public class AdjectiveDictionaryEntry
{
    public EntityType word;
    public string ruleClass;
}