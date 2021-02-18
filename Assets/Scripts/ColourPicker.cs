using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(RawImage))]
public class ColourPicker : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public event Action<Color> ColourChanged;
    public event Action<Vector2> PositionChanged;

    private RectTransform _recTransform;
    private Texture2D _texture;

    #region MonoBehaviour

    // Initialize
    private void Start()
    {
        _recTransform = transform as RectTransform;
        _texture = GetComponent<RawImage>().texture as Texture2D;
    }

    #endregion

    #region Interface implementations

    // Pass EventData on
    public void OnPointerDown(PointerEventData eventData) => getColourFromEventData(eventData);
    public void OnDrag(PointerEventData eventData) => getColourFromEventData(eventData);

    #endregion

    // Gets the colour
    private void getColourFromEventData(PointerEventData data)
    {
        Vector2 localCursor;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(_recTransform, data.position, data.pressEventCamera, out localCursor))
            return;

        // Account for pivots
        localCursor.Set(localCursor.x + (_recTransform.rect.width * _recTransform.pivot.x),
            localCursor.y + (_recTransform.rect.height * _recTransform.pivot.y));

        Color32 tempColour = _texture.GetPixel((int)localCursor.x, (int)localCursor.y);

        // Fire actions
        ColourChanged?.Invoke(tempColour);
        PositionChanged?.Invoke(data.position);
    }
}
