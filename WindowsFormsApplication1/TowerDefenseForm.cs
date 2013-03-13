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

        private PictureBox pBoxTower1;

        private int gameBoardWidth;
        private int gameBoardHeight;
        private int towerPanelWidth;
        private int towerPanelHeight;

        //private Timer timer;
        private const int FRAMES_PER_SECOND = 30;

        private Beetle beetle;

        public TowerDefenseForm()
        {
            InitializeComponent();

            beetle = new Beetle();

            gameBoardWidth = this.Height;
            gameBoardHeight = this.Height;
            towerPanelWidth = this.Width - gameBoardWidth;
            towerPanelHeight = this.Height;

            //timer = new Timer();
            //timer.Tick += new EventHandler(timer_Tick);
            timer1.Interval = 1000 / FRAMES_PER_SECOND;
            timer1.Start();

            timer2.Interval = 1000 / FRAMES_PER_SECOND;
            timer2.Start();

            //this.BackgroundImage = Image.FromFile(@"C:\Users\Matt Johnson\Documents\Visual Studio 2010\Projects\TowerDefenseApplication\WindowsFormsApplication1\Maps\second mockup.png");

            pBoxTower1 = createTower1PictureBox(new Point(0, gameBoardHeight / 2));
            this.Controls.Add(pBoxTower1);
            //this.DoubleBuffered = true;
        }

        private void TowerDefenseForm_Paint(object sender, PaintEventArgs e)
        {
            //Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            //Gl.glColor3f(0.0f, 0.0f, 0.0f);
            //simpleOpenGlControl1.BackgroundImage = Image.FromFile("C:\\Users\\Matt Johnson\\Documents\\Visual Studio 2010\\Projects\\TowerDefenseApplication\\WindowsFormsApplication1\\Maps\\second mockup.png");

            //Draw GameBoard graphics

            //GraphicsUtilities.setViewport(0, 0, this.Height, this.Height);
            //GraphicsUtilities.setWindow(-50, 50, -50, 50);

            //Draw TowerPanel graphics
            //towerPanelWidth = this.Width - gameBoardWidth;

            //GraphicsUtilities.setViewport(gameBoardWidth, this.Height/2, towerPanelWidth, this.Height/2);
            //GraphicsUtilities.setWindow(0, TowerSelectionPanel.TOWER_NUMBER_OF_COLUMNS, 0, TowerSelectionPanel.TOWER_NUMBER_OF_ROWS);

            //Gl.glLineWidth(2.0f);
            //Gl.glBegin(Gl.GL_LINES);
            //{
            //    for (int row = 0; row <= TowerSelectionPanel.TOWER_NUMBER_OF_ROWS; row++)
            //    {
            //        Gl.glVertex2d(0, row);
            //        Gl.glVertex2d(TowerSelectionPanel.TOWER_NUMBER_OF_COLUMNS, row);
            //    }

            //    for (int column = 0; column <= TowerSelectionPanel.TOWER_NUMBER_OF_COLUMNS; column++)
            //    {
            //        Gl.glVertex2d(column, 0);
            //        Gl.glVertex2d(column, TowerSelectionPanel.TOWER_NUMBER_OF_ROWS);
            //    }
            //} 
            //Gl.glEnd();
        }

        public PictureBox createTower1PictureBox(Point point)
        {
            PictureBox pBox = new PictureBox();
            //path should be relative
            pBox.Image = Image.FromFile(@"C:\Users\Matt Johnson\Documents\Visual Studio 2010\Projects\TowerDefenseApplication\WindowsFormsApplication1\Beetle\BeetleOpeningWings00000.png");
            pBox.Location = point;
            pBox.Size = new Size(Enemy.ANIMATION_WIDTH, Enemy.ANIMATION_HEIGHT);
            pBox.SizeMode = PictureBoxSizeMode.StretchImage;
            return pBox;
        }

        private void simpleOpenGlControl1_MouseClick(object sender, MouseEventArgs e)
        {
            // you clicked on the game board
            if (e.X < gameBoardWidth)
            {
                Console.WriteLine("In gameBoard");
            }
            //you clicked on the the tower panel
            if (e.X > gameBoardWidth)
            {
                Console.WriteLine("In towerPanel");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            beetle.CurrentAnimationPicture = (beetle.CurrentAnimationPicture + 2) % beetle.AnimationPictureNumber;
            pBoxTower1.Image = beetle.Animation[beetle.CurrentAnimationPicture];
            //Point currentLocation = pBoxTower1.Location;
            //pBoxTower1.Location = new Point(currentLocation.X + 3, currentLocation.Y);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Point currentLocation = pBoxTower1.Location;
            pBoxTower1.Location = new Point(currentLocation.X + 1, currentLocation.Y);
            Invalidate();
        }

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    beetle.CurrentAnimationPicture = (beetle.CurrentAnimationPicture + 2) % beetle.AnimationPictureNumber;
        //    pBoxTower1.Image = beetle.Animation[beetle.CurrentAnimationPicture];
        //    //pBoxTower1.Location = new Point(pBoxTower1.Location.X + 1, pBoxTower1.Location.Y);
        //}

    }
}
