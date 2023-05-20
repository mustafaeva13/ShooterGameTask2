using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f; 
    public float explosionForce = 100f;
    private bool hasExploded = false;
    [SerializeField] float speed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            hasExploded = true;
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider collider in colliders)
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }

                Destroy(gameObject);
            }
        }
    }
    IEnumerator Bombe()
    {
        yield return new WaitForSeconds(2f);
        

    }
}
