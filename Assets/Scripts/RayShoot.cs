// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for ray casting test

using TMPro;
using UnityEngine;

public class RayShoot : MonoBehaviour
{
    public TextMeshProUGUI text;

    private bool up = false;

    public float speed;

    private Vector3 ps;
    
    public LayerMask whatIsGround;

    private bool hit;

    public Material[] materials;

    public GameObject ray;
    

    private void Start()
    {
        ps = transform.position;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.right, out RaycastHit hitInfo, 15f))
        {
            if (hitInfo.collider.CompareTag("Ball"))
            {
                text.text = "Hit";
                text.color = Color.green;
                ray.GetComponent<MeshRenderer>().material = materials[0];
            }
            else
            {
                text.text = "No hit";
                text.color = Color.red;
                ray.GetComponent<MeshRenderer>().material = materials[1];
            }
            
        }
        else
        {
            text.text = "No hit";
            text.color = Color.red;
            ray.GetComponent<MeshRenderer>().material = materials[1];
        }

        transform.position = Vector3.MoveTowards(transform.position, up ? new Vector3(ps.x, ps.y + 3f, ps.z) 
                                                 : new Vector3(ps.x, ps.y, ps.z), speed * Time.deltaTime);
        
        if (transform.position == new Vector3(ps.x, ps.y + 3f, ps.z))
        {
            up = false;
        }
        if (transform.position == new Vector3(ps.x, ps.y, ps.z))
        {
            up = true;
        }
    }
}
