using UnityEngine;
using UnityEngine.UI;

public class ShowImageOnClick : MonoBehaviour
{
    public Button button;  // Reference to the Button component
    public Image image;    // Reference to the Image component

    void Start()
    {
        // Make sure the image is not visible initially
        image.gameObject.SetActive(false);

        // Add a listener to the button to call the ShowImage function when clicked
        button.onClick.AddListener(ShowImage);
    }

    // Function to show the image
    void ShowImage()
    {
        image.gameObject.SetActive(true);
    }
}
