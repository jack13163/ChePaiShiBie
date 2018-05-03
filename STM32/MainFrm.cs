using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM32
{
    public partial class MainFrm : Form
    {
        private string filename = "";
        Image img = null;

        public MainFrm()
        {
            InitializeComponent();
        }

        //保存图片
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //生成时间戳
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                string time = Convert.ToInt64(ts.TotalSeconds).ToString();
                this.pbToRec.Image.Save(@"C:\Users\Administrator\Desktop\F" + time + ".bmp");
                MessageBox.Show("图片成功保存到桌面！");
            }
        }

        //输出指定信息到文本文件
        public void WriteMessage(string msg)
        {
            using (FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\log" + ".txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine("{0}\n", msg, DateTime.Now);
                    sw.Flush();
                }
            }
        }

        ///获取时间戳
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileopen = new OpenFileDialog();

            fileopen.Filter = "位图文件|*.bmp";

            if (DialogResult.OK == fileopen.ShowDialog())
            {
                filename = fileopen.FileName;
                img = Image.FromFile(filename);
                this.pbToRec.Width = img.Width;
                this.pbToRec.Height = img.Height;
                this.pbToRec.Image = img;
            }
        }

        private void btnGraying_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.Graying(bmp);
            }
        }

        private void btnSmoothing_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.Smoothing(bmp);
            }
        }

        private void btnMeaning_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.Meaning(bmp);
            }
        }

        private void btnGuass_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.Guassing(bmp);
            }
        }

        private void btnGrayReverse_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.GrayReverse(bmp);
            }
        }

        private void btnBinary_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.Binary(bmp);
            }
        }

        private void btnEdging_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.Edging(bmp);
            }
        }

        private void btnOstu_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.Ostu(bmp);
            }
        }

        private void btnErosion_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.Erosion(bmp);
            }
        }

        private void btnDilation_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                //设置显示的内容
                this.pbToRec.Image = ImageProcess.Dilation(bmp);
            }
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                this.pbToRec.Image = ImageProcess.OpenOperate(bmp);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                this.pbToRec.Image = ImageProcess.CloseOperate(bmp);
            }
        }

        //车牌定位
        private void btnLocation_Click(object sender, EventArgs e)
        {
            if (null != this.pbToRec.Image)
            {
                //创建位图副本
                Bitmap bmp = (Bitmap)this.pbToRec.Image.Clone();

                int height = bmp.Height;
                int width = bmp.Width;

                int PF = int.Parse(this.txtPointCount.Text.Trim());//行跳变点阀值
                int fa = int.Parse(this.txtInnerPointCount.Text.Trim());//矩形框跳变点阀值
                int LF = int.Parse(this.txtLineCount.Text.Trim());//连续行数阀值
                int kfa = int.Parse(this.txtKCount.Text.Trim()); ;//连续框数阀值
                int windowsWidth = int.Parse(this.txtStepWidth.Text.Trim()); ;//粗定位时的步长

                int flag = 0;//是否为起点
                int skipcount = 0;//跳变点计数
                byte[] lines = new byte[height];//标记该行是否为可能的车牌区域
                int[] kflag = new int[width - windowsWidth];//标记该框是否为可能的车牌区域
                int start = 0;//开始行
                int end = 0;//结束行
                int startpoint = 0;//框开始点
                int endpoint = 0;//框结束点
                int linecount = 0;//连续行数累计
                int kcount = 0;//连续可能的区域框的累计

                //日志写入
                FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\log" + ".txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);

                sw.WriteLine("输出跳变点大于{0}（阀值）的行信息：\n", PF);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width - 1; j++)
                    {
                        //统计各行的跳变点个数
                        if ((bmp.GetPixel(j, i).R == 0 && bmp.GetPixel(j + 1, i).R == 255) || (bmp.GetPixel(j, i).R == 255 && bmp.GetPixel(j + 1, i).R == 0))
                        {
                            skipcount++;
                        }
                    }
                    //当跳变点小于阀值时，暂定为车牌候选区域
                    if (skipcount >= PF)
                    {
                        sw.WriteLine("第{0}行跳变点个数为：{1}\n", i + 1, skipcount);
                        lines[i] = 1;
                    }
                    skipcount = 0;
                }

                //统计连续有标志的行数，若行数大于某一阀值，则为车牌区域
                for (int i = 0; i < height; i++)
                {
                    //统计连续的行数
                    if (lines[i] == 1)
                    {
                        linecount++;
                        if (flag == 0)//第一次的时候记下起始位置
                        {
                            start = i;
                            flag = 1;
                        }
                    }
                    else if (linecount >= LF)//行数大于阀值，为候选区域
                    {
                        end = i;
                        break;
                    }
                    else//行数小于阀值，不是候选区域
                    {
                        start = 0;
                        flag = 0;
                        linecount = 0;//重新选择
                    }
                }
                sw.WriteLine("输出宽：{0}，高：{1}的矩形区域的跳变点大于{2}（阀值）的窗口信息：\n", windowsWidth, end - start, fa);

                skipcount = 0;

                //粗定位
                for (int k = 0; k < width - windowsWidth; k++)//矩形框从左往右不断移动
                {
                    for (int j = start; j < end; j++)//纵坐标
                    {
                        for (int i = k; i < k + windowsWidth - 1; i++)//横坐标
                        {
                            if ((bmp.GetPixel(i, j).R == 0 && bmp.GetPixel(i + 1, j).R == 255) || (bmp.GetPixel(i, j).R == 255 && bmp.GetPixel(i + 1, j).R == 0))
                            {
                                skipcount++;
                            }
                        }
                    }
                    if (skipcount >= fa)
                    {
                        sw.WriteLine("第{0}个：左上角坐标：（{1},{2}）的矩形框内跳变点个数为：{3}\n", k + 1, k, start, skipcount);
                        kflag[k] = 1;
                    }
                    skipcount = 0;//重新统计
                }

                flag = 0;//重置开始标志，开始左右边界检测
                //统计连续可能的框的个数，若行数大于某一阀值，则为车牌区域
                for (int i = 0; i < width - windowsWidth; i++)
                {
                    //统计连续的框数
                    if (kflag[i] == 1)
                    {
                        kcount++;
                        if (flag == 0)//第一次的时候记下起始位置
                        {
                            startpoint = i;
                            flag = 1;
                        }
                    }
                    else if (kcount >= kfa)//框数大于阀值，为候选区域
                    {
                        endpoint = i;
                        break;
                    }
                    else//框数小于阀值，不是候选区域
                    {
                        startpoint = 0;
                        flag = 0;
                        kcount = 0;//重新选择
                    }
                }
                if ((end - start) == 0)
                {
                    MessageBox.Show("垂直定位失败！");
                }
                else if ((endpoint - startpoint) == 0)
                {
                    MessageBox.Show("水平定位失败！");
                }
                else
                {
                    start -= 10;
                    end += 10;
                    Bitmap bmp1 = new Bitmap(endpoint + windowsWidth - startpoint, end - start);
                    //标记指定区域
                    for (int i = start; i < end; i++)//y
                    {
                        for (int j = startpoint; j < endpoint + windowsWidth; j++)//x
                        {
                            bmp1.SetPixel(j - startpoint, i - start, ((Bitmap)img).GetPixel(j, i));
                            //将车牌框起来
                            if ((i == start) || (j == startpoint) || (i == end - 1) || (j == endpoint + windowsWidth - 1))
                            {
                                bmp.SetPixel(j, i, Color.Blue);
                            }
                        }
                    }
                    this.pbLocationResult.Image = bmp1;
                }
                //将处理过的图片显示出来
                this.pbToRec.Image = bmp;
                sw.Flush();//将缓存区的内容写入文件
                sw.Close();
                fs.Close();
            }
        }

        //倾斜矫正
        private void btnQXJZ_Click(object sender, EventArgs e)
        {
            if (this.pbLocationResult.Image != null)
            {
                int theta = 0;
                Bitmap bmp = (Bitmap)this.pbLocationResult.Image.Clone();//用于计算倾斜角度
                Bitmap tmp = (Bitmap)this.pbLocationResult.Image.Clone();//用于旋转图片
                int width = bmp.Width;
                int height = bmp.Height;

                //(车牌蓝底白字需要灰度反转，车牌颜色为黄底黑字的不需要灰度反转)
                ImageProcess.Edging(ImageProcess.Dilation(ImageProcess.Ostu(ImageProcess.Graying(bmp))));

                //霍夫变换计算倾斜角度
                theta = ImageProcess.Hough(bmp);
                int slope = 0;

                //计算需要旋转的角度
                if (theta < 90)
                {
                    slope = 360 - theta;
                }
                else if (theta < 180)
                {
                    slope = 180 - theta;
                }

                //旋转指定的角度slope
                Bitmap res = ImageProcess.Ostu(ImageProcess.Graying(ImageProcess.RotateImg(tmp, slope)));

                int centerx = width / 2;
                int centery = height / 2;
                int left = centerx - 5, right = centerx + 5;
                int top = centery - 1, buttom = centery + 1;
                int fa = 150;
                int count = 0;

                do
                {
                    for (int i = top; i < buttom; i++) //height原图高度
                    {
                        for (int j = left; j < right; j++) //width 原图宽度
                        {
                            if (res.GetPixel(j, i).R == 0)
                            {
                                count++;
                            }
                        }
                    }
                    left -= 1;
                    right += 1;
                } while (count <= fa);

                int lastcount = 0;
                count = 0;

                //定位上边界
                do
                {
                    lastcount = count;
                    count = 0;

                    for (int i = top; i < buttom; i++) //height原图高度
                    {
                        for (int j = left; j < right; j++) //width 原图宽度
                        {
                            if (res.GetPixel(j, i).R == 0)
                            {
                                count++;
                            }
                        }
                    }
                    top -= 1;
                } while (count - lastcount > 1);

                lastcount = 0;
                count = 0;

                //定位下边界
                do
                {
                    lastcount = count;
                    count = 0;

                    for (int i = top; i < buttom; i++) //height原图高度
                    {
                        for (int j = left; j < right; j++) //width 原图宽度
                        {
                            if (res.GetPixel(j, i).R == 0)
                            {
                                count++;
                            }
                        }
                    }
                    buttom += 1;
                } while (count - lastcount > 1);

                //截取
                Bitmap ret = new Bitmap(width, buttom - top);
                for (int i = top; i < buttom; i++) //height原图高度
                {
                    for (int j = 0; j < width; j++) //width 原图宽度
                    {
                        ret.SetPixel(j, i - top, res.GetPixel(j, i));
                    }
                }

                this.pbHorizelJZ.Image = ret;
            }
        }

        //竖直倾斜矫正
        private void btnVertical_Click(object sender, EventArgs e)
        {
            //水平倾斜矫正之后
            if (this.pbHorizelJZ.Image != null)
            {
                Bitmap bmp = (Bitmap)this.pbHorizelJZ.Image.Clone();
                Bitmap src = (Bitmap)this.pbHorizelJZ.Image.Clone();

                int width = bmp.Width;
                int height = bmp.Height;
                int[] xs = new int[height];
                Bitmap jfc = new Bitmap(width, height);

                //膨胀后边缘化
                ImageProcess.Edging(ImageProcess.Dilation(bmp));

                //计算竖直倾斜角
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (bmp.GetPixel(j, i).R == 255)
                        {
                            jfc.SetPixel(j, i, bmp.GetPixel(j, i));
                            break;
                        }
                    }
                }

                int slope = ImageProcess.Hough(jfc);//待修改，应该将Hough变换得到的大致角度+-15°，精确矫正。

                //基于字符投影的垂直矫正算法的具体实现步骤如下（精确垂直矫正）
                //在[-20,+20]范围内，以1为步长对其做垂直投影，并计算垂直投影距离
                int[] ScArray = new int[40];

                for (int l = -20; l < 20; l++)
                {
                    int[] M = new int[width];
                    int Taoc = (int)(height * 0.12);
                    Bitmap b1 = (Bitmap)src.Clone();

                    //1.垂直矫正
                    Bitmap tmp = ImageProcess.VerticalCorrect(b1, slope + l);

                    //1.计算字符的垂直投影
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            if (tmp.GetPixel(i, j).R == 0)
                            {
                                //计算每列黑色字符的处置投影和
                                M[i]++;
                            }
                        }
                        if (M[i] < Taoc)//认为是噪声点，消除
                        {
                            M[i] = 0;
                        }
                        else
                        {
                            M[i] = 1;//认为是字符区域
                        }
                    }

                    //2.分析数组M，统计数组中1的个数，即有效字符的垂直投影总距离Sc
                    int Sc = 0;
                    for (int i = 0; i < width; i++)
                    {
                        if (M[i] == 1)
                        {
                            Sc++;
                        }
                    }
                    ScArray[l + 20] = Sc;
                }

                //3.求最小的垂直投影距离对应的角度
                int min = ScArray[0];
                int t = 0;
                for (int i = 1; i < 40; i++)
                {
                    if (ScArray[i] < min)
                    {
                        min = ScArray[i];
                        t = i - 20;
                    }
                }

                //竖直矫正
                this.pbJZResult.Image = ImageProcess.VerticalCorrect(src, slope + t);
            }
        }

        //字符分割
        private void btnCutCharacter_Click(object sender, EventArgs e)
        {
            if (this.pbJZResult.Image != null)
            {
                //基于垂直投影和车牌先验知识的字符分割
                Bitmap bmp = (Bitmap)this.pbJZResult.Image.Clone();

                int height = bmp.Height;
                int width = bmp.Width;

                //根据先验知识知：
                //字符的平均宽度Wc = 0.5 * heigh；
                //一般字符的间距为W12 = 0.13 * heigh；
                //第二个和第三个字符的间距为W23 = 0.36H；
                //字符“1”的右边界到一般字符左边界的距离W1x = 0.17H.
                //1.对倾斜矫正后的二值化车牌做垂直投影
                int[] M = new int[width];
                int Taoc = (int)(height * 0.12);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (bmp.GetPixel(i, j).R == 0)
                        {
                            //计算每列黑色字符的处置投影和
                            M[i]++;
                        }
                    }
                    if (M[i] < Taoc)//认为是噪声点，消除
                    {
                        M[i] = 0;
                    }
                    else
                    {
                        M[i] = 1;//认为是字符区域
                    }
                }

                //2.利用前两个字符和后面五个字符之间的间隔较大这一先验知识，估算出大间隔的开始位置Ls.
                int count = 0;
                int max = 0;
                int Ls = 0, Le = 0;
                for (int i = 1; i < width / 4 * 3; i++)
                {
                    if (M[i] == 0)
                    {
                        count++;
                    }
                    else if (M[i] == 1 && M[i - 1] == 0)
                    {
                        if (count > max)
                        {
                            max = count;
                            Ls = i - count;
                            Le = i;
                        }
                        count = 0;
                    }
                }

                //3.从后向前查找，分割前两个字符
                int N1s = 0, N2s = 0, N1e = 0, N2e = Ls;
                for (int i = Ls - 1; i >= 0; i--)
                {
                    if (M[i] == 0)
                    {
                        N2s = i - 1;
                        N1s = i - 1;
                        break;
                    }
                }

                //过滤非字符区域
                while (M[N1s] == 0)
                {
                    N1s--;
                }

                N1e = N1s + 1;
                for (int i = N1s; i >= 0; i--)
                {
                    if (M[i] == 0)
                    {
                        N1s = i - 1;
                        break;
                    }
                }

                //4.从前向后查找，分割后五个字符
                int N3s = Le;
                int N3e = 0;
                int N4s = 0;
                int N4e = 0;
                int N5s = 0;
                int N5e = 0;
                int N6s = 0;
                int N6e = 0;
                int N7s = 0;
                int N7e = 0;
                for (int i = N3s; i <= N3s + height; i++)
                {
                    if (M[i] == 0)
                    {
                        N3e = i;
                        N4s = i;
                        break;
                    }
                }

                //过滤非字符区域
                while (M[N4s] == 0)
                {
                    N4s++;
                }

                N4e = N4s;
                for (int i = N4s; i <= N4s + height; i++)
                {
                    if (M[i] == 0)
                    {
                        N4e = i;
                        N5s = i;
                        break;
                    }
                }

                //过滤非字符区域
                while (M[N5s] == 0)
                {
                    N5s++;
                }

                N5e = N5s;
                for (int i = N5s; i <= N5s + height; i++)
                {
                    if (M[i] == 0)
                    {
                        N5e = i;
                        N6s = i;
                        break;
                    }
                }

                //过滤非字符区域
                while (M[N6s] == 0)
                {
                    N6s++;
                }

                N6e = N6s;
                for (int i = N6s; i <= N6s + height; i++)
                {
                    if (M[i] == 0)
                    {
                        N6e = i;
                        N7s = i;
                        break;
                    }
                }

                //过滤非字符区域
                while (M[N7s] == 0)
                {
                    N7s++;
                }

                N7e = N7s;
                for (int i = N7s; i <= N7s + height; i++)
                {
                    if (M[i] == 0)
                    {
                        N7e = i;
                        break;
                    }
                }

                //5.显示
                Bitmap b1 = new Bitmap(N1e - N1s + 1, height);
                Bitmap b2 = new Bitmap(N2e - N2s + 1, height);
                Bitmap b3 = new Bitmap(N3e - N3s + 1, height);
                Bitmap b4 = new Bitmap(N4e - N4s + 1, height);
                Bitmap b5 = new Bitmap(N5e - N5s + 1, height);
                Bitmap b6 = new Bitmap(N6e - N6s + 1, height);
                Bitmap b7 = new Bitmap(N7e - N7s + 1, height);

                this.pbCutPart1.Image = ImageProcess.CutImage(bmp, N1s, N1e, 0, height);
                this.pbCutPart2.Image = ImageProcess.CutImage(bmp, N2s, N2e, 0, height);
                this.pbCutPart3.Image = ImageProcess.CutImage(bmp, N3s, N3e, 0, height);
                this.pbCutPart4.Image = ImageProcess.CutImage(bmp, N4s, N4e, 0, height);
                this.pbCutPart5.Image = ImageProcess.CutImage(bmp, N5s, N5e, 0, height);
                this.pbCutPart6.Image = ImageProcess.CutImage(bmp, N6s, N6e, 0, height);
                this.pbCutPart7.Image = ImageProcess.CutImage(bmp, N7s, N7e, 0, height);
            }
        }

        //归一化
        private void btnResize_Click(object sender, EventArgs e)
        {
            if (this.pbCutPart1.Image != null
                && this.pbCutPart2.Image != null
                && this.pbCutPart3.Image != null
                && this.pbCutPart4.Image != null
                && this.pbCutPart5.Image != null
                && this.pbCutPart6.Image != null
                && this.pbCutPart7.Image != null)
            {
                //归一化
                this.pbCutPart1.Image = ImageProcess.Resize((Bitmap)this.pbCutPart1.Image, 16, 32);
                this.pbCutPart2.Image = ImageProcess.Resize((Bitmap)this.pbCutPart2.Image, 16, 32);
                this.pbCutPart3.Image = ImageProcess.Resize((Bitmap)this.pbCutPart3.Image, 16, 32);
                this.pbCutPart4.Image = ImageProcess.Resize((Bitmap)this.pbCutPart4.Image, 16, 32);
                this.pbCutPart5.Image = ImageProcess.Resize((Bitmap)this.pbCutPart5.Image, 16, 32);
                this.pbCutPart6.Image = ImageProcess.Resize((Bitmap)this.pbCutPart6.Image, 16, 32);
                this.pbCutPart7.Image = ImageProcess.Resize((Bitmap)this.pbCutPart7.Image, 16, 32);
            }
        }

        //模板识别
        private void btnRec_Click(object sender, EventArgs e)
        {
            if (this.pbCutPart3.Image != null
                && this.pbCutPart4.Image != null
                && this.pbCutPart5.Image != null
                && this.pbCutPart6.Image != null
                && this.pbCutPart7.Image != null)
            {
                Bitmap part3 = (Bitmap)this.pbCutPart3.Image.Clone();
                Bitmap part4 = (Bitmap)this.pbCutPart4.Image.Clone();
                Bitmap part5 = (Bitmap)this.pbCutPart5.Image.Clone();
                Bitmap part6 = (Bitmap)this.pbCutPart6.Image.Clone();
                Bitmap part7 = (Bitmap)this.pbCutPart7.Image.Clone();

                this.lblResult.Text = ImageProcess.Rec(part3).ToString() + ImageProcess.Rec(part4).ToString() + ImageProcess.Rec(part5).ToString() + ImageProcess.Rec(part6).ToString() + ImageProcess.Rec(part7).ToString();
            }
        }

    }
}