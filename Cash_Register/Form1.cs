using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Cash_Register
{
    public partial class Form1 : Form
    {
        //Creates all of the variables to be used
        const double COFSMALL = 4.25;
        const double COFMED = 6.00;
        const double COFLARGE = 7.25;
        const double TEASMALL = 6.00;
        const double TEALARGE = 7.50;
        const double DONUT = 2.25;
        const double BISCUIT = 2.75;
        double price;
        double smallCofA;
        double medCofA;
        double largeCofA;
        double smallTeaA;
        double largeTeaA;
        double donutA;
        double biscuitA;
        double tax;
        double finalPrice;
        double change;
        double changeBack;
        double smallCof;
        double medCof;
        double largeCof;
        double smallTea;
        double largeTea;
        double donut;
        double biscuit;


        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void finButton_Click(object sender, EventArgs e)
        {

            //Makes each amount variable equal to the amount text, and also converts string to double
            smallCofA = Convert.ToDouble(smallCofText.Text);
            medCofA = Convert.ToDouble(medCofText.Text);
            largeCofA = Convert.ToDouble(LargeCofText.Text);
            smallTeaA = Convert.ToDouble(smallTeaText.Text);
            largeTeaA = Convert.ToDouble(largeTeaText.Text);
            donutA = Convert.ToDouble(donutText.Text);
            biscuitA = Convert.ToDouble(biscuitText.Text);

            //creates final price for each product according to amount inputted
            smallCof = smallCofA * COFSMALL;
            medCof = medCofA * COFMED;
            largeCof = largeCofA * COFLARGE;
            smallTea = smallTeaA * TEASMALL;
            largeTea = largeTeaA * TEALARGE;
            donut = donutA * DONUT;
            biscuit = biscuitA * BISCUIT;

            //Creates variable price which will be used for reciept
            price = (smallCof + medCof + largeCof + smallTea + largeTea + donut + biscuit);
            tax = price * 0.13; 
            finalPrice = price + tax;

            //Shows subtotal, tax, and total prices before making receipt

            Refresh();
            Thread.Sleep(10);

            subTotalAmount.Text ="$" + price.ToString("0.00");
            subTotalAmount.Visible = true;

            Refresh();
            Thread.Sleep(1000);

            taxAmount.Text = "$" + tax.ToString("0.00");
            taxAmount.Visible = true;

            Refresh();
            Thread.Sleep(1000);

            totalAmount.Text = "$" + finalPrice.ToString("0.00");
            totalAmount.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Takes input and then calculates and displays change back
            change = Convert.ToDouble(givenText.Text);
            changeBack = change - finalPrice;
            amountBackA.Text = "$" + changeBack.ToString("0.00");
            amountBackA.Visible = true;
            printButton.Visible = true;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            //Sets up graphics
            Graphics formGraphics = this.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 5);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Graphics fg = this.CreateGraphics();
            Font receiptFont = new Font("Arial", 8, FontStyle.Bold);
            Font cafeFont = new Font("BrushScriptStd", 8, FontStyle.Italic);

            //converts prices to string
            
            //Draws lines and prices
            formGraphics.DrawLine(blackPen, 260, 0, 260, 1000);
            formGraphics.DrawLine(blackPen, 260, 300, 1000, 300);
            fg.DrawString("Small Coffee " + "(" + smallCofA +")" , receiptFont, blackBrush, 350, 40);
            fg.DrawString("Medium Coffee " + "(" + medCofA + ")", receiptFont, blackBrush, 350, 80);
            fg.DrawString("Large Coffee " + "(" + largeCofA + ")" , receiptFont, blackBrush, 350, 120);
            fg.DrawString("Small Tea " + "(" + smallTeaA + ")", receiptFont, blackBrush, 350, 160);
            fg.DrawString("Large Tea " + "(" + largeTeaA + ")", receiptFont, blackBrush, 350, 200);
            fg.DrawString("Donut " + "(" + donutA + ")", receiptFont, blackBrush, 350, 240);
            fg.DrawString("Tea Biscuit " + "(" + biscuitA + ")", receiptFont, blackBrush, 350, 280);
            fg.DrawString(Convert.ToString(smallCof), receiptFont, blackBrush, 500, 40);
            fg.DrawString(Convert.ToString(medCof), receiptFont, blackBrush, 500, 80);
            fg.DrawString(Convert.ToString(largeCof), receiptFont, blackBrush, 500, 120);
            fg.DrawString(Convert.ToString(smallTea), receiptFont, blackBrush, 500, 160);
            fg.DrawString(Convert.ToString(largeTea), receiptFont, blackBrush, 500, 200); 
            fg.DrawString(Convert.ToString(donut), receiptFont, blackBrush, 500, 240);
            fg.DrawString(Convert.ToString(biscuit), receiptFont, blackBrush, 500, 280);
            fg.DrawString("MacCafe", cafeFont, blackBrush, 350, 10);
            fg.DrawString("Order #5142, 12/5/2014", cafeFont, blackBrush, 420, 10);

            //Prints price according to each item
            /* sCReceipt.Visible = true;
             sCReceipt.Text = "$" + smallCof;
             mCReceipt.Visible = true;
             mCReceipt.Text = "$" + medCof;
             lCReceipt.Visible = true;
             lCReceipt.Text = "$" + largeCof;
             sTReceipt.Visible = true;
             sTReceipt.Text = "$" + smallTea;
             lTReceipt.Visible = true;
             lTReceipt.Text = "$" + largeTea;
             donutReceipt.Visible = true;
             donutReceipt.Text = "$" + donut;
             biscuitReceipt.Visible = true;
             biscuitReceipt.Text = "$" + biscuit;*/
        }
    }
}
