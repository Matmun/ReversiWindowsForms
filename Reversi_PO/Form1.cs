using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi_PO
{
    public partial class Form1 : Form
    {
        public static bool WhoseTurn;
        public static int SBW = 40, BPS = 8;//Singluar block width , Blocks Per Side
        public static Block[,] Board;
        public static Queue<Point> MoveList = new Queue<Point>();

        public Form1()
        {
            InitializeComponent();
            WhoseTurn = true;
            Board = new Block[BPS, BPS];
            Scene.Width = SBW * BPS;
            Scene.Height = SBW * BPS;
            for (int i = 0; i < Board.GetLength(0); ++i)
                for (int j = 0; j < Board.GetLength(1); ++j)
                    Board[i, j] = new Block('N');
            Board[BPS / 2, BPS / 2].Place('W');
            Board[BPS / 2 - 1, BPS / 2].Place('B');
            Board[BPS / 2, BPS / 2 - 1].Place('B');
            Board[BPS / 2 - 1, BPS / 2 - 1].Place('W');
            
        }

        private void Scene_Paint(object sender, PaintEventArgs e)
        {
            int B = Count(true), P= Count(false);
            BotTomaszPoints.Text = "Bot Points = " + B;
            PlayerFranekPoints.Text = "Player Points = " + P;
            if (B + P >= BPS*BPS)
                AtTheEnd(P > B ? "Player" : "Bot");
            BotTomaszPoints.Refresh();
            PlayerFranekPoints.Refresh();
            int temp = 1;
            for (int i = 0; i < Board.GetLength(0); ++i)
            {
                for (int j = 0; j < Board.GetLength(1); ++j)
                    switch (Board[i, j].State)
                    {
                        case null:
                            if (temp == 1)
                            {
                                e.Graphics.DrawImage(Image.FromFile(@"../ReversiData/emptyL.png"), i * SBW, j * SBW, SBW, SBW);
                                temp *= -1;
                            }
                            else
                            {
                                e.Graphics.DrawImage(Image.FromFile(@"../ReversiData/emptyD.png"), i * SBW, j * SBW, SBW, SBW);
                                temp *= -1;
                            }
                            break;
                        case true:
                            e.Graphics.DrawImage(Image.FromFile(@"../ReversiData/white.png"), i * SBW, j * SBW, SBW, SBW);
                            temp *= -1;
                            break;
                        case false:
                            e.Graphics.DrawImage(Image.FromFile(@"../ReversiData/black.png"), i * SBW, j * SBW, SBW, SBW);
                            temp *= -1;
                            break;
                    }
                temp *= -1;
            }
            BoardScan(WhoseTurn);
            if (MoveList.Count == 0)
            {
                WhoseTurn = !WhoseTurn;
                BoardScan(WhoseTurn);
                if (MoveList.Count == 0) 
                {
                    AtTheEnd(P > B ? "Player" : "Bot");
                }
            }
            foreach (var item in MoveList)
            {
                e.Graphics.DrawImage(Image.FromFile(@"../ReversiData/circleD.png"), item.X * SBW, item.Y * SBW, SBW, SBW);
            }
        }

        private void Scene_MouseClick(object sender, MouseEventArgs e)
        {

            foreach (var item in MoveList)
            {
                if ((e.X >= item.X * SBW && e.X <= item.X * SBW + SBW) && (e.Y >= item.Y * SBW && e.Y <= item.Y * SBW + SBW))
                {
                    Board[item.X, item.Y].Place((WhoseTurn) ? 'W' : 'B');
                    FlipMultiple(item.X, item.Y);
                    WhoseTurn = !WhoseTurn;
                    ClearDict();
                    Scene.Refresh();
                    if (true)
                    {
                        Thread.Sleep(200);
                        AI();
                    }
                    
                    break;
                }
            }

            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
                Initializer();
        }

        private int Count(bool who)
        {
            int counter = 0;
            for (int i = 0; i < Board.GetLength(0); ++i)
                for (int j = 0; j < Board.GetLength(1); ++j)
                    if (Board[i, j].State == !who) counter++;
            return counter;
        }//Funckja zliczajaca liczbe pionkow danego gracza

        private void ClearDict()
        {
            foreach (var item in MoveList)
            {
                Board[item.X, item.Y].ClearDict();
                //foreach (var item2 in Board[item.X, item.Y].Data.Keys)
                //{
                //    Board[item.X, item.Y].Data[item2] = (short)0;
                //}
            }
            MoveList.Clear();
            

        }//Funckja odpalajaca na kazdym bloku funckje czyszczaca

        private void BoardScan(bool S)
        {
            for (int i = 0; i < Board.GetLength(0); ++i)
                for (int j = 0; j < Board.GetLength(1); ++j)
                    if (Board[i, j].State == S) SingularBlockScan(i, j, S);
            //{ 
            //if(i!=Board.GetLength(0)-1 && Board[i+1, j].State!=S && Board[i + 1, j].State !=null) SingularBlockScan(i + 1, j);
            //if(i!=0 && Board[i - 1, j].State != S && Board[i + 1, j].State != null) SingularBlockScan(i - 1, j);
            //if(j!=Board.GetLength(1)-1 && Board[i + 1, j].State != S && Board[i + 1, j].State != null) SingularBlockScan(i, j + 1);
            //if(j!=0 && Board[i + 1, j].State != S && Board[i - 1, j].State != null) SingularBlockScan(i, j - 1);
            //}
        }//Funckja pomocnicza odpalajaca przeszukiwanie dla kazdego pola

        private void FlipMultiple(int x, int y)
        {
            int dy = 0;
            int dx = 0;
            int tempX, tempY;
            short tempV;
            foreach (var item in Board[x, y].Data)
            {
                dy = 0;
                dx = 0;
                if (item.Value != 0)
                {
                    if (item.Key.Contains("S")) dy = 1;
                    if (item.Key.Contains("N")) dy = -1;
                    if (item.Key.Contains("E")) dx = 1;
                    if (item.Key.Contains("W")) dx = -1;
                    tempX = x;
                    tempY = y;
                    tempV = item.Value;
                    while (tempV > 0)
                    {
                        tempX += dx;
                        tempY += dy;
                        Board[tempX, tempY].Flip();
                        tempV--;
                    }
                }
            }
        }//Funkcja odwracajoca wiele pionkow

        private void SingularBlockScan(int x, int y, bool S)
        {

            int tempSum;
            int tempX, tempY;
            for (int dx = -1; dx <= 1; ++dx)
            {
                for (int dy = -1; dy <= 1; ++dy)
                {
                    if (dx == 0 && dy == 0) continue;
                    tempX = x + dx;
                    tempY = y + dy;

                    tempSum = 0;
                    while (tempX >= 0 && tempX < BPS && tempY >= 0 && tempY < BPS)
                    {
                        if (Board[tempX, tempY].State == null && tempSum != 0)//Odwrocone kierunki
                        {
                            string kierunek = "";
                            switch (dy)
                            {
                                case -1:
                                    kierunek += 'S';
                                    break;
                                case 1:
                                    kierunek += 'N';
                                    break;
                            }
                            switch (dx)
                            {
                                case -1:
                                    kierunek += 'E';
                                    break;
                                case 1:
                                    kierunek += 'W';
                                    break;
                            }
                            if (Board[tempX, tempY].Data.ContainsKey(kierunek))
                            {
                                Board[tempX, tempY].Data[kierunek] = (short)tempSum;
                                MoveList.Enqueue(new Point(tempX, tempY));
                            }
                            break;
                        }

                        if (Board[tempX, tempY].State != !S)
                        {
                            break;
                        }
                        tempSum++;
                        //Board[tempX, tempY].;



                        tempX += dx;
                        tempY += dy;
                    }
                }
            }
        }//Funkcja przeszukujaca plansze dla danego pionka ,zapelnianie kolejki pol do klikniecia

        private void AI() 
        {
            int MaxVal=0,tempV=0;
            Point target = new Point(0,0);

            foreach (var item in MoveList) 
            {
                tempV = 0;
                foreach (var suma in Board[item.X, item.Y].Data)
                {
                    tempV += suma.Value;
                }
                if (tempV >= MaxVal) {
                    MaxVal = tempV;
                    target.X = item.X;
                    target.Y = item.Y;
                }
            }
            Board[target.X, target.Y].Place((WhoseTurn) ? 'W' : 'B');
            FlipMultiple(target.X, target.Y);
            WhoseTurn = !WhoseTurn;
            ClearDict();
            Scene.Refresh();

        }//Zachowanie Bota

        private void AtTheEnd(string winner) 
        {
            Winner.Text ="Wygral :" + winner;
            Winner.Visible = true;
            
        }// Funkcja wypisujaca zwyciezce

        private void Initializer() 
        {
            MoveList.Clear();
            Winner.Visible = false;
            Winner.Refresh();
            WhoseTurn = true;
            Board = new Block[BPS, BPS];
            Scene.Width = SBW * BPS;
            Scene.Height = SBW * BPS;
            for (int i = 0; i < Board.GetLength(0); ++i)
                for (int j = 0; j < Board.GetLength(1); ++j)
                    Board[i, j] = new Block('N');
            Board[BPS / 2, BPS / 2].Place('W');
            Board[BPS / 2 - 1, BPS / 2].Place('B');
            Board[BPS / 2, BPS / 2 - 1].Place('B');
            Board[BPS / 2 - 1, BPS / 2 - 1].Place('W');
            Scene.Refresh();
        } //kopia konstruktora potrzebna do restartu
    }
}
