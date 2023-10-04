using System.Collections.Generic;
using UnityEngine;
using static Cube;

public class CubeStackManager : MonoBehaviour
{
    [SerializeField] Transform cubesTrans;

    public List<GameObject> cubes;

    public Transform characterTrans;
    public Animator characterAnimController;

    public void AddCube(GameObject cube)
    {
        cubes.Add(cube);
        cube.transform.parent = cubesTrans;
        Vector3 newPos = new Vector3(
            cubesTrans.position.x,
            (cubes.Count * 0.53f + (0.075f * cubes.Count)), // cubesCount * cubelenght * effectHieght
            cubesTrans.position.z
            );
        characterTrans.position = newPos + (Vector3.up * 0.01f);
        characterAnimController.SetTrigger("Jump");

        cube.transform.position = newPos;
        Cube cubeGO = cube.GetComponent<Cube>();
        cubeGO.enabled = true;
        cubeGO.CubeStackManager = this;

        cube.SetActive(true);
    }
    public void RemoveCube(GameObject cube)
    {
        cubes.Remove(cube);
        cube.transform.parent = null;
        cube.GetComponent<Cube>().enabled = false;
    }
}
