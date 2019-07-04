using UnityEngine;

public class ShotEnemyScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.back * speed;
    }

    private void Update()
    {
        if (transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}