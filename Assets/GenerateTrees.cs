using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{

    public GameObject treePrefab;
    public GameObject trees;
    public int treeNum;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTree(treeNum);
    }

    // Update is called once per frame
    void GenerateTree(int num)
    {
        for(int i = 0; i < num; i++)
        {
            GameObject tree1 = Instantiate(treePrefab, new Vector3(treePrefab.transform.position.x, treePrefab.transform.position.y, treePrefab.transform.position.z + i * 4f), treePrefab.transform.rotation);
            GameObject tree2 = Instantiate(treePrefab, new Vector3(-treePrefab.transform.position.x, treePrefab.transform.position.y, treePrefab.transform.position.z + i * 4f), treePrefab.transform.rotation);
            GameObject tree3 = Instantiate(treePrefab, new Vector3(treePrefab.transform.position.x - 1.5f, treePrefab.transform.position.y, treePrefab.transform.position.z + i * 4f + 2f), treePrefab.transform.rotation);
            GameObject tree4 = Instantiate(treePrefab, new Vector3(-treePrefab.transform.position.x + 1.5f, treePrefab.transform.position.y, treePrefab.transform.position.z + i * 4f +2f), treePrefab.transform.rotation);
            GameObject tree5 = Instantiate(treePrefab, new Vector3(treePrefab.transform.position.x - 3f, treePrefab.transform.position.y, treePrefab.transform.position.z + i * 4f), treePrefab.transform.rotation);
            GameObject tree6 = Instantiate(treePrefab, new Vector3(-treePrefab.transform.position.x + 3f, treePrefab.transform.position.y, treePrefab.transform.position.z + i * 4f), treePrefab.transform.rotation);
            tree1.transform.parent = trees.transform;
            tree2.transform.parent = trees.transform;
            tree3.transform.parent = trees.transform;
            tree4.transform.parent = trees.transform;
            tree5.transform.parent = trees.transform;
            tree6.transform.parent = trees.transform;
            tree1.name = "Tree1." + (i + 1);
            tree2.name = "Tree2." + (i + 1);
            tree3.name = "Tree3." + (i + 1);
            tree4.name = "Tree4." + (i + 1);
            tree5.name = "Tree5." + (i + 1);
            tree6.name = "Tree6." + (i + 1);
        }
    }
}
