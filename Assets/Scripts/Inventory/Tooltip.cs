using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public GameObject tooltipPanel;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI itemValueText;
    private RectTransform rectTransform;

    private void Start()
    {
        tooltipPanel.SetActive(false);
        rectTransform = tooltipPanel.GetComponent<RectTransform>();
    }

    public void ShowTooltip(ItemInfo inventoryItem)
    {
        itemNameText.text = inventoryItem.name;
        itemDescriptionText.text = inventoryItem.description;
        itemValueText.text = "Value: " + inventoryItem.value.ToString();

        tooltipPanel.SetActive(true);
        UpdateTooltipPosition();
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }

    private void UpdateTooltipPosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 anchoredPosition = new Vector2(mousePosition.x / Screen.width, mousePosition.y / Screen.height);
        rectTransform.anchorMin = anchoredPosition;
        rectTransform.anchorMax = anchoredPosition;
        rectTransform.pivot = new Vector2(0, 1); // Set pivot to top left
    }
}
