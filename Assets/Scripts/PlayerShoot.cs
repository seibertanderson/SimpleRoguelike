using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject projectile;
    public GameObject projectileSpawnPoint;
    [Range(0, 1000f)]
    public float projectileVelocity = .1f;
    public float TempoParaDestruirABullet = .5f; // fazer upgrade distancia da bala
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ShootArrow();

        
    }



    public void ShootArrow()
    {
        // ROTINA DE TIRO NORMAL
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));

            projectileSpawnPoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - projectileSpawnPoint.transform.position);

            GameObject bulletInstance = Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.Euler(new Vector3(0, 0, projectileSpawnPoint.transform.localEulerAngles.z)));

            bulletInstance.GetComponent<Rigidbody2D>().AddForce(projectileSpawnPoint.transform.up * projectileVelocity);

            Destroy(bulletInstance.gameObject, TempoParaDestruirABullet);
        }
    }
}
