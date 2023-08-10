using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectsContainer : MonoBehaviour
{
    public static GameObjectsContainer Instance;

    private List<GameObject> _slots;
    private List<GameObject> _cards;
    void Start()
    {
        _slots = GameObject.FindGameObjectsWithTag("GeneratingSlot").ToList();
        _cards = new List<GameObject>();
        Instance = this;
    }

    void Update()
    {
        if (_cards.Count != _slots.Count)
        {
            _cards = GameObject.FindGameObjectsWithTag("RAMCard").ToList();
            Instance = this;
        }
    }

    public List<GameObject> GetAllSlots()
    {
        return _slots;
    }

    public List<GameObject> GetAllCards()
    {
        return _cards;
    }
}
