using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwo : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-7.68f, 0.55f}, //Checkpoint 1 {-29.92f, 0.57f} {-7.68f, 0.55f} 
            {16.52484f, 4.135397f}, //Checkpoint 2
            {42.001f, 0.578f} //Checkpoint 3
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}

