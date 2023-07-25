using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormulaDecoder : MonoBehaviour
{
    public int FormularsDecoder(string oriFormular, int oriNum)
    {
        string[] seperators = new string[] { " ", "f(x)=" };
        string[] splitedFormula = oriFormular.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

        for (var i = 0; i < splitedFormula.Length; i++)
        {
            print(splitedFormula[i] + oriNum);
            if(splitedFormula[i] == "2x")
            {
                oriNum = oriNum * 2;
            }
            if (splitedFormula[i] == "3x")
            {
                oriNum = oriNum * 3;
            }
            if (splitedFormula[i] == "4x")
            {
                oriNum = oriNum * 4;
            }
            if (splitedFormula[i] == "5x")
            {
                oriNum = oriNum * 5;
            }
            if(splitedFormula[i] == "+1")
            {
                oriNum += 1;
            }
            if (splitedFormula[i] == "+2")
            {
                oriNum += 2;
            }
            if (splitedFormula[i] == "+3")
            {
                oriNum += 3;
            }
            if (splitedFormula[i] == "+4")
            {
                oriNum += 4;
            }
            if (splitedFormula[i] == "+5")
            {
                oriNum += 5;
            }
            print("passssssss");
        }

        return oriNum;
    }

    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            arr[a] = arr[a + 1];
        }
        Array.Resize(ref arr, arr.Length - 1);
    }
}
