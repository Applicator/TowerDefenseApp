using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;

namespace TowerDefense
{

    public partial class TowerDefenseForm : Form
    {
        private const double TOWER_PANEL_BOUNDARY = 0.2;
        private int towerWidth;
        private int towerHeight;

        private PictureBox pBoxTower1;
        private PictureBox pBoxTower1Follower;
        private bool pBoxTower1FollowerEnabled = false;

        private int gameBoardWidth = 0;
        private int towerPanelWidth = 0;

        //private Timer timer;

        public TowerDefenseForm()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();

            //timer = new Timer();
            //timer.Tick += new EventHandler(timer_Tick);
            //timer.Interval = 16;
        }

        private void TowerDefenseForm_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3f(0.0f, 0.0f, 0.0f);
            //simpleOpenGlControl1.BackgroundImage = Image.FromFile("C:\\Users\\Matt Johnson\\Documents\\Visual Studio 2010\\Projects\\TowerDefenseApplication\\WindowsFormsApplication1\\Maps\\second mockup.png");

            //Draw GameBoard graphics
            gameBoardWidth = (int) (simpleOpenGlControl1.Width * (1 - TOWER_PANEL_BOUNDARY));

            GraphicsUtilities.setViewport(0, 0, gameBoardWidth, simpleOpenGlControl1.Height);
            GraphicsUtilities.setWindow(-50, 50, -50, 50);

            //Draw TowerPanel graphics
            towerPanelWidth = simpleOpenGlControl1.Width - gameBoardWidth;

            GraphicsUtilities.setViewport(gameBoardWidth, simpleOpenGlControl1.Height/2, towerPanelWidth, simpleOpenGlControl1.Height/2);
            GraphicsUtilities.setWindow(0, TowerSelectionPanel.TOWER_NUMBER_OF_COLUMNS, 0, TowerSelectionPanel.TOWER_NUMBER_OF_ROWS);

            Gl.glLineWidth(2.0f);
            Gl.glBegin(Gl.GL_LINES);
            {
                for (int row = 0; row <= TowerSelectionPanel.TOWER_NUMBER_OF_ROWS; row++)
                {
                    Gl.glVertex2d(0, row);
                    Gl.glVertex2d(TowerSelectionPanel.TOWER_NUMBER_OF_COLUMNS, row);
                }

                for (int column = 0; column <= TowerSelectionPanel.TOWER_NUMBER_OF_COLUMNS; column++)
                {
                    Gl.glVertex2d(column, 0);
                    Gl.glVertex2d(column, TowerSelectionPanel.TOWER_NUMBER_OF_ROWS);
                }
            } 
            Gl.glEnd();

            pBoxTower1 = createTower1PictureBox(new Point(gameBoardWidth, 0));
            pBoxTower1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBoxTower1_MouseClick);
            simpleOpenGlControl1.Controls.Add(pBoxTower1);
            towerWidth = pBoxTower1.Size.Width;
            towerHeight = pBoxTower1.Size.Height;
        }

        public void fillBeetleList()
        {
            //imageNumber = 0;
            //while (imageNumber <= 150)
            //{
            //    string imageString = imageNumber.ToString();
            //    string originalString = imageNumber.ToString();
            //    for (int i = 4; i >= originalString.Length; i--)
            //    {
            //        imageString = "0" + imageString;
            //    }
            //    beetleImages.Add(Image.FromFile("C:\\Users\\Matt Johnson\\Documents\\Visual Studio 2010\\Projects\\TowerDefenseApplication\\WindowsFormsApplication1\\Beetle\\Comp 1_" + imageString + ".png"));
            //    imageNumber++;
            //}
        }

        public PictureBox createTower1PictureBox(Point point)
        {
            PictureBox pBox = new PictureBox();
            pBox.Image = Image.FromFile("C:\\Users\\Matt Johnson\\Documents\\Visual Studio 2010\\Projects\\TowerDefenseApplication\\WindowsFormsApplication1\\Beetle\\Comp 1_00000.png");
            pBox.Location = point;
            pBox.Size = new Size(towerPanelWidth / TowerSelectionPanel.TOWER_NUMBER_OF_COLUMNS, simpleOpenGlControl1.Height / 2 / TowerSelectionPanel.TOWER_NUMBER_OF_ROWS);
            pBox.SizeMode = PictureBoxSizeMode.StretchImage;
            return pBox;
        }

        private void TowerDefenseForm_Resize(object sender, EventArgs e)
        {
            //GraphicsUtilities.setViewport(0, 0, simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
            Refresh();
        }


        private void simpleOpenGlControl1_MouseClick(object sender, MouseEventArgs e)
        {
            // you clicked on the game board
            if (e.X < gameBoardWidth)
            {
                Console.WriteLine("In gameBoard");
                if (pBoxTower1FollowerEnabled)
                {
                    PictureBox pBoxTower1Placed = createTower1PictureBox(new Point(e.X - pBoxTower1Follower.Size.Width / 2, e.Y - pBoxTower1Follower.Size.Height / 2));
                    simpleOpenGlControl1.Controls.Add(pBoxTower1Placed);
                    pBoxTower1FollowerEnabled = false;
                }
            }
            //you clicked on the the tower panel
            if (e.X > gameBoardWidth)
            {
                Console.WriteLine("In towerPanel");
            }
        }

        private void pBoxTower1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.X + ", " + e.Y);
            if (!pBoxTower1FollowerEnabled)
            {
                pBoxTower1Follower = createTower1PictureBox(new Point(e.X + gameBoardWidth - (towerWidth / 2), e.Y - (towerHeight / 2)));
                simpleOpenGlControl1.Controls.Add(pBoxTower1Follower);
                pBoxTower1FollowerEnabled = true;
                pBoxTower1Follower.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBoxTower1Follower_MouseClick);
                pBoxTower1Follower.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBoxTower1Follower_MouseMove);
            }
        }

        private void pBoxTower1Follower_MouseClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Box Tower MouseCLick");
            //simpleOpenGlControl1_MouseClick(sender,e);
            //if ((e.X < gameBoardWidth) && pBoxTower1FollowerEnabled)
            //{
            //    PictureBox pBoxTower1Placed = createTower1PictureBox(new Point(e.X - (pBoxTower1Follower.Size.Width / 2), e.Y - (pBoxTower1Follower.Size.Height / 2)));
            //    simpleOpenGlControl1.Controls.Add(pBoxTower1Placed);
            //    pBoxTower1FollowerEnabled = false;
            //}
        }

        private void pBoxTower1Follower_MouseMove(object sender, MouseEventArgs e)
        {
            pBoxTower1Follower.Location = new Point(e.X + gameBoardWidth - (towerWidth / 2), e.Y - (towerHeight / 2));
        }

        private void simpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pBoxTower1FollowerEnabled)
            {
                pBoxTower1Follower.Location = new Point(e.X - pBoxTower1Follower.Size.Width / 2, e.Y - pBoxTower1Follower.Size.Height / 2);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //imageNumber = (imageNumber + 1) % 151;
            //string imageString = imageNumber.ToString();
            //for (int i = 4; i >= imageString.Length; i--)
            //{
            //    imageString = "0" + imageString;
            //}
            //for (int i = 0; i < multipleBeetles.Count; i++)
            //{
            //    multipleBeetles[i].Image = beetleImages[imageNumber];
            //}
            //Refresh();
        }
    }
}
