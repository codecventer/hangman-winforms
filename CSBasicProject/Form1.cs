// Filename: Form1.cs
// Author : Christiaan Venter
// Student Number : BG4C6CLN1
// Created On : 28/06/2021 9:56:39 AM
// Operating System : Microsoft Windows 10 x64
// Description : This is a WinForms Hangman game.
// Version : 1.0.0

using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System;

namespace CSBasicProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Create variables
        int i;
        char guess;
        string target;
        int score = 0;
        int lives = 10;
        bool hit = false;

        // Create ArrayList for both correct and incorrect letters
        ArrayList incorrect = new ArrayList();
        ArrayList correct = new ArrayList();

        // Create SortedList for each scores of each word
        SortedList sl = new SortedList();

        // Start a new game
        private void button2_Click(object sender, EventArgs e)
        {
            // Prevents multiple words to be stacked together as the secret word, test without if statement
            if (label3.Text == "")
            {
                // Create array list of words
                ArrayList al = new ArrayList();
                al.Add("foo");
                al.Add("bar");
                al.Add("hello");
                al.Add("world");
                al.Add("agile");
                al.Add("software");
                al.Add("localhost");
                al.Add("production");

                // Generate random number
                Random rd = new Random();
                int random = rd.Next(0, 7);

                // Select word to be guessed
                target = (string)al[random];
                Setting();

                // Displays the current score of the player
                label6.Text = "Score: 0";
                label7.Text = "Lives: 10";
            }
        }

        // Replace each character with asterisk
        private void Setting()
        {
            for (int i = 0; i < target.Length; i++)
            {
                label3.Text = label3.Text.Insert(i, "*");
                textBox1.Text = "";
            }
        }

        // Guess a letter button
        private void button1_Click(object sender, EventArgs e)
        {
            // Disables the guess button if a game has not started
            if (label3.Text != "" && textBox1.Text != "")
            {
                textBox1.Focus();
                textBox1.SelectAll();
                guess = textBox1.Text[0];

                // Regex for alphabetical characters only
                string pattern = "[A-Za-z]";
                Regex re = new Regex(pattern);

                // Only accepts alphabetical characters
                if (re.Match(guess.ToString()).Success)
                {
                    guess = textBox1.Text[0];

                    // Replace asterisk with correct character and add letter to either correct or incorrect textbox 
                    for (int i = 0; i < target.Length; i++)
                    {
                        if (Char.ToUpper(target[i]) == Char.ToUpper(guess))
                        {
                            hit = true;
                            score += 1;
                            label3.Text = label3.Text.Remove(i, 1);
                            label3.Text = label3.Text.Insert(i, guess.ToString());
                            textBox3.Text = textBox3.Text.Insert(0, guess.ToString());
                            correct.Add(guess);
                        }
                        else if (Char.ToUpper(target[i]) != Char.ToUpper(guess))
                        {
                            hit = false;
                            textBox2.Text = textBox2.Text.Insert(0, guess.ToString());
                            incorrect.Add(guess);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter alphabetical character");
                }

                label6.Text = "Score: " + score.ToString();

                // Win game if all letters correctly guessed, add score to scoreboard
                if (label3.Text.ToUpper() == target.ToUpper())
                {
                    WonGame();

                    // Add score to scoreboard
                    lstBox.Items.AddRange(new object[]
                    {
                        score
                    });

                    // Add word's score to SortedList
                    i++;
                    string slEntry = target + i;
                    sl.Add(slEntry, score);
                }

                // Lose game if lives reach 0, also display lives left with each incorrect guess
                if (!hit)
                {
                    lives--;
                    if (lives == 0)
                    {
                        LostGame();
                    }
                }

                // Display updated data
                label6.Text = "Score: " + score.ToString();
                label7.Text = "Lives: " + lives.ToString();
            }
        }

        // Click to exit game
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Game won, display points
        private void WonGame()
        {
            MessageBox.Show("You Won! Your score: " + score, "Well Done!");
            ResetGame();
        }

        // Game lost, display correct word
        private void LostGame()
        {
            MessageBox.Show("The correct word was: " + target, "You Lost...");
            ResetGame();
        }

        // Click to reset game
        private void button4_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        // Reset game
        private void ResetGame()
        {
            label6.Text = "Score: ";
            label7.Text = "Lives: ";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label3.Text = "";
            target = "";
            lives = 10;
        }
    }
}
