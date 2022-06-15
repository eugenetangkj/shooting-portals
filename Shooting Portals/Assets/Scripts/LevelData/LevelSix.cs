using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSix : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-36.22847f, -21.46f}, //Checkpoint 1  {-36.22847f, -21.46f}
            {-7.16f, -19.4271f}, //Checkpoint 2
            {17.8f, -16.42711f}, //Checkpoint 3
            {39.06049f, -22.45f}, //Checkpoint 4
            {44.678f, -15.431f}, //Checkpoint 5
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
