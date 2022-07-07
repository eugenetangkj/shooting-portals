using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTen : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-35.64f, -200.428f}, //Checkpoint 1  {-35.64f, -200.428f}
            {-6.412f, -200.428f}, //Checkpoint 2
            {21.71f, -200.428f}, //Checkpoint 3
            {48.09f, -200.428f}, //Checkpoint 4
            {73.85f, -200.428f}, //Checkpoint 5
            {100.54f, -200.428f}, //Checkpoint 6
            {126.6f, -200.428f}, //Checkpoint 7
            {151.55f, -200.428f} //Checkpoint 8
            
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
