// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for camera movement and input handling in tests

using UnityEngine;
using UnityEngine.SceneManagement;

public class ExamplesManager : MonoBehaviour
{
    public Transform cameraPos;

    private int count = 0;

    public Transform[] positions;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }

        if (!Input.GetButtonDown("Jump")) return;
        
        count++;
        if (count == 3)
        {
            count = 0;
        }

        cameraPos.position = positions[count].position;
        cameraPos.rotation = positions[count].rotation;
    }
}
