using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class SaveLoadDeck : MonoBehaviour {

	public Deck deckScript;

	public List<string[]> loadedData = new List<string[]> ();

	string appdata = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

	public void LoadDeck() {
		LoadDeckFromFile(appdata+"/myunitygame/saves/file1.save");
		InjectCardsIntoDeck ();
	}

	public void SaveDeck() {
		SaveDeckToFile (appdata + "/myunitygame/saves/file1.save");
	}

	private void SaveDeckToFile(string fileName) {
		//https://support.unity3d.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(fileName, true);
		writer.WriteLine ("Test,1,1,1");
		writer.WriteLine ("");
		writer.WriteLine ("2,2");
		writer.Close();

		return;
	}

	//------------
	private bool LoadDeckFromFile(string fileName)
	//http://answers.unity3d.com/questions/279750/loading-data-from-a-txt-file-c.html
	{
		// Handle any problems that might arise when reading the text
		try
		{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = theReader.ReadLine();

					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						string[] entries = line.Split(',');
						if (entries.Length > 0)
							ParseInput(entries);
					}
				}
				while (line != null);
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				return true;
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (System.Exception e)
		{
			Debug.Log(e.Message);
			return false;
		}
	}
	//------------

	private void ParseInput(string[] singleLine) {
		if (singleLine.Length != 4) {
			Debug.Log("Wrong entry, number of elements: " + singleLine.Length);
		} else {
			if (singleLine[0] != "name" && singleLine[0] != "card") {
				Debug.Log("Wrong entry, name row: " + singleLine[0]);
			} else {
				if (singleLine [0] == "name" && (singleLine [1].Length == 0 || singleLine [2].Length != 0 || singleLine [3].Length != 0)) {
					Debug.Log ("Wrong entry, first row: " + singleLine [0] + "," + singleLine [1] + "," + singleLine [2] + "," + singleLine [3]);
				} else if (singleLine[0] == "card" && (singleLine [1].Length != 3 || singleLine [2].Length != 3 || singleLine [3].Length != 3)) {
					Debug.Log ("Wrong entry, card row: "  + singleLine [0] + "," + singleLine [1] + "," + singleLine [2] + "," + singleLine [3]);
				} else {
					//Debug.Log ("Good row: " + singleLine [0] + "," + singleLine [1] + "," + singleLine [2] + "," + singleLine [3]);
					loadedData.Add (singleLine);
				}
			}
		}
	}

	private void InjectCardsIntoDeck () {
		foreach(string[] str in loadedData)
		{
			if (str [0] == "card") {
				Board.Obj_Stack.AddCardToTop( Board.InstantiateCard (str [1], str [2], str [3]));
			} else
				Debug.Log ("SaveLoadDeck.InjectCardsIntoDeck() : NAME = " + str [1]);
		}
		return;
	}
}
