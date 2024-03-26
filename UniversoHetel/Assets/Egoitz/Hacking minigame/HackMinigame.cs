using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HackMinigame : MonoBehaviour
{
    [SerializeField] private String[] ipMix;
    [SerializeField] private String[] solution;

    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Text text3;
    [SerializeField] private Text text4;
    
    [SerializeField] private Button[] butons;
    [SerializeField] private float moveRate;
    [SerializeField] private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        text4.gameObject.SetActive(false);
        MostrarTexto(solution, text1);
        MostrarBoton();
        
        
        InvokeRepeating("MoverValores", 0.0f, moveRate);
        InvokeRepeating("MostrarBoton", 0.0f, moveRate);
        InvokeRepeating("resetButtons", 0.0f, moveRate);

    }

    private void FixedUpdate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            text3.text = time.ToString();
        }
        else
        {
            text3.text = "Time over";
            allButtonsRed();
            endScreen("Failure!");
            Time.timeScale = 0;
        }
    }

    private void MostrarTexto(string[] strings, Text textArea)
    {
        
        String textoAmostrar = null;
        for (int i = 0; i < strings.Length; i++)
        {
            textoAmostrar = textoAmostrar + strings[i];
        }

        textArea.text = textoAmostrar.ToString();
        
    }

    private void MoverValores()
    {
        String primeraIp = ipMix[0];

        for (int i = 0; i < ipMix.Length; i++)
        {
            if (i == ipMix.Length-1)
            {
                ipMix[ipMix.Length-1] = primeraIp;
            }
            else
            {
                ipMix[i] = ipMix[i + 1];  
            }
        }
    }
    
    private void MostrarBoton()
    {

        for (int i = 0; i < butons.Length; i++)
        {
            butons[i].GetComponentInChildren<Text>().text = ipMix[i].ToString();
        }
    }

    public void Seleccion(Button bottonSeleccionado)
    {
        bool isCorrect = false;
        int selectedButtonId = 0;

        for (int i = 0; i < butons.Length; i++)
        {
            if (butons[i] == bottonSeleccionado)
            {
                selectedButtonId = i;
            }
        }
        
        Button button0 = null;
        Button button1 = null;
        Button button2 = null;
        Button button3 = null;
        Button button4 = null;
        Button button5 = null;
        Button button6 = null;
        Button button7 = null;
        Button button8 = null;
        
        
        
        //Checkear el limite superior
        int limiteInferior = 0 - selectedButtonId;
        Debug.Log("inferior"+limiteInferior);
        
        //Checkear el limite inferior
        int limiteSuperior = butons.Length - selectedButtonId;
        Debug.Log("superior"+limiteSuperior);

        
        //Si hay valores inferiores al limite, ponerlos
        if (limiteInferior >= -3)
        {
            button0 = butons[butons.Length - 1];
            
            if (limiteInferior >= -2)
            {
                button1 = butons[butons.Length - 1];
                button0 = butons[butons.Length - 2];
                
                if (limiteInferior >= -1)
                {
                    button2 = butons[butons.Length - 1];
                    button1 = butons[butons.Length - 2];
                    button0 = butons[butons.Length - 3];
                    
                    if (limiteInferior == 0)
                    {
                        button3 = butons[butons.Length - 1];
                        button2 = butons[butons.Length - 2];
                        button1 = butons[butons.Length - 3];
                        button0 = butons[butons.Length - 4];
                        
                    }
                }
            }

        }

        //poner los valores restantes
        if (button3 == null)
        {
            button3 = butons[selectedButtonId-1];
        }
        if (button2 == null)
        {
            button2 = butons[selectedButtonId-2];
        }
        if (button1 == null)
        {
            button1 = butons[selectedButtonId-3];
        }
        if (button0 == null)
        {
            button0 = butons[selectedButtonId-4];
        }
        
        //El valor que se ha clickado
        button4 = butons[selectedButtonId];
        
        
        
        //Si hay valores superiores al limite, ponerlos
        if (limiteSuperior <= 4)
        {
            button8 = butons[0];
            
            if (limiteSuperior <= 3)
            {
                button7 = butons[0];
                button8 = butons[1];
                
                if (limiteSuperior <= 2)
                {
                    button6 = butons[0];
                    button7 = butons[1];
                    button8 = butons[2];
                    
                    if (limiteSuperior == 1)
                    {
                        button5 = butons[0];
                        button6 = butons[1];
                        button7 = butons[2];
                        button8 = butons[3];
                    }
                }
            }

        }

        //poner los valores restantes
        if (button5 == null)
        {
            button5 = butons[selectedButtonId + 1];
        }
        if (button6 == null)
        {
            button6 = butons[selectedButtonId+2];
        }
        if (button7 == null)
        {
            button7 = butons[selectedButtonId+3];
        }
        if (button8 == null)
        {
            button8 = butons[selectedButtonId+4];
        }
        
        
        Button[] selectedButtonSequence =
        {
            button0,
            button1,
            button2,
            button3,
            button4,
            button5,
            button6,
            button7,
            button8
        };
        
        //Mostrar resultados
        string selectedStrings = null;
        for (int i = 0; i < selectedButtonSequence.Length; i++)
        {
            selectedStrings = selectedStrings + selectedButtonSequence[i].GetComponentInChildren<Text>().text;
        }    

        if (selectedStrings.Equals(text1.text))
        {
            isCorrect = true;
            for (int i = 0; i < selectedButtonSequence.Length; i++)
            {
                selectedButtonSequence[i].GetComponent<Image>().color = Color.white;
                endScreen("Succes!");
                Time.timeScale = 0;
            }
        }
        else
        {
            for (int i = 0; i < selectedButtonSequence.Length; i++)
            {
                selectedButtonSequence[i].GetComponent<Image>().color = Color.red;
            }
        }
        
        Debug.Log(selectedStrings + "|" + isCorrect);
    }

    private void resetButtons()
    {
        for (int i = 0; i < butons.Length; i++)
        {
            butons[i].GetComponent<Image>().color = Color.black;  
        }
        
    }
    
    private void allButtonsRed()
    {
        for (int i = 0; i < butons.Length; i++)
        {
            butons[i].GetComponent<Image>().color = Color.red;  
        }
        
    }

    private void endScreen(String message)
    {
        for (int i = 0; i < butons.Length; i++)
        {
            butons[i].gameObject.SetActive(false);
        }

        text4.text = message;
        text4.gameObject.SetActive(true);
    }
    
}
