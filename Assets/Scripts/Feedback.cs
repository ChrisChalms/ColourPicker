using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour
{
    [SerializeField] private ColourPicker _colourPicker;
    [SerializeField] private Text _colourText;
    [SerializeField] private Image _previewImage;

    private bool _turnedOn;

    #region MonoBehaviour
    
    // Initialize
    private void Start() => _colourPicker.ColourChanged += colourHasChanged;

    #endregion

    // Feedback the changes
    private void colourHasChanged(Color newColour)
    {
        if(!_turnedOn)
        {
            _previewImage.enabled = true;
            _turnedOn = true;
        }

        _colourText.text = $"The colour selected is: \n{newColour}";
        _previewImage.color = newColour;
    }
}
