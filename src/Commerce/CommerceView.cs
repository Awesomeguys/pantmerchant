using System;
using SwinGameSDK;

namespace PantMerchant
{
    public class CommerceView : IDrawable
    {
        public Bitmap Image { get { return null; } }

        Point2D IDrawable.ScreenPos { get { return null; } }

        private int x;

        public void Draw()
        {
            x = 500;

            SwinGame.DrawText(
                "Income: " + (
                    Finance.CalculateNetAmount() > 0 ? 
                    "+" + Finance.CalculateNetAmount().ToString() : 
                    Finance.CalculateNetAmount().ToString()
                ),
                Color.Green,
                2, 
                x
            );
            SwinGame.DrawText("Money: $" + Finance.Money.ToString(), Color.Green, 2, x += 10);

            SwinGame.DrawText("Stock: " + Stock.Amount, Color.Blue, 2, x += 20);
            SwinGame.DrawText("Stock per day: " + Stock.AmountPerDay, Color.Blue, 2, x += 10);

            SwinGame.DrawText("Pant Pricing", Color.Red, 2, x += 20);
            SwinGame.DrawText("Store: $" + Market.StorePrice, Color.Red, 2, x += 10);
            SwinGame.DrawText("Stock: $" + Market.StockPrice, Color.Red, 2, x += 10);
            SwinGame.DrawText("RRP: $" + Market.RegularRetailPrice, Color.Red, 2, x += 10);

            int streamsX = 598;
            int textHeight = SwinGame.TextHeight(View.Font, "AAA");
            // DrawTe(string theText, Color textColor, Color backColor, string name, FontAlignment align, Rectangle area)
            Finance.Streams.ForEach(delegate (FinanceStream stream)
            {
                SwinGame.DrawText(
                    stream.ToString(),
                    stream.Amount >= 0 ? Color.Green : Color.Red,
                    View.Font,
                    798 - SwinGame.TextWidth(View.Font, stream.ToString()),
                    streamsX -= textHeight
                );
            });
            SwinGame.DrawText(
                "FINANCE STREAMS",
                Color.Black,
                View.Font,
                798 - SwinGame.TextWidth(View.Font, "FINANCE STREAMS"),
                streamsX -= textHeight
            );
        }
    }
}
