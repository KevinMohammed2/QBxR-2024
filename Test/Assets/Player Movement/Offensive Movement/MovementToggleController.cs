using UnityEngine;
using UnityEngine.UI;

public class MovementToggleController : MonoBehaviour
{
  public Toggle slantToggle;            // Reference to the toggle for slant movement
  public Toggle outToggle;              // Reference to the toggle for out movement

  void Start()
  {
    // Add listeners to the toggles so when they are selected, it triggers a method
    slantToggle.onValueChanged.AddListener(delegate { OnToggleChanged(slantToggle); });
    outToggle.onValueChanged.AddListener(delegate { OnToggleChanged(outToggle); });

    // Ensure the player starts with the correct movement behavior if a toggle is on
    if (slantToggle.isOn) OnToggleChanged(slantToggle);
    if (outToggle.isOn) OnToggleChanged(outToggle);
  }

  // This method is called when any toggle value changes
  public void OnToggleChanged(Toggle changedToggle)
  {
    return;
  }
}
