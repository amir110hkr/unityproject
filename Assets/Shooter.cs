using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject fireParticlePrefab; // Prefab ذره
    public Transform muzzlePoint;         // نقطه شلیک
    public float shootForce = 5f;         // نیروی شلیک

    void Update()
    {
        // بررسی فشرده شدن دکمه Enter
        if (Input.GetKeyDown(KeyCode.Return)) // Enter یا KeypadEnter هم میشه
        {
            Shoot();
        }
    }

void Shoot()
{
    // تشخیص جهت نگاه کاراکتر
    float direction = transform.localScale.x > 0 ? -1f : 1f;

    // تنظیم زاویه چرخش: 0 برای چپ، 180 برای راست (محور Y در 2D)
    Quaternion rotation = direction > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

    // ساخت پارتیکل با چرخش مناسب
    GameObject bullet = Instantiate(fireParticlePrefab, muzzlePoint.position, rotation);

    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

    
        rb.AddForce(new Vector2(direction * shootForce, 0), ForceMode2D.Impulse);

        Destroy(bullet, 4f);

}


}