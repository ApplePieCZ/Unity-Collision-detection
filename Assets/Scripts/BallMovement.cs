// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for first ball movement in triggers test

using TMPro;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;

    public Transform[] positions;

    private bool right = true;
    
    public TextMeshProUGUI[] text;

    private int enterCounter = 0;
    private int insideCounter = 0;
    private int exitCounter = 0;

    private void OnTriggerEnter(Collider other)
    {
        enterCounter++;
        text[0].text = "Entered: " + enterCounter;
        text[0].color = Color.green;
    }

    private void OnTriggerStay(Collider other)
    {
        insideCounter++;
        text[1].text = "Inside: " + insideCounter;
        text[1].color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        exitCounter++;
        text[2].text = "Exited: " + exitCounter;
        text[2].color = Color.green;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, right ? positions[1].position : 
                                                 positions[0].position, speed * Time.deltaTime);

        if (transform.position == positions[1].position)
        {
            right = false;
            Clean();
        }
        else if (transform.position == positions[0].position)
        {
            right = true;
            Clean();
        }
    }

    private void Clean()
    {
        enterCounter = 0;
        insideCounter = 0;
        exitCounter = 0;
        text[0].text = "Entered: " + enterCounter;
        text[1].text = "Inside: " + insideCounter;
        text[2].text = "Exited: " + exitCounter;
        text[0].color = Color.red;
        text[1].color = Color.red;
        text[2].color = Color.red;
    }
}
