using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject fireParticlePrefab; 
    public Transform muzzlePoint;        
    public float shootForce = 5f;        

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

void Shoot()
{
  
    float direction = transform.localScale.x > 0 ? -1f : 1f;


    Quaternion rotation = direction > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

   
    GameObject bullet = Instantiate(fireParticlePrefab, muzzlePoint.position, rotation);

    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

    
        rb.AddForce(new Vector2(direction * shootForce, 0), ForceMode2D.Impulse);

        Destroy(bullet, 4f);

}


}