using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-9.542f, 2.519f}, //Checkpoint 1 {-9.542f, 2.519f} {47.72f, -6.435f}, 
            {16.52484f, 4.135397f}, //Checkpoint 2
            {42.001f, 0.578f} //Checkpoint 3
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
