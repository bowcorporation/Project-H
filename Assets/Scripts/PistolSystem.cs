using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolSystem : MonoBehaviour {

    public float minSpread;
    public float maxSpread;

    public float bulletSpeed;
    public float fireRate;
    public float nextTimeToFire = 0f;

    public Transform bulletSpawn;
    public GameObject bulletPref;

    private float aimPosY;
    private float aimPosX;

    public Animator anim;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //bulletSpawn.localEulerAngles = new Vector3(aimPosX, transform.localRotation.y, aimPosY);

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
            anim.SetBool("isFiring", true);
        } else
        {
            anim.SetBool("isFiring", false);
        }

    }

    void Fire()
    {
        aimPosY = Random.Range(-minSpread, maxSpread);
        aimPosX = Random.Range(-minSpread, maxSpread);

        var bullet = (GameObject)Instantiate(bulletPref, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, 8.0f);
    }
}
