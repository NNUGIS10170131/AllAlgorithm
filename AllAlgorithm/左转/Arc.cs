﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace CreateTopology
{
    public partial class ArcForm : Form
    {
        List<Arc> AllArc;
        PictureBox pictureBox1;
        Bitmap Map;
        double[] border;
        public ArcForm(List<Arc> AllArc,PictureBox Pic,double[]border)
        {
            InitializeComponent();
            this.AllArc = new List<Arc>();
            this.AllArc=AllArc;
            this.pictureBox1 = Pic;
            Map = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.Map = (Bitmap)this.pictureBox1.Image.Clone();
            this.border = border;
        }

        private void ArcForm_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[3];
            columns[0] = new DataGridViewTextBoxColumn();
            columns[1] = new DataGridViewTextBoxColumn();
            columns[2] = new DataGridViewTextBoxColumn();
            columns[0].HeaderText = "ID号";
            columns[1].HeaderText = "头结点";
            columns[2].HeaderText = "尾结点";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowDrop = false;
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSize = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.dataGridView1.Columns.AddRange(columns);
            this.dataGridView1.Rows.Add(AllArc.Count);
            for (int i = 0; i < AllArc.Count; i++)
            {
                this.dataGridView1[0, i].Value = AllArc[i].ID;//ID
                this.dataGridView1[1, i].Value = AllArc[i].HeadNode.ID;//头结点
                this.dataGridView1[2, i].Value = AllArc[i].EndNode.ID;//末节点
            }
        }

        /*
        public void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)//按下一行
        {
            if (e.RowIndex > -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.dataGridView1.ClearSelection();
                    this.dataGridView1.Rows[e.RowIndex].Selected = true;
                    int ID = (int)this.dataGridView1[0, e.RowIndex].Value;
                    this.pictureBox1.Image = (Bitmap)Map.Clone();
                    DrawPicture(AllArc[ID - 1].data);
                }
            }
        }

        public void DrawPicture(List<point> DrawData)//画图
        {
            Graphics g = Graphics.FromImage(this.pictureBox1.Image);
            Pen p = new Pen(Color.Red,4.5f);

            double times = 0d;
            if (border[1] - border[0] < this.pictureBox1.Width | border[3] - border[2] < this.pictureBox1.Height)//数据放大
            {
                double x1 = border[0], x2 = border[1], y1 = border[2], y2 = border[3];
                if (((y2 - y1) / this.pictureBox1.Height) > ((x2 - x1) / this.pictureBox1.Width))
                    times = (float)(y2 - y1) / (this.pictureBox1.Height - 20);
                else
                    times = (float)(x2 - x1) / (this.pictureBox1.Width - 20);
            }
            else//数据缩小
            {
                double x1 = border[0], x2 = border[1], y1 = border[2], y2 = border[3];
                if (((y2 - y1) / this.pictureBox1.Height) > ((x2 - x1) / this.pictureBox1.Width))
                    times = (float)(y2 - y1) / (this.pictureBox1.Height - 20);
                else
                    times = (float)(x2 - x1) / (this.pictureBox1.Width - 20);
            }

                PointF[] pt = new PointF[DrawData.Count];
                int i = 0;

                foreach (point data2 in DrawData)
                {
                    pt[i] = ShiftPoint( new PointF((float)data2.X, (float)data2.Y), times);
                    i++;
                }
                if (DrawData.Count == 1)
                {
                    g.DrawEllipse(p, pt[0].X, pt[0].Y, 2.5f, 2.5f);
                    return;
                }
                g.DrawLines(p, pt);

        }

        public PointF world2screen(PointF pt, double times)//转化到屏幕坐标，1代表数据放大，2代表数据缩小
        {
            double x1 = 0d, x2 = 0d, y1 = 0d, y2 = 0d;
            x1 = border[0]; x2 = border[1]; y1 = border[2]; y2 = border[3];
            return new PointF((float)((pt.X - x1) / times), (float)(this.pictureBox1.Height - (pt.Y - y1) / times));
        }

        public PointF ShiftPoint( PointF pt, double times)//将地图平移至图像中心
        {
            PointF CenterPoint = world2screen( new PointF((float)(border[0] / 2.0 + border[1] / 2.0),
                (float)(border[2] / 2.0 + border[3] / 2.0)), times);
            double x1 = 0d, x2 = 0d, y1 = 0d, y2 = 0d;
            x1 = border[0]; x2 = border[1]; y1 = border[2]; y2 = border[3];
            return new PointF((float)((pt.X - x1) / times + pictureBox1.Width / 2.0 - CenterPoint.X),
                   (float)(this.pictureBox1.Height - (pt.Y - y1) / times + this.pictureBox1.Height / 2.0 - CenterPoint.Y));

        }
        */
        private void ArcForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.pictureBox1.Image=Map;
        }


    }
}
