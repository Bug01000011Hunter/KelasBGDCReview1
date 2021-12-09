using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootForce = 3f;
    private Camera mainCam;
    private void Start()
    {
        mainCam = Camera.main;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Vector3 target = mainCam.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0f;

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce((target - transform.position).normalized * shootForce, ForceMode2D.Impulse);

            Destroy(bullet, 3f);
        }
    }
}
