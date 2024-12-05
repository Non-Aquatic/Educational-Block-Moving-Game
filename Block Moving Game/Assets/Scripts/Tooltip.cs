using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltip; 
    public string tooltipText1;
    public string tooltipText2;
    public float fadeInDuration = 0.5f; 
    public float fadeOutDuration = 0.5f; 
    public float delayBeforeFadeIn = .5f; 

    private Image tooltipImage; 
    private TextMeshProUGUI tooltipTextMeshPro; 
    private Color initialColor; 

    private void Start()
    {
        tooltipImage = tooltip.GetComponent<Image>(); 
        tooltipTextMeshPro = tooltip.GetComponentInChildren<TextMeshProUGUI>(); 
        initialColor = tooltipImage.color;

        tooltip.SetActive(false); 
        tooltipImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f); 
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(FadeInTooltip());
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(FadeOutTooltip());
    }

    private IEnumerator FadeInTooltip()
    {
        yield return new WaitForSeconds(delayBeforeFadeIn);

        tooltip.SetActive(true); 
        tooltipTextMeshPro.text = tooltipText1 + "\n" + tooltipText2;

        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            tooltipImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha); 
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tooltipImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1f); 
    }

    private IEnumerator FadeOutTooltip()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration);
            tooltipImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha); 
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tooltipImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f); 
        tooltip.SetActive(false);
    }
}
