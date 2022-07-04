using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace SharpMario
{
    public partial class lvl1 : Form
    {
        public lvl1()
        {
            InitializeComponent();
        }

        bool Right, Left, Jump;
        int speed = 3;
        int force = 0;
        int jumpSpeed = 0;
        bool playerIsSmall = true;
        bool mushroom1move = false;
        bool mushroom1down = false;
        bool canmovearea = false;
        DateTime _lastCheckTime = DateTime.Now;
        long _frameCount = 0;
        bool mariodied = false;
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        private void lvl1_Load(object sender, EventArgs e)
        {
            mario.Image = Image.FromFile(@"assets\original\characters\sRmarioidle.png");
            axWindowsMediaPlayer1.URL = @"assets\original\sounds\lvl1.wav";
            axWindowsMediaPlayer1.settings.playCount = 9999;
            axWindowsMediaPlayer1.Visible = false;
            mistery1.Image = Image.FromFile(@"assets\original\lvl1\Question Block.gif");
            mistery2.Image = Image.FromFile(@"assets\original\lvl1\Question Block.gif");
            mistery3.Image = Image.FromFile(@"assets\original\lvl1\Question Block.gif");
            mistery4.Image = Image.FromFile(@"assets\original\lvl1\Question Block.gif");
            coin1.Image = Image.FromFile(@"assets\original\lvl1\mario-coin.gif");
            coin3.Image = Image.FromFile(@"assets\original\lvl1\mario-coin.gif");
            coin4.Image = Image.FromFile(@"assets\original\lvl1\mario-coin.gif");
            coin5.Image = Image.FromFile(@"assets\original\lvl1\mario-coin.gif");
            brick1.Image = Image.FromFile(@"assets\original\lvl1\breakable.png");
            brick2.Image = Image.FromFile(@"assets\original\lvl1\breakable.png");
            brick3.Image = Image.FromFile(@"assets\original\lvl1\breakable.png");
            mushroom1.Image = Image.FromFile(@"assets\original\mushroompick.png");
            bg.Image = Image.FromFile(@"assets\original\lvl1\background.png");
            mario.BackColor = Color.Transparent;
        }
        double GetFps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            long count = Interlocked.Exchange(ref _frameCount, 0);
            double fps = count / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            double fpsrounded = Math.Round(fps, 0);
            fpsLbl.Text = $"{fpsrounded}";
            return fps;
        }
        bool playerjumpedgoomba1 = false;
        bool mushroomdontjump = false;
        int mariosize = 0;
        private void move_Tick(object sender, EventArgs e)
        {
            if (playerjumpedgoomba1 == false)
            {
                goomba1.Location = new Point(goomba1.Location.X - 1, goomba1.Location.Y);
                goomba1head.Location = new Point(goomba1head.Location.X - 1, goomba1head.Location.Y);
                goomba1enemy.Location = new Point(goomba1enemy.Location.X - 1, goomba1enemy.Location.Y);
            }
            Interlocked.Increment(ref _frameCount);
            GetFps();
            mario.Top += jumpSpeed;
            if (Left == true && mario.Left > 5)
            {
                mario.Left -= speed;
                scrollgame("back");
            }
            if (Right == true)
            {
                scrollgame("forward");
                if (mario.Left < 500)
                {
                    mario.Left += speed;
                }
            }
            if (Jump == true && force < 0)
            {
                Jump = false;
            }
            if (Jump == true)
            {
                jumpSpeed = -7;
                force -= 1;
            }
            else
            {
                jumpSpeed = 7;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform" && mariodied == false)
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 20;
                            mario.Top = x.Top - mario.Height;
                            godown.Stop();
                            brick1.Location = new Point(brick1.Location.X, 277);
                            brick2.Location = new Point(brick2.Location.X, 277);
                            brick3.Location = new Point(brick3.Location.X, 277);
                            brick4.Location = new Point(brick4.Location.X, 277);
                            brick5.Location = new Point(brick5.Location.X, 277);
                            brick6.Location = new Point(brick6.Location.X, 139);
                            brick7.Location = new Point(brick7.Location.X, 139);
                            brick8.Location = new Point(brick8.Location.X, 139);
                            brick9.Location = new Point(brick9.Location.X, 139);
                            mistery1.Location = new Point(mistery1.Location.X, 277);
                            mistery2.Location = new Point(mistery2.Location.X, 277);
                            mistery3.Location = new Point(mistery3.Location.X, 277);
                            mistery4.Location = new Point(mistery4.Location.X, 161);
                            mistery5.Location = new Point(mistery5.Location.X, 277);
                        }
                        //x.BringToFront();
                    }
                    if (playerIsSmall == true)
                    {
                        if ((string)x.Tag == "brick1")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                                bump.Play();
                                while (brick1.Location.Y > 263)
                                {
                                    brick1.Location = new Point(brick1.Location.X, brick1.Location.Y - 1);
                                }
                                godown.Start();
                            }
                        }
                        if ((string)x.Tag == "brick2")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                                bump.Play();
                                while (brick2.Location.Y > 263)
                                {
                                    brick2.Location = new Point(brick2.Location.X, brick2.Location.Y - 1);
                                }
                                godown.Start();
                            }
                        }
                        if ((string)x.Tag == "brick3")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                                bump.Play();
                                while (brick3.Location.Y > 263)
                                {
                                    brick3.Location = new Point(brick3.Location.X, brick3.Location.Y - 1);
                                }
                                godown.Start();
                            }
                        }
                        if ((string)x.Name == "brick4cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                                bump.Play();
                                while (brick4.Location.Y > 263)
                                {
                                    brick4.Location = new Point(brick4.Location.X, brick4.Location.Y - 1);
                                }
                                godown.Start();
                            }
                        }
                        if ((string)x.Name == "brick5cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                                bump.Play();
                                while (brick5.Location.Y > 263)
                                {
                                    brick5.Location = new Point(brick5.Location.X, brick5.Location.Y - 1);
                                }
                                godown.Start();
                            }
                        }
                        if ((string)x.Name == "brick6cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                                bump.Play();
                                while (brick6.Location.Y > 125)
                                {
                                    brick6.Location = new Point(brick6.Location.X, brick6.Location.Y - 1);
                                }
                                godown.Start();
                            }
                        }
                        if ((string)x.Name == "brick7cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                                bump.Play();
                                while (brick7.Location.Y > 125)
                                {
                                    brick7.Location = new Point(brick7.Location.X, brick7.Location.Y - 1);
                                }
                                godown.Start();
                            }
                        }
                        if ((string)x.Name == "brick8cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                                bump.Play();
                                while (brick8.Location.Y > 125)
                                {
                                    brick8.Location = new Point(brick8.Location.X, brick8.Location.Y - 1);
                                }
                                godown.Start();
                            }
                        }
                        if ((string)x.Name == "brick9cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                                bump.Play();
                                while (brick9.Location.Y > 125)
                                {
                                    brick9.Location = new Point(brick9.Location.X, brick9.Location.Y - 1);
                                }
                                godown.Start();
                            }
                        }
                    }
                    if(playerIsSmall == false)
                    {
                        if ((string)x.Tag == "brick1")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_breakblock.wav");
                                bump.Play();
                                brick1.Location = new Point(-100, -100);
                                pictureBox98.Location = new Point(-100, -100);
                                pl1.Location = new Point(-100, -100);
                                godown.Start();
                            }
                        }
                        if ((string)x.Tag == "brick2")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_breakblock.wav");
                                bump.Play();
                                brick2.Location = new Point(-100, -100);
                                pictureBox102.Location = new Point(-100, -100);
                                pl2.Location = new Point(-100, -100);
                                godown.Start();
                            }
                        }
                        if ((string)x.Tag == "brick3")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_breakblock.wav");
                                bump.Play();
                                brick3.Location = new Point(-100, -100);
                                pictureBox103.Location = new Point(-100, -100);
                                pl3.Location = new Point(-100, -100);
                                godown.Start();
                            }
                        }
                        if ((string)x.Name == "brick4cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_breakblock.wav");
                                bump.Play();
                                brick4cl.Location = new Point(-100, -100);
                                godown.Start();
                                brick4.Visible = false;
                                pl4.Location = new Point(-100, -100);
                            }
                        }
                        if ((string)x.Name == "brick5cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_breakblock.wav");
                                bump.Play();
                                brick5cl.Location = new Point(-100, -100);
                                godown.Start();
                                brick5.Visible = false;
                                pl5.Location = new Point(-100, -100);
                            }
                        }
                        if ((string)x.Name == "brick6cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_breakblock.wav");
                                bump.Play();
                                brick6cl.Location = new Point(-100, -100);
                                godown.Start();
                                brick6.Visible = false;
                                pl6.Location = new Point(-100, -100);
                            }
                        }
                        if ((string)x.Name == "brick7cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_breakblock.wav");
                                bump.Play();
                                brick7cl.Location = new Point(-100, -100);
                                godown.Start();
                                brick7.Visible = false;
                                pl7.Location = new Point(-100, -100);
                            }
                        }
                        if ((string)x.Name == "brick8cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_breakblock.wav");
                                bump.Play();
                                brick8cl.Location = new Point(-100, -100);
                                godown.Start();
                                brick8.Visible = false;
                                pl8.Location = new Point(-100, -100);
                            }
                        }
                        if ((string)x.Name == "brick9cl")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_breakblock.wav");
                                bump.Play();
                                brick9cl.Location = new Point(-100, -100);
                                godown.Start();
                                brick9.Visible = false;
                                pl9.Location = new Point(-100, -100);
                            }
                        }
                    }
                    if ((string)x.Tag == "godown")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                            bump.Play();
                            while (mistery1.Location.Y > 263)
                            {
                                mistery1.Location = new Point(mistery1.Location.X, mistery1.Location.Y - 1);
                            }
                            godown.Start();
                        }
                    }
                    if ((string)x.Tag == "godownms2")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                            bump.Play();
                            while (mistery2.Location.Y > 263)
                            {
                                mistery2.Location = new Point(mistery2.Location.X, mistery2.Location.Y - 1);
                            }
                            godown.Start();
                        }
                    }
                    if ((string)x.Tag == "godownms3")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                            bump.Play();
                            while (mistery3.Location.Y > 263)
                            {
                                mistery3.Location = new Point(mistery3.Location.X, mistery3.Location.Y - 1);
                            }
                            godown.Start();
                        }
                    }
                    if ((string)x.Tag == "godownms4")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                            bump.Play();
                            while (mistery4.Location.Y > 145)
                            {
                                mistery4.Location = new Point(mistery4.Location.X, mistery4.Location.Y - 1);
                            }
                            godown.Start();
                        }
                    }
                    if ((string)x.Name == "godown5")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer bump = new SoundPlayer(@"assets\original\sounds\smb_bump.wav");
                            bump.Play();
                            while (mistery5.Location.Y > 263)
                            {
                                mistery5.Location = new Point(mistery5.Location.X, mistery5.Location.Y - 1);
                            }
                            godown.Start();
                        }
                    }
                    if ((string)x.Tag == "mistery1")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer coin = new SoundPlayer(@"assets\original\sounds\coin.wav");
                            coin.Play();
                            mistery1.Image = Image.FromFile(@"assets\original\lvl1\mistery_used.png");
                            godown.Start();
                            coin1.Visible = true;
                            pictureBox97.Location = new Point(0, 0);
                            coinAnim.Start();
                        }
                    }
                    if ((string)x.Tag == "mistery2")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer powerup = new SoundPlayer(@"assets\original\sounds\smb_powerup_appears.wav");
                            powerup.Play();
                            mistery2.Image = Image.FromFile(@"assets\original\lvl1\mistery_used.png");
                            godown.Start();
                            mushroom1.Visible = true;
                            pictureBox101.Location = new Point(0, 0);
                            coinAnim.Start();
                            coinint = 0;
                        }
                    }
                    if ((string)x.Tag == "mistery3")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer coin = new SoundPlayer(@"assets\original\sounds\coin.wav");
                            coin.Play();
                            mistery3.Image = Image.FromFile(@"assets\original\lvl1\mistery_used.png");
                            godown.Start();
                            coin3.Visible = true;
                            pictureBox110.Location = new Point(0, 0);
                            coinAnim.Start();
                        }
                    }
                    if ((string)x.Tag == "mistery4")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer coin = new SoundPlayer(@"assets\original\sounds\coin.wav");
                            coin.Play();
                            mistery4.Image = Image.FromFile(@"assets\original\lvl1\mistery_used.png");
                            godown.Start();
                            coin4.Visible = true;
                            pictureBox100.Location = new Point(0, 0);
                            coinAnim.Start();
                        }
                    }
                    if ((string)x.Name == "mistery5cl")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer coin = new SoundPlayer(@"assets\original\sounds\coin.wav");
                            coin.Play();
                            mistery5.Image = Image.FromFile(@"assets\original\lvl1\mistery_used.png");
                            godown.Start();
                            coin5.Visible = true;
                            mistery5cl.Location = new Point(0, 0);
                            coinAnim.Start();
                        }
                    }
                    if ((string)x.Name == "goomba1head")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer coin = new SoundPlayer(@"assets\original\sounds\smb_stomp.wav");
                            coin.Play();
                            goomba1.Image = Image.FromFile(@"assets\original\enemys\Goomba3.png");
                            goomba1head.Location = new Point(0, 0);
                            playerjumpedgoomba1 = true;
                            mario.Location = new Point(mario.Location.X, mario.Location.Y - 30);
                            goombadis.Start();
                            goomba1enemy.Location = new Point(0, 0);
                            coinAnim.Start();
                            getscore = 100;
                        }
                    }
                    if ((string)x.Name == "goomba1enemy")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            //SoundPlayer coin = new SoundPlayer(@"assets\original\sounds\smb_mariodie.wav");
                            //coin.Play();
                            goomba1enemy.Location = new Point(0, 0);
                            axWindowsMediaPlayer1.URL = (@"assets\original\sounds\smb_mariodie.wav");
                            axWindowsMediaPlayer1.settings.playCount = 1;
                            mario.Image = Image.FromFile(@"assets\original\characters\mariodie.png");
                            mario.Location = new Point(mario.Location.X, mario.Location.Y - 30);
                            mariodied = true;
                            animation.Interval = 10;
                            SendKeys.Send("{LEFT}");
                        }
                    }
                    if ((string)x.Name == "mariodead1")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            //SoundPlayer coin = new SoundPlayer(@"assets\original\sounds\smb_mariodie.wav");
                            //coin.Play();
                            mariodead1.Location = new Point(0, 0);
                            axWindowsMediaPlayer1.URL = (@"assets\original\sounds\smb_mariodie.wav");
                            axWindowsMediaPlayer1.settings.playCount = 1;
                            mario.Image = Image.FromFile(@"assets\original\characters\mariodie.png");
                            mario.Location = new Point(mario.Location.X, mario.Location.Y - 30);
                            mariodied = true;
                            animation.Interval = 10;
                            SendKeys.Send("{LEFT}");
                        }
                    }
                        if ((string)x.Name == "mariodead2")
                        {
                            if (mario.Bounds.IntersectsWith(x.Bounds))
                            {
                                //SoundPlayer coin = new SoundPlayer(@"assets\original\sounds\smb_mariodie.wav");
                                //coin.Play();
                                mariodead2.Location = new Point(0, 0);
                                axWindowsMediaPlayer1.URL = (@"assets\original\sounds\smb_mariodie.wav");
                                axWindowsMediaPlayer1.settings.playCount = 1;
                                mario.Image = Image.FromFile(@"assets\original\characters\mariodie.png");
                                mario.Location = new Point(mario.Location.X, mario.Location.Y - 30);
                                mariodied = true;
                                animation.Interval = 10;
                                SendKeys.Send("{LEFT}");
                            }
                        }
                    if ((string)x.Name == "mushroom1")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            SoundPlayer coin = new SoundPlayer(@"assets\original\sounds\smb_powerup.wav");
                            coin.Play();
                            mushroom1.Location = new Point(0, 0);
                            mushroom1.Visible = false;
                            mushroommove.Stop();
                            mario.Size = new Size(36, 50);
                            mariosizer.Start();
                            playerIsSmall = false;
                            }
                    }
                    if ((string)x.Tag == "destroy")
                    {
                        if (mistery1.Bounds.IntersectsWith(x.Bounds))
                        {
                            mistery1.Image.Dispose();
                            mistery1.Location = new Point(-1000, -1000);
                            mistery1.Image = null;
                            mistery1.Visible = false;
                        }
                        if (mistery2.Bounds.IntersectsWith(x.Bounds))
                        {
                            mistery2.Image.Dispose();
                            mistery2.Location = new Point(-1000, -1000);
                            mistery2.Image = null;
                            mistery2.Visible = false;
                        }
                        if (mistery3.Bounds.IntersectsWith(x.Bounds))
                        {
                            mistery3.Image.Dispose();
                            mistery3.Location = new Point(-1000, -1000);
                            mistery3.Image = null;
                            mistery3.Visible = false;
                        }
                        if (mistery4.Bounds.IntersectsWith(x.Bounds))
                        {
                            mistery4.Image.Dispose();
                            mistery4.Location = new Point(-1000, -1000);
                            mistery4.Image = null;
                            mistery4.Visible = false;
                        }
                        if (brick1.Bounds.IntersectsWith(x.Bounds))
                        {
                            brick1.Image.Dispose();
                            brick1.Location = new Point(-1000, -1000);
                            brick1.Image = null;
                            brick1.Visible = false;
                        }
                        if (brick2.Bounds.IntersectsWith(x.Bounds))
                        {
                            brick2.Image.Dispose();
                            brick2.Location = new Point(-1000, -1000);
                            brick2.Image = null;
                            brick2.Visible = false;
                        }
                        if (brick3.Bounds.IntersectsWith(x.Bounds))
                        {
                            brick3.Image.Dispose();
                            brick3.Location = new Point(-1000, -1000);
                            brick3.Image = null;
                            brick3.Visible = false;
                        }
                        if (brick4.Bounds.IntersectsWith(x.Bounds))
                        {
                            brick4.Image.Dispose();
                            brick4.Location = new Point(-1000, -1000);
                            brick4.Image = null;
                            brick4.Visible = false;
                        }
                        if (mushroom1.Bounds.IntersectsWith(x.Bounds))
                        {
                            mushroom1.Image.Dispose();
                            mushroom1.Location = new Point(-1000, -1000);
                            mushroom1.Image = null;
                            mushroom1.Visible = false;
                            mushroommove.Stop();
                        }
                        if (goomba1.Bounds.IntersectsWith(x.Bounds))
                        {
                            goomba1.Image.Dispose();
                            goomba1.Location = new Point(-1000, -1000);
                            goomba1.Image = null;
                            goomba1.Visible = false;
                        }
                    }
                    if ((string)x.Name == "powerupdown")
                    {
                        if (mushroom1.Bounds.IntersectsWith(x.Bounds))
                        {
                            mushroom1down = true;
                        }
                    }
                    if ((string)x.Name == "wall")
                    {
                        if (mushroom1.Bounds.IntersectsWith(x.Bounds))
                        {
                            mushroomright = false;
                        }
                    }
                    if ((string)x.Tag == "movearea")
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds))
                        {
                            canmovearea = true;
                        }
                    }
                }
            }
        }
        private void scrollgame(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "platform" || (x is PictureBox && (string)x.Tag == "decor") || (x is PictureBox && (string)x.Tag == "mistery1") || (x is PictureBox && (string)x.Tag == "godown") || (x is PictureBox && (string)x.Tag == "element") || 
                    (x is PictureBox && (string)x.Tag == "mistery2") || (x is PictureBox && (string)x.Tag == "godownms2") || (x is PictureBox && (string)x.Tag == "element") ||
                    (x is PictureBox && (string)x.Tag == "element") || (x is PictureBox && (string)x.Tag == "mistery3") || (x is PictureBox && (string)x.Tag == "godownms3") || (x is PictureBox && (string)x.Tag == "brick1") ||
                    (x is PictureBox && (string)x.Tag == "brick2") || (x is PictureBox && (string)x.Tag == "brick3") || (x is PictureBox && (string)x.Tag == "godownms4") || (x is PictureBox && (string)x.Tag == "mistery4"))
                {
                    if(direction == "forward")
                    {
                        if (canmovearea == true)
                        {
                            x.Left -= 4;
                        }
                    }
                    if (direction == "back")
                    {
                        canmovearea = false;
                    }
                }
            }
        }
        private void lvl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void anims_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }
        int mariofly = 0;
        private void animation_Tick(object sender, EventArgs e)
        {
            if(Right == true && mariodied == false)
            {
                animation.Interval = 1500;
                mario.Image = Image.FromFile(@"assets\original\characters\sRmairomove.gif");
            }
            if (Left == true && mariodied == false)
            {
                animation.Interval = 1500;
                mario.Image = Image.FromFile(@"assets\original\characters\sLmairomove.gif");
            }
            if(mariodied == true)
            {
                mario.Location = new Point(mario.Location.X, mario.Location.Y - 10);
                animation.Interval = 10;
                Right = false;
                Left = false;
                Jump = false;
                mariofly++;
            }
            if(mariofly >= 50)
            {
                mario.Location = new Point(mario.Location.X, mario.Location.Y + 10);
            }
            if (mariofly >= 200)
            {
                mariofly = 0;
                animation.Stop();
                this.Dispose(); this.Close();
                lvl1 lvl1form = new lvl1();
                lvl1form.ShowDialog();
            }
        }

        private void godown_Tick(object sender, EventArgs e)
        {
            jumpSpeed = 7;
        }
        int coinint = 0;
        int scorenm = 0;
        int getscore = 0;
        private void coinAnim_Tick(object sender, EventArgs e)
        {
            coinint++;
            if (coinint <= 10)
            {
                score.Location = new Point(mario.Location.X + 20, mario.Location.Y - 10);
                if(coin1.Visible == true)
                { coin1.Location = new Point(coin1.Location.X, coin1.Location.Y - 5); getscore = 200; }
                if(coin3.Visible == true)
                { coin3.Location = new Point(coin3.Location.X, coin3.Location.Y - 5); getscore = 200; }
                if(coin4.Visible == true)
                { coin4.Location = new Point(coin4.Location.X, coin4.Location.Y - 5); getscore = 200; }
                if(coin5.Visible == true)
                { coin5.Location = new Point(coin5.Location.X, coin5.Location.Y - 5); getscore = 200; }
                if (mushroom1.Location.Y > 254 && mushroom1.Visible == true && mushroomdontjump == false)
                {
                    mushroom1.Location = new Point(mushroom1.Location.X, mushroom1.Location.Y - 4);
                }
            }
            if(coinint >= 20)
            {
                if (coin1.Visible == true)
                { coin1.Location = new Point(coin1.Location.X, coin1.Location.Y + 5); }
                if (coin3.Visible == true)
                { coin3.Location = new Point(coin3.Location.X, coin3.Location.Y + 5); }
                if (coin4.Visible == true)
                { coin4.Location = new Point(coin4.Location.X, coin4.Location.Y + 5); }
                if (coin5.Visible == true)
                { coin5.Location = new Point(coin5.Location.X, coin5.Location.Y + 5); }
                score.Text = $"{getscore}";
                score.Visible = true;
                if (score.Visible == true)
                { score.Location = new Point(score.Location.X, score.Location.Y - 5); }
            }
            if(coinint >= 30)
            {
                coinint = 0;
                coinAnim.Stop();
                coin1.Visible = false;
                score.Visible = false;
                coin3.Visible = false;
                coin4.Visible = false;
                coin5.Visible = false;
                if(mushroom1.Location.Y == 253)
                {
                    mushroom1move = true;
                    mushroommove.Start();
                }
            }
        }
        bool mushroomright = true;
        private void mushroommove_Tick(object sender, EventArgs e)
        {
         if(mushroom1move == true && mushroomright == true)
            {
               mushroom1.Location = new Point(mushroom1.Location.X + 1, mushroom1.Location.Y);
            }
            if (mushroom1move == true && mushroomright == false)
            {
                mushroom1.Location = new Point(mushroom1.Location.X + -1, mushroom1.Location.Y);
            }
            if (mushroom1down == true && mushroom1.Location.Y != 376)
            {
                mushroom1.Location = new Point(mushroom1.Location.X, mushroom1.Location.Y + 3);
            }
            if(mushroom1.Location.Y  >= 376)
            {
                mushroomdontjump = true;
            }
        }

        private void lvl1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void bg_Click(object sender, EventArgs e)
        {

        }
        int goombadestroy = 0;
        private void goombadis_Tick(object sender, EventArgs e)
        {
            goombadestroy++;
            if(goombadestroy == 1)
            {
                if(playerjumpedgoomba1 == true)
                {
                    goomba1.Visible = false;
                    goombadis.Stop();
                }
            }

        }

        private void mariosizer_Tick(object sender, EventArgs e)
        {
            mariosize++;
            if(mariosize <= 1)
            {
                mario.Image = Image.FromFile(@"assets\original\characters\marioup.gif");
            }
            if(mariosize > 20)
            {
                mario.Image = Image.FromFile(@"assets\original\characters\bRmarioidle.png");
                mariosizer.Stop();
                mariosize = 0;
            }
        }

        private void lvl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                Left = true;
                animation.Start();
            }
            if (e.KeyCode == Keys.Right)
            {
                Right = true;
                animation.Start();
            }
            if (e.KeyCode == Keys.Space || (e.KeyCode == Keys.LControlKey) && Jump == false)
            {
                if (playerIsSmall == true)
                {
                    Jump = true;
                    SoundPlayer jump = new SoundPlayer(@"assets\original\sounds\jump.wav");
                    jump.Play();
                }
                if(playerIsSmall == false)
                {
                    Jump = true;
                    SoundPlayer jump = new SoundPlayer(@"assets\original\sounds\smb_jump-super.wav");
                    jump.Play();
                }
            }
            else
            {
            }
        }

        private void lvl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && mariodied == false)
            {
                Left = false;
                animation.Stop();
                animation.Interval = 1;
                mario.Image = Image.FromFile(@"assets\original\characters\sLmarioidle.png");
            }
            if (e.KeyCode == Keys.Right && mariodied == false)
            {
                Right = false;
                animation.Stop();
                animation.Interval = 1;
                mario.Image = Image.FromFile(@"assets\original\characters\sRmarioidle.png");
            }
            if (e.KeyCode == Keys.Space || (e.KeyCode == Keys.LControlKey))
            {
                Jump = false;
            }
        }
    }
}
