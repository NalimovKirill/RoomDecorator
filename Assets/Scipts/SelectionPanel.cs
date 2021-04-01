using UnityEngine;

public class SelectionPanel : MonoBehaviour
{
    [SerializeField] private ItemData[] _itemDates;
    [SerializeField] private ObjectPlacer _objectPlacer;
    [SerializeField] private GameObject _itemTemplate;
    [SerializeField] private Transform _container;

    private void Start()
    {
        for (int i = 0; i < _itemDates.Length; i++)
        {
            AddItem(_itemDates[i]);
        }
    }

    private void AddItem(ItemData itemData)
    {
        Instantiate(_itemTemplate, _container).TryGetComponent(out ItemView itemView);
        itemView.Initialize(itemData);

        itemView.ItemSelected += OnItemSelected;
        itemView.ItemDisabled += OnItemDisabled;

    }

    private void OnItemSelected(ItemData itemData)
    {
        _objectPlacer.SetInstalledObject(itemData);
    }
    private void OnItemDisabled(ItemView itemView)
    {
        itemView.ItemSelected -= OnItemSelected;
        itemView.ItemDisabled -= OnItemDisabled ;

    }
}
