using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerShooting : MonoBehaviour
{
    public ParticleSystem shootParticles;  // Reference to the Particle System
    public Transform shootPoint;  // Where the particles will be shot from
    public float shootForce = 10f;  // The force with which the particles are shot

    void Update()
    {
        // Check if the player presses the fire button (e.g., spacebar)
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Play the particle system at the shoot point
        if (shootParticles != null && shootPoint != null)
        {
            // Set the position of the particle system to the shoot point
            shootParticles.transform.position = shootPoint.position;

            // You can also add a force to make the particle move (optional)
            // This part can depend on your particle settings
            var main = shootParticles.main;
            main.startSpeed = shootForce;

            // Play the particle system
            shootParticles.Play();
        }
    }
}
