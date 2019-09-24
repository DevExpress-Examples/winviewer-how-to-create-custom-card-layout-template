using DevExpress.DashboardCommon;
using System.Drawing;

namespace CardCustomLayoutTemplateExample
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            dashboardViewer1.Dashboard = CreateDashboardWithCards();

        }
        Dashboard CreateDashboardWithCards()
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Title.Text = "Card Custom Template";
            dashboard.CurrencyCultureName = "en-US";

            DashboardObjectDataSource dataSource = new DashboardObjectDataSource();
            dashboardViewer1.AsyncDataLoading += (s, ev) => {
                ev.Data = DataGenerator.GenerateTestData();
            };
            dashboard.DataSources.Add(dataSource);

            CardDashboardItem cardItem = new CardDashboardItem();
            cardItem.SeriesDimensions.Add(new Dimension("Country"));
            cardItem.SparklineArgument = new Dimension("SalesDate", DateTimeGroupInterval.DayMonthYear);
            cardItem.DataSource = dataSource;
            cardItem.ShowCaption = false;

            dashboard.Items.Add(cardItem);
            Measure actualValue = new Measure("Sales");
            actualValue.NumericFormat.FormatType = DataItemNumericFormatType.Currency;
            Measure targetValue = new Measure("SalesTarget");
            targetValue.NumericFormat.FormatType = DataItemNumericFormatType.Currency;
            Card card = new Card(actualValue, targetValue)
            {
                LayoutTemplate = CreateCustomCardLayoutTemplate()
            };
            cardItem.Cards.Add(card);
            return dashboard;
        }
        CardLayoutTemplate CreateCustomCardLayoutTemplate()
        {
            CardCustomLayoutTemplate customTemplate = new CardCustomLayoutTemplate();
            CardLayout layout = new CardLayout();

            CardSparklineRow sparklineRow = new CardSparklineRow
            {
                Indent = 10,
                Height = 40,
                VerticalAlignment = CardVerticalAlignment.Top
            };

            CardRow captionRow = new CardRow
            {
                VerticalAlignment = CardVerticalAlignment.Center
            };
            CardRowTextElement captionTextElement = new CardRowTextElement
            {
                FontSize = 14,
                HorizontalAlignment = CardHorizontalAlignment.Left,
                Text = "Country: "
            };
            CardRowDataElement captionValueElement = new CardRowDataElement
            {
                ValueType = CardRowDataElementType.Title,
                FontSize = 18,
                ForeColor = Color.Blue,
                FontStyle = FontStyle.Italic,
                HorizontalAlignment = CardHorizontalAlignment.Right
            };
            CardRowIndicatorElement deltaIndicator = new CardRowIndicatorElement(CardHorizontalAlignment.Right, 22);
            captionRow.Elements.AddRange(captionTextElement, captionValueElement, deltaIndicator);
            CardRow absoluteVariationRow = new CardRow
            {
                VerticalAlignment = CardVerticalAlignment.Center,
                Indent = 20
            };
            CardRowTextElement absoluteVariationText = new CardRowTextElement
            {
                FontSize = 16,
                ForeColor = Color.MediumBlue,
                HorizontalAlignment = CardHorizontalAlignment.Left,
                Text = "Absolute Variation: "
            };
            CardRowDataElement absoluteVariationValue = new CardRowDataElement
            {
                FontSize = 20,
                ValueType = CardRowDataElementType.AbsoluteVariation,
                HorizontalAlignment = CardHorizontalAlignment.Right,
                PredefinedForeColor = CardPredefinedColor.Delta
            };
            absoluteVariationRow.Elements.AddRange(absoluteVariationText, absoluteVariationValue);

            CardRow percentVariationRow = new CardRow
            {
                VerticalAlignment = CardVerticalAlignment.Center,
                Indent = 20
            };
            CardRowTextElement percentVariationText = new CardRowTextElement
            {
                FontSize = 16,
                ForeColor = Color.MediumBlue,
                HorizontalAlignment = CardHorizontalAlignment.Left,
                Text = "Percent Variation: "
            };
            CardRowDataElement percentVariationValue = new CardRowDataElement
            {
                FontSize = 20,
                ValueType = CardRowDataElementType.PercentVariation,
                PredefinedForeColor = CardPredefinedColor.Delta,
                HorizontalAlignment = CardHorizontalAlignment.Right
            };
            percentVariationRow.Elements.AddRange(percentVariationText, percentVariationValue);

            CardRow percentOfTargetRow = new CardRow
            {
                VerticalAlignment = CardVerticalAlignment.Center,
                Indent = 20
            };
            CardRowTextElement percentOfTargetText = new CardRowTextElement
            {
                FontSize = 16,
                ForeColor = Color.MediumBlue,
                HorizontalAlignment = CardHorizontalAlignment.Left,
                Text = "Percent of Target: "
            };
            CardRowDataElement percentOfTargetValue = new CardRowDataElement
            {
                FontSize = 20,
                ValueType = CardRowDataElementType.PercentOfTarget,
                PredefinedForeColor = CardPredefinedColor.Delta,
                HorizontalAlignment = CardHorizontalAlignment.Right
            };
            percentOfTargetRow.Elements.AddRange(percentOfTargetText, percentOfTargetValue);

            CardRow totalSalesRow = new CardRow
            {
                VerticalAlignment = CardVerticalAlignment.Center
            };
            CardRowTextElement totalSalesText = new CardRowTextElement
            {
                FontStyle = FontStyle.Underline,
                FontSize = 14,
                ForeColor = Color.BlueViolet,
                Text = "Total Sales: ",
                HorizontalAlignment = CardHorizontalAlignment.Left
            };
            CardRowDataElement totalSalesValue = new CardRowDataElement
            {
                ForeColor = Color.CadetBlue,
                FontSize = 16,
                ValueType = CardRowDataElementType.ActualValue,
                HorizontalAlignment = CardHorizontalAlignment.Right
            };
            totalSalesRow.Elements.AddRange(totalSalesText, totalSalesValue);

            CardRow targetSalesRow = new CardRow
            {
                VerticalAlignment = CardVerticalAlignment.Center
            };
            CardRowTextElement targetSalesText = new CardRowTextElement
            {
                FontStyle = FontStyle.Underline,
                FontSize = 14,
                ForeColor = Color.BlueViolet,
                Text = "Target Sales: ",
                HorizontalAlignment = CardHorizontalAlignment.Left
            };
            CardRowDataElement targetSalesValue = new CardRowDataElement
            {
                ForeColor = Color.CadetBlue,
                FontSize = 16,
                ValueType = CardRowDataElementType.TargetValue,
                HorizontalAlignment = CardHorizontalAlignment.Right
            };
            targetSalesRow.Elements.AddRange(targetSalesText, targetSalesValue);

            layout.Rows.AddRange(sparklineRow,
                captionRow,
                absoluteVariationRow,
                percentVariationRow,
                percentOfTargetRow,
                totalSalesRow,
                targetSalesRow);
            customTemplate.Layout = layout;
            customTemplate.MinWidth = 300;
            customTemplate.MaxWidth = 350;
            return customTemplate;
        }
    }
}
