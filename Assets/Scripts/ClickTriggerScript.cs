using UnityEngine;

public class ClickTriggerScript : MonoBehaviour
{
    public LightSwitchScript lightSwitch;

    private void OnMouseDown()
    {
        lightSwitch.ToggleLight();
    }
}
