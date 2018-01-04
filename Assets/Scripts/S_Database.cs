using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class S_Database : MonoBehaviour {

    private string secretKey = "mySecretKey";

	public int Shotcount;
	public int Scorecount;
	public string Level;
	public string TotalOutput;

    public string AddUserURL = "https://databasesite.000webhostapp.com/AddUser.php?";
    public string ShowAllUsersURL = "https://databasesite.000webhostapp.com/selectAllUsers.php?";

    UnityEngine.UI.InputField name;
    UnityEngine.UI.InputField password1;

	public S_UI UIscript;

    
    //Loads Scoreboard (By Ray Sloan)
    public void OnLoadButtonClick()
    {

		UIscript.PrintScoreboard (getAllUsers ());
    }

    //Loads Scoreboard and Submits New User (By Ray Sloan)
    public void OnSubmitButtonClick()
    {
        name = GameObject.Find("InputFieldName").GetComponent<UnityEngine.UI.InputField>();
		AddUser(name.text, "NULL", Shotcount.ToString(), Level, Scorecount.ToString());
		UIscript.PrintScoreboard (getAllUsers ());
        
    }

    //Loads all user scores from online database (By Ray Sloan)
    public string getAllUsers ()
    {
        WWW GetUsers = new WWW(ShowAllUsersURL);


        while (!GetUsers.isDone)
        {
            
        }

        if (GetUsers.error != null)
        {
            Debug.Log("There was an error getting the high score: " + GetUsers.error);
        }

        return GetUsers.text;
    }

    //Submits new user, score, shot count and level played on to online database (By Ray Sloan)
    public void AddUser (string UserName, string Password, string Shots, string Level, string Score)
    {
        string hash = CreateMD5(UserName + Password + secretKey);

		string post_url = AddUserURL + "Email=" + WWW.EscapeURL(UserName) + "&Password=" + Password + "&Score=" + Score + "&Level=" + Level + "&Shots=" + Shots  + "&hash=" + hash;

        print(post_url);

        WWW post = new WWW(post_url);

        while(!post.isDone)
        {

        }

        if(post.error != null)
        {
            print("There was an error posting the user data: " + post.error);
        }
    }

    //Creates hash (By Ray Sloan)
    public static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        //Convert the byte array to hexadecimal string
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));

        }
        return sb.ToString();
    }

}
