using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarManager : MonoBehaviour
{
    public float carSpeed;
    public float carTurnMultiplier;
    public float timer = 30;
    public int invincibilityTicks = 3;
    public int sceneToLoad = 3;
    public AnimationCurve carTurnAngle;
    public Transform[] XPosRef;
    public Slider distanceMeter;
    public Image[] livesImages;

    private InputBindings inputBindings;
    private int lives = 3;
    private int xDirection;
    private int xPosIndex = 1;
    private bool isCarMoving = false;
    private bool isCarInvincible = false;
    private Vector3 nextPosition;
    private Vector3 lastPosition;

    private void Awake()
    {
        inputBindings = InputBindings.CreateWithDefaultBindings();
        distanceMeter.maxValue = timer;
        if(lives != livesImages.Length)
        {
            Debug.LogWarning("The ammount of lives images is not equal to the ammount of lives.");
        }
        StartCoroutine(Timer());
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ObstacleMover>() != null && !isCarInvincible)
        {
            lives--;
            livesImages[lives].enabled = false;
            if(lives <= 0)
            {
                StartCoroutine(Invincible(100));
                UI.Instance.LoadSceneRemote(sceneToLoad, true);
            }
            StartCoroutine(Invincible(invincibilityTicks));
        }
    }

    private IEnumerator Invincible(int ticks)
    {
        isCarInvincible = true;
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        //ticks last for half of a second
        for (int i = 0; i < ticks; i++)
        {
            mesh.enabled = false;
            yield return new WaitForSecondsRealtime(0.25f);
            mesh.enabled = true;
            yield return new WaitForSecondsRealtime(0.25f);
        }
        isCarInvincible = false;
    }

    private IEnumerator Timer()
    {
        while(timer > 0 && lives > 0)
        {
            timer -= Time.deltaTime;
            distanceMeter.value += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (lives > 0)
        {
            StartCoroutine(Invincible(100));
            UI.Instance.LoadSceneRemote(sceneToLoad, true);
        }
    }
}
