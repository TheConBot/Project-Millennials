using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class BallToss : MonoBehaviour
{
    //Private Vars
    private Rigidbody body;
    private LineRenderer lineRenderer;
    private bool holdingBall;
    private float cameraOrigonalZoom;
    private const string triesText = "Tries: ";
    private const string cupsText = "Cups: ";
    //Inspector Vars
    [Header("Game Settings")]
    public int tries = 20;
    public int cups = 10;
    public float ballResetTime = 4;
    [Header("Ball Settings")]
    public float zOffset;
    public float ballSpeed = 1000;
    [Header("Camera Settings")]
    public float cameraZoomAmount = 15;
    public float cameraZoomSpeed = 5;
    [Header("UI")]
    public Text triesRemaining;
    public Text cupsRemaining;
    public Slider powerGauge;


    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        holdingBall = true;
        body.isKinematic = holdingBall;
        cameraOrigonalZoom = Camera.main.fieldOfView;
        triesRemaining.text = triesText + tries;
        cupsRemaining.text = cupsText + cups;
    }

    private void Update()
    {
        if (tries > 0 && cups > 0)
        {
            if (holdingBall)
            {
                //Launch Input
                if (Input.GetMouseButton(0))
                {
                    powerGauge.value = Mathf.PingPong(Time.time * 10, powerGauge.maxValue);
                    UpdateTrajectory(transform.position, (transform.forward * powerGauge.value * 1.25f), Physics.gravity);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    LaunchBall();
                }
                //Ball Aim
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = zOffset;
                transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
                //Camera Zoom Out
                if (Camera.main.fieldOfView != cameraOrigonalZoom)
                {
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, cameraOrigonalZoom, Time.deltaTime * cameraZoomSpeed);
                }
            }
            else
            {
                //Camera Zoom In
                if (Camera.main.fieldOfView != cameraZoomAmount)
                {
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, cameraZoomAmount, Time.deltaTime * cameraZoomSpeed);
                }
                //Reset Falling Ball
                if (gameObject.transform.position.y < -5)
                {
                    ResetBall();
                }
            }
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }
    private void ResetBall()
    {
        StopAllCoroutines();
        holdingBall = true;
        body.isKinematic = holdingBall;
        tries--;
        triesRemaining.text = triesText + tries;
        gameObject.transform.rotation = Quaternion.identity;
        lineRenderer.enabled = false;
    }

    private void LaunchBall()
    {
        holdingBall = false;
        body.isKinematic = holdingBall;
        body.AddForce(transform.forward * ballSpeed * powerGauge.value);
        StartCoroutine(ResetBallTimer());
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        cups--;
        tries++;
        cupsRemaining.text = cupsText + cups;
        ResetBall();
    }

    private IEnumerator ResetBallTimer()
    {
        int originTry = tries;
        yield return new WaitForSeconds(ballResetTime);
        if (!holdingBall)
        {
            ResetBall();
        }
        yield return null;
    }

    private void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity)
    {
        int numSteps = 30; // for example
        float timeDelta = 1.0f / initialVelocity.magnitude; // for example
        lineRenderer.enabled = true;
        lineRenderer.positionCount = numSteps;

        Vector3 position = initialPosition;
        Vector3 velocity = initialVelocity;
        for (int i = 0; i < numSteps; ++i)
        {
            if(i == numSteps / 2)
            {
                if (position.y > -0.6f && position.y < 0.3f)
                {
                    lineRenderer.startColor = Color.green;
                    lineRenderer.endColor = Color.green;
                }
                else
                {
                    lineRenderer.startColor = Color.white;
                    lineRenderer.endColor = Color.white;

                }
            }
            lineRenderer.SetPosition(i, position);
            position += velocity * timeDelta + 0.5f * gravity * timeDelta * timeDelta;
            velocity += gravity * timeDelta;
        }
        

    }
}
