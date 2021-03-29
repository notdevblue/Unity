using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    public float            power           = 10.0f;
    public float            range           = 100.0f;
    public float            impactForce     = 50.0f;
    public float            fireRate        = 3.0f;
    public float            nextTimeToFire  = 0.0f;
    public float            reloadCurTime   = 0.0f;
    public float            reloadMaxTime   = 0.0f;
    public bool             isSngleFire     = false;
    public bool             bReload         = false;

    public ParticleSystem   muzzleFlash;
    public GameObject       impactEffect;
    public GameObject       crossHair;
    public Image            cooltimeImage;
    public LineRenderer     lineLazer;
    

    private void Update()
    {
        lineLazer.gameObject.SetActive(false);


        RaycastHit lazerHit;
        Ray lazerRay = new Ray(lineLazer.transform.position, lineLazer.transform.forward);
        if(Physics.Raycast(lazerRay, out lazerHit))
        {
            crossHair.SetActive(true);
            lineLazer.SetPosition(1, lineLazer.transform.InverseTransformPoint(lazerHit.point));

            Vector3 crosshailLocation = Camera.main.WorldToScreenPoint(lazerHit.point);

            crossHair.transform.position = crosshailLocation;
        }
        else
        {
            crossHair.SetActive(false);
        }



        if(Input.GetKeyDown(KeyCode.B))
        {
            isSngleFire = !isSngleFire;
        }
        //if(Input.GetKeyDown(KeyCode.R) && !bReload)
        //{
        //    bReload = true;
        //}



        switch(isSngleFire)
        {
            case true:
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    Shoot();

                    bReload = true;
                    reloadMaxTime = nextTimeToFire - Time.time;
                    reloadCurTime = 0.0f;
                }
                break;

            case false: 
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + fireRate;
                    Shoot();

                    bReload = true;
                    reloadMaxTime = nextTimeToFire - Time.time;
                    reloadCurTime = 0.0f;
                }
                break;
        }
        

        if(bReload)
        {
            reloadCurTime += Time.deltaTime;
            cooltimeImage.fillAmount = reloadCurTime / reloadMaxTime;
            if(cooltimeImage.fillAmount > 1)
            {
                cooltimeImage.fillAmount = 0;
                bReload = false;
            }
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        lineLazer.gameObject.SetActive(true);
        RaycastHit hit;
        if(Physics.Raycast(lineLazer.transform.position, lineLazer.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TargetBox tb = hit.transform.GetComponent<TargetBox>();
            if(tb != null)
            {
                tb.TakeDamage(power);
            }
            
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObj, 2.0f);
            
        }
    }
}
