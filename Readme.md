<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/144724571/19.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830544)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Dashboard for WinForms - How to Create a Custom Template for the Card Dashboard Item

This example creates a custom template to display the [Card dashboard item](https://docs.devexpress.com/Dashboard/15263).

![screenshot](/images/screenshot.png)

To accomplish this, create the [CardCustomLayoutTemplate](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.CardCustomLayoutTemplate) instance and assign it to the [Card.LayoutTemplate](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Card.LayoutTemplate) property of a new [Card](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Card) instance. Specify required settings and add the **Card** instance to the [CardDashboardItem.Cards](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.CardDashboardItem.Cards) collection.

## Files to Review

* [Form1.cs](./CS/ViewerForm.cs) (VB: [Form1.vb](./VB/ViewerForm.vb))

## Documentation

- [Cards Layout](https://docs.devexpress.com/Dashboard/113798)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winviewer-how-to-create-custom-card-layout-template&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winviewer-how-to-create-custom-card-layout-template&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
