using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWeapon : MonoBehaviour
{
    public Transform PfirePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(PfirePoint.position, PfirePoint.right);

        if (hitInfo)
        {
            PEnemy enemy = hitInfo.transform.GetComponent<PEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, PfirePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, PfirePoint.position);
            lineRenderer.SetPosition(1, PfirePoint.position + PfirePoint.right * 100);
        }

        lineRenderer.enabled = true;

        // wait one frame

        yield return new WaitForSeconds(0.02f);


        lineRenderer.enabled = false;
    }
}
