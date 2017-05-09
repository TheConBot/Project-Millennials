using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class BallToss : MonoBehaviour
{
    //Private Vars
    private AudioSource audio;
    private Rigidbody body;
    private LineRenderer lineRenderer;
    private bool playGame;
    private bool holdingBall;
    private bool bounced;
    private float cameraOrigonalZoom;
    private float powerMultiplier;
    private float originTimeStep;
    private int cupsRemaining;
    private const string TRIES_TEXT = "Tries: ";
    private const string CUPS_TEXT = "Cups: ";
    //Inspector Vars
    [Header("Game Settings")]
    public float fixedTimeStep = 0.005f;
    public int sceneToLoad = 8;
    public int triesRemaining = 20;
    public float ballResetTime = 4;
    public AudioClip ballTable;
    public GameObject[] cups;
    [Header("Ball Settings")]
    public float zOffset;
    public float ballSpeed = 1000;
    [Header("Guide Line Settings")]
    public GameObject guideLine;
    public Gradient lineGradiant;
    public float powerMultiplierSpeed = 5;
    public float minPowerMultiplier = 5;
    public float maxPowerMultiplier = 14;
    [Header("Camera Settings")]
    public float cameraZoomAmount = 15;
    public float cameraZoomSpeed = 5;
    [Header("UI")]
    public Text triesRemainingText;
    public Text cupsRemainingText;

    private bool fireOnce;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if(!fireOnce && !UI.Instance.isMainMenuActive)
        {
            StartGame();
        }
        if (playGame)
        {
            if (triesRemaining > 0 && cupsRemaining > 0)
            {
                if (holdingBall)
                {
                    //Ball Aim
                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition.z = zOffset;
                    transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
                    //Launch Input
                    if (Input.GetMouseButton(0))
                    {
                        powerMultiplier = Mathf.Clamp(powerMultiplier + (Time.deltaTime * powerMultiplierSpeed), minPowerMultiplier, maxPowerMultiplier);
                        UpdateTrajectory(transform.position, (transform.forward * powerMultiplier * 1.25f), Physics.gravity);
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        LaunchBall();
                    }
                    else if(powerMultiplier == maxPowerMultiplier)
                    {
                        powerMultiplier = minPowerMultiplier;
                    }
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
                if (cupsRemaining <= 0)
                {
                    Debug.Log("You win!");
                }
                else if (triesRemaining <= 0)
                {
                    Debug.Log("Good try!");
                }
                EndGame();
            }
        }
    }

    private void Initialize()
    {
        originTimeStep = Time.fixedDeltaTime;
        Time.fixedDeltaTime = fixedTimeStep;
        body = GetComponent<Rigidbody>();
        lineRenderer = guideLine.GetComponent<LineRenderer>();
        audio = GetComponent<AudioSource>();
        holdingBall = true;
        body.isKinematic = holdingBall;
        cupsRemaining = cups.Length;
        cameraOrigonalZoom = Camera.main.fieldOfView;
        triesRemainingText.text = TRIES_TEXT + triesRemaining;
        cupsRemainingText.text = CUPS_TEXT + cupsRemaining;
    }

    private void StartGame()
    {
        playGame = true;
        fireOnce = true;
    }

    private void EndGame()
    {
        Time.fixedDeltaTime = originTimeStep;
        UI.Instance.LoadSceneRemote(sceneToLoad, true);
        playGame = false;
    }

    private void ResetBall()
    {
        StopAllCoroutines();
        holdingBall = true;
        bounced = false;
        powerMultiplier = 0;
        body.isKinematic = holdingBall;
        triesRemaining--;
        triesRemainingText.text = TRIES_TEXT + triesRemaining;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        lineRenderer.enabled = false;
    }

    private void LaunchBall()
    {
        holdingBall = false;
        body.isKinematic = holdingBall;
        body.AddForce(transform.forward * ballSpeed * powerMultiplier);
        StartCoroutine(ResetBallTimer());
    }

    private void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity)
    {
        int numSteps = 30;
        float timeDelta = 1.0f / initialVelocity.magnitude;
        guideLine.transform.position = transform.position;
        lineRenderer.enabled = true;
        lineRenderer.positionCount = numSteps;

        Vector3 position = initialPosition;
        Vector3 velocity = initialVelocity;
        for (int i = 0; i < numSteps; ++i)
        {
            lineRenderer.SetPosition(i, position);
            position += velocity * timeDelta + 0.5f * gravity * timeDelta * timeDelta;
            velocity += gravity * timeDelta;
        }
        lineRenderer.startColor = lineGradiant.Evaluate(EstimatedPower());
        lineRenderer.endColor = lineRenderer.startColor;
    }

    private float EstimatedPower()
    {
        return Mathf.Clamp(((powerMultiplier - minPowerMultiplier) / (maxPowerMultiplier - minPowerMultiplier)), 0 ,1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cup")
        {
            cupsRemaining--;
            triesRemaining++;
            if(cupsRemaining != 0) other.gameObject.SetActive(false);
            if (bounced)
            {
                foreach(GameObject cup in cups)
                {
                    if (cup.activeSelf)
                    {
                        cupsRemaining--;
                        triesRemaining++;
                        if (cupsRemaining != 0) other.gameObject.SetActive(false);
                        break;
                    }
                }
            }
            cupsRemainingText.text = CUPS_TEXT + cupsRemaining;
            if (cupsRemaining != 0)  ResetBall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        audio.PlayOneShot(ballTable);
        if(collision.transform.tag == "Table")
        {
            bounced = true;
        }
    }

    private IEnumerator ResetBallTimer()
    {
        yield return new WaitForSeconds(ballResetTime);
        if (!holdingBall)
        {
            ResetBall();
        }
        yield return null;
    }
}
