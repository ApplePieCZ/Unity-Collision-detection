// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for coin movement and pick up

using TMPro;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    [Header("Coin text")]
    public TextMeshProUGUI text;

    private bool up = false;
    [Header("Movement speed")]
    public float speed;

    private Vector3 ps;
    private void OnCollisionEnter(Collision other)
    {
        // If coin collides with player, it destroy itself
        if (!other.gameObject.CompareTag("Player")) return;
        text.text = (int.Parse(text.text) + 1).ToString();
        Destroy(gameObject);
    }

    private void Start()
    {
        ps = transform.position;
    }

    private void Update()
    {
        // Every update rotates a moves coin by slight distance
        transform.Rotate (0,0,45*Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, up ? new Vector3(ps.x, ps.y, ps.z) : 
            new Vector3(ps.x, ps.y - 0.5f, ps.z), speed * Time.deltaTime);
        
        if (transform.position == new Vector3(ps.x, ps.y, ps.z))
        {
            up = false;
        }
        
        if (transform.position == new Vector3(ps.x, ps.y - 0.5f, ps.z))
        {
            up = true;
        }
    }
}
