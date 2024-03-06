using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light targetlight;

    [SerializeField] private float minIntensity = 1f;
    [SerializeField] private float maxIntensity = 2f;
    [SerializeField] private float flickerSpeed = 1f;
    private float randomOffset;

    private void Awake()
    {
        targetlight = GetComponent<Light>();
    }
    private void Start()
    {
        randomOffset = Random.Range(0f, 100f);
    }

    private void Update()
    {
        float noise = Mathf.PerlinNoise(randomOffset, Time.time * flickerSpeed);
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        targetlight.intensity = intensity;
    }
}
