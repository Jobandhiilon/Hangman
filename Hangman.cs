using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections;
using Android.Content;
using System.IO;

namespace HelloWorld
{
	[Activity (Label = "Hangman")]			
	public class Hangman : Activity
	{
        int i = 0;
        int score;
        int wrong = 0;
        ImageView[] bodyParts;
        GridView gridView;
        ArrayAdapter adapter;
        ArrayList alphabets;
        String currentWord;
        TextView scoreview;
        TextView que;
        Button submit;
        LinearLayout currentWordLayout;

        public static String[] allPlayers;
        public TextView[] charView;
        
        public static int highscore;
        public static String currentPlayer;
        public static String log;

        String[] questions = {"MICROSOFTS FOUNDER'S LAST NAME", "GOOGLE CEO's FIRST NAME?", "APPLE FOUNDER'S LAST NAME?", "CAPITAL OF ITALY?","PARENT COMPANY OF JAVA?"};
        String[] answers = {"GATES","SUNDAR", "JOBS","ROME","ORACLE"};

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
                        SetContentView(Resource.Layout.GameLayout);

            gridView = FindViewById<GridView>(Resource.Id.gridView);
            getData();
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, alphabets);
            gridView.Adapter = adapter;
            gridView.ItemClick += gridView_ItemClick;

            currentWordLayout = (LinearLayout) FindViewById(Resource.Id.currentWordLayout);
            sequence();

            que = (TextView)FindViewById(Resource.Id.question);
             
            submit = (Button) FindViewById(Resource.Id.submit);

            submit.Click +=delegate {
                write();
                MainActivity.editText.Text = "";
                Toast.MakeText(this, "YOUR SCORE IS: " + score, ToastLength.Long).Show();
                this.Finish();
            };
            
            que.Text = questions[i];
            scoreview = (TextView)FindViewById(Resource.Id.score);
            
            play();

        }

    void gridView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            String c = alphabets[e.Position].ToString();
            alphabets[e.Position] = " ";

            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, alphabets);
            gridView.Adapter = adapter;

            if (answers[i].Contains(c))
            {
                currentWord = currentWord + c;

                for(int n = 0; n < answers[i].Length; n++)
                {
                    if (charView[n].Text == c)
                    {
                        charView[n].SetTextColor(Android.Graphics.Color.White);
                    }
                }

                if (answers[i].Length == currentWord.Length)
                {
                    getData();
                    adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, alphabets);
                    gridView.Adapter = adapter;
                    Toast.MakeText(this, "GOOD!!", ToastLength.Short).Show();
                    Toast.MakeText(this, "ANSWER: " + answers[i], ToastLength.Long).Show();
                    i++;
                    score++;
                    scoreview.Text = MainActivity.playerName+" SCORE: " + score.ToString();
                    currentPlayer = MainActivity.playerName;
                    highscore = score;
                    que.Text = questions[i];
                    currentWord = "";
                    currentWordLayout.RemoveAllViews();
                    sequence();
                    wrong = 0;
                    play();
                }
            }
            else
            {
                bodyParts[wrong].Visibility = ViewStates.Visible;
                wrong++;
                if (wrong == 6)
                {
                    Toast.MakeText(this, "Oops! It's wrong!!", ToastLength.Short).Show();
                    Toast.MakeText(this, "RIGHT ANSlWER: "+answers[i], ToastLength.Long).Show();
                    Toast.MakeText(this, MainActivity.playerName+"'s"+" SCORE: " + score, ToastLength.Long).Show();
                    currentPlayer = MainActivity.playerName;
                    MainActivity.editText.Text = "";
                    highscore = score;
                    write();
                    this.Finish();
                    i++;
                }
            }

        }

        //FILL DATA
        private void getData()
        {
            alphabets = new ArrayList();
            alphabets.Add("A");
            alphabets.Add("B");
            alphabets.Add("C");
            alphabets.Add("D");
            alphabets.Add("E");
            alphabets.Add("F");
            alphabets.Add("G");
            alphabets.Add("H");
            alphabets.Add("I");
            alphabets.Add("J");
            alphabets.Add("K");
            alphabets.Add("L");
            alphabets.Add("M");
            alphabets.Add("N");
            alphabets.Add("O");
            alphabets.Add("P");
            alphabets.Add("Q");
            alphabets.Add("R");
            alphabets.Add("S");
            alphabets.Add("T");
            alphabets.Add("U");
            alphabets.Add("V");
            alphabets.Add("W");
            alphabets.Add("X");
            alphabets.Add("Y");
            alphabets.Add("Z");

        }

        private void play()
        {
            bodyParts = new ImageView[6];
            bodyParts[0] = (ImageView) FindViewById(Resource.Id.head);
            bodyParts[1] = (ImageView)FindViewById(Resource.Id.body);
            bodyParts[2] = (ImageView)FindViewById(Resource.Id.left_arm);
            bodyParts[3] = (ImageView)FindViewById(Resource.Id.right_arm);
            bodyParts[4] = (ImageView)FindViewById(Resource.Id.left_leg);
            bodyParts[5] = (ImageView)FindViewById(Resource.Id.right_leg);

            for (int p = 0; p < 6; p++)
            {
                bodyParts[p].Visibility = ViewStates.Invisible;
            }

        }

        public void write()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filename = System.IO.Path.Combine(path, "newlog.txt");


            using (var streamWriter = new StreamWriter(filename, true))
            {
                streamWriter.WriteLine(currentPlayer+": "+highscore);
            }

            using (var streamReader = new StreamReader(filename))
            {
                string content = streamReader.ReadToEnd();
                allPlayers = new string[5];
                allPlayers = content.Split('\n');

            }
        }

        private void sequence()
        {
            charView = new TextView[answers[i].Length];

            for (int k = 0; k < answers[i].Length; k++)
            {
                charView[k] = new TextView(this);
                charView[k].Text = "" + answers[i][k];
                charView[k].SetTextColor(Android.Graphics.Color.Black);
                currentWordLayout.AddView(charView[k]);
            }
        }
    }
}

