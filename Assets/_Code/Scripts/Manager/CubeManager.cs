using System.Diagnostics.Tracing;
using UnityEngine;


public class CubeManager : MonoBehaviour
{
    public static CubeManager Instance;

    public Cube[] cubes;
    public Material[] colorMaterials;

    public delegate void ColorChanged(Color color);
    public event ColorChanged OnColorChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            ChangeCubeColor("Green");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            ChangeCubeColor("Orange");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            ChangeCubeColor("Yellow");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            ChangeCubeColor("Purple");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            ChangeCubeColor("Blue");
        }
    }

    private void Start()
    {
        SetCubes();

        ChangeCubeColor("Green");
    }
    public void SetCubes()
    {
        cubes = FindObjectsOfType<Cube>();
    }
    public void ChangeCubeColor(string color)
    {
        int matIndex = 0;
        switch (color)
        {
            case "Green":
                matIndex = 0;
                break;
            case "Orange":
                matIndex = 1;
                break;
            case "Yellow":
                matIndex = 2;
                break;
            case "Purple":
                matIndex = 3;
                break;
            case "Blue":
                matIndex = 4;
                break;
            default:
                matIndex = 0;
                break;
        }

        foreach (Cube c in cubes)
        {
            c.GetComponent<Renderer>().material = colorMaterials[matIndex];
        }


        OnColorChanged?.Invoke(colorMaterials[matIndex].color);
    }
}
