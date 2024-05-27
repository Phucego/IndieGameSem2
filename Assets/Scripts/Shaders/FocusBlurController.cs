using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FocusBlurController : MonoBehaviour
{
    public GameObject blurPanel;
    public InputField[] inputFields; // Array to hold multiple input fields

    private Material blurMaterial;
    private float originalBlurRadius;

    void Start()
    {
        blurMaterial = blurPanel.GetComponent<Image>().material;
        originalBlurRadius = blurMaterial.GetFloat("_Radius");

        // Add EventTrigger components to input fields
        foreach (InputField inputField in inputFields)
        {
            AddEventTrigger(inputField.gameObject, EventTriggerType.Select, OnInputFieldSelect);
            AddEventTrigger(inputField.gameObject, EventTriggerType.Deselect, OnInputFieldDeselect);
        }
    }

    private void AddEventTrigger(GameObject obj, EventTriggerType eventType, System.Action<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = obj.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener((data) => { action((BaseEventData)data); });

        trigger.triggers.Add(entry);
    }

    private void OnInputFieldSelect(BaseEventData eventData)
    {
        blurMaterial.SetFloat("_Radius", 1.0f); // Adjust as necessary
    }

    private void OnInputFieldDeselect(BaseEventData eventData)
    {
        blurMaterial.SetFloat("_Radius", originalBlurRadius);
    }
}
