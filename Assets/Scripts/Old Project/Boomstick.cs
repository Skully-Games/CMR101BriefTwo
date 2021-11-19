using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomstick : MonoBehaviour
{
    public float fuseTimer, radius, force;

    public void Trigger()
    {
        StartCoroutine(Explode());
    }

    public IEnumerator Explode()
    {
        yield return new WaitForSeconds(fuseTimer);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
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
