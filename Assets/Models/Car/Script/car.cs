using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public float rotationSpeed = 20f;

    [Header("Gestion des roues")]
    public GameObject wheelPrefab;
    public Transform[] wheelSlots;
    private GameObject[] currentWheels;

    [Header("Association Carrousel")]
    public Carousel2DManager carousel;
    public List<Sprite> carouselSprites;
    public List<GameObject> wheelPrefabs;

    private Sprite lastSprite = null;

    void Start()
    {
        currentWheels = new GameObject[wheelSlots.Length];
        SpawnDefaultWheels();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void Update()
    {
        if (carousel == null || carouselSprites == null || wheelPrefabs == null) return;

        Sprite selected = carousel.GetSelectedCarousel();

        if (selected != null && selected != lastSprite)
        {
            for (int i = 0; i < carouselSprites.Count; i++)
            {
                if (carouselSprites[i] == selected)
                {
                    ChangeWheel(wheelPrefabs[i]);
                    lastSprite = selected;
                    break;
                }
            }
        }
    }

    public void SpawnDefaultWheels()
    {
        for (int i = 0; i < wheelSlots.Length; i++)
        {
            if (currentWheels[i] != null)
                Destroy(currentWheels[i]);

            currentWheels[i] = Instantiate(wheelPrefab, wheelSlots[i]);
        }
    }

    public void ChangeWheel(GameObject newWheelPrefab)
    {
        Bounds defaultBounds = GetBounds(wheelPrefab);

        for (int i = 0; i < wheelSlots.Length; i++)
        {
            if (currentWheels[i] != null)
                Destroy(currentWheels[i]);

            GameObject newWheel = Instantiate(newWheelPrefab, wheelSlots[i]);

            Bounds newBounds = GetBounds(newWheel);
            if (newBounds.size != Vector3.zero)
            {
                float scaleFactor = defaultBounds.size.magnitude / newBounds.size.magnitude;
                newWheel.transform.localScale *= scaleFactor;
            }

            currentWheels[i] = newWheel;
        }
    }

    private Bounds GetBounds(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0) return new Bounds();

        Bounds bounds = renderers[0].bounds;
        for (int i = 1; i < renderers.Length; i++)
        {
            bounds.Encapsulate(renderers[i].bounds);
        }

        return bounds;
    }
}