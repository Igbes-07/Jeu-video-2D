using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    public PlayerData dataPlayer;
    public Gradient lifeColorGradient;

    // Update is called once per frame
    void Update()
    {
        float lifeRatio = ((float) dataPlayer.currentLifePoints / (float) dataPlayer.maxLifePoints);
        fillImage.fillAmount = lifeRatio;
        fillImage.color = lifeColorGradient.Evaluate(lifeRatio);
    }
}
