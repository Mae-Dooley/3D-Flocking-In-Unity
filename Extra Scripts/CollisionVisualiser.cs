using UnityEngine;

public class Collisionvisualiser : MonoBehaviour
{
    //Prefabs
    public GameObject testCube;
    public GameObject testPoint;

    private GameObject gameCube;
    private Cuboid cuboid;
    private Vector3 cuboidCentre = new Vector3(0, 0, 0);
    private float cuboidWidth = 10f;
    private float cuboidHeight = 5f;
    private float cuboidDepth = 10f;

    private GameObject gameSphere;
    private Vector3 sphereCentre = new Vector3(1, 1, 1);
    private float sphereRadius = 5f;

    private GameObject closestPoint;

    void Start()
    {
        cuboid = new Cuboid(cuboidCentre, cuboidWidth, cuboidHeight, cuboidDepth);
        gameCube = Instantiate(testCube, cuboidCentre, Quaternion.identity);
        gameCube.transform.localScale = new Vector3(cuboidWidth * 2, cuboidHeight * 2, cuboidDepth * 2);
        // gameCube.GetComponent<Renderer>().material.color = new Color(255, 0, 255);

        gameSphere = Instantiate(testPoint, sphereCentre, Quaternion.identity);
        gameSphere.transform.localScale = new Vector3(sphereRadius * 2, sphereRadius * 2, sphereRadius * 2);
        // gameSphere.GetComponent<Renderer>().material.color = new Color(255, 255, 0);

        closestPoint = Instantiate(testPoint, new Vector3(0, 0, 0), Quaternion.identity);
        closestPoint.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    void Update()
    {
        //Update the structures in code to match the editor values
        cuboid.centre = gameCube.transform.position;
        cuboid.width = gameCube.transform.localScale.x / 2;
        cuboid.height = gameCube.transform.localScale.y / 2;
        cuboid.depth = gameCube.transform.localScale.z / 2;

        sphereCentre = gameSphere.transform.position;
        sphereRadius = gameSphere.transform.localScale.x / 2;

        //Collect the data from the intersect sphere method
        float[] data = cuboid.IntersectsSphere(sphereCentre, sphereRadius);

        //Move the game object to the closest point
        closestPoint.transform.position = new Vector3(data[0], data[1], data[2]);

        //Colour the point with a glow to represent a collision detected
        if (data[3] == 0) {
            closestPoint.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
        } else {
            closestPoint.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
    }
}
