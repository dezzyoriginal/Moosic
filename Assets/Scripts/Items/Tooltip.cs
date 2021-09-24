using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public static Tooltip instance;

    [SerializeField] private float textPaddingSize = 4f;
    private TextMeshProUGUI toolTipText;
    private RectTransform backgroundRectTransform;

    [SerializeField] private Item itemOfChoice;
    [SerializeField] private Camera uiCamera;

    private void Awake()
    {
        instance = this;

        //uiCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        backgroundRectTransform = GetComponent<RectTransform>();
        toolTipText = GetComponentInChildren<TextMeshProUGUI>();
        HideToolTip();
        //ShowToolTip(itemOfChoice);
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = localPoint;
        if (RentController.instance != null) if (RentController.instance.isActive) HideToolTip();
    }

    public void ShowToolTip(Item item)
    {
        gameObject.SetActive(true);

        //toolTipText.text = "Name: " + item.name + "\n\nType: " + item.type + "\n\nLevel: " + item.level + "\n\nPrice: " + item.price;
        toolTipText.text = "Name: " + item.name +  "\n\nPrice: " + item.price;
        //Vector2 backgroundSize = new Vector2(toolTipText.preferredWidth + textPaddingSize * 32, toolTipText.preferredHeight - textPaddingSize * 80  );
        Vector2 backgroundSize = new Vector2(toolTipText.preferredWidth + textPaddingSize * 32, toolTipText.preferredHeight + textPaddingSize * 32);

        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);

    }

    /*
    public static void ShowToolTip_Static(Item item)
    {
        instance.ShowToolTip(item);
    }

    public static void HideToolTip_Static()
    {
        instance.HideToolTip();
    }
    */
}
