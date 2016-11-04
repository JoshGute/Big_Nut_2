using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BatteryLogic : MonoBehaviour
{

    public float YellowLife;
    public float RedLife;

    public GameObject BatteryPack;
    public BodyScript Parent;

    public Slider HealthBar;
    public Color FullHealth;
    public Color MediumHealth;
    public Color LowHealth;

    Light LightColor;
    Renderer BatteryRender;

    // Use this for initialization
    void Start ()
    {
        Parent = GetComponentInParent<BodyScript>();
        //LightColor = GetComponent<Light>();

        //LightColor.color = FullHealth;

       BatteryRender = GetComponent<Renderer>();
       BatteryRender.material.SetColor("_Color", FullHealth);

        //HealthBar.maxValue = fLifetime;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Parent.fLifetime <= YellowLife)
        {
            //Debug.Log("yellow");
            //LightColor.color = MediumHealth;
            BatteryRender.material.SetColor("_Color", MediumHealth);
            // HealthBar.normalizedValue = fLifetime;
            //batteryRender.sharedMaterial.SetColor("_Color", Color.yellow);
        }

        if (Parent.fLifetime <= RedLife)
        {
            //LightColor.color = LowHealth;
            //Debug.Log("red");
            BatteryRender.material.SetColor("_Color", LowHealth);

            //batteryRender.sharedMaterial.SetColor("_Color", Color.red);
            //BatteryPack.GetComponent<Light>().color = Color.red;
        }

    }
}
