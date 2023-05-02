// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for shooting projectiles in 'Demo'

using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPoint;

    public float bulletForce;

    public GameObject bulletPrefab;
    
    private void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        
        var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        var rigidBody = bullet.GetComponent<Rigidbody>();
        rigidBody.AddForce(shootPoint.forward * bulletForce, ForceMode.Impulse);
    }
}
