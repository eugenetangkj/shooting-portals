using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the spawn positions for the player in Level 2.
public class LevelTwo : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {56.07f, -11.45832f}, //Checkpoint 1 {-29.92f, 0.57f}
            {-7.68f, 0.55f}, //Checkpoint 2
            {15.35f, 0.5729118f}, //Checkpoint 3
            {30.295f, -5.43f}, //Checkpoint 4
            {56.07f, -11.45832f} //Checkpoint 5
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}

