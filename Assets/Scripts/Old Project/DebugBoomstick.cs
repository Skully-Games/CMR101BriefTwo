using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBoomstick : MonoBehaviour
{
    public bool isActivated;
    public float fuseTimer, radius, force;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActivated = true;
            StartCoroutine(BoomLogic());
        }
    }

    IEnumerator BoomLogic()
    {
        if (isActivated == true)
        {
            yield return new WaitForSeconds(fuseTimer);

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }

            Destroy(gameObject);
        }
    }


}
