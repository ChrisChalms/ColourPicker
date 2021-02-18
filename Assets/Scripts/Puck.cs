using UnityEngine;
using UnityEngine.UI;

public class Puck : MonoBehaviour
{
    [SerializeField] private ColourPicker _colourPicker;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _image;

    private bool _turnedOn;

    #region MonoBehaviour

    // Initialize
    private void Start() => _colourPicker.PositionChanged += movePuck;

    #endregion

    // Turn the puck on if we haven't already and move to the supplied position
    private void movePuck(Vector2 pos)
    {
        if (!_turnedOn)
        {
            _image.enabled = true;
            _turnedOn = true;
        }

        _rectTransform.position = pos;
    }
}
