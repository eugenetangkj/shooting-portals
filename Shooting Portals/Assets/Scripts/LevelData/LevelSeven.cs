using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSeven : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-60.8f, -41.5f}, //Checkpoint 1  {-60.8f, -41.5f}
            {-34.21569f, -41.42709f}, //Checkpoint 2
            {16.51f, -40.44f}, //Checkpoint 3
            {-6.39f, -54.42f}, //Checkpoint 4
            {17.46f, -54.42f}, //Checkpoint 5
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
