using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;
    private AssetSelectable current;

    void Awake() => Instance = this;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                AssetSelectable asset = hit.collider.GetComponent<AssetSelectable>();
                if (asset != null)
                    SelectAsset(asset);
            }
        }
    }
    void SelectAsset(AssetSelectable asset)
    {
        if (current != null)
        {
            current.Deselect();
            InfoPanelUI.Instance.Hide();
        }

        current = asset;
        current.Select();
    }

}
