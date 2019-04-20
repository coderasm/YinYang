using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YinYang
{
  public partial class Form1 : Form
  {
    private int clientDimension = 400;
    public Form1()
    {
      InitializeComponent();
      ClientSize = new Size(clientDimension, clientDimension);
      MinimumSize = ClientSize;
    }

    private void onPaint(object sender, PaintEventArgs e)
    {
      var piesPenWidth = 2F;
      var largeDiameter = (int)(clientDimension - (piesPenWidth >= 1F ? piesPenWidth / 2 : 0));
      var mediumDiameter = largeDiameter / 2;
      var smallDiameter = mediumDiameter / 3;
      var pen = new Pen(Color.White);
      var brush = new SolidBrush(Color.White);
      var rect = new Rectangle(0, 0, largeDiameter, largeDiameter);

      //color background
      e.Graphics.DrawRectangle(pen, rect);
      e.Graphics.FillRectangle(brush, rect);
      pen.Color = Color.Black;
      brush.Color = Color.Black;
      //save pen width
      var penWidth = pen.Width;
      //increse pen width
      pen.Width = piesPenWidth;

      //Largest Parent Circle
      //Draw left hemisphere
      e.Graphics.DrawPie(pen, rect, 270, 180);
      e.Graphics.FillPie(brush, rect, 270, -180);
      //Draw right hemisphere
      e.Graphics.DrawPie(pen, rect, 90, 180);
      //restore pen width
      pen.Width = penWidth;

      //Draw top black circle
      var upperX = (largeDiameter - mediumDiameter) / 2;
      rect = new Rectangle(upperX, 0, mediumDiameter, mediumDiameter);
      e.Graphics.DrawEllipse(pen, rect);
      e.Graphics.FillEllipse(brush, rect);

      //Draw bottom white circle
      var bottomY = largeDiameter - mediumDiameter;
      rect = new Rectangle(upperX, bottomY, mediumDiameter, mediumDiameter);
      pen.Color = Color.White;
      e.Graphics.DrawEllipse(pen, rect);
      brush.Color = Color.White;
      e.Graphics.FillEllipse(brush, rect);

      //Draw top white circle
      var topX = largeDiameter - mediumDiameter - smallDiameter / 2;
      var topY = (mediumDiameter - smallDiameter) / 2;
      rect = new Rectangle(topX, topY, smallDiameter, smallDiameter);
      e.Graphics.DrawEllipse(pen, rect);
      brush.Color = Color.White;
      e.Graphics.FillEllipse(brush, rect);

      //Draw bottom black circle
      var lowerY = (largeDiameter - mediumDiameter) + (mediumDiameter - smallDiameter) / 2;
      rect = new Rectangle(topX, lowerY, smallDiameter, smallDiameter);
      brush.Color = Color.Black;
      pen.Color = Color.Black;
      e.Graphics.DrawEllipse(pen, rect);
      e.Graphics.FillEllipse(brush, rect);
    }

    private void onResize(object sender, System.EventArgs e)
    {
      //Resize drawing to new window size
      clientDimension = ClientSize.Height > ClientSize.Width ? ClientSize.Height : ClientSize.Width;
      ClientSize = new Size(clientDimension, clientDimension);
      Invalidate();
    }
  }
}
