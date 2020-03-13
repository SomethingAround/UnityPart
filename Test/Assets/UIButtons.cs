using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButtons : MonoBehaviour
{
    Animator m_player;
    ParticleSystem m_particle;
    TMP_Dropdown m_dropdown;
    Slider m_runSlider;
    // Start is called before the first frame update
    void Start()
    {
        //Find components that are needed
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        m_particle = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
        m_runSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        m_dropdown = GameObject.FindGameObjectWithTag("Dropdown").GetComponent<TMP_Dropdown>();
    }

    //Plays the particles system
    public void PlayParticle()
    {
        m_particle.Play();
    }
    
    //Swaps the animations that the player will do
    public void SwapAnim()
    {
        switch(m_dropdown.value)
        {
            //Check if the dropdown changed to Run
            case 0:
                {
                    m_runSlider.enabled = true;
                    m_player.SetBool("Jump", false);
                    m_player.SetBool("Death", false);
                    break;
                }
            //Check if the dropdown changed to Jump
            case 1:
                {
                    m_runSlider.enabled = false;
                    m_player.SetBool("Jump", true);
                    m_player.SetBool("Death", false);
                    break;
                }
            //Check if the dropdown changed to Death
            case 2:
                {
                    m_runSlider.enabled = false;
                    m_player.SetBool("Death", true);
                    m_player.SetBool("Jump", false);
                    break;
                }
        }
    }

    //Changes the amount that the player is running
    public void RunSlider()
    {
        //Checks if the dropdown is on Run
        if (m_dropdown.value == 0)
        {
            m_player.SetFloat("X_Velocity", m_runSlider.value);
        }
    }

    //Causes the application to quit
    public void QuitGame()
    {
        Application.Quit();
    }
}
