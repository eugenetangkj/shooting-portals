using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the spawn positions for the player in Level 7.
public class LevelSeven : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-60.8f, -41.5f}, //Checkpoint 1  {-60.8f, -41.5f}
            {-34.21569f, -41.42709f}, //Checkpoint 2
            {16.51f, -40.44f}, //Checkpoint 3
            {-6.39f, -54.42f}, //Checkpoint 4
            {17.46f, -54.42f}, //Checkpoint 5
            {43.57f, -54.42f}, //Checkpoint 6
            {55.067f, -66.429f} //Checkpoint 7
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
