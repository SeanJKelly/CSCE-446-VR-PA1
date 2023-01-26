using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreasureSpawner : MonoBehaviour
{
    [SerializeField] float TreasureSpawnHeight = 5.0f;
    private float collisionCheckRadius = 0.1f;
    [SerializeField] int NumberOfTreasures = 3;
    [SerializeField] GameObject TreasureToSpawn;
    void Start()
    {
        // Find position within field
        Vector3 Center = this.transform.position;
        Vector3 Scale = this.transform.lossyScale;

        float MinScaleX = Center.x - ((Scale.x) / 2);
        float MaxScaleX = Center.x + ((Scale.x) / 2);
        float MinScaleZ = Center.z - ((Scale.z) / 2);
        float MaxScaleZ = Center.z + ((Scale.z) / 2);

        //float treasureRadius = TreasureToSpawn.GetComponent<SphereCollider>().radius;
        //Debug.Log("Center: " + Center + " Scale: " + Scale + " MinScaleX: " + MinScaleX + " MaxScaleX: " + MaxScaleX + " MinScaleZ: " + MinScaleZ + " MaxScaleZ: " + MaxScaleZ);

        // Set randomX = Random.Range(min,max)
        int successfulTreasureSpawns = 0;
        while (successfulTreasureSpawns < NumberOfTreasures)
        {
            Vector3 RandomSpawnPosition = new Vector3(Random.Range(MinScaleX, MaxScaleX),
                                                      TreasureSpawnHeight,
                                                      Random.Range(MinScaleZ, MaxScaleZ));
            //Debug.Log(RandomSpawnPosition);

            // Check collision by using a sphere to do so
            if (!Physics.CheckSphere(RandomSpawnPosition, collisionCheckRadius))
            {
                Instantiate(TreasureToSpawn, RandomSpawnPosition, Quaternion.identity);
                successfulTreasureSpawns++;
            }
        }

        // Spawn object at found position
    }
}
