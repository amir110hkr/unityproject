using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    private Transform characterTransform; // ارجاع به Transform کاراکتر

    void Start()
    {
        // دریافت کامپوننت Transform کاراکتر در زمان شروع
        characterTransform = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // تعیین جهت شلیک بر اساس مقیاس X کاراکتر
        Vector3 shootDirection = characterTransform.localScale.x < 0 ? firePoint.right : -firePoint.right;

        GameObject projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootDirection * projectileSpeed;
            Destroy(projectileInstance, 2f);
        }
        else
        {
            Debug.LogWarning("Prefab پارتیکل Rigidbody2D ندارد!");
        }
    }
}