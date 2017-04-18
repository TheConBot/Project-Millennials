using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class BallToss : MonoBehaviour
{
    //Private Vars
    private Rigidbody body;
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
            //Launch Input
            if (Input.GetMouseButton(0) && holdingBall)
            {
                powerGauge.value = Mathf.PingPong(Time.time * 10, powerGauge.maxValue);
            }
            else if(Input.GetMouseButtonUp(0) && holdingBall)
            {
                LaunchBall();
            }
            //Ball Aim
            if (holdingBall)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = zOffset;
                transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            }
            //Camera Zoom
            if (holdingBall && Camera.main.fieldOfView != cameraOrigonalZoom)
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, cameraOrigonalZoom, Time.deltaTime * cameraZoomSpeed);
            }
            else if (!holdingBall && Camera.main.fieldOfView != cameraZoomAmount)
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, cameraZoomAmount, Time.deltaTime * cameraZoomSpeed);
            }

            if (gameObject.transform.position.y < -5)
            {
                ResetBall();
            }
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }
    private void ResetBall()
    {
        holdingBall = true;
        body.isKinematic = holdingBall;
        tries--;
        triesRemaining.text = triesText + tries;
        gameObject.transform.rotation = Quaternion.identity;
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
        cupsRemaining.text = cupsText + cups;
        ResetBall();
    }

    private IEnumerator ResetBallTimer()
    {
        int originTry = tries;
        yield return new WaitForSeconds(ballResetTime);
        if(!holdingBall && originTry == tries)
        {
            ResetBall();
        }
        yield return null;
    }
}
