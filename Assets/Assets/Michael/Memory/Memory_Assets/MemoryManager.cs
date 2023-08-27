using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MemoryManager : MonoBehaviour
{
    public SpriteRenderer[] spritesToFade;
    public SpriteRenderer person1;
    public SpriteRenderer speech1;
    public SpriteRenderer drink1;
    public SpriteRenderer box;
    public SpriteRenderer questionMark;
    public SpriteRenderer[] drinks;
    public List<SpriteRenderer> randomPersons;
    public SpriteRenderer drinkClick1;
    public SpriteRenderer drinkClick2;
    public SpriteRenderer drinkClick3;
    private SpriteRenderer chosenPerson;
    private int pointCount;
    private bool gameOver = false;
    public float fadeInDuration = 2f;
    public float waitDuration = 1f;
    public float fadeOutDuration = 2f;
    private int currentSpriteIndex = 0;

    public void Start()
    {
        person1.gameObject.SetActive(true);
        speech1.gameObject.SetActive(true);
        drink1.gameObject.SetActive(true);
        StartCoroutine(FadeInAndOut(spritesToFade[0], spritesToFade[1], spritesToFade[2]));

    }

    private void Update()
    {
        if (pointCount == 3 && gameOver == false)
        {
            SceneManager.UnloadSceneAsync(14);
            GameEvents.current.FinishGame();
            gameOver = true;
        }


    }
    private IEnumerator FadeInAndOut(SpriteRenderer spriteRenderer1, SpriteRenderer spriteRenderer2, SpriteRenderer spriteRenderer3)
    {
        Color originalColor = spriteRenderer1.color;

        // Fade In
        spriteRenderer1.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        spriteRenderer2.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        spriteRenderer3.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        float fadeInElapsedTime = 0f;

        while (fadeInElapsedTime < fadeInDuration)
        {
            float normalizedTime = fadeInElapsedTime / fadeInDuration;
            Color fadedInColor = new Color(originalColor.r, originalColor.g, originalColor.b, normalizedTime);
            spriteRenderer1.color = fadedInColor;
            spriteRenderer2.color = fadedInColor;
            spriteRenderer3.color = fadedInColor;

            fadeInElapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer1.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
        spriteRenderer2.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
        spriteRenderer3.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);

        // Wait
        yield return new WaitForSeconds(waitDuration);

        // Fade Out
        float fadeOutElapsedTime = 0f;

        while (fadeOutElapsedTime < fadeOutDuration)
        {
            float normalizedTime = fadeOutElapsedTime / fadeOutDuration;
            Color fadedOutColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - normalizedTime);
            spriteRenderer1.color = fadedOutColor;
            spriteRenderer2.color = fadedOutColor;
            spriteRenderer3.color = fadedOutColor;

            fadeOutElapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer1.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        spriteRenderer2.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        spriteRenderer3.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        // Deactivate the game object after the fading is complete
        spriteRenderer1.gameObject.SetActive(false);

        currentSpriteIndex = currentSpriteIndex + 3;
        if (currentSpriteIndex  < spritesToFade.Length)
        {
            spritesToFade[currentSpriteIndex].gameObject.SetActive(true);
            StartCoroutine(FadeInAndOut(spritesToFade[currentSpriteIndex], spritesToFade[currentSpriteIndex+1], spritesToFade[currentSpriteIndex+2]));
        }
        else
        {
            foreach (var sprite in drinks)
            {
                sprite.gameObject.SetActive(true);
                StartCoroutine(FadeIn(sprite));
            }
            box.gameObject.SetActive(true);
            StartCoroutine(FadeIn(box));
            questionMark.gameObject.SetActive(true);
            StartCoroutine(FadeIn(questionMark));

            if (randomPersons.Count > 0)
            {
                int randomIndex = Random.Range(0, randomPersons.Count);
                chosenPerson = randomPersons[randomIndex];
                chosenPerson.gameObject.SetActive(true);
                StartCoroutine(FadeIn(chosenPerson));
                randomPersons.RemoveAt(randomIndex);

                if (chosenPerson.gameObject.tag == "1")
                {
                    drinkClick1.gameObject.SetActive(true);
                    StartCoroutine(FadeIn(drinkClick1));
                }
                if (chosenPerson.gameObject.tag == "2")
                {
                    drinkClick2.gameObject.SetActive(true);
                    StartCoroutine(FadeIn(drinkClick2));
                }
                if (chosenPerson.gameObject.tag == "3")
                {
                    drinkClick3.gameObject.SetActive(true);
                    StartCoroutine(FadeIn(drinkClick3));
                }
            }

        }
    }

    private IEnumerator FadeIn(SpriteRenderer spriteRenderer)
    {
        Color originalColor = spriteRenderer.color;

        // Fade In
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        float fadeInElapsedTime = 0f;

        while (fadeInElapsedTime < fadeInDuration)
        {
            float normalizedTime = fadeInElapsedTime / fadeInDuration;
            Color fadedInColor = new Color(originalColor.r, originalColor.g, originalColor.b, normalizedTime);
            spriteRenderer.color = fadedInColor;

            fadeInElapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
    }

    private IEnumerator FadeOut(SpriteRenderer spriteRenderer)
    {
        Color originalColor = spriteRenderer.color;
        float fadeOutElapsedTime = 0f;



        while (fadeOutElapsedTime < fadeOutDuration)
        {
            float normalizedTime = fadeOutElapsedTime / fadeOutDuration;
            Color fadedOutColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - normalizedTime);
            spriteRenderer.color = fadedOutColor;

            fadeOutElapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        // Deactivate the game object after the fading is complete
        spriteRenderer.gameObject.SetActive(false);
    }


        public void RightObjectClicked()
    {
        if (chosenPerson.gameObject.tag == "1")
        {
            drinkClick1.gameObject.SetActive(false);
            StartCoroutine(FadeOut(chosenPerson));
        }
        if (chosenPerson.gameObject.tag == "2")
        {
            drinkClick2.gameObject.SetActive(false);
            StartCoroutine(FadeOut(chosenPerson));
        }
        if (chosenPerson.gameObject.tag == "3")
        {
            drinkClick3.gameObject.SetActive(false);
            StartCoroutine(FadeOut(chosenPerson));
        }

        if (randomPersons.Count > 0)
        {
            int randomIndex = Random.Range(0, randomPersons.Count);
            chosenPerson = randomPersons[randomIndex];
            chosenPerson.gameObject.SetActive(true);
            StartCoroutine(FadeIn(chosenPerson));
            randomPersons.RemoveAt(randomIndex);

            if (chosenPerson.gameObject.tag == "1")
            {
                drinkClick1.gameObject.SetActive(true);
                StartCoroutine(FadeIn(drinkClick1));
            }
            if (chosenPerson.gameObject.tag == "2")
            {
                drinkClick2.gameObject.SetActive(true);
                StartCoroutine(FadeIn(drinkClick2));
            }
            if (chosenPerson.gameObject.tag == "3")
            {
                drinkClick3.gameObject.SetActive(true);
                StartCoroutine(FadeIn(drinkClick3));
            }

        }
        pointCount++;
    }
}
