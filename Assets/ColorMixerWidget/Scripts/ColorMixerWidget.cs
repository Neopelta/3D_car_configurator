using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorMixerWidget : MonoBehaviour
{
    //===============================================================
    // CONFIGURABLE PARAMETERS
    //===============================================================

    [Header("Available Colors")]
    [SerializeField]
    private List<Color> mixColors = new List<Color> {
        Color.cyan,
        Color.magenta,
        Color.yellow
    };

    [Header("Targets")]
    [SerializeField] private List<Renderer> targetObj = new List<Renderer>();

    [Header("Settings")]
    [Range(0.1f, 1f)]
    [SerializeField] private float btnSpacing = 0.7f;
    [SerializeField] private int btnsPerRow = 4;

    [Header("Button color Appearance")]
    [SerializeField] private float selScale = 1.1f;
    [SerializeField] private float deselScale = 1.0f;
    [Range(0f, 1f)]
    [SerializeField] private float darkFactor = 0.3f;

    //===============================================================
    // PRIVATE VARIABLES
    //===============================================================

    private Transform btnContainer;
    private RawImage colorDisplay;
    private Slider brightSlider;
    private TextMeshProUGUI brightText;
    private Button applyBtn;
    private string colorProperty = "_Color";

    private List<ColorButtonInfo> colorBtns = new List<ColorButtonInfo>();
    private float brightness = 0.5f;
    private List<int> selectedIndices = new List<int>();
    private Texture2D brightnessGradientTexture;
    private Sprite brightnessGradientSprite;

    // Class for managing colour button information
    private class ColorButtonInfo
    {
        public GameObject btnObj;
        public Button btn;
        public Image btnImg;
        public Color origColor;
        public int colorIdx;
        public bool isSelected;

        public ColorButtonInfo(GameObject obj, Button btn, Image img, Color color, int index)
        {
            btnObj = obj;
            this.btn = btn;
            btnImg = img;
            origColor = color;
            colorIdx = index;
            isSelected = false;
        }
    }

    //===============================================================
    // INITIALIZATION
    //===============================================================

    private void Awake()
    {
        btnContainer = GetComponentInChildren<GridLayoutGroup>(true).transform;
        colorDisplay = GetComponentInChildren<RawImage>(true);
        brightSlider = GetComponentInChildren<Slider>(true);

        TextMeshProUGUI[] textComponents = GetComponentsInChildren<TextMeshProUGUI>(true);
        foreach (var text in textComponents)
        {
            if (text.gameObject.name.Contains("Value"))
            {
                brightText = text;
                break;
            }
        }

        Button[] buttons = GetComponentsInChildren<Button>(true);
        foreach (var button in buttons)
        {
            if (button.gameObject.name.Contains("Apply"))
            {
                applyBtn = button;
                break;
            }
        }
        if (applyBtn == null && buttons.Length > 0)
        {
            applyBtn = buttons[0];
        }
    }

    private void Start()
    {
        brightSlider.value = brightness;
        CreateColorBtns();
        SetupBrightnessSlider();
        SetupListeners();
        StartCoroutine(SelectDefaultAfterDelay());
    }

    private IEnumerator SelectDefaultAfterDelay()
    {
        yield return null;
        if (selectedIndices.Count == 0 && colorBtns.Count > 0)
        {
            OnBtnClicked(0);
        }
    }

    private void SetupListeners()
    {
        brightSlider.onValueChanged.AddListener(OnBrightChanged);
        applyBtn.onClick.AddListener(OnApplyClicked);
    }

    //===============================================================
    // INTERFACE CREATION
    //===============================================================

    private void CreateColorBtns()
    {
        foreach (Transform child in btnContainer)
        {
            Destroy(child.gameObject);
        }
        colorBtns.Clear();

        GridLayoutGroup gridLayout = btnContainer.GetComponent<GridLayoutGroup>();
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = btnsPerRow;

        RectTransform containerRect = btnContainer.GetComponent<RectTransform>();
        float availableWidth = containerRect.rect.width > 0 ? containerRect.rect.width : 200;
        float cellWidth = (availableWidth / btnsPerRow) * btnSpacing;
        cellWidth = Mathf.Max(cellWidth, 30f);

        gridLayout.cellSize = new Vector2(cellWidth, cellWidth);
        gridLayout.spacing = new Vector2(5, 5);

        StartCoroutine(CreateBtnsAfterLayout());
    }

    private IEnumerator CreateBtnsAfterLayout()
    {
        yield return null;

        for (int i = 0; i < mixColors.Count; i++)
        {
            GameObject buttonObj = new GameObject("ColorBtn_" + i, typeof(RectTransform));
            buttonObj.transform.SetParent(btnContainer, false);

            RectTransform rectTransform = buttonObj.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.localScale = Vector3.one;

            Image buttonImage = buttonObj.AddComponent<Image>();
            buttonImage.color = mixColors[i];

            Button button = buttonObj.AddComponent<Button>();
            ColorBlock colors = button.colors;
            colors.normalColor = Color.white;
            colors.highlightedColor = new Color(0.9f, 0.9f, 0.9f, 1f);
            colors.pressedColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            colors.selectedColor = Color.white;
            button.colors = colors;
            button.transition = Selectable.Transition.ColorTint;
            button.targetGraphic = buttonImage;

            ColorButtonInfo buttonInfo = new ColorButtonInfo(buttonObj, button, buttonImage, mixColors[i], i);
            colorBtns.Add(buttonInfo);

            SetBtnDeselected(buttonInfo);

            int index = i;
            button.onClick.AddListener(() => OnBtnClicked(index));
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(btnContainer as RectTransform);
        UpdateColorDisplay();
    }

    private void SetupBrightnessSlider()
    {
        Image backgroundImage = brightSlider.transform.Find("Background")?.GetComponent<Image>();

        if (backgroundImage == null)
        {
            Image[] images = brightSlider.GetComponentsInChildren<Image>();
            foreach (Image img in images)
            {
                if (!img.transform.name.Contains("Handle") && !img.transform.name.Contains("Fill"))
                {
                    backgroundImage = img;
                    break;
                }
            }
        }

        if (backgroundImage != null)
        {
            CreateGradientForColor(backgroundImage, Color.gray);
        }
    }

    private void CreateGradientForColor(Image targetImage, Color midColor)
    {
        // Create a texture for the black -> white gradient
        Texture2D gradientTexture = new Texture2D(256, 1);
        gradientTexture.wrapMode = TextureWrapMode.Clamp;

        for (int i = 0; i < 256; i++)
        {
            float t = i / 255f;
            Color color = Color.Lerp(Color.black, Color.white, t);
            gradientTexture.SetPixel(i, 0, color);
        }

        gradientTexture.Apply();

        if (brightnessGradientSprite != null)
        {
            Object.Destroy(brightnessGradientSprite);
        }
        if (brightnessGradientTexture != null)
        {
            Object.Destroy(brightnessGradientTexture);
        }

        brightnessGradientTexture = gradientTexture;
        brightnessGradientSprite = Sprite.Create(
            gradientTexture,
            new Rect(0, 0, gradientTexture.width, gradientTexture.height),
            new Vector2(0.5f, 0.5f)
        );

        targetImage.sprite = brightnessGradientSprite;
        targetImage.type = Image.Type.Sliced;
    }

    //===============================================================
    // BUTTON STATUS MANAGEMENT
    //===============================================================

    private void SetBtnSelected(ColorButtonInfo btnInfo)
    {
        btnInfo.btnImg.color = btnInfo.origColor;
        btnInfo.btnObj.transform.localScale = new Vector3(selScale, selScale, selScale);

        Outline outline = btnInfo.btnObj.GetComponent<Outline>();
        if (outline == null)
        {
            outline = btnInfo.btnObj.AddComponent<Outline>();
        }
        outline.effectColor = Color.white;
        outline.effectDistance = new Vector2(2, 2);
    }

    private void SetBtnDeselected(ColorButtonInfo btnInfo)
    {
        Color darkenedColor = btnInfo.origColor * darkFactor;
        darkenedColor.a = 1.0f;
        btnInfo.btnImg.color = darkenedColor;

        btnInfo.btnObj.transform.localScale = new Vector3(deselScale, deselScale, deselScale);

        Outline outline = btnInfo.btnObj.GetComponent<Outline>();
        if (outline != null)
        {
            Destroy(outline);
        }
    }

    //===============================================================
    // EVENT MANAGEMENT
    //===============================================================

    private void OnBrightChanged(float value)
    {
        brightness = value;
        brightText.text = (brightness * 100).ToString("0") + "%";
        UpdateColorDisplay();
    }

    private void OnApplyClicked()
    {
        if (targetObj.Count > 0)
        {
            Color mixedColor = CalcMixedColor();

            foreach (Renderer renderer in targetObj)
            {
                if (renderer != null)
                {
                    Material materialToUse;

                    if (renderer.sharedMaterial == null)
                    {
                        materialToUse = new Material(Shader.Find("Standard"));
                    }
                    else
                    {
                        materialToUse = new Material(renderer.sharedMaterial);
                    }

                    materialToUse.SetColor(colorProperty, mixedColor);
                    materialToUse.color = mixedColor;

                    renderer.material = materialToUse;
                }
            }
        }
    }

    private void OnBtnClicked(int btnIndex)
    {
        ColorButtonInfo buttonInfo = colorBtns.Find(b => b.colorIdx == btnIndex);
        if (buttonInfo == null)
            return;

        buttonInfo.isSelected = !buttonInfo.isSelected;

        if (buttonInfo.isSelected)
        {
            SetBtnSelected(buttonInfo);

            if (!selectedIndices.Contains(btnIndex))
            {
                selectedIndices.Add(btnIndex);
            }
        }
        else
        {
            SetBtnDeselected(buttonInfo);
            selectedIndices.Remove(btnIndex);
        }

        UpdateColorDisplay();
    }

    //===============================================================
    // CALCULATING AND MIXING COLOURS
    //===============================================================

    private Color CalcMixedColor()
    {
        if (selectedIndices.Count == 0)
        {
            return Color.black;
        }

        Color mixedColor = Color.black;
        int count = selectedIndices.Count;

        // Add the contribution of each selected colour
        foreach (int index in selectedIndices)
        {
            if (index >= 0 && index < mixColors.Count)
            {
                mixedColor.r += mixColors[index].r / Mathf.Sqrt(count);
                mixedColor.g += mixColors[index].g / Mathf.Sqrt(count);
                mixedColor.b += mixColors[index].b / Mathf.Sqrt(count);
            }
        }

        // Saturate values at 1.0
        mixedColor.r = Mathf.Min(mixedColor.r, 1.0f);
        mixedColor.g = Mathf.Min(mixedColor.g, 1.0f);
        mixedColor.b = Mathf.Min(mixedColor.b, 1.0f);

        // Apply the luminosity effect
        if (brightness != 0.5f)
        {
            if (brightness < 0.5f)
            {
                float factor = brightness * 2.0f;
                mixedColor = Color.Lerp(Color.black, mixedColor, factor);
            }
            else
            {
                float factor = (brightness - 0.5f) * 2.0f;
                mixedColor = Color.Lerp(mixedColor, Color.white, factor);
            }
        }

        mixedColor.a = 1.0f;

        return mixedColor;
    }

    private void UpdateColorDisplay()
    {
        colorDisplay.color = CalcMixedColor();
    }

    //===============================================================
    // API PUBLIQUE
    //===============================================================

    public void SetTargetRenderer(Renderer renderer)
    {
        if (renderer != null && !targetObj.Contains(renderer))
        {
            targetObj.Add(renderer);
        }
    }

    public void AddColor(Color newColor)
    {
        mixColors.Add(newColor);
        CreateColorBtns();
    }

    public void RemoveColorAt(int index)
    {
        if (index >= 0 && index < mixColors.Count)
        {
            mixColors.RemoveAt(index);
            selectedIndices.Remove(index);
            CreateColorBtns();
            UpdateColorDisplay();
        }
    }

    public void SetButtonsPerRow(int count)
    {
        btnsPerRow = Mathf.Max(1, count);
        CreateColorBtns();
    }
}