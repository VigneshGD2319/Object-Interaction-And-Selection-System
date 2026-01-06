using UnityEngine;

public class AssetSelectable : MonoBehaviour
{
    public AssetData data;
    private Renderer rend;
    [SerializeField] private Material select_material;
    [SerializeField] private Material deSelect_material;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.material = deSelect_material;
    }

    public void Select()
    {
        rend.material = select_material;
        InfoPanelUI.Instance.Show(data, transform);
    }

    public void Deselect()
    {
        rend.material = deSelect_material;
    }
}
