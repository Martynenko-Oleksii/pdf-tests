
namespace PDFTest
{
    using PdfSharp;
    using PdfSharp.Charting;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;

    internal class Program
    {
        static void Main(string[] args)
        {
            PdfDocument pdfDocument = new PdfDocument();

            PdfPage page = pdfDocument.AddPage();
            page.Size = PageSize.A4;

            Chart chart = new Chart(ChartType.Bar2D);

            Series series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Bar2D;
            series.Add(new double[] { 1, 17, 45, 5, 3, 20, 11, 23, 8, 19 });
            series.HasDataLabel = false;

            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N");

            chart.XAxis.MajorTickMark = TickMarkType.None;

            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            chart.PlotArea.LineFormat.Color = XColors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = false;

            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            XGraphics gfx = XGraphics.FromPdfPage(page);
            chartFrame.Draw(gfx);

            pdfDocument.Save("test.pdf");
        }
    }
}
