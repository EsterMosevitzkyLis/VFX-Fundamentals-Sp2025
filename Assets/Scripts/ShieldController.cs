using UnityEngine;

public class ShieldController : MonoBehaviour
{
    // Drag your "Shield_Dome_New" particle system here in the Inspector
    public ParticleSystem shieldDomeParticles;

    // You can change these values in the Inspector
    public float drawTime = 1.5f;
    public float holdTime = 2.0f;
    public float fadeDuration = 0.5f;

    private bool isFading = false;
    private float fadeStartTime;

    void Start()
    {
        // After the draw and hold time, call the "StartFade" function
        Invoke("StartFade", drawTime + holdTime);
    }

    void Update()
    {
        // Only run this code if the fade should be happening
        if (!isFading)
        {
            return;
        }

        // Get an array to hold all the living particles
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[shieldDomeParticles.particleCount];
        int particleCount = shieldDomeParticles.GetParticles(particles);

        // Calculate how far we are into the fade (from 0 to 1)
        float fadeProgress = (Time.time - fadeStartTime) / fadeDuration;

        // Loop through every single particle
        for (int i = 0; i < particleCount; i++)
        {
            // Get the particle's current color
            Color particleColor = particles[i].startColor;

            // Calculate the new transparency based on our fade progress
            // This forces every particle to the same transparency value
            particleColor.a = Mathf.Lerp(1.0f, 0.0f, fadeProgress);

            // Apply the new color with the new transparency
            particles[i].startColor = particleColor;
        }

        // Push the changes back to the particle system
        shieldDomeParticles.SetParticles(particles, particleCount);

        // When the fade is finished, stop the effect
        if (fadeProgress >= 1.0f)
        {
            isFading = false;
            shieldDomeParticles.Stop();
        }
    }

    // This function is called by Invoke after the delay
    void StartFade()
    {
        isFading = true;
        fadeStartTime = Time.time;
    }
}