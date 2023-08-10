using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstanciateObjectByTap : MonoBehaviour
{
    [SerializeField]
    private GameObject manipulatorObject;

    [SerializeField]
    private GameObject instanciateObject;

    [SerializeField]
    private int maxInstances = 5;

    [SerializeField]
    private bool isVisibilityChangable = true;

    private int currentInstances = 0;
    private ManipulatorContoller manipulatorContoller;

    void Start()
    {
        manipulatorContoller = manipulatorObject.GetComponentInParent<ManipulatorContoller>();
    }

    void Update()
    {
        if (!manipulatorContoller.isVisible() || currentInstances >= maxInstances)
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                Instanciate();
        } else if (Input.GetMouseButtonDown(0))
        {
            Instanciate();
        }
    }

    void ChangeVisibilityOfNearestSlot(GameObject instance)
    {
        var slots = GameObjectsContainer.Instance.GetAllSlots();
        int index = int.MaxValue;
        float distance = float.MaxValue;

        for (int i = 0; i != slots.Count; ++i)
        {
            float current_distance = Mathf.Abs(slots[i].GetComponent<Renderer>().bounds.center.x - instance.GetComponent<Renderer>().bounds.center.x);
            if (distance > current_distance)
            {
                index = i;
                distance = current_distance;
            }
        }

        slots[index].SetActive(!slots[index].activeSelf);
    }

    void Instanciate()
    {
        var instance = Instantiate(instanciateObject, manipulatorObject.transform.position, new Quaternion());
        currentInstances++;
        manipulatorContoller.SetVisibility(false);

        if (isVisibilityChangable)
            ChangeVisibilityOfNearestSlot(instance);
    }
}
