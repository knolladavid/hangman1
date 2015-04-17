﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HangNail
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string username = string.Empty;

            Console.WriteLine(@"
            (/)
            (/)
             (/)
            (/)
             (/)
            (/)
            (/))
           (/)(/)
          (/)'`(/)
         (/)    (/)
         (/)    (/)
         (/)    (/)
         (/)    (/)
          (/)  (/)
           (/)(/)
            `""`");

            Console.WriteLine(@"/\  /\ __ _  _ __    __ _   /\/\    __ _  _ __
 / /_/ // _` || '_ \  / _` | /    \  / _` || '_ \
/ __  /| (_| || | | || (_| |/ /\/\ \| (_| || | | |
\/ /_/  \__,_||_| |_| \__, |\/    \/ \__,_||_| |_|");

            Console.WriteLine("Ladies and Gentlmen, step right up and play the game thats sweeping the nation.  Why hello kindly villager, what be your name? ");
            username = Console.ReadLine();

            Console.WriteLine("Welcome " + username + ". We are going to be play ye' olde game of hangman, but with a slight twist.\n This is called hangnail. With every letter guessed incorrectly,\n the skin of the cuticle is ripped further down.\n This is a game that will take skill and cunning to make it through unscathed.\nYou will have to guess the word, but be careful, you only have a 8 lives.\n Guess too many wrong answers and you'll lose your LIFE! Can you guess the word?\n  ");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(@"
            (/)
            (/)
             (/)
            (/)
             (/)
            (/)
            (/))
           (/)(/)
          (/)'`(/)
         (/)    (/)
         (/)    (/)
         (/)    (/)
         (/)    (/)
          (/)  (/)
           (/)(/)
            `""`");

            Console.WriteLine(@"/\  /\ __ _  _ __    __ _   /\/\    __ _  _ __
 / /_/ // _` || '_ \  / _` | /    \  / _` || '_ \
/ __  /| (_| || | | || (_| |/ /\/\ \| (_| || | | |
\/ /_/  \__,_||_| |_| \__, |\/    \/ \__,_||_| |_|");
            Console.WriteLine("Great to hear " + username + ", lets play ");

            HangNail();

            Console.ReadKey(); //keep the console open
        }

        private static void HangNail()
        {
            //boolean value to tell console whether to continue to play
            bool playing = true;

            // the amount of lives remaining in the counter
            int lives = 8;

            //Create our word bank, obviously
            List<string> wordStorage = new List<string>() { "banana", "meatloaf", "rap", "rock", "football" };

            Random rng = new Random();

            int randomNumber = rng.Next(0, wordStorage.Count());
            //choose a random word from the word bank or invisibility 
            // force it to be UPPERCASE
            string wordToGuess = wordStorage[randomNumber].ToUpper();

            
            string lettersGuessed = string.Empty;

            //Begin with our game loop 
            while (playing)
            {
                //this will show our hidden word
                Console.WriteLine(Invisibility(wordToGuess, lettersGuessed));

                //tell the user how many lives they have remaining
                Console.WriteLine("Let me remdind you that you only have  " + lives + " lives remaining");
                //let them begin the  game
                Console.WriteLine("Guess away!");

                string userInput = Console.ReadLine().ToUpper();

                //is it a letter or a full guessed word?
                if (userInput.Length == 1)
                {
                    //guessed a letter that is the word, add it to the string
                    lettersGuessed += userInput;

                    if (wordToGuess.Contains(userInput))
                    {
                        //if they correctly guess the word
                        Console.WriteLine("Good Guess, Not too shabby!");

                        //has the user guessed all the letters in the word?
                        if (AllLettersGuessed(Invisibility(wordToGuess, lettersGuessed)))
                        {
                            playing = false;
                            Console.WriteLine("Winner, Winner, Chicken Dinner!");
                        }
                    }
                    else
                    {
                        //user has given an incorrect guess
                        Console.WriteLine("Ha ha ha.... Nope");
                        lives--;
                    }
                }
                else
                {
                    if (wordToGuess == userInput)
                    {
                        //they beat the game . WAY TO GO!
                        Console.WriteLine("Sweet Baby Jesus, you're smart!");
                        playing = true;
                    }
                    else
                    {
                        //lost a Life
                        Console.WriteLine("Another one bites the dust");
                        lives--;
                    }
                }
                //check to see if game is over because of lives
                if (lives == 0)
                {
                    playing = false;
                    Console.WriteLine("Oh, too bad! I thought you had it. ");
                }
            }
        }

        private static string Invisibility(string wordToGuess, string lettersGuessed)
        {
            string returnString = "";

            //loop through to examine chars and look for letters
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                // use i index to get char from wordtoguess
                char letter = wordToGuess[i];

                //check to see if letter guessed is in wordtoguess
                if (lettersGuessed.ToUpper().Contains(Char.ToUpper(letter)))
                {
                    returnString += letter + " ";
                }
                else
                {
                    returnString += "_" + " ";
                }
            }
            //return the returnString
            return returnString;
        }

        private static bool AllLettersGuessed(string maskedWord)
        {
            //determine if the user has guessed all the
            //letters of the word.
            if (maskedWord.Contains("_"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        ///

        // return invisibility ( the hidden word )
        
    }
}