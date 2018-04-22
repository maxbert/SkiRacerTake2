using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject fallingObstaclePrefab;
    public GameObject linePrefab;
    public GameObject outPrefab;
	public GameObject treePrefab;
    public Vector2 spawnDelayMinMax;
    public PlayerControl player;
    float nextSpawnTime;
    float treeTime;
    float lastSlalomX;
	Vector2 screenHalfSize;
    float spawnSize;

    void Start () {
		screenHalfSize = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        lastSlalomX = 1;
        spawnSize = 0.7f;
    }

    void Update() {
        if (Time.time > treeTime) {
            float secondsBetweenSpawns = Mathf.Lerp(spawnDelayMinMax.y, spawnDelayMinMax.x, Difficulty.GetDifficultyPercent(player.counter));
            treeTime = Time.time + secondsBetweenSpawns / 3;
            Random rnd = new Random();
            
            int rand1 = Random.Range(1, 5);
            int randX = Random.Range((int)(-2 * (screenHalfSize.x)), (int)(2 * (screenHalfSize.x)));


            if (rand1 > 2)
            {
                Vector2 treeSpawn1 = new Vector2(randX, -1 * screenHalfSize.y - 5);
                GameObject randomTree1 = (GameObject)Instantiate(treePrefab, treeSpawn1, Quaternion.identity);
                randomTree1.transform.localScale = Vector2.one * spawnSize;

            }
        }
        if (Time.time > nextSpawnTime)
        {
            PlayerControl player = FindObjectOfType<PlayerControl>();
            float secondsBetweenSpawns = Mathf.Lerp(spawnDelayMinMax.y, spawnDelayMinMax.x, Difficulty.GetDifficultyPercent(player.counter));
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            //			float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
            
            float slalomx = 5;
            if (lastSlalomX < 0)
            {
                slalomx = Random.Range(0, screenHalfSize.x / 4);
            }
            else
            {
                slalomx = Random.Range(-screenHalfSize.x / 4 - 5, 0);
            }
            /*while (Mathf.Abs(slalomx - lastSlalomX) > 5)
            {
                print("repositioning\n");
                slalomx = Random.Range(-screenHalfSize.x / 4 - 5, screenHalfSize.x / 4);
            }*/

			//generate random number for trees

			
            lastSlalomX = slalomx;
            float slalomy = -screenHalfSize.y - 15;
            Vector2 spawnPosition = new Vector2(slalomx, slalomy);
            Vector2 spawnPosition2 = new Vector2(slalomx + 5, slalomy);
            Vector2 spawnPositionLine = new Vector2(slalomx + (5 / 2) + 0.7f, slalomy);
            Vector2 spawnPositionLineLeft = new Vector2(-(screenHalfSize.x - slalomx) / 2.0F, slalomy - spawnSize);
            Vector2 spawnPositionLineRight = new Vector2((slalomx + 5) + ((screenHalfSize.x - (slalomx + 5)) / 2), slalomy - spawnSize);

          

            GameObject slalomPostLeft = (GameObject)Instantiate(fallingObstaclePrefab, spawnPosition, Quaternion.identity);
            GameObject slalomPostRight = (GameObject)Instantiate(fallingObstaclePrefab, spawnPosition2, Quaternion.identity);
            
			GameObject pointLine = (GameObject)Instantiate(linePrefab, spawnPositionLine, Quaternion.identity);
			GameObject pointLineLeft = (GameObject)Instantiate(outPrefab, spawnPositionLineLeft, Quaternion.identity);
            pointLineLeft.transform.localScale = new Vector3(screenHalfSize.x + slalomx, 0.1F, 0);
            

            GameObject pointLineRight = (GameObject)Instantiate(outPrefab, spawnPositionLineRight, Quaternion.identity);
            pointLineRight.transform.localScale = new Vector3(screenHalfSize.x - (slalomx + 5), 0.1F, 0);

            slalomPostLeft.transform.localScale = Vector2.one * spawnSize;
            slalomPostRight.transform.localScale = Vector2.one * spawnSize;
        }
	}
		
}
