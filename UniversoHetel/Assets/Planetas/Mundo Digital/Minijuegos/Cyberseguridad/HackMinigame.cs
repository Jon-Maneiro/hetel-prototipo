using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HackMinigame : MonoBehaviour
{
    [SerializeField] private String[] ipMix; //El churro de ips random
    [SerializeField] private String[] solution; //La secuencia correcta

    [SerializeField] private Text text1; //Mostar solucion
    [SerializeField] private Text text3; //Timer
    [SerializeField] private Text text4; //Mensaje final
    
    [SerializeField] private Button[] butons; //Los bottones tablero central
    [SerializeField] private float moveRate; //Cada cuantos segundos se mueven el tablero
    [SerializeField] private float time; //El tiempo del minijuego
    
    // Start is called before the first frame update
    void Start()
    {
        text4.gameObject.SetActive(false); //Ocultar el mensaje final
        MostrarTexto(solution, text1); //Enseñar la solucion
        MostrarTablero();
        
        
        //Que el tablero se mueva
        InvokeRepeating("MoverValores", 0.0f, moveRate);
        InvokeRepeating("MostrarTablero", 0.0f, moveRate);
        InvokeRepeating("resetButtons", 0.0f, moveRate);

    }

    private void FixedUpdate()
    {
        if (time > 0) //Tiempo
        {
            time -= Time.deltaTime;
            text3.text = time.ToString();
        }
        else
        { //Game over
            text3.text = "Time over";
            allButtonsRed();
            endScreen("Failure!");
            Invoke(nameof(Failure),2f);
            Time.timeScale = 0;
        }
    }

    private void MostrarTexto(string[] strings, Text textArea) //Te muestra un array de strings en eel text area
    {
        
        String textoAmostrar = null;
        for (int i = 0; i < strings.Length; i++)
        {
            textoAmostrar = textoAmostrar + strings[i];
        }

        textArea.text = textoAmostrar.ToString();
        
    }

    private void MoverValores() //Mueve las ips del tablero
    {
        String primeraIp = ipMix[0];//Se guarda la primera

        for (int i = 0; i < ipMix.Length; i++) 
        {
            if (i == ipMix.Length-1)
            {
                ipMix[ipMix.Length-1] = primeraIp; //Poner la que habiamos guardado en la ultima posicion
            }
            else
            {
                ipMix[i] = ipMix[i + 1];  //Pone cada una en la siguiente posicion  
            }
        }
    }
    
    private void MostrarTablero()//Mostrar el tablero
    {

        for (int i = 0; i < butons.Length; i++)
        {
            butons[i].GetComponentInChildren<Text>().text = ipMix[i].ToString(); //Que cada boton tenga la ip que le corresponda
        }
    }

    public void Seleccion(Button bottonSeleccionado)//El usuario a seleccionado un boton(bottonSeleccionado) y queremos guardarlo en una sequencia de 9 botones (los 4 previos, el seleccionado y 4 posteriores)
    {
        bool isCorrect = false;
        int selectedButtonId = 0;

        //Recoger el ID del boton que ha sido seleccionado
        for (int i = 0; i < butons.Length; i++)
        {
            if (butons[i] == bottonSeleccionado)
            {
                selectedButtonId = i;
            }
        }
        
        //Resetar los botones de la sequencia
        Button button0 = null;
        Button button1 = null;
        Button button2 = null;
        Button button3 = null;
        Button button4 = null;
        Button button5 = null;
        Button button6 = null;
        Button button7 = null;
        Button button8 = null;
        
        
        //Si se selecciona el ultimo boton del tablero que los 4 botones posteriores sean los 4 primeros y si selecciona el primer boton que los previos sean los ultimos del tablero
        
        
        //Checkear el limite superior
        int limiteInferior = 0 - selectedButtonId;
        Debug.Log("inferior"+limiteInferior);
        
        //Checkear el limite inferior
        int limiteSuperior = butons.Length - selectedButtonId;
        Debug.Log("superior"+limiteSuperior);
        
        
        //Si hay valores inferiores al limite, pasar al limite superior
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
        
        
        
        //Si hay valores superiores al limite, pasar al limite inferior
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
        
        //La sequencia de botones seleccionados
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
        for (int i = 0; i < selectedButtonSequence.Length; i++)//Pasar a strings los botones seleccionados
        {
            selectedStrings = selectedStrings + selectedButtonSequence[i].GetComponentInChildren<Text>().text;
        }    

        if (selectedStrings.Equals(text1.text)) //Comparar con la solucion
        {
            isCorrect = true;//Si es correcto
            for (int i = 0; i < selectedButtonSequence.Length; i++)
            {
                selectedButtonSequence[i].GetComponent<Image>().color = Color.white;
                endScreen("Success!");
                Invoke(nameof(Success),2f);//Salir al Continente
                Time.timeScale = 0;
            }
        }
        else// Si no es correcto
        {
            for (int i = 0; i < selectedButtonSequence.Length; i++)
            {
                selectedButtonSequence[i].GetComponent<Image>().color = Color.red;
            }
        }
        
        Debug.Log(selectedStrings + "|" + isCorrect);
    }

    //Quitarle el color a los botones
    private void resetButtons()
    {
        for (int i = 0; i < butons.Length; i++)
        {
            butons[i].GetComponent<Image>().color = Color.black;  
        }
        
    }
    
    //Poner los botones en rojo
    private void allButtonsRed()
    {
        for (int i = 0; i < butons.Length; i++)
        {
            butons[i].GetComponent<Image>().color = Color.red;  
        }
        
    }

    //Mensaje final
    private void endScreen(String message)
    {
        for (int i = 0; i < butons.Length; i++) //Quitar los botones
        {
            butons[i].gameObject.SetActive(false);
        }

        //Mostrar el mensaje
        text4.text = message;
        text4.gameObject.SetActive(true);
    }

    private void Failure()
    {
        LoadingData.SceneToLoad = LoadingData.CurrentScene;
        SceneManager.LoadScene("LoadingScreen");
    }

    private void Success()
    {
        LoadingData.SceneToLoad = LoadingData.NextContinent;
        SceneManager.LoadScene("LoadingScreen");
    }

}
