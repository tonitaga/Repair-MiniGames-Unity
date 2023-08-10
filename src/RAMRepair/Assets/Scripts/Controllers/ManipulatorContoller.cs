using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatorContoller : MonoBehaviour
{
    [SerializeField]
    [Range(1.0f, 10.0f)]
    private float movementSpeed = 2.0f;

    [SerializeField]
    [Range(2.0f, 20.0f)]
    private float movementSpeedWithoutItem = 6.0f;

    [SerializeField]
    [Tooltip("Manipulator start move point")]
    private float leftBorder = -10.0f;

    [SerializeField]
    [Tooltip("Manipulator end move point")]
    private float rightBorder = 10.0f;

    private bool isMovingRight = true;
    private Transform _transform = null;

    private GameObject manipulatingItem = null;
    private bool isManipulatingItemVisible = true;

    void Start()
    {
        _transform = GetComponent<Transform>();
        foreach (Transform child in _transform)
            if (child.tag == "ManipulatingItem")
                manipulatingItem = child.gameObject;
    }

    void Update()
    {
        if (_transform == null)
            return;

        if (isMovingRight)
            MoveRight();
        else
            MoveLeft();
    }

    void MoveRight()
    {
      
        if (!isManipulatingItemVisible)
            _transform.position += Vector3.right * Time.deltaTime * movementSpeedWithoutItem;
        else
            _transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        
        if (_transform.position.x >= rightBorder)
        {
            isMovingRight = false;

            if (!isManipulatingItemVisible)
                SetVisibility(true);
        }
    }

    void MoveLeft()
    {
        if (!isManipulatingItemVisible)
            _transform.position += Vector3.left * Time.deltaTime * movementSpeedWithoutItem;
        else
            _transform.position += Vector3.left * Time.deltaTime * movementSpeed;

        if (_transform.position.x <= leftBorder)
        {
            isMovingRight = true;

            if (!isManipulatingItemVisible)
                SetVisibility(true);
        }
    }

    public void SetVisibility(bool isVisible)
    {
        if (manipulatingItem == null)
            return;

        manipulatingItem.SetActive(isVisible);
        isManipulatingItemVisible = isVisible;
    }

    public bool isVisible()
    {
        return isManipulatingItemVisible;
    }
}
