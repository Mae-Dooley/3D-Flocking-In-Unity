using UnityEngine;
using System.Collections.Generic;
//this code is just for debugging the Octree
//In particular it generates a colleciton of points and then pushes them to an Octree. A sphere is then used
//to detect points within its radius and cause said points to glow
public class OctreeVisualiser : MonoBehaviour
{
    //Prefabs
    public GameObject testCube;
    public GameObject testPoint;
    public GameObject collisionSphere;

    //Octree variables
    private Octree octree;
    private Cuboid boundary;
    private Point point;
    public int numPoints;
    private GameObject[] pointsToShow;
    private GameObject testSphere;

    //Colours of points
    private Color normColour = new Color(0f, 0f, 0f);
    private Color detectedColour = new Color(0f, 1f, 0f);

    //Octree game area
    public float xBound;
    public float yBound;
    public float zBound;

    void Start() {
        //Make the Octree
        boundary = new Cuboid(new Vector3(0, 0, 0), xBound, yBound, zBound);
        octree = new Octree(boundary);

        testSphere = Instantiate(collisionSphere, new Vector3(50, 50, 50), Quaternion.identity);
        testSphere.transform.localScale = new Vector3(20, 20, 20);

        pointsToShow = new GameObject[numPoints];

        for (int i = 0; i < numPoints; i++) {
            float x = Random.Range(-xBound, xBound);
            float y = Random.Range(-yBound, yBound);
            float z = Random.Range(-zBound, zBound);
            
            point = new Point(x, y, z, i);
            pointsToShow[i] = Instantiate(testPoint, new Vector3(x, y, z), Quaternion.identity);

            octree.AddPoint(point);
        }

        ShowOctree(octree);
    }

    void Update()
    {
        //Set the colour of the points to black by default
        for (int i = 0; i < pointsToShow.Length; i++) {
            pointsToShow[i].GetComponent<Renderer>().material.SetColor("_BaseColor", normColour);
        }

        //Query the tree for points in the test sphere
        List<int> detected = octree.QuerySphere(testSphere.transform.position, 
                                                        testSphere.transform.localScale.x / 2);
        
        //Change the colour of the detected points
        for (int i = 0; i < detected.Count; i++) {
            pointsToShow[detected[i]].GetComponent<Renderer>().material.SetColor("_BaseColor", detectedColour);
        }

    }

    //Create a cube over each boundary in the tree
    private void ShowOctree(Octree oct) {
        for (int i = 0; i < oct.children.Length; i++) {
            if (oct.children[i].divided) {
                ShowOctree(oct.children[i]);
            }
        }

        GameObject visualCube = Instantiate(testCube, oct.boundary.centre, Quaternion.identity);
        Vector3 size = new Vector3(oct.boundary.width*2, oct.boundary.height*2, oct.boundary.depth*2);
        visualCube.transform.localScale = size;

    }

}
