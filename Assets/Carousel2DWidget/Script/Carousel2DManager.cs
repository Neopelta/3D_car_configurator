using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carousel2DManager : MonoBehaviour
{
    [Header("Sprites to show")]
    public List<Sprite> sprites;

    private Image leftImage;
    private Image centerImage;
    private Image rightImage;

    private Button leftButton;
    private Button rightButton;

    private int currentIndex = 0;

    void Start()
    {
        // Trouver les éléments dans la hiérarchie par nom
        leftImage = transform.Find("Container/LeftImage")?.GetComponent<Image>();
        centerImage = transform.Find("Container/CenterImage")?.GetComponent<Image>();
        rightImage = transform.Find("Container/RightImage")?.GetComponent<Image>();

        leftButton = transform.Find("LeftButton")?.GetComponent<Button>();
        rightButton = transform.Find("RightButton")?.GetComponent<Button>();

        // Vérification
        if (leftImage == null || centerImage == null || rightImage == null ||
            leftButton == null || rightButton == null)
        {
            Debug.LogError("Carousel2DManager: Un ou plusieurs éléments sont introuvables dans la hiérarchie.");
            return;
        }

        if (sprites.Count < 3)
        {
            Debug.LogError("Carousel2DManager: Provide at least 3 sprites.");
            return;
        }

        // Ajout des listeners
        leftButton.onClick.AddListener(Previous);
        rightButton.onClick.AddListener(Next);

        UpdateCarousel();
    }

    void UpdateCarousel()
    {
        int left = (currentIndex - 1 + sprites.Count) % sprites.Count;
        int right = (currentIndex + 1) % sprites.Count;

        leftImage.sprite = sprites[left];
        centerImage.sprite = sprites[currentIndex];
        rightImage.sprite = sprites[right];
    }

    public void Next()
    {
        currentIndex = (currentIndex + 1) % sprites.Count;
        UpdateCarousel();
    }

    public void Previous()
    {
        currentIndex = (currentIndex - 1 + sprites.Count) % sprites.Count;
        UpdateCarousel();
    }

    public Sprite GetSelectedCarousel()
    {
        if (sprites == null || sprites.Count == 0) return null;
        return sprites[currentIndex];
    }
}
