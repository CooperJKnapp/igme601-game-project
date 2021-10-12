using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestCoroutine : MonoBehaviour
{
	public TextMeshProUGUI textCo;
	int num;
	bool flag = true;

	IEnumerator InfAdd()
	{
		while (flag)
		{
			num++;
			textCo.text = num.ToString();
			yield return null;
		}


	}

	private void Start()
	{
		StartCoroutine(InfAdd());
	}

	public void SetAdd(bool f)
	{
		flag = f;
	}

}
