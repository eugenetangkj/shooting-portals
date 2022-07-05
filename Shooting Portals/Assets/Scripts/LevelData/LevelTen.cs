using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTen : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-35.64f, -200.428f}, //Checkpoint 1  {-35.64f, -200.428f}
            {-6.5f, -200.428f}, //Checkpoint 2
            {20.67f, -200.428f}, //Checkpoint 3
            {50.53f, -200.428f}, //Checkpoint 4
            {73.85f, -200.428f}, //Checkpoint 5
            {98.56f, -200.428f}, //Checkpoint 6
            {124.78f, -200.428f}, //Checkpoint 7
            {150.11f, -200.428f} //Checkpoint 8
            
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
