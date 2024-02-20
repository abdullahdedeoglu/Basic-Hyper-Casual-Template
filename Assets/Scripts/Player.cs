using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Touch touch;
    [SerializeField] private float speed;
    [SerializeField] private float posXMin;
    [SerializeField] private float posXMax;

    private void Update()
    {
        GetTouch();
        PositionFixer();
    }

    private void GetTouch()
    {
        if (Input.touchCount >0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                Move();
            }

        }
    }

    private void Move()
    {
        transform.position = new Vector3(
            transform.position.x + touch.deltaPosition.x * speed,
            transform.position.y,
            transform.position.z
            );
    }

    private void PositionFixer()
    {
        if (transform.position.x > posXMax)
        {
            transform.position = new Vector3(
                posXMax,
                transform.position.y,
                transform.position.z
                );
        }

        if (transform.position.x < posXMin)
        {
            transform.position = new Vector3(
                posXMin,
                transform.position.y,
                transform.position.z
                );
        }
    }
}
