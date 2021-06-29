*Files to look at*:

* [Form1.cs](./CS/ViewerForm.cs) (VB: [Form1.vb](./VB/ViewerForm.vb))


# How to Create a Custom Template for the Card Dashboard Item

This example creates a custom template to display the [Card dashboard item](https://docs.devexpress.com/Dashboard/15263).

![screenshot](/images/screenshot.png)


To accomplish this, create the [CardCustomLayoutTemplate](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.CardCustomLayoutTemplate) instance and assign it to the [Card.LayoutTemplate](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Card.LayoutTemplate) property of a new [Card](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Card) instance. Specify required settings and add the **Card** instance to the [CardDashboardItem.Cards](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.CardDashboardItem.Cards) collection.

## Documentation

- [Cards Layout](https://docs.devexpress.com/Dashboard/113798)
