using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
    [SerializeField] private PopUp popUp;
    [SerializeField] private Slider slider;
    
    private void OnEnable()
    {
        popUp.currentTimeChangedEvent.AddListener(OnCurrentTimeChanged);
    }

    private void OnDisable()
    {
        popUp.currentTimeChangedEvent.RemoveListener(OnCurrentTimeChanged);
    }

    private void OnCurrentTimeChanged(float arg0)
    {
        slider.value = arg0;
    }
    
}