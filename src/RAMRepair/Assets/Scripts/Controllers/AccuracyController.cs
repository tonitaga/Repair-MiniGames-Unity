using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AccuracyController : MonoBehaviour
{
    [SerializeField]
    [Range(25, 100)]
    [Tooltip("25 - Easy, 50 - Normal, 75 - Medium, 100 - Hard")]
    private int difficalty = 50;

    [SerializeField]
    [Range(0, 10)]
    [Tooltip("Constant that will increase the main accuracy variable")]
    private int accuracy_increase_constant = 5;

    bool isCalculated = false;
    float _accuracy = 0.0f;

    GameObjectsContainer _container;



    void Update()
    {
        if (isCalculated)
            return;

        GameObjectsContainer container = GameObjectsContainer.Instance;
        if (container == null)
            return;

        if (container.GetAllCards().Count == container.GetAllSlots().Count)
        {
            isCalculated = true;
            CalculateAccuracy();
            GameEndController.instance.ShowGameEndPanel(_accuracy);
            TimeController.Stop();
        }
    }

    void CalculateAccuracy()
    {
        var generatedSlots = GameObjectsContainer.Instance.GetAllSlots();
        var ramCards = GameObjectsContainer.Instance.GetAllCards();
        generatedSlots = generatedSlots.OrderBy(slot => slot.transform.position.x).ToList();
        ramCards = ramCards.OrderBy(slot => slot.transform.position.x).ToList();

        float sum = 0.0f;
        for (int i = 0; i != generatedSlots.Count; ++i)
        {
            var slotBounds = generatedSlots[i].GetComponent<Renderer>().bounds;
            var ramBounds = ramCards[i].GetComponent<Renderer>().bounds;
            if (!slotBounds.Intersects(ramBounds))
                sum += 0.0f;
            else
            {
                float distance = Mathf.Abs(slotBounds.center.x - ramBounds.center.x);
                float current_accuracy = -difficalty * distance + 100;
                sum += Mathf.Clamp(current_accuracy, 0.0f, current_accuracy);
            }
        }

        _accuracy = sum / generatedSlots.Count;

        if (_accuracy >= 50.0f)
            _accuracy += accuracy_increase_constant;

        _accuracy = Mathf.Clamp(_accuracy, _accuracy, 100.0f);
        Debug.Log("Accuracy: " + _accuracy);
    }
}
