using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    public static CubeManager Instance;

    public Cube[] cubes;
    public Material[] colorMaterials;
    public Image[] colorBtnImgs;
    public delegate void ColorChanged(Color color);
    public event ColorChanged OnColorChanged;

    private void Awake()
    {
        Time.timeScale = 1.0f;

        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

    }

    private void Start()
    {
        SetCubes();

        ChangeCubeColor("Green");
        SetUICubesColor();
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

    private void SetUICubesColor()
    {
        if (colorBtnImgs.Length != colorMaterials.Length) return;

        for (int i = 0; i < colorBtnImgs.Length; i++)
        {
            colorBtnImgs[i].color = colorMaterials[i].color;
        }
    }
}
