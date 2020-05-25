using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ctrl K + crtl f indent
public class UIFade : MonoBehaviour {

    public static UIFade instance;

    public Image fadeScreen;
    public float fadeSpeed;

    public bool shouldFadeToBlack;
    public bool shouldFadeFromBlack;

	// Use this for initialization
	void Start () {
        instance = this;

        DontDestroyOnLoad(gameObject);//senao o Canvas não vai junto com a nova cena
	}
	
	// Update is called once per frame
	void Update () {
        
        if (shouldFadeToBlack)
        {
            //mudo o valor Alfa da cor (aquele que eu troquei na imagem quando coloquei para preto)
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));//esse MoveTowards pega um valor e passa para outro de forma gradual, dando o efeito de fade ao invés da tela piscar preta
                                                                                                                                                                            //* Time.deltaTime porque senão a transição dura 10 frames independente do FPS que roda (30 FPS levaria 1/3 de min, 90FPS 1/9 de min) o fadeSpeed começa em 0.1 e vai até 1, apesar do range da cor ser de 0 a 255
        if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }

    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;

    }
    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
