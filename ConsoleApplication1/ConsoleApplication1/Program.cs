

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace HangNail
{
    class Program
    {
        static void Main(string[] args)
        {
            
               bool keepPlaying = true;
            
        
            Console.WriteLine("Ladies and Gentlmen, step right up and play the game thats sweeping the nation.  Why hello kindly villager, what be your name? ");
            Console.ReadLine();
            Console.WriteLine("We are going to be play ye' olde game of hangman, but with a slight twist.\n This is called hangnail. With every letter guessed incorrectly,\n the skin of the cuticle is ripped further down.\n This is a game that will take skill and cunning to make it through unscathed.\nYou will have to guess the word, but be careful, you only have a 8 lives.\n Guess too many wrong answers and you'll lose Can you guess the word?\n  ");
            Console.ReadLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();


           Console.WriteLine("Great to hear, lets play ");
            HangNail();

            Console.ReadKey(); //keep the console open
        }
        
    
   
            
        
        
        
        
        static void HangNail()
        {
            //boolean to hold whether to continue the game.
            bool playing = true;
            string playerName; //hold the player's name
            int lives =8 ; //number of guesses
            


            //Create our word bank, obviously
            List<string> wordBank = new List<string>() { "banana", "meatloaf", "rap", "rock" , "football"};
            

            Random rng = new Random(); //make a new rng
            //select a random number between 0 and the #
            // of things in our wordBank List
            int randomNumber = rng.Next(0, wordBank.Count());
            //choose a random item from our wordBank List
            // force it to be UPPERCASE
            string wordToGuess = wordBank[randomNumber].ToUpper();

            //one line solution for getting a random item
            //string wordToGuess = wordBank[new Random().Next(0, wordBank.Count())];

            //need to track what letters they've guessed
            string lettersGuessed = string.Empty;

            //start our game loop
            while (playing)
            {
                //1. show the masked word
                Console.WriteLine(MaskedWord(wordToGuess, lettersGuessed));
                //2. tell them how many lives left
                Console.WriteLine("Let me remdind you that you only have  " + lives + " lives remaining");
                //3. ask for input
                Console.WriteLine("Guess away!");
                //4. get the input, force it to be UPPERCASE
                string input = Console.ReadLine().ToUpper();

                //determine if its a letter or a word guess
                if (input.Length == 1)
                {
                    //guessed a letter, add it to the string
                    lettersGuessed += input;

                    //letter guess.  determine if its a
                    // correct guess
                    if (wordToGuess.Contains(input))
                    {
                        //correct guess!
                        Console.WriteLine("Good Guess, Not too shabby!");
                        //determine if they have guessed all the letters in the word
                        if (AllLettersGuessed(MaskedWord(wordToGuess, lettersGuessed)))
                        {
                            playing = false;
                            Console.WriteLine("Winner, Winner, Chicken Dinner!");
                        }
                    }
                    else
                    {
                        //incorrect guess!
                        Console.WriteLine("Ha ha ha.... Nope");
                        lives--;
                    }
                }
                else
                {
                   
                  
                    if (wordToGuess == input)
                    {
                        //they beat the game 
                        Console.WriteLine("Sweet Baby Jesus, you're smart!");
                        playing = true;
                    }
                    else
                    {
                        //lose a life
                        Console.WriteLine("Another one bites the dust");
                        lives--;
                    }
                }
                //check for a loss because of life
                if (lives == 0)
                {
                    playing = false;
                    Console.WriteLine("Oh, too bad! I thought you had it. ");
                }

            }

        }

     
        static string MaskedWord(string wordToGuess, string lettersGuessed)
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

        static bool AllLettersGuessed(string maskedWord)
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
        
            //One line solution: not maskedWord contains an underscore
            //return !maskedWord.Contains("_");
        }
    }

