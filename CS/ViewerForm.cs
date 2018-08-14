using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DashboardCommon;

namespace CardCustomLayoutTemplateExample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            dashboardViewer1.Dashboard = CreateDashboardWithCards();
        }
        Dashboard CreateDashboardWithCards() {
            Dashboard dashboard = new Dashboard();
            dashboard.Title.Text = "Card Custom Template";
            dashboard.CurrencyCultureName = "en-US";
            DashboardObjectDataSource dataSource = new DashboardObjectDataSource(DataGenerator.GenerateTestData());
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
            Card card = new Card(actualValue, targetValue);
            card.LayoutTemplate = CreateCustomCardLayoutTemplate();
            cardItem.Cards.Add(card);
            return dashboard;
        }
        CardLayoutTemplate CreateCustomCardLayoutTemplate() {
            CardCustomLayoutTemplate customTemplate = new CardCustomLayoutTemplate();
            CardLayout layout = new CardLayout();

            CardSparklineRow sparklineRow = new CardSparklineRow();
            sparklineRow.Indent = 10;
            sparklineRow.Height = 40;
            sparklineRow.VerticalAlignment = CardVerticalAlignment.Top;

            CardRow captionRow = new CardRow();
            captionRow.VerticalAlignment = CardVerticalAlignment.Center;
            CardRowTextElement captionTextElement = new CardRowTextElement();
            captionTextElement.FontSize = 14;
            captionTextElement.HorizontalAlignment = CardHorizontalAlignment.Left;
            captionTextElement.Text = "Country: ";
            CardRowDataElement captionValueElement = new CardRowDataElement();
            captionValueElement.ValueType = CardRowDataElementType.Title;
            captionValueElement.FontSize = 18;
            captionValueElement.ForeColor = Color.Blue;
            captionValueElement.FontStyle = FontStyle.Italic;
            captionValueElement.HorizontalAlignment = CardHorizontalAlignment.Right;
            captionRow.Elements.AddRange(captionTextElement, captionValueElement);

            CardRow absoluteVariationRow = new CardRow();
            absoluteVariationRow.VerticalAlignment = CardVerticalAlignment.Center;
            absoluteVariationRow.Indent = 20;
            CardRowTextElement absoluteVariationText = new CardRowTextElement();
            absoluteVariationText.FontSize = 16;
            absoluteVariationText.ForeColor = Color.MediumBlue;
            absoluteVariationText.HorizontalAlignment = CardHorizontalAlignment.Left;
            absoluteVariationText.Text = "Absolute Variation: ";
            CardRowDataElement absoluteVariationValue = new CardRowDataElement();
            absoluteVariationValue.FontSize = 20;
            absoluteVariationValue.ValueType = CardRowDataElementType.AbsoluteVariation;
            absoluteVariationValue.HorizontalAlignment = CardHorizontalAlignment.Right;
            absoluteVariationValue.PredefinedForeColor = CardPredefinedColor.Delta;
            absoluteVariationRow.Elements.AddRange(absoluteVariationText, absoluteVariationValue);

            CardRow percentVariationRow = new CardRow();
            percentVariationRow.VerticalAlignment = CardVerticalAlignment.Center;
            percentVariationRow.Indent = 20;
            CardRowTextElement percentVariationText = new CardRowTextElement();
            percentVariationText.FontSize = 16;
            percentVariationText.ForeColor = Color.MediumBlue;
            percentVariationText.HorizontalAlignment = CardHorizontalAlignment.Left;
            percentVariationText.Text = "Percent Variation: ";
            CardRowDataElement percentVariationValue = new CardRowDataElement();
            percentVariationValue.FontSize = 20;
            percentVariationValue.ValueType = CardRowDataElementType.PercentVariation;
            percentVariationValue.PredefinedForeColor = CardPredefinedColor.Delta;
            percentVariationValue.HorizontalAlignment = CardHorizontalAlignment.Right;
            percentVariationRow.Elements.AddRange(percentVariationText, percentVariationValue);

            CardRow percentOfTargetRow = new CardRow();
            percentOfTargetRow.VerticalAlignment = CardVerticalAlignment.Center;
            percentOfTargetRow.Indent = 20;
            CardRowTextElement percentOfTargetText = new CardRowTextElement();
            percentOfTargetText.FontSize = 16;
            percentOfTargetText.ForeColor = Color.MediumBlue;
            percentOfTargetText.HorizontalAlignment = CardHorizontalAlignment.Left;
            percentOfTargetText.Text = "Percent Variation: ";
            CardRowDataElement percentOfTargetValue = new CardRowDataElement();
            percentOfTargetValue.FontSize = 20;
            percentOfTargetValue.ValueType = CardRowDataElementType.PercentOfTarget;
            percentOfTargetValue.PredefinedForeColor = CardPredefinedColor.Delta;
            percentOfTargetValue.HorizontalAlignment = CardHorizontalAlignment.Right;
            percentOfTargetRow.Elements.AddRange(percentOfTargetText, percentOfTargetValue);

            CardRow totalSalesRow = new CardRow();
            totalSalesRow.VerticalAlignment = CardVerticalAlignment.Center;
            CardRowTextElement totalSalesText = new CardRowTextElement();
            totalSalesText.FontStyle = FontStyle.Underline;
            totalSalesText.FontSize = 14;
            totalSalesText.ForeColor = Color.BlueViolet;
            totalSalesText.Text = "Total Sales: ";
            totalSalesText.HorizontalAlignment = CardHorizontalAlignment.Left;
            CardRowDataElement totalSalesValue = new CardRowDataElement();
            totalSalesValue.ForeColor = Color.CadetBlue;
            totalSalesValue.FontSize = 16;
            totalSalesValue.ValueType = CardRowDataElementType.ActualValue;
            totalSalesValue.HorizontalAlignment = CardHorizontalAlignment.Right;
            totalSalesRow.Elements.AddRange(totalSalesText, totalSalesValue);

            CardRow targetSalesRow = new CardRow();
            targetSalesRow.VerticalAlignment = CardVerticalAlignment.Center;
            CardRowTextElement targetSalesText = new CardRowTextElement();
            targetSalesText.FontStyle = FontStyle.Underline;
            targetSalesText.FontSize = 14;
            targetSalesText.ForeColor = Color.BlueViolet;
            targetSalesText.Text = "Target Sales: ";
            targetSalesText.HorizontalAlignment = CardHorizontalAlignment.Left;
            CardRowDataElement targetSalesValue = new CardRowDataElement();
            targetSalesValue.ForeColor = Color.CadetBlue;
            targetSalesValue.FontSize = 16;
            targetSalesValue.ValueType = CardRowDataElementType.TargetValue;
            targetSalesValue.HorizontalAlignment = CardHorizontalAlignment.Right;
            targetSalesRow.Elements.AddRange(targetSalesText, targetSalesValue);

            layout.Rows.AddRange(sparklineRow, captionRow, absoluteVariationRow, percentVariationRow, percentOfTargetRow, totalSalesRow, targetSalesRow);
            customTemplate.Layout = layout;
            customTemplate.MinWidth = 300;
            customTemplate.MaxWidth = 350;
            return customTemplate;
        }
    }
}
