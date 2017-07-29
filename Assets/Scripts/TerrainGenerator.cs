using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public int width = 256;
    public int height = 256;

    public int depth = 20;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public GameObject theMiner, theWindmill;

    public float instantianScale = 50f;
    public float minerOffsetX = 5f;
    public float minerOffsetY = 5f;

    void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    void Update()
    {
       

    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float [,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
                if(x < 10 && y < 10)
                {
                    Instantiate(theWindmill, new Vector3(x * instantianScale, depth, y * instantianScale), Quaternion.Euler(0f, 0f, 0f));
                    Instantiate(theMiner, new Vector3(x * instantianScale + minerOffsetX, depth, y * instantianScale + minerOffsetY), Quaternion.Euler(0f, 0f, 0f));
                }
                
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);

        //return Mathf.Sin(4 * Mathf.PI * x) * Mathf.Sin(5 * Mathf.PI * y);
    }

}
