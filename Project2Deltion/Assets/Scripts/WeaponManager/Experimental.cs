using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experimental : MonoBehaviour
{
    public float radius;
    public float force;

    [SerializeField] private GameObject explodeEffect;

    private float countDown;
    private bool hasExplode = false;

    [SerializeField] private float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject && !hasExplode)
        {
            Explode();
            hasExplode = true;
        }
    }

    void Explode()
    {
        Instantiate(explodeEffect, transform.position, transform.rotation);

        Collider[] enemyHealth = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in enemyHealth)
        {
            EnemyHealth health = nearbyObject.GetComponent<EnemyHealth>();
            HealthManager healthM = nearbyObject.GetComponent<HealthManager>();

            if (health != null)
            {
                health.EnemyHealthCheck(damage);
            }
            if (healthM != null)
            {
                healthM.Health(damage);
            }
        }

        Collider[] colliderToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliderToDestroy)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Collider[] colliderToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliderToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
