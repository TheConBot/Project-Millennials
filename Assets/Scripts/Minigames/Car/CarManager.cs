using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CarManager : MonoBehaviour
{
    public float carSpeed;
    public float carTurnMultiplier;
    public AnimationCurve carTurnAngle;
    public Transform[] XPosRef;

    private InputBindings inputBindings;
    private int xDirection;
    private int xPosIndex = 1;
    private bool isCarMoving = false;
    private Vector3 nextPosition;
    private Vector3 lastPosition;

    private void Awake()
    {
        inputBindings = InputBindings.CreateWithDefaultBindings();
    }

    private void Update()
    {
        if (InputDetected() && !isCarMoving)
        {
            lastPosition = transform.position;
            //X Axis Input
            if (inputBindings.Right.WasPressed && xPosIndex != XPosRef.Length - 1)
            {
                xPosIndex++;
                xDirection = 1;
            }
            else if (inputBindings.Left.WasPressed && xPosIndex != 0)
            {
                xPosIndex--;
                xDirection = -1;
            }
            nextPosition = new Vector3(XPosRef[xPosIndex].position.x, transform.position.y, transform.position.z);
            StartCoroutine(MoveCar());
        }

    }

    private bool InputDetected()
    {
        return inputBindings.Left.WasPressed || inputBindings.Right.WasPressed;
    }

    private IEnumerator MoveCar()
    {
        isCarMoving = true;
        while (transform.position.x != nextPosition.x)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * carSpeed);
            Quaternion newRot = RotateCar();
            transform.SetPositionAndRotation(newPos, newRot);
            yield return new WaitForEndOfFrame();
        }
        isCarMoving = false;
        transform.rotation = Quaternion.identity;
        yield return null;
    }

    private Quaternion RotateCar()
    {
        float percentage = Mathf.InverseLerp(lastPosition.x, nextPosition.x, transform.position.x);
        Quaternion targetRotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, carTurnAngle.Evaluate(percentage) * carTurnMultiplier * xDirection, transform.eulerAngles.z));
        return targetRotation;
    }
}
