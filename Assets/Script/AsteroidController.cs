using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject[] asteroid;
    public GameObject enemyship;

    public float minDelay;// задержка между астероидами
    public float maxDelay;


    public float minShip;// задержка между астероидами
    public float maxShip;


    private float nextSpawn;// время следующего астероида
    private float SpawnShip = 12;
    private float asteroidCount = 1;
    public float asteroidingreate;


    void Update()
    {
        if (Time.time > nextSpawn)
        {
            float maxAsteroid = Random.Range(1, asteroidCount);
            for (int i = 0; i <= maxAsteroid; i++)
            {
                float randomXposition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                Vector3 randomposition = new Vector3(randomXposition, transform.position.y, transform.position.z);


                Instantiate(asteroid[Random.Range(0, 2)], randomposition, Quaternion.identity);

                nextSpawn += Random.Range(minDelay, maxDelay);
            }
            asteroidCount += asteroidingreate;
            nextSpawn += Random.Range(minDelay, maxDelay);
        }
        if (Time.time > 12)
        {
            if (Time.time > SpawnShip)
            {
                float maxAsteroid = Random.Range(1, asteroidCount);
                for (int i = 0; i <= maxAsteroid; i++)
                {
                    float randomXposition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                    Vector3 randomposition = new Vector3(randomXposition, transform.position.y, transform.position.z);


                    Instantiate(enemyship, randomposition, Quaternion.Euler(0, 180, 0));

                    SpawnShip += Random.Range(minShip, maxShip);
                }
                asteroidCount += asteroidingreate;
                SpawnShip += Random.Range(minShip, maxShip);
            }
        }
    }
}
