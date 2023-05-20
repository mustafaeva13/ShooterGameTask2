using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform bulletPref;
    [SerializeField] private Transform firePosition;
    private Oyuncu Oyuncu;
    private Vector3 drection;

    private void Start()
    {
        Oyuncu = FindObjectOfType<Oyuncu>();
    }

    void Update()
    {
        drection = Oyuncu.transform.position - transform.position;
        drection.Normalize();
        transform.Translate(drection * speed * Time.deltaTime);

        transform.LookAt(Oyuncu.transform);

        if (Vector3.Distance(Oyuncu.transform.position , transform.position) < 5 )
        {
            Transform bullet = Instantiate(bulletPref);
            bullet.position = firePosition.position;

            bullet.GetComponent<Rigidbody>().AddForce(firePosition.forward * 50, ForceMode.Impulse);
            
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
    }
}
    
