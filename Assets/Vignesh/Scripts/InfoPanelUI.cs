using UnityEngine;
using TMPro;

public class InfoPanelUI : MonoBehaviour
{
    public static InfoPanelUI Instance;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI statusText;

    private Transform target;
    private Vector3 offset = new Vector3(0, 1.8f, 0);

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show(AssetData data, Transform followTarget)
    {
        target = followTarget;

        nameText.text = data.assetName;
        typeText.text = data.assetType;
        statusText.text = data.status;

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        target = null;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!target) return;

        Vector3 screenPos =
            Camera.main.WorldToScreenPoint(target.position + offset);

        // Hide if behind camera
        if (screenPos.z < 0)
        {
            gameObject.SetActive(false);
            return;
        }

        transform.position = screenPos;
    }
}
