using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image goalImage;

    void Start()
    {
        SetEndGoal(120); // 120 Seconds to win
    }

    public void SetEndGoal(int Hight)
    {
        slider.maxValue = Hight;
        slider.value = Hight;

        goalImage.color = gradient.Evaluate(1f);
    }

    // Update current visual vaule of the hight, when this function is run
    public void SetProgress(int Hight)
    {
        slider.value = Hight;

        goalImage.color = gradient.Evaluate(slider.normalizedValue);

        
    }
}
