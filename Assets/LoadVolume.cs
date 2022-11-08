using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class LoadVolume : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        UpdateSlider();
    }

    public void UpdateSlider()
    {
        slider.value = PlayerPrefManager.instance.GetVolume();
    }
}
