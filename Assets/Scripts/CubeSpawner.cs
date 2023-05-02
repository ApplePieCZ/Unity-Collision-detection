// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for object spawning in 'stress test'

using System;
using TMPro;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Header("Matrix size")]
    public double cubes = 3.0;
    [Header("Spawn point")]
    public Transform spawnPoint;
    [Header("All objects prefabs")]
    public GameObject[] prefabs;

    private GameObject chosenPrefab;
    [Header("Text output")]
    public TextMeshProUGUI textCubes;

    public TextMeshProUGUI textMode;

    public TextMeshProUGUI textQuantity;

    private int[] quantity = {3, 5, 7, 9, 11, 13, 15, 17, 19};

    private int quantityPointer = 0;

    private int cubesCounter = 0;

    private string[] modes = {"Cubes", "Spheres", "Capsules"};

    private int mode = 0;

    private void Start()
    {
        chosenPrefab = prefabs[mode];
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SpawnCubes();
        }

        if (Input.GetButtonDown("Plus"))
        {
            IncreaseQuantity();
        }
        
        if (Input.GetButtonDown("Minus"))
        {
            DecreaseQuantity();
        }
        
        if (Input.GetButtonDown("Shift"))
        {
            ChooseMode();
        }
    }

    private void SpawnCubes()
    {
        var step = Math.Floor(cubes / 2);

        var inc = 0.5;
        
        // Cycles for 3D matrix movement, each cell is an spawned object
        for (var x = step * -inc; x <= step * inc; x += inc)
        {
            for (var y = step * -inc; y <= step * inc; y += inc)
            {
                for (var z = step * -inc; z <= step * inc; z += inc)
                {
                    var newPos = spawnPoint.position;
                    Instantiate(chosenPrefab, new Vector3(newPos.x + (float)x, newPos.y + (float)y, newPos.z + (float)z), Quaternion.Euler(0,0,0));
                    cubesCounter++;
                }
            }
        }

        textCubes.text = cubesCounter.ToString();
    }

    private void IncreaseQuantity()
    {
        if (quantityPointer == 8)
        { return; }
        
        quantityPointer++;
        cubes = quantity[quantityPointer];
        textQuantity.text = quantity[quantityPointer].ToString();
    }
    
    private void DecreaseQuantity()
    {
        if (quantityPointer == 0)
        { return; }
        
        quantityPointer--;
        cubes = quantity[quantityPointer];
        textQuantity.text = quantity[quantityPointer].ToString();
    }

    private void ChooseMode()
    {
        if (mode == 2)
        {
            mode = 0;
        }
        else
        {
            mode++;
        }

        chosenPrefab = prefabs[mode];
        textMode.text = modes[mode];
    }
}
