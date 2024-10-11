using UnityEngine;
using System.Collections;
using System.Xml;
using System;

public class XMLManager : MonoBehaviour {
	public string _fileName = "good";
	//xml Load
	void Start()
	{
		Xme_Load(_fileName);
	}

	void Xme_Load(string Filename)
	{
		TextAsset textAsset = (TextAsset)Resources.Load ("XML/" + Filename);
		XmlDocument xmldoc = new XmlDocument ();
		xmldoc.LoadXml(textAsset.text);
		//xml을 생성

		//각 요소별로 가오기
		XmlNodeList info_Table = xmldoc.GetElementsByTagName("info");
		int info = int.Parse (info_Table [0].InnerText);
		Debug.Log (info);

		//전체 가져오기
		XmlNodeList nodes = xmldoc.SelectNodes("Unitset/Unit");

		string s = "";
		foreach (XmlNode node in nodes)
		{
			Debug.Log ("Name : " + node.SelectSingleNode ("Name").InnerText);
			Debug.Log ("info : " + node.SelectSingleNode ("info").InnerText);
		}
	}
}