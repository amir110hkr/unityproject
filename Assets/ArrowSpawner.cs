using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ArrowPrefab;
    [SerializeField] private float ArrowSpeed;
    [SerializeField] private float SpawnInterval;
    [SerializeField] private int PoolSize = 10;

    private List<GameObject> _arrowPool;

    private void Awake()
    {
        _arrowPool = new List<GameObject>();

        for (int i = 0; i < PoolSize; i++)
        {
            GameObject arrow = Instantiate(ArrowPrefab);
            arrow.SetActive(false);
            _arrowPool.Add(arrow);
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, SpawnInterval);
    }

    private void Spawn()
{
    GameObject arrow = GetPooledArrow();

    if (arrow == null)
    {
        Debug.LogWarning("No available arrows in pool.");
        return;
    }

    arrow.transform.position = transform.position;
    arrow.SetActive(true);

    Vector2 direction = Random.insideUnitCircle.normalized;

    float archerAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0, 0, archerAngle);

    Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
    rb.velocity = direction * ArrowSpeed;

    arrow.transform.rotation = Quaternion.Euler(0, 0, archerAngle);

    StartCoroutine(DeactivateAfterDelay(arrow, 5f));
}

    private GameObject GetPooledArrow()
    {
        foreach (GameObject arrow in _arrowPool)
        {
            if (!arrow.activeInHierarchy)
            {
                return arrow;
            }
        }

        return null;
    }

    private IEnumerator DeactivateAfterDelay(GameObject arrow, float delay)
    {
        yield return new WaitForSeconds(delay);
        arrow.SetActive(false);
    }
}