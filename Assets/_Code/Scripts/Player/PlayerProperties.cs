using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public TrailRenderer m_Trail;
    public ParticleSystem m_Particles;

    public float darkenFactor = 0.5f;

    private void Start()
    {
        CubeManager.Instance.OnColorChanged += UpdateProperties;
    }


    public void UpdateProperties(Color color)
    {
        Color darkerColor = Darken(color, darkenFactor);

        Debug.Log(" UpdateProperties Callled !");
        m_Trail.startColor = darkerColor;
        m_Trail.endColor = darkerColor;

        ParticleSystem.MainModule mainModule = m_Particles.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(color);

        //m_Particles. = mainModule;
    }

    // Function to darken a color
    private Color Darken(Color color, float factor)
    {
        return new Color(color.r * factor, color.g * factor, color.b * factor, color.a);
    }

}
