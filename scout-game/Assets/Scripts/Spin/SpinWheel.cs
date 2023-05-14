using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SpinWheel : MonoBehaviour
{
    public SpinPanelManager spinPanelManager;
    public float speed = 500f;
    private bool isSpinning = false;// Flag to indicate if the wheel is Spining
    private bool isStopping = false; // Flag to indicate if the wheel is stopping
    private bool hasStopped = false;// Flag to indicate if the wheel is stopped

    public Dictionary<float, int> prizeList; // Key is the angle, value is the prize ID
    private float[] angles; // Array to store the angles for each prize
    private float angle; // Angle at which the wheel is rotated
    private int prizeId; // ID of the prize that the wheel stops at


    private Button spinButton;// Reference to the spin button

    private Quaternion initialRotation;

    private void Awake()
    {
        // Store the initial rotation of the wheel object
        initialRotation = transform.rotation;
        // Find the GameObject that contains the Button component for the spin button
        GameObject buttonGameObject = GameObject.Find("SpinBtn");

        // Get the Button component itself
        spinButton = buttonGameObject.GetComponent<Button>();

        //Assining the prize number for each angle 
        prizeList = new Dictionary<float, int>();
        prizeList.Add(0f, 1);
        prizeList.Add(45f, 2);
        prizeList.Add(90f, 3);
        prizeList.Add(135f, 4);
        prizeList.Add(180f, 5);
        prizeList.Add(225f, 6);
        prizeList.Add(270f, 7);
        prizeList.Add(315f, 8);

        angles = prizeList.Keys.ToArray();


    }

    public void Spin()
    {

        if (!isSpinning && !isStopping)
        {
            isSpinning = true;
            angle = 0f;
            prizeId = 0;
            isStopping = false;
            spinButton.interactable = false; // Disable the spin button
            Debug.Log($"{isSpinning} and {isStopping} Now Start Spining");
            StartCoroutine(StopWheel());


        }
        else
        {
            Debug.Log($"{isSpinning}and {isStopping}");
        }
    }

    private void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
            angle += speed * Time.deltaTime;

            if (angle >= 360f)
            {
                angle -= 360f;
            }

            // Check if wheel has stopped
            if (speed <= 0 && !isStopping)
            {
                isStopping = true;
                Debug.Log("Slowing");
                StartCoroutine(StopWheel());
            }
            else if (hasStopped)
            {
                // Wheel has stopped
                hasStopped = false;
                Debug.Log("wheel Stopped");


            }
        }
    }

    IEnumerator StopWheel()
    {
        // Get the angle that the wheel has stopped at
        float closestAngle = angles.OrderBy(a => Mathf.Abs(a - angle)).First();

        // Get the prize ID for that angle
        prizeId = prizeList[closestAngle];

        // Generate a random slow down speed 
        float slowDownSpeed = Random.Range(160f, 400f);

        // Slow down the wheel
        while (speed > 0)
        {
            speed -= slowDownSpeed * Time.deltaTime;
            yield return null;
        }

        // Reset the speed and isSpinning flag
        speed = 500f;
        isSpinning = false;
        isStopping = false;
        hasStopped = true;
        // Reset the rotation of the wheel object to its initial value
        transform.rotation = initialRotation;


        Debug.Log("Wheel stopped at prize " + prizeId);
        spinPanelManager.SetNumberOfMoves(prizeId);



        // Close the spin wheel panel
        spinPanelManager.spinWheelPanel.SetActive(false);

        //open the game board panel
        spinPanelManager.gameBoardPanel.SetActive(true);
        // Activate the spin button
        spinPanelManager.ActivateSpinButton();

    }


}