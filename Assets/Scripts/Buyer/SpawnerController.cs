using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [Header("Spawner Result")]
    public int maxCarSpawn = 18;
    public int maxParkCarSpawn = 0;
    public float performance = 0.9f;
    [Space(10), Range(0f, 0.2f)] public float luck = 0.2f;
    [Range(0, 6)] public int luckIntensity = 3;
    private int luckBonus;

    [Header("Car System")]
    [Range(0,10)] public float speed;
    [Range(0,10)] public float slowedSpeed;
    public float parkTime;

    public List<int> spawnTime = new List<int>();
    //private List<bool> hasSpawned = new List<bool>();

    [Header("Spawner System")]
    [SerializeField] GameObject spawner1;
    [SerializeField] GameObject spawner2;
    [Space(5)] public GameObject carPrefab1;
    public GameObject carPrefab2;
    private TimeController timeController;
    [HideInInspector] public bool hasSkipped;

    public int additionalCow = 0;
    public bool noCowsLeft;
    void Awake()
    {
        timeController = GameObject.Find("Time Controller").GetComponent<TimeController>();
    }

    void FixedUpdate()
    {
        
        if(spawnTime.Count > 0)
        {
            if (timeController.timeCounter == spawnTime[0])
            {
                GameObject carClone = GetRandomCar();
                Instantiate(carClone, GetSpawnPoint().transform);
                spawnTime.Remove(spawnTime[0]);
            }
        }
        else
        {
            if (!hasSkipped)
            {
                TimeController.instance.EndDay();
                hasSkipped = true;
            }
        }
    }

    public void Reset()
    {
        spawnTime.Clear();
        hasSkipped = false;
        float car = maxCarSpawn;


        //spawning formula
        int x = timeController.dayCounter;
        maxCarSpawn = 4 + Mathf.RoundToInt((2 * Mathf.Log10(x + 3)) + 0.1f * (x + 3) + 0.3f * (Mathf.Cos(1.5f * (x - 2))));
        /*
        if (timeController.dayCounter > 49)
        {
            //maxCarSpawn = Mathf.RoundToInt(165 - Mathf.Sin(car) + 100 * Mathf.Log10(0.0001f * (timeController.dayCounter - 42)) + 200 + (0.05f * timeController.dayCounter));
        }
        else
        {
            maxCarSpawn = Mathf.RoundToInt(Mathf.Tan(0.06f * timeController.dayCounter - 17.2f) + 30 + 0.3f * timeController.dayCounter - Mathf.Sin(car));
        }
        */

        if (Random.Range(0, 101) > luck * 100)
        {
            luckBonus = 0;
        }
        else
        {
            luckBonus = luckIntensity;
        }

        //performance bonus
        if (performance > 1.1f)
        {
            performance = 1.1f;
        }


        maxParkCarSpawn = Mathf.RoundToInt(maxCarSpawn * 0.9f * performance) + luckBonus + additionalCow;

        //create randomized int of spawnTime
        for (int i = 0; i < maxParkCarSpawn; i++)
        {
            spawnTime.Add(Random.Range(0, timeController.timeWithinDay-125));
            //hasSpawned.Add(false);
        }

        //sort the int of spawnTime
        for (int i = 0; i < spawnTime.Count; i++)
        {
            for (int j = i + 1; j < spawnTime.Count; j++)
            {
                if (spawnTime[i] > spawnTime[j])
                {
                    //swap
                    int l = spawnTime[j];
                    spawnTime[j] = spawnTime[i];
                    spawnTime[i] = l;
                }
            }
        }
    }

    public void AddExtraCow(int price)
    {
        if (MoneyController.instance.money >= price)
        {
            additionalCow++;
            MoneyController.instance.money -= price;
        }
    }

    private GameObject GetRandomCar()
    {
        int x = Random.Range(0, 2);

        if (x == 0)
        {
            return carPrefab1;
        }
        else
        {
            return carPrefab2;
        }
    }

    private GameObject GetSpawnPoint()
    {
        int x = Random.Range(0, 2);

        if (x == 0)
        {
            return spawner1;
        }
        else
        {
            return spawner2;
        }
    }

    private void SpawnCar(GameObject car, GameObject spawn)
    {
        for (int i = 0; i <  spawnTime.Count; i++)
        {
            GameObject carClone = car;
            Instantiate(car, spawn.transform);
        }
    }

}

