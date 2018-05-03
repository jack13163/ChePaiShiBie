using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM32
{
    public class ImageProcess
    {
        /// <summary>
        /// 灰度化
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Graying(Bitmap bmp)
        {
            Color curColor;
            int ret = 0;

            //灰度化
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    curColor = bmp.GetPixel(i, j);
                    ret = (int)(curColor.R * 0.299 + curColor.G * 0.587 + curColor.B * 0.114);
                    bmp.SetPixel(i, j, Color.FromArgb(ret, ret, ret));
                }
            }
            return bmp;
        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Smoothing(Bitmap bmp)
        {
            int ret1 = 0;
            int ret2 = 0;
            int ret3 = 0;

            //3*3模板滤波计算，不计算边缘像素
            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    ret1 = (int)((bmp.GetPixel(i - 1, j - 1).R
                        + bmp.GetPixel(i - 1, j).R
                        + bmp.GetPixel(i - 1, j + 1).R
                        + bmp.GetPixel(i, j - 1).R
                        + bmp.GetPixel(i, j).R
                        + bmp.GetPixel(i, j + 1).R
                        + bmp.GetPixel(i + 1, j - 1).R
                        + bmp.GetPixel(i + 1, j).R
                        + bmp.GetPixel(i + 1, j + 1).R) / 9);

                    ret2 = (int)((bmp.GetPixel(i - 1, j - 1).G
                        + bmp.GetPixel(i - 1, j).G
                        + bmp.GetPixel(i - 1, j + 1).G
                        + bmp.GetPixel(i, j - 1).G
                        + bmp.GetPixel(i, j).G
                        + bmp.GetPixel(i, j + 1).G
                        + bmp.GetPixel(i + 1, j - 1).G
                        + bmp.GetPixel(i + 1, j).G
                        + bmp.GetPixel(i + 1, j + 1).G) / 9);

                    ret3 = (int)((bmp.GetPixel(i - 1, j - 1).B
                        + bmp.GetPixel(i - 1, j).B
                        + bmp.GetPixel(i - 1, j + 1).B
                        + bmp.GetPixel(i, j - 1).B
                        + bmp.GetPixel(i, j).B
                        + bmp.GetPixel(i, j + 1).B
                        + bmp.GetPixel(i + 1, j - 1).B
                        + bmp.GetPixel(i + 1, j).B
                        + bmp.GetPixel(i + 1, j + 1).B) / 9);

                    bmp.SetPixel(i, j, Color.FromArgb(ret1, ret2, ret3));
                }
            }
            return bmp;
        }

        /// <summary>
        /// 直方图均值
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Meaning(Bitmap bmp)
        {
            int rIndex = 0;
            int[] rhist = new int[256];
            float[] rfphist = new float[256];
            int[] reqhist = new int[256];
            float[] reqhistTemp = new float[256];

            int gIndex = 0;
            int[] ghist = new int[256];
            float[] gfphist = new float[256];
            int[] geqhist = new int[256];
            float[] geqhistTemp = new float[256];

            int bIndex = 0;
            int[] bhist = new int[256];
            float[] bfphist = new float[256];
            int[] beqhist = new int[256];
            float[] beqhistTemp = new float[256];

            //计算差分矩阵直方图
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    rIndex = bmp.GetPixel(i, j).R;
                    gIndex = bmp.GetPixel(i, j).G;
                    bIndex = bmp.GetPixel(i, j).B;
                    rhist[rIndex]++;
                    ghist[gIndex]++;
                    bhist[bIndex]++;
                }
            }

            //计算灰度分布密度
            for (int i = 0; i < 256; i++)
            {
                rfphist[i] = (float)rhist[i] / (bmp.Width * bmp.Height);
                gfphist[i] = (float)ghist[i] / (bmp.Width * bmp.Height);
                bfphist[i] = (float)bhist[i] / (bmp.Width * bmp.Height);
            }

            //计算累计直方图分布
            reqhistTemp[0] = rfphist[0];
            geqhistTemp[0] = gfphist[0];
            beqhistTemp[0] = bfphist[0];
            for (int i = 1; i < 256; i++)
            {
                reqhistTemp[i] = reqhistTemp[i - 1] + rfphist[i];
                geqhistTemp[i] = geqhistTemp[i - 1] + gfphist[i];
                beqhistTemp[i] = beqhistTemp[i - 1] + bfphist[i];
            }

            //累计分布取整，保存计算出来的灰度映射关系
            for (int i = 1; i < 256; i++)
            {
                reqhist[i] = (int)(255.0 * reqhistTemp[i] + 0.5);
                geqhist[i] = (int)(255.0 * geqhistTemp[i] + 0.5);
                beqhist[i] = (int)(255.0 * beqhistTemp[i] + 0.5);
            }

            //进行均衡化
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    rIndex = bmp.GetPixel(i, j).R;
                    gIndex = bmp.GetPixel(i, j).G;
                    bIndex = bmp.GetPixel(i, j).B;
                    bmp.SetPixel(i, j, Color.FromArgb(reqhist[rIndex], geqhist[gIndex], beqhist[bIndex]));
                }
            }
            return bmp;
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Guassing(Bitmap bmp)
        {
            double nSigma = 0.2;
            int nWindowSize = 1 + 2 * (int)(Math.Ceiling(3 * nSigma));//窗口大小

            int nCenter = nWindowSize / 2;//中心坐标
            int nWidth = bmp.Width;
            int nHeight = bmp.Height;
            //生成二维滤波核
            double[,] pKernel_2 = new double[nWindowSize, nWindowSize];
            double d_sum = 0.0;

            for (int i = 0; i < nWindowSize; i++)
            {
                for (int j = 0; j < nWindowSize; j++)
                {
                    double n_Disx = i - nCenter;//水平方向距离中心像素距离
                    double n_Disy = j - nCenter;
                    pKernel_2[i, j] = Math.Pow(Math.E, (-0.5 * (n_Disx * n_Disx + n_Disy * n_Disy) / (nSigma * nSigma)) / (2.0 * 3.1415926) * nSigma * nSigma);
                    d_sum = d_sum + pKernel_2[i, j];
                }
            }

            for (int i = 0; i < nWindowSize; i++)//归一化处理
            {
                for (int j = 0; j < nWindowSize; j++)
                {
                    pKernel_2[i, j] = pKernel_2[i, j] / d_sum;
                }
            }

            //滤波处理
            for (int s = 0; s < nWidth; s++)
            {
                for (int t = 0; t < nHeight; t++)
                {
                    double dFilter = 0;
                    double dSum = 0;
                    int ret = 0;
                    //当前坐标（s,t）
                    //获取8邻域
                    for (int x = -nCenter; x <= nCenter; x++)
                    {
                        for (int y = -nCenter; y <= nCenter; y++)
                        {
                            if ((x + s >= 0) && (x + s < nWidth) && (y + t >= 0) && (y + t < nHeight))//判断是否越界
                            {
                                int currentvalue = bmp.GetPixel(x + s, y + t).R;
                                dFilter += currentvalue * pKernel_2[x + nCenter, y + nCenter];
                                dSum += pKernel_2[x + nCenter, y + nCenter];
                            }
                        }
                    }
                    ret = (int)(dFilter / dSum);
                    bmp.SetPixel(s, t, Color.FromArgb(ret, ret, ret));
                }
            }
            return bmp;
        }

        //检测水平边缘的模板
        int[,] horizon = new int[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
        //检测垂直边缘的模板
        int[,] vertical = new int[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };

        //template为模板，nThreshold是一个阈值，
        //用来将模板游历的结果（也就是梯度）进行划分。
        //大于阈值的和小于阈值的分别赋予两种颜色，白或黑来标志边界和背景
        public static Bitmap EdgeDectect(Bitmap bmp, int[,] template, int nThreshold)
        {
            int height = bmp.Height;
            int width = bmp.Width;
            //取出和模板等大的原图中的区域
            int[,] gRGB = new int[3, 3];
            //模板值结果，梯度
            int templateValue = 0;
            //遍历灰度图中每个像素
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    //取得模板下区域的颜色，即灰度
                    gRGB[0, 0] = bmp.GetPixel(i - 1, j - 1).R;
                    gRGB[0, 1] = bmp.GetPixel(i - 1, j).R;
                    gRGB[0, 2] = bmp.GetPixel(i - 1, j + 1).R;
                    gRGB[1, 0] = bmp.GetPixel(i, j - 1).R;
                    gRGB[1, 1] = bmp.GetPixel(i, j).R;
                    gRGB[1, 2] = bmp.GetPixel(i, j + 1).R;
                    gRGB[2, 0] = bmp.GetPixel(i + 1, j - 1).R;
                    gRGB[2, 1] = bmp.GetPixel(i + 1, j).R;
                    gRGB[2, 2] = bmp.GetPixel(i + 1, j + 1).R;
                    //按模板计算
                    for (int m = 0; m < 3; m++)
                    {
                        for (int n = 0; n < 3; n++)
                        {
                            templateValue += template[m, n] * gRGB[m, n];
                        }
                    }
                    //将梯度之按阈值分类，并赋予不同的颜色
                    if (templateValue > nThreshold)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(255, 255, 255)); //白
                    }
                    else
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0)); //黑
                    }
                    templateValue = 0;
                }
            }
            return bmp;
        }

        /// <summary>
        /// 边缘检测
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Edging(Bitmap bmp)
        {
            int height = bmp.Height;
            int width = bmp.Width;

            byte[] orients = new byte[width * height];// 梯度方向数组
            float[,] gradients = new float[width, height];// 梯度值数组  
            double gx, gy;
            double orientation = 0;
            double toAngle = 180 / Math.PI;//用于将值正弦值转换为角度值
            float maxGradient = 0;
            float sumGradient = 0;

            //求梯度
            for (int i = 1; i < (width - 1); i++)
            {
                for (int j = 1; j < (height - 1); j++)
                {
                    //计算机是如何检测边缘的。以灰度图像为例，它的理论基础是这样的，如果出现一个边缘，那么图像的灰度就会有一定的变化，
                    //为了方便假设由黑渐变为白代表一个边界，那么对其灰度分析，在边缘的灰度函数就是一个一次函数y=kx，对其求一阶导数就是其斜率k，
                    //就是说边缘的一阶导数是一个常数，而由于非边缘的一阶导数为零，这样通过求一阶导数就能初步判断图像的边缘了。
                    //通常是X方向和Y方向的导数，也就是梯度。理论上计算机就是通过这种方式来获得图像的边缘。
                    //但是，具体应用到图像中你会发现这个导数是求不了的，因为没一个准确的函数让你去求导，
                    //而且计算机在求解析解要比求数值解麻烦得多，所以就想到了一种替代的方式来求导数。
                    //就是用一个3×3的窗口来对图像进行近似求导。拿对X方向求导为例，某一点的导数为第三列的元素之和减去第一列元素之和，
                    //这样就求得了某一点的近似导数。其实也很好理解为什么它就近似代表导数，导数就代表一个变化率，从第一列变为第三列，灰度值相减，当然就是一个变化率了。
                    //这就是所谓的Prewitt算子。这样近似X方向导数就求出来了。Y方向导数与X方向导数求法相似，只不过是用第三行元素之和减去第一行元素之和。
                    //X方向和Y方向导数有了，那么梯度也就出来了。这样就可以找出一幅图中的边缘了。
                    //这里使用了Sobel算子，相比Prewitt算子，Sobel的抗噪能力更强。
                    //检测水平边缘的模板:  int[,] horizon = new int[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
                    //检测垂直边缘的模板:  int[,] vertical = new int[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                    //求水平和竖直导数(利用一阶导数算子, 一般是sobel模板, 计算灰度图每个像素点在 水平和垂直方向上的倒数)
                    gx = -bmp.GetPixel(i - 1, j - 1).R - 2 * bmp.GetPixel(i - 1, j).R - bmp.GetPixel(i - 1, j + 1).R + bmp.GetPixel(i + 1, j - 1).R
                        + 2 * bmp.GetPixel(i + 1, j).R + bmp.GetPixel(i + 1, j + 1).R;

                    gy = -bmp.GetPixel(i - 1, j - 1).R + bmp.GetPixel(i - 1, j + 1).R - 2 * bmp.GetPixel(i, j - 1).R + 2 * bmp.GetPixel(i, j + 1).R
                        - bmp.GetPixel(i + 1, j - 1).R + bmp.GetPixel(i + 1, j + 1).R;

                    //计算梯度值,保存在梯度值数组中
                    gradients[i, j] = (float)Math.Sqrt(gx * gx + gy * gy);
                    //计算梯度和
                    sumGradient += gradients[i, j];
                    //求最大的梯度
                    if (gradients[i, j] > maxGradient)
                    {
                        maxGradient = gradients[i, j];
                    }

                    //计算梯度方向
                    if (gx == 0)
                    {
                        orientation = (gy == 0) ? 0 : 90;
                    }
                    else
                    {
                        double div = (double)gy / gx;

                        if (div < 0)
                        {
                            orientation = 180 - Math.Atan(-div) * toAngle;
                        }
                        else
                        {
                            orientation = Math.Atan(div) * toAngle;
                        }
                        //只保留成4个方向  
                        if (orientation < 22.5)
                            orientation = 0;
                        else if (orientation < 67.5)
                            orientation = 45;
                        else if (orientation < 112.5)
                            orientation = 90;
                        else if (orientation < 157.5)
                            orientation = 135;
                        else orientation = 0;
                    }
                    orients[i * height + j] = (byte)orientation;//保存方向值
                }
            }

            //非极大值抑制(每个像素点的梯度与其梯度方向上的相邻像素比较,
            //如果不是极大值,将其置零,否则置为某一个不大于255的数)
            float leftPixel = 0, rightPixel = 0;
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    //获得相邻两像素梯度值(先确定该点的梯度方向,再取梯度方向上的相邻左右两个点)
                    switch (orients[x * height + y])
                    {
                        case 0:
                            leftPixel = gradients[x - 1, y];
                            rightPixel = gradients[x + 1, y];
                            break;
                        case 45:
                            leftPixel = gradients[x - 1, y + 1];
                            rightPixel = gradients[x + 1, y - 1];
                            break;
                        case 90:
                            leftPixel = gradients[x, y + 1];
                            rightPixel = gradients[x, y - 1];
                            break;
                        case 135:
                            leftPixel = gradients[x + 1, y + 1];
                            rightPixel = gradients[x - 1, y - 1];
                            break;
                    }
                    //如果该点非极大值点,肯定不是边界
                    if ((gradients[x, y] <= leftPixel) || (gradients[x, y] <= rightPixel))
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        //极大值点,暂时当作边界
                        int ret = (int)(gradients[x, y] / maxGradient * 255);//maxGradient是最大梯度  
                        bmp.SetPixel(x, y, Color.FromArgb(ret, ret, ret));
                    }
                }
            }

            //双阀值检测
            float fmean = sumGradient / (height * width);
            fmean = fmean / maxGradient * 255;//某统计信息  
            int highThreshold = (int)(fmean);//高阈值  
            int lowThreshold = (int)(0.4 * highThreshold); //低阈值 (一般设置为高阈值的0.4倍)

            for (int x = 1; x < width; x++)
            {
                for (int y = 1; y < height; y++)
                {
                    //高于高阀值的像素点一定是边缘
                    if (gradients[x, y] < highThreshold)
                    {
                        //梯度小于低阀值,认为其一定不是边缘
                        if (gradients[x, y] < lowThreshold)
                        {
                            bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        }
                        else
                        {
                            //介于高低阀值之间的待定边缘,如果该像素周围8邻域
                            //的梯度都小于高阀值,热为其不是边缘点置为0
                            if ((gradients[x - 1, y] < highThreshold) &&
                                (gradients[x + 1, y] < highThreshold) &&
                                (gradients[x - 1, y - 1] < highThreshold) &&
                                (gradients[x, y - 1] < highThreshold) &&
                                (gradients[x + 1, y - 1] < highThreshold) &&
                                (gradients[x - 1, y + 1] < highThreshold) &&
                                (gradients[x, y + 1] < highThreshold) &&
                                (gradients[x + 1, y + 1] < highThreshold))
                            {
                                bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            }
                        }
                    }
                }
            }
            return bmp;
        }

        /// <summary>
        /// OSTU二值化
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Ostu(Bitmap bmp)
        {
            int h = bmp.Height;
            int w = bmp.Width;

            //定义灰度图像信息存储变量  
            int[] srcData = new int[w * h];
            //定义阈值变量  
            int Th = 0; ;
            //定义背景和目标像素数目变量N1,N2，灰度变量U1,U2
            int N1 = 0, N2 = 0;
            //灰度和变量Sum1,Sum2
            int Sum1 = 0, Sum2 = 0;
            //图像整体平均灰度变量U
            double U1 = 0, U2 = 0;
            //方差变量g，对比阈值变量TT
            double g = 0, TT = 0;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    srcData[i * h + j] = bmp.GetPixel(i, j).R;
                }
            }
            //寻找最大类间方差  
            for (int T = 0; T <= 255; T++)
            {
                //统计两个类的元素个数和像素灰度和
                for (int i = 0; i < h * w; i++)
                {
                    if (srcData[i] > T)
                    {
                        N2++;
                        Sum2 += srcData[i];
                    }
                    else
                    {
                        N1++;
                        Sum1 += srcData[i];
                    }
                }
                U1 = (N1 == 0 ? 0.0 : (Sum1 / N1));//类1像素均值
                U2 = (N2 == 0 ? 0.0 : (Sum2 / N2));
                g = N1 * N2 * (U1 - U2) * (U1 - U2);//计算两个分类之间的方差
                if (g > TT)//保存最大的方差
                {
                    TT = g;//保存最大的方差
                    Th = T;//以此时的灰度值为阀值
                }
                N1 = 0; N2 = 0;
                Sum1 = 0; Sum2 = 0; U1 = 0.0; U2 = 0.0; g = 0.0;
            }
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    int ret = (int)(srcData[i * h + j] < Th ? 0 : 255);
                    bmp.SetPixel(i, j, Color.FromArgb(ret, ret, ret));
                }
            }
            return bmp;
        }

        /// <summary>
        /// 灰度图像二值化
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Binary(Bitmap bmp)
        {
            int average = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    average += color.R;
                }
            }
            average = (int)average / (bmp.Width * bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //获取该点的像素的RGB的颜色
                    Color color = bmp.GetPixel(i, j);
                    int value = 255 - color.R;
                    Color newColor = value > average ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }

        /// <summary>
        /// 灰度反转
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap GrayReverse(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //获取该点的像素的RGB的颜色
                    Color color = bmp.GetPixel(i, j);
                    Color newColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }

        /// <summary>
        /// 返回(x,y)周围像素的情况，为黑色，则设置为true 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool[] getRoundPixel(Bitmap bitmap, int x, int y)
        {
            bool[] pixels = new bool[8];
            Color c;
            int num = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    c = bitmap.GetPixel(x + i, y + j);
                    if (i != 0 || j != 0)
                    {
                        if (255 == c.G)//因为经过了二值化，所以只要检查RGB中一个属性的值  
                        {
                            pixels[num] = false;//为白色，设置为false  
                            num++;
                        }
                        else if (0 == c.G)
                        {
                            pixels[num] = true;//为黑色，设置为true  
                            num++;
                        }
                    }
                }
            }
            return pixels;
        }

        /// <summary>
        /// 图像膨胀
        /// 水平膨胀
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Dilation(Bitmap bmp)
        {
            int height = bmp.Height;
            int width = bmp.Width;
            int tmp = 0;

            int num = 5; //num 膨胀幅度
            //水平方向 膨胀
            for (int i = 0; i < height; i++)
            {
                for (int j = (num - 1) / 2; j < (width - (num - 1) / 2); j++)
                {
                    for (int k = -(num - 1) / 2; k <= (num - 1) / 2; k++)
                    {
                        tmp = bmp.GetPixel(j + k, i).R;//从二值化数据取出数据

                        if (tmp == 255)
                        {
                            bmp.SetPixel(j, i, Color.White);//水平方向膨胀的结果存在temp3中
                            break;
                        }
                    }
                }
            }

            ////对水平膨胀后进行垂直方向膨胀
            //for (int i = (num - 1) / 2; i < height - (num - 1) / 2; i++)//height 原图高度
            //{
            //    for (int j = 0; j < width; j++) //width原图宽度
            //    {
            //        for (int k = -(num - 1) / 2; k < (num - 1) / 2; k++)
            //        {
            //            tmp = bmp.GetPixel(j, i + k).R;//从二值化数据取出数据

            //            if (tmp == 255)
            //            {
            //                bmp.SetPixel(j, i, Color.White);//水平方向膨胀的结果存在temp3中
            //                break;
            //            }
            //        }
            //    }
            //}

            return bmp;
        }

        /// <summary>
        /// 图像腐蚀
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap Erosion(Bitmap bmp)
        {
            Color c;
            int height = bmp.Height;
            int width = bmp.Width;
            bool[] pixels;
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (bmp.GetPixel(i, j).R == 0)
                    {
                        pixels = getRoundPixel(bmp, i, j);
                        for (int k = 0; k < pixels.Length; k++)
                        {
                            if (pixels[k] == false)
                            {
                                //set this piexl's color to black
                                bmp.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                                break;
                            }
                        }
                    }
                }
            }
            return bmp;
        }

        /// <summary>
        /// 开运算
        /// 先腐蚀后膨胀的过程开运算。用来消除小物体、在纤细点处分离物体、平滑较大物体的边界的同时并不明显改变其面积。
        /// 开运算通常是在需要去除小颗粒噪声，以及断开目标物之间粘连时使用。
        /// 其主要作用与腐蚀相似，与腐蚀操作相比，具有可以基本保持目标原有大小不变的优点。
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap OpenOperate(Bitmap bmp)
        {
            return Dilation(Erosion(bmp));
        }

        /// <summary>
        /// 闭运算
        /// 先膨胀后腐蚀的过程称为闭运算。用来填充物体内细小空洞、连接邻近物体、平滑其边界的同时并不明显改变其面积。
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap CloseOperate(Bitmap bmp)
        {
            return Erosion(Dilation(bmp));
        }

        /// <summary>
        /// 为了节省计算量，采用数组的形式保存正余弦值
        /// </summary>
        public static double[] carCos = new double[] {1.000000, 0.999848, 0.999391, 0.998630, 0.997564, 0.996195, 0.994522, 0.992546, 0.990268, 0.987688, 0.984808, 0.981627,
            0.978148, 0.974370, 0.970296, 0.965926,0.961262, 0.956305, 0.951057, 0.945519, 0.939693, 0.933580, 0.927184, 0.920505, 0.913545, 0.906308, 0.898794,
            0.891007, 0.882948, 0.874620, 0.866025, 0.857167,0.848048, 0.838671, 0.829038, 0.819152, 0.809017, 0.798636, 0.788011, 0.777146, 0.766044, 0.754710,
            0.743145, 0.731354, 0.719340, 0.707107, 0.694658, 0.681998,0.669131, 0.656059, 0.642788, 0.629320, 0.615662, 0.601815, 0.587785, 0.573576, 0.559193,
            0.544639, 0.529919, 0.515038, 0.500000, 0.484810, 0.469472, 0.453991,0.438371, 0.422618, 0.406737, 0.390731, 0.374607, 0.358368, 0.342020, 0.325568,
            0.309017, 0.292372, 0.275637, 0.258819, 0.241922, 0.224951, 0.207912, 0.190809,0.173648, 0.156434, 0.139173, 0.121869, 0.104528, 0.087156, 0.069757,
            0.052336, 0.034900, 0.017452, 0.000000, -0.017452, -0.034899, -0.052336, -0.069756, -0.087156,-0.104528, -0.121869, -0.139173, -0.156434, -0.173648,
            -0.190809, -0.207912, -0.224951, -0.241922, -0.258819, -0.275637, -0.292372, -0.309017, -0.325568, -0.342020, -0.358368,-0.374607, -0.390731, -0.406737,
            -0.422618, -0.438371, -0.453990, -0.469472, -0.484810, -0.500000, -0.515038, -0.529919, -0.544639, -0.559193, -0.573576, -0.587785, -0.601815,-0.615661,
            -0.629320, -0.642788, -0.656059, -0.669131, -0.681998, -0.694658, -0.707107, -0.719340, -0.731354, -0.743145, -0.754710, -0.766044, -0.777146, -0.788011,
            -0.798635,-0.809017, -0.819152, -0.829038, -0.838671, -0.848048, -0.857167, -0.866025, -0.874620, -0.882948, -0.891007, -0.898794, -0.906308, -0.913545,
            -0.920505, -0.927184, -0.933580,-0.939693, -0.945519, -0.951056, -0.956305, -0.961262, -0.965926, -0.970296, -0.974370, -0.978148, -0.981627, -0.984808,
            -0.987688, -0.990268, -0.992546, -0.994522, -0.996195,-0.997564, -0.998630, -0.999391, -0.999848, -1.000000};

        public static double[] carSin = new double[]{
            0.000000, 0.017452, 0.034899, 0.052336, 0.069756, 0.087156, 0.104528, 0.121869, 0.139173, 0.156434, 0.173648, 0.190809, 0.207912, 0.224951, 0.241922, 0.258819,
            0.275637, 0.292372, 0.309017, 0.325568, 0.342020, 0.358368, 0.374607, 0.390731, 0.406737, 0.422618, 0.438371, 0.453990, 0.469472, 0.484810, 0.500000, 0.515038,
            0.529919, 0.544639, 0.559193, 0.573576, 0.587785, 0.601815, 0.615661, 0.629320, 0.642788, 0.656059, 0.669131, 0.681998, 0.694658, 0.707107, 0.719340, 0.731354,
            0.743145, 0.754710, 0.766044, 0.777146, 0.788011, 0.798635, 0.809017, 0.819152, 0.829038, 0.838671, 0.848048, 0.857167, 0.866025, 0.874620, 0.882948, 0.891007,
            0.898794, 0.906308, 0.913545, 0.920505, 0.927184, 0.933580, 0.939693, 0.945519, 0.951056, 0.956305, 0.961262, 0.965926, 0.970296, 0.974370, 0.978148, 0.981627,
            0.984808, 0.987688, 0.990268, 0.992546, 0.994522, 0.996195, 0.997564, 0.998630, 0.999391, 0.999848, 1.000000, 0.999848, 0.999391, 0.998630, 0.997564, 0.996195,
            0.994522, 0.992546, 0.990268, 0.987688, 0.984808, 0.981627, 0.978148, 0.974370, 0.970296, 0.965926, 0.961262, 0.956305, 0.951057, 0.945519, 0.939693, 0.933580,
            0.927184, 0.920505, 0.913545, 0.906308, 0.898794, 0.891007, 0.882948, 0.874620, 0.866025, 0.857167, 0.848048, 0.838671, 0.829038, 0.819152, 0.809017, 0.798636,
            0.788011, 0.777146, 0.766044, 0.754710, 0.743145, 0.731354, 0.719340, 0.707107, 0.694658, 0.681998, 0.669131, 0.656059, 0.642788, 0.629320, 0.615662, 0.601815,
            0.587785, 0.573576, 0.559193, 0.544639, 0.529919, 0.515038, 0.500000, 0.484810, 0.469472, 0.453991, 0.438371, 0.422618, 0.406737, 0.390731, 0.374607, 0.358368,
            0.342020, 0.325568, 0.309017, 0.292372, 0.275637, 0.258819, 0.241922, 0.224951, 0.207912, 0.190809, 0.173648, 0.156435, 0.139173, 0.121869, 0.104529, 0.087156,
            0.069757, 0.052336, 0.034900, 0.017452, 0.000000};

        /// <summary>
        /// 霍夫变换
        /// </summary>
        /// <param name=""></param>
        /// <param name="srcBmp"></param>
        /// <returns>角度（0~180）</returns>
        public static int Hough(Bitmap srcBmp)
        {
            int width = srcBmp.Width;
            int height = srcBmp.Height;
            int kmax = 0, pmax = 0;
            int yuzhi = 0;
            int p = 0;
            int[,] npp = new int[180, 1000];//保存所有的点

            int mp = (int)(Math.Sqrt(width * width + height * height) + 1);//最长直线的阈值
            int ma = 180;//角度最大值

            for (int i = 0; i < height; i++) //img.height原图高度
            {
                for (int j = 0; j < width; j++) //img.width 原图宽度
                {
                    if (srcBmp.GetPixel(j, i).R == 255) //对边缘检测后的数据（存在lpDIBBits中）进行hough变化
                    {
                        for (int k = 1; k < ma; k++) //ma=180
                        {
                            p = (int)(i * Math.Cos(Math.PI * k / 180) + j * Math.Sin(Math.PI * k / 180));//p为hough变换中距离参数
                            p = (int)(p / 2 + mp / 2); //对p值优化防止为负
                            npp[k, p]++; //npp对变换域中对应重复出现的点累加
                        }
                    }
                }
            }

            //这一部分为寻找最长直线
            for (int i = 1; i < ma; i++) //ma=180
            {
                for (int j = 1; j < mp; j++) //mp为原图对角线距离
                {
                    if (npp[i, j] > yuzhi) //找出最长直线 yuzhi为中间变量用于比较
                    {
                        yuzhi = npp[i, j];
                        kmax = i; //记录最长直线的角度
                        pmax = j; //记录最长直线的距离
                    }
                }
            }

            //标记直线
            for (int i = 0; i < height; i++) //img.height原图高度
            {
                for (int j = 0; j < width; j++) //img.width 原图宽度
                {
                    if (srcBmp.GetPixel(j, i).R == 255)
                    {
                        p = (int)(i * carCos[kmax] + j * carSin[kmax]);
                        p = (int)(p / 2 + mp / 2);
                        if (p == pmax)
                        {
                            srcBmp.SetPixel(j, i, Color.Red);
                        }
                    }
                }
            }
            return kmax;
        }

        /// <summary>  
        /// 以逆时针为方向对图像进行旋转  
        /// </summary>  
        /// <param name="b">位图</param>  
        /// <param name="angle">旋转角度[0,360](前台给的)</param>  
        /// <returns></returns>  
        public static Bitmap RotateImg(Image b, int angle)
        {
            angle = angle % 360;
            //弧度转换  
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高  
            int w = b.Width;
            int h = b.Height;
            //旋转之后的宽和高
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            //目标位图  
            Bitmap dsImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //计算偏移量  
            Point Offset = new Point((W - w) / 2, (H - h) / 2);

            //构造图像显示区域：让图像的中心与窗口的中心点一致  
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);

            //恢复图像在水平和垂直方向的平移  
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换  
            g.ResetTransform();
            g.Save();
            g.Dispose();
            //保存旋转后的图片  
            b.Dispose();
            return dsImage;
        }

        /// <summary>
        /// 垂直倾斜矫正
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="slope"></param>
        /// <returns></returns>
        public static Bitmap VerticalCorrect(Bitmap bmp, int slope)
        {
            int height = bmp.Height;
            int width = bmp.Width;
            Bitmap bmpnew = new Bitmap(width, height);

            //竖直矫正
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int jnew = 0;
                    if (slope > 0 && slope < 90)
                    {
                        jnew = (int)(j - (height - i) * Math.Tan((90 - slope) * Math.PI / 180));
                    }
                    else
                    {
                        jnew = (int)(j + (i - 1) * Math.Tan(slope * Math.PI / 180));//待修改
                    }
                    //舍去超出的区域
                    if (jnew < width && jnew >= 0)
                    {
                        bmpnew.SetPixel(jnew, i, bmp.GetPixel(j, i));
                    }
                }
            }
            return bmpnew;
        }

        /// <summary>
        /// 图片剪辑
        /// </summary>
        /// <param name="bmp">待剪辑图片</param>
        /// <param name="ws">水平起始点</param>
        /// <param name="we">水平结束点</param>
        /// <param name="hs">垂直起始点</param>
        /// <param name="he">垂直结束点</param>
        /// <returns></returns>
        public static Bitmap CutImage(Bitmap bmp, int ws, int we, int hs, int he)
        {
            Bitmap b = new Bitmap(we - ws, he - hs);

            for (int i = ws; i < we; i++)
            {
                for (int j = hs; j < he; j++)
                {
                    b.SetPixel(i - ws, j - hs, bmp.GetPixel(i, j));
                }
            }

            return b;
        }

        /// <summary>
        /// 放缩图片
        /// </summary>
        /// <param name="bmp">待放缩位图</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static Bitmap Resize(Bitmap bmp, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);

            //基于外框归一化
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    int srcj = (j * bmp.Width / width);
                    int srci = (i * bmp.Height / height);
                    b.SetPixel(j, i, bmp.GetPixel(srcj, srci));
                }
            }

            return b;
        }

        /// <summary>
        /// 模板识别
        /// </summary>
        /// <param name="bmp">待识别位图</param>
        /// <returns></returns>
        public static int Rec(Bitmap bmp)
        {
            int height = 32;
            int width = 16;

            Bitmap template0 = new Bitmap(@"模板库/0.bmp");
            Bitmap template1 = new Bitmap(@"模板库/1.bmp");
            Bitmap template2 = new Bitmap(@"模板库/2.bmp");
            Bitmap template3 = new Bitmap(@"模板库/3.bmp");
            Bitmap template4 = new Bitmap(@"模板库/4.bmp");
            Bitmap template5 = new Bitmap(@"模板库/5.bmp");
            Bitmap template6 = new Bitmap(@"模板库/6.bmp");
            Bitmap template7 = new Bitmap(@"模板库/7.bmp");
            Bitmap template8 = new Bitmap(@"模板库/8.bmp");
            Bitmap template9 = new Bitmap(@"模板库/9.bmp");

            int[] count = new int[10];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (bmp.GetPixel(j, i).R == template0.GetPixel(j, i).R)
                    {
                        count[0]++;
                    }
                    if (bmp.GetPixel(j, i).R == template1.GetPixel(j, i).R)
                    {
                        count[1]++;
                    }
                    if (bmp.GetPixel(j, i).R == template2.GetPixel(j, i).R)
                    {
                        count[2]++;
                    }
                    if (bmp.GetPixel(j, i).R == template3.GetPixel(j, i).R)
                    {
                        count[3]++;
                    }
                    if (bmp.GetPixel(j, i).R == template4.GetPixel(j, i).R)
                    {
                        count[4]++;
                    }
                    if (bmp.GetPixel(j, i).R == template5.GetPixel(j, i).R)
                    {
                        count[5]++;
                    }
                    if (bmp.GetPixel(j, i).R == template6.GetPixel(j, i).R)
                    {
                        count[6]++;
                    }
                    if (bmp.GetPixel(j, i).R == template7.GetPixel(j, i).R)
                    {
                        count[7]++;
                    }
                    if (bmp.GetPixel(j, i).R == template8.GetPixel(j, i).R)
                    {
                        count[8]++;
                    }
                    if (bmp.GetPixel(j, i).R == template9.GetPixel(j, i).R)
                    {
                        count[9]++;
                    }
                }
            }
            int max = 0;
            int maxi = 0;
            for (int i = 0; i < 10; i++)
            {
                if (count[i] > max)
                {
                    max = count[i];
                    maxi = i;
                }
            }
            return maxi;
        }
    }
}
