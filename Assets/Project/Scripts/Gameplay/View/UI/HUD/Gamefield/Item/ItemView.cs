using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Item))]
public class ItemView : ButtonListener
{
    [SerializeField] private ItemTypeRepository _typeRepository;
    [SerializeField] private ItemTypeViewRepository _typeViewRepository;
    [SerializeField] private ClickedItemsCounter _clickedItemsCounter;

    private Item _item;
    private Image _image;

    public Item Item => _item;

    protected override void HandleInitialized()
    {
        _item = _item != null ? _item : GetComponent<Item>();
        _image = _image != null ? _image : GetComponent<Image>();
    }

    public void Actualize()
    {
        if (_item == null || _image == null)
        {
            HandleInitialized();
        }

        _item.Reset();

        _image.sprite = _typeViewRepository.GetSpriteByType(_item.Type);
        Button.interactable = true;
    }

    protected override void Listen()
    {
        if (_clickedItemsCounter.Count == _typeRepository.TargetCount - 1)
        {
            _item.TryClick();
            return;
        }

        if (!_item.TryClick()) return;

        Button.interactable = false;
    }
}