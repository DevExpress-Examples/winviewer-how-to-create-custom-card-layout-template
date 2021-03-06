﻿Imports DevExpress.DashboardCommon
Imports System.Drawing

Namespace CardCustomLayoutTemplateExample
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
            InitializeComponent()
            dashboardViewer1.Dashboard = CreateDashboardWithCards()
		End Sub
		Private Function CreateDashboardWithCards() As Dashboard
			Dim dashboard As New Dashboard()
			dashboard.Title.Text = "Card Custom Template"
			dashboard.CurrencyCultureName = "en-US"
            Dim dataSource As New DashboardObjectDataSource()
            AddHandler dashboardViewer1.AsyncDataLoading, Sub(s, ev)
                                                              ev.Data = DataGenerator.GenerateTestData()
                                                          End Sub
            dashboard.DataSources.Add(dataSource)

            Dim cardItem As New CardDashboardItem()
			cardItem.SeriesDimensions.Add(New Dimension("Country"))
			cardItem.SparklineArgument = New Dimension("SalesDate", DateTimeGroupInterval.DayMonthYear)
			cardItem.DataSource = dataSource
			cardItem.ShowCaption = False

			dashboard.Items.Add(cardItem)
			Dim actualValue As New Measure("Sales")
			actualValue.NumericFormat.FormatType = DataItemNumericFormatType.Currency
			Dim targetValue As New Measure("SalesTarget")
			targetValue.NumericFormat.FormatType = DataItemNumericFormatType.Currency
            Dim card As New Card(actualValue, targetValue)
            card.LayoutTemplate = CreateCustomCardLayoutTemplate()
            cardItem.Cards.Add(card)
			Return dashboard
		End Function
		Private Function CreateCustomCardLayoutTemplate() As CardLayoutTemplate
			Dim customTemplate As New CardCustomLayoutTemplate()
			Dim layout As New CardLayout()

            Dim sparklineRow As CardSparklineRow = New CardSparklineRow()
            sparklineRow.Indent = 10
            sparklineRow.Height = 40
            sparklineRow.VerticalAlignment = CardVerticalAlignment.Top

            Dim captionRow As CardRow = New CardRow()
            captionRow.VerticalAlignment = CardVerticalAlignment.Center
            Dim captionTextElement As CardRowTextElement = New CardRowTextElement()
            captionTextElement.FontSize = 14
            captionTextElement.HorizontalAlignment = CardHorizontalAlignment.Left
            captionTextElement.Text = "Country: "
            Dim captionValueElement As CardRowDataElement = New CardRowDataElement()
            captionValueElement.ValueType = CardRowDataElementType.Title
            captionValueElement.FontSize = 18
            captionValueElement.ForeColor = Color.Blue
            captionValueElement.FontStyle = FontStyle.Italic
            captionValueElement.HorizontalAlignment = CardHorizontalAlignment.Right
            Dim deltaIndicator As New CardRowIndicatorElement(CardHorizontalAlignment.Right, 22)
			captionRow.Elements.AddRange(captionTextElement, captionValueElement, deltaIndicator)
            Dim absoluteVariationRow As CardRow = New CardRow()
            absoluteVariationRow.VerticalAlignment = CardVerticalAlignment.Center
            absoluteVariationRow.Indent = 20
            Dim absoluteVariationText As CardRowTextElement = New CardRowTextElement()
            absoluteVariationText.FontSize = 16
            absoluteVariationText.ForeColor = Color.MediumBlue
            absoluteVariationText.HorizontalAlignment = CardHorizontalAlignment.Left
            absoluteVariationText.Text = "Absolute Variation: "
            Dim absoluteVariationValue As CardRowDataElement = New CardRowDataElement()
            absoluteVariationValue.FontSize = 20
            absoluteVariationValue.ValueType = CardRowDataElementType.AbsoluteVariation
            absoluteVariationValue.HorizontalAlignment = CardHorizontalAlignment.Right
            absoluteVariationValue.PredefinedForeColor = CardPredefinedColor.Delta
            absoluteVariationRow.Elements.AddRange(absoluteVariationText, absoluteVariationValue)

            Dim percentVariationRow As CardRow = New CardRow()
            percentVariationRow.VerticalAlignment = CardVerticalAlignment.Center
            percentVariationRow.Indent = 20
            Dim percentVariationText As CardRowTextElement = New CardRowTextElement()
            percentVariationText.FontSize = 16
            percentVariationText.ForeColor = Color.MediumBlue
            percentVariationText.HorizontalAlignment = CardHorizontalAlignment.Left
            percentVariationText.Text = "Percent Variation: "
            Dim percentVariationValue As CardRowDataElement = New CardRowDataElement()
            percentVariationValue.FontSize = 20
            percentVariationValue.ValueType = CardRowDataElementType.PercentVariation
            percentVariationValue.PredefinedForeColor = CardPredefinedColor.Delta
            percentVariationValue.HorizontalAlignment = CardHorizontalAlignment.Right
            percentVariationRow.Elements.AddRange(percentVariationText, percentVariationValue)

            Dim percentOfTargetRow As CardRow = New CardRow()
            percentOfTargetRow.VerticalAlignment = CardVerticalAlignment.Center
            percentOfTargetRow.Indent = 20
            Dim percentOfTargetText As CardRowTextElement = New CardRowTextElement()
            percentOfTargetText.FontSize = 16
            percentOfTargetText.ForeColor = Color.MediumBlue
            percentOfTargetText.HorizontalAlignment = CardHorizontalAlignment.Left
            percentOfTargetText.Text = "Percent of Target: "
            Dim percentOfTargetValue As CardRowDataElement = New CardRowDataElement()
            percentOfTargetValue.FontSize = 20
            percentOfTargetValue.ValueType = CardRowDataElementType.PercentOfTarget
            percentOfTargetValue.PredefinedForeColor = CardPredefinedColor.Delta
            percentOfTargetValue.HorizontalAlignment = CardHorizontalAlignment.Right
            percentOfTargetRow.Elements.AddRange(percentOfTargetText, percentOfTargetValue)

            Dim totalSalesRow As CardRow = New CardRow()
            totalSalesRow.VerticalAlignment = CardVerticalAlignment.Center
            Dim totalSalesText As CardRowTextElement = New CardRowTextElement()
            totalSalesText.FontStyle = FontStyle.Underline
            totalSalesText.FontSize = 14
            totalSalesText.ForeColor = Color.BlueViolet
            totalSalesText.Text = "Total Sales: "
            totalSalesText.HorizontalAlignment = CardHorizontalAlignment.Left
            Dim totalSalesValue As CardRowDataElement = New CardRowDataElement()
            totalSalesValue.ForeColor = Color.CadetBlue
            totalSalesValue.FontSize = 16
            totalSalesValue.ValueType = CardRowDataElementType.ActualValue
            totalSalesValue.HorizontalAlignment = CardHorizontalAlignment.Right
            totalSalesRow.Elements.AddRange(totalSalesText, totalSalesValue)

            Dim targetSalesRow As CardRow = New CardRow()
            targetSalesRow.VerticalAlignment = CardVerticalAlignment.Center
            Dim targetSalesText As CardRowTextElement = New CardRowTextElement()
            targetSalesText.FontStyle = FontStyle.Underline
            targetSalesText.FontSize = 14
            targetSalesText.ForeColor = Color.BlueViolet
            targetSalesText.Text = "Target Sales: "
            targetSalesText.HorizontalAlignment = CardHorizontalAlignment.Left
            Dim targetSalesValue As CardRowDataElement = New CardRowDataElement()
            targetSalesValue.ForeColor = Color.CadetBlue
            targetSalesValue.FontSize = 16
            targetSalesValue.ValueType = CardRowDataElementType.TargetValue
            targetSalesValue.HorizontalAlignment = CardHorizontalAlignment.Right
            targetSalesRow.Elements.AddRange(targetSalesText, targetSalesValue)

			layout.Rows.AddRange(sparklineRow, 
       captionRow, 
       absoluteVariationRow, 
       percentVariationRow, 
       percentOfTargetRow, 
       totalSalesRow, 
       targetSalesRow)
			customTemplate.Layout = layout
			customTemplate.MinWidth = 300
			customTemplate.MaxWidth = 350
			Return customTemplate
		End Function
	End Class
End Namespace
