using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the spawn positions for the player in Level 1.
public class LevelOne : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-34.80144f, 2.541639f}, //Checkpoint 1 {-34.80144f, 2.541639f}
            {-9.542f, 2.519f}, //Checkpoint 2 
            {16.52484f, 4.135397f}, //Checkpoint 3
            {42.001f, 0.578f} //Checkpoint 4
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
