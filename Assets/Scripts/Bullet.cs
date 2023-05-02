// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for bullet behavior in triggers test

using UnityEngine;

public class Bullet : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Enemy"))
      {
         Destroy(gameObject);
      }
   }
}
