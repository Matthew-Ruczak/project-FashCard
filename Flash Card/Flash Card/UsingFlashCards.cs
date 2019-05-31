﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Flash_Card
{
    public partial class UsingFlashCards : Form
    {
        //Fields
        private ListOfCards listOfCards = new ListOfCards();
        private string currentAnswer;


        public UsingFlashCards()
        {
            InitializeComponent();

            ////Test cards (Only for testing, remove when finished)
            //listOfCards.addCard(new Card("What year did Canada become a country?", "1867"));
            //listOfCards.addCard(new Card("What is the capital of Canada?", "Ottawa"));
            //listOfCards.addCard(new Card("What colours are in the Canadian Flag?", "Red and White"));

            //Opens a dialog for the user to select the file they would like to open (Still testing)
            openFileAndLoadQuestions();

            //Loading first question when the form loads
            loadQuestion(listOfCards.getNextCard());
        }

        //An event handler that executes when the "Next" button is pressed
        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            loadQuestion(listOfCards.getNextCard());
        }
        //An event handler that executes when the "Previous" button is pressed
        private void btnPreviousQuestion_Click(object sender, EventArgs e)
        {
            loadQuestion(listOfCards.getPreviousCard());
        }
        //An event handler that executes when the "Show Answer" button is pressed
        private void btnShowAnswer_Click(object sender, EventArgs e)
        {
            richTextBoxAnswer.Text = currentAnswer;
        }
        //Loads the question in to the form (Hides the answer until the user wants to reveal it)
        private void loadQuestion(Card c)
        {
            richTextBoxQuestion.Text = c.getQuestion();     //Displaying the Question in the question rich text box
            richTextBoxAnswer.Text = "Click button below to reveal!";   //Instructions to the user
            currentAnswer = c.getAnswer();  //Storing the answer to the question, so it can be revealed when the user wants it
        }

        //Opening the file that contain the questions (Should be in JSON)
        private void openFileAndLoadQuestions()
        {
            try
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (StreamReader r = new StreamReader(openFileDialog.FileName))
                    {
                        string json = r.ReadToEnd();
                        List<tmpCard> tmpListOfCards = JsonConvert.DeserializeObject<List<tmpCard>>(json);

                        foreach (tmpCard c in tmpListOfCards)
                        {
                            listOfCards.addCard(new Card(c.question, c.answer));
                        }
                    }
                }
                MessageBox.Show("File was successfuly opened!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            
        }
    }

    public class tmpCard
    {
        public string question;
        public string answer;
    }
}
