using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public TrailRenderer m_Trail;
    public ParticleSystem m_Particles;

    public float darkenFactor = 0.5f;

    private void Start()
    {
        StopTrail();




        CubeManager.Instance.OnColorChanged += UpdateProperties;
        GameManager.Instance.OnLevelStartedEvent += StartTrail;
        GameManager.Instance.OnLevelEndedEvent += StopTrail;
    }


    public void UpdateProperties(Color color)
    {
        Color darkerColor = Darken(color, darkenFactor);

        m_Trail.startColor = darkerColor;
        m_Trail.endColor = darkerColor;

        ParticleSystem.MainModule mainModule = m_Particles.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(color);

    }
    // Function to darken a color
    private Color Darken(Color color, float factor)
    {
        return new Color(color.r * factor, color.g * factor, color.b * factor, color.a);
    }



    private void StartTrail()
    {
        m_Trail.enabled = true;
        m_Particles.Play();
    }
    private void StopTrail()
    {
        m_Trail.enabled = false;
        m_Particles.Stop();
    }


}
