using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSlide : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public AudioSource audioSource; // Référence à votre AudioSource

    private Slider slider;
    private const string VolumeKey = "Volume";

    void Start()
    {
        slider = GetComponent<Slider>();

        // Récupérer la valeur du volume depuis PlayerPrefs
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1.0f); // Valeur par défaut : 1.0f
        slider.value = savedVolume * 100f; // Mettre à jour la valeur du Slider
        SetNumberText(savedVolume * 100f); // Mettre à jour le texte

        // Appliquer le volume récupéré à l'AudioSource
        if (audioSource != null)
        {
            audioSource.volume = savedVolume;
        }
    }

    public void SetNumberText(float value)
    {
        numberText.text = value.ToString();

        // Modifier le volume de l'AudioSource en fonction de la valeur du Slider
        if (audioSource != null)
        {
            float volume = value / 100f;
            audioSource.volume = volume;

            // Sauvegarder la valeur du volume dans PlayerPrefs
            PlayerPrefs.SetFloat(VolumeKey, volume);
            PlayerPrefs.Save(); // S'assurer que les changements sont enregistrés
        }
    }
}

