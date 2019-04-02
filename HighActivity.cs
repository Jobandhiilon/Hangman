
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HelloWorld
{
    [Activity(Label = "HighActivity")]
    public class HighActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Highscores);

            TextView highScore1 = (TextView)FindViewById(Resource.Id.highscore1);
            TextView highScore2 = (TextView)FindViewById(Resource.Id.highscore2);
            TextView highScore3 = (TextView)FindViewById(Resource.Id.highscore3);
            TextView highScore4 = (TextView)FindViewById(Resource.Id.highscore4);
            TextView highScore5 = (TextView)FindViewById(Resource.Id.highscore5);
            Button backButton = (Android.Widget.Button)FindViewById(Resource.Id.backBtn);

            highScore1.Click += delegate
            {
                MainActivity.playerName = Hangman.allPlayers[0];
                Intent newGame = new Intent(this, typeof(Hangman));
                StartActivity(newGame);
            };

            highScore2.Click += delegate
            {
                MainActivity.playerName = Hangman.allPlayers[1];
                Intent newGame = new Intent(this, typeof(Hangman));
                StartActivity(newGame);
            };

            highScore3.Click += delegate
            {
                MainActivity.playerName = Hangman.allPlayers[2];
                Intent newGame = new Intent(this, typeof(Hangman));
                StartActivity(newGame);
            };

            highScore4.Click += delegate
            {
                MainActivity.playerName = Hangman.allPlayers[3];
                Intent newGame = new Intent(this, typeof(Hangman));
                StartActivity(newGame);
            };

            highScore5.Click += delegate
            {
                MainActivity.playerName = Hangman.allPlayers[4];
                Intent newGame = new Intent(this, typeof(Hangman));
                StartActivity(newGame);
            };


            try
            {
                highScore1.Text = Hangman.allPlayers[0];
            }
            catch
            {

            }

            try
            {
                highScore2.Text = Hangman.allPlayers[1];
            }
            catch
            {

            }

            try
            {
                highScore3.Text = Hangman.allPlayers[2];
            }
            catch
            {

            }

            try
            {
                highScore4.Text = Hangman.allPlayers[3];
            }
            catch
            {

            }

            try
            {
                highScore5.Text = Hangman.allPlayers[4];
            }
            catch
            {

            }

            backButton.Click += delegate
            {
                Intent newGame = new Intent(this, typeof(MainActivity));
                StartActivity(newGame);
            };

        }

    }
}
