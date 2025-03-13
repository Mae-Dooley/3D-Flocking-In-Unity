using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    //Prefabs
    [Space(10)]
    [Header("Prefabs")]
    [Space(5)]
    public GameObject floor;
    public GameObject grass;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;    
    public GameObject rock1;
    public GameObject rock2;
    public GameObject mushroom;
    
    //Dimensions
    [Space(10)]
    [Header("Dimensions")]
    [Space(5)]
    public float width;
    public float depth;
    public float floorBuffer;

    //Flora variables
    [Space(10)]
    [Header("Flora Variables")]
    [Space(5)]
    public int numGrass;
    public int numTrees;
    public int numRocks;
    public int numMushrooms;

    void Awake()
    {
        GameObject floorSize = Instantiate(floor, new Vector3(0, 0, 0), Quaternion.identity);
        floorSize.transform.localScale = new Vector3(width + floorBuffer, 1, depth + floorBuffer);

        for (int i = 0; i < numGrass; i++) {
            Vector3 pos = RandomVector(-width/2, width/2, 0.5f, 0.5f, -depth/2, depth/2);
            GameObject tempGrass = Instantiate(grass, pos, Quaternion.identity);

            float variance = Random.Range(0.7f, 1.3f);
            tempGrass.transform.localScale *= variance;

            float rotation = Random.Range(0, 360);
            tempGrass.transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
        }

        for (int i = 0; i < numTrees; i++) {
            Vector3 pos = RandomVector(-width/2, width/2, 0.5f, 0.5f, -depth/2, depth/2);

            float treeType = Random.Range(0f, 1f);
            GameObject tempTree;

            if (treeType < 0.33) {
                tempTree = Instantiate(tree1, pos, Quaternion.identity);
            } else if (treeType < 0.66) {
                tempTree = Instantiate(tree2, pos, Quaternion.identity);
            } else {
                tempTree = Instantiate(tree3, pos, Quaternion.identity);
            }

            float variance = Random.Range(0.7f, 1.3f);
            tempTree.transform.localScale *= variance;
            
            float rotation = Random.Range(0, 360);
            tempTree.transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
        }

        for (int i = 0; i < numRocks; i++) {
            Vector3 pos = RandomVector(-width/2, width/2, 0.5f, 0.5f, -depth/2, depth/2);

            float rockType = Random.Range(0f, 1f);
            GameObject tempRock;

            if (rockType < 0.5) {
                tempRock = Instantiate(rock1, pos, Quaternion.identity);
            } else {
                tempRock = Instantiate(rock2, pos, Quaternion.identity);
            } 

            float variance = Random.Range(0.7f, 1.3f);
            tempRock.transform.localScale *= variance;
            
            float rotation = Random.Range(0, 360);
            tempRock.transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
        }

        for (int i = 0; i < numMushrooms; i++) {
            Vector3 pos = RandomVector(-width/2, width/2, 0.5f, 0.5f, -depth/2, depth/2);
            GameObject tempMush = Instantiate(mushroom, pos, Quaternion.identity);

            float variance = Random.Range(0.7f, 1.3f);
            tempMush.transform.localScale *= variance;

            float rotation = Random.Range(0, 360);
            tempMush.transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
        }
    }
    
    //Generate a random vector within the six given bounds
    private Vector3 RandomVector(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
    {
        float xCoord = Random.Range(minX, maxX);
        float yCoord = Random.Range(minY, maxY);
        float zCoord = Random.Range(minZ, maxZ);

        Vector3 randomVector = new Vector3(xCoord, yCoord, zCoord);

        return randomVector;
    }
}
