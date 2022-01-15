using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPush : MonoBehaviour
{
    //The first Fibonacci numbers that will be displayed
    float fibonacci1 = 1;
    float fibonacci2 = 1;

    //The textbox where the numbers will be displayed
    public Text NumberDisplay;

    //The panel where the grid will be displayed.
    public GameObject panel;
    private float panelSize = 40f;
    //Variable used to determine the direction the next square will be generated (up, left, down, right)
    private int pos = 0;

    //The last square generated
    public GameObject square;
    //Variables for coordinates of the current corners of the grid
    private float minX = 0f;
    private float maxX = 0f;
    private float minY = 0f;
    private float maxY = 0f;


    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.name == "ButtonTop")
                {
                    hit.transform.gameObject.GetComponent<AudioSource>().Play();
                    GameObject clone;

                    panel.GetComponent<AudioSource>().Play();
                    //Generate next square based on its direction
                    switch (pos)
                    {
                        case 1:
                            //square going up
                            clone = Instantiate(square, square.transform.position, square.transform.rotation);

                            Text squareNumber = clone.GetComponentInChildren<Text>();
                            squareNumber.text = fibonacci1.ToString();

                            clone.transform.parent = panel.transform;
                            clone.transform.position = new Vector3(maxX - (fibonacci1 / 2), maxY + (fibonacci1 / 2), square.transform.position.z);
                            clone.transform.localScale = Vector2.one * fibonacci1;

                            clone.GetComponent<Image>().color = new Color32(15, 185, 31, 255);

                            square = clone;
                            break;
                        case 2:
                            //square going left;
                            clone = Instantiate(square, square.transform.position, square.transform.rotation);

                            squareNumber = clone.GetComponentInChildren<Text>();
                            squareNumber.text = fibonacci1.ToString();

                            clone.transform.parent = panel.transform;
                            clone.transform.position = new Vector3(minX - (fibonacci1 / 2), maxY - (fibonacci1 / 2), square.transform.position.z);
                            clone.transform.localScale = Vector2.one * fibonacci1;

                            clone.GetComponent<Image>().color = new Color32(0, 87, 235, 255);

                            square = clone;
                            break;
                        case 3:
                            //square going down;
                            clone = Instantiate(square, square.transform.position, square.transform.rotation);

                            squareNumber = clone.GetComponentInChildren<Text>();
                            squareNumber.text = fibonacci1.ToString();

                            clone.transform.parent = panel.transform;
                            clone.transform.position = new Vector3(minX + (fibonacci1 / 2), minY - (fibonacci1 / 2), square.transform.position.z);
                            clone.transform.localScale = Vector2.one * fibonacci1;

                            clone.GetComponent<Image>().color = new Color32(176, 26, 26, 255);

                            square = clone;
                            break;
                        case 4:
                            //square going right;
                            clone = Instantiate(square, square.transform.position, square.transform.rotation);

                            squareNumber = clone.GetComponentInChildren<Text>();
                            squareNumber.text = fibonacci1.ToString();

                            clone.transform.parent = panel.transform;
                            clone.transform.position = new Vector3(maxX + (fibonacci1 / 2), minY + (fibonacci1 / 2), square.transform.position.z);
                            clone.transform.localScale = Vector2.one * fibonacci1;

                            clone.GetComponent<Image>().color = new Color32(253, 215, 1, 255);

                            square = clone;
                            break;
                    }

                    //Debug.Log("x: " + square.transform.position.x + " y: " + square.transform.position.y);

                    //Update grid corners
                        if (square.transform.position.x - (fibonacci1 / 2) < minX)
                        {
                            minX = square.transform.position.x - (fibonacci1 / 2);
                        }
                        if (square.transform.position.x + (fibonacci1 / 2) > maxX)
                        {
                            maxX = square.transform.position.x + (fibonacci1 / 2);
                        }
                        if (square.transform.position.y - (fibonacci1 / 2) < minY)
                        {
                            minY = square.transform.position.y - (fibonacci1 / 2);
                        }
                        if (square.transform.position.y + (fibonacci1 / 2) > maxY)
                        {
                            maxY = square.transform.position.y + (fibonacci1 / 2);
                        }

                    
                    if (fibonacci1 < 100)
                    {
                        //Display current Fibonacci number and calculate the next one
                        NumberDisplay.text = fibonacci1.ToString();
                        float fibonacci3 = fibonacci1 + fibonacci2;
                        fibonacci1 = fibonacci2;
                        fibonacci2 = fibonacci3;
                    }

                    if (fibonacci1 > 8)
                    {
                        NumberDisplay.gameObject.SetActive(false);
                    }

                    //Update square position
                    if (fibonacci1 == 1)
                    {
                        pos = 4;
                    }
                    else if (fibonacci1 < 100 && pos < 4)
                    {
                        pos++;
                    }
                    else if (pos == 4 && fibonacci1 < 100)
                    {
                        pos = 1;
                    }
                    else
                    {
                        pos = 0;
                    }
                    Debug.Log(pos);

                    //Scales down panel if square is too big
                    /*if (minX <= -panelSize || maxX >= panelSize || minY <= -panelSize || maxY >= panelSize)
                    {
                        panel.transform.localScale /= 4;
                        panelSize *= 4;
                    }*/

                    Debug.Log("minX: " + minX + " maxX: " + maxX + " minY: " + minY + " maxY: " + maxY);
                }
            }
        }
    }

}
