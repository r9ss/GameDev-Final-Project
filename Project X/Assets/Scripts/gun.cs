
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 60f;
    

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

  


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           ;
           Shoot();
        }

    }

    void Shoot ()
    {
       muzzleFlash.Play();

       RaycastHit hit;
      if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
         {
            Debug.Log(hit.transform.name);

            target target = hit.transform.GetComponent<target>();
            if (target != null)
            {
               target.TakeDamage(damage);
            }
                
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * impactForce, hit.point);
                }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
         }
    }
}
