using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the spawn positions for the player in Level 3.
public class LevelThree : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-9.93f, 0.572883f}, //Checkpoint 1  {-9.93f, 0.572883f}
            {16.13479f, 0.5729172f}, //Checkpoint 2
            {41.19f, 7.56f}, //Checkpoint 3
            {47.071f, -4.428f}, //Checkpoint 4
            {68.123f, -7.412f} //Checkpoint 5
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
