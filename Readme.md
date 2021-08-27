<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/144724571/18.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830544)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to Create a Custom Template for the Card Dashboard Item

This example creates a custom template to display the [Card dashboard item](https://docs.devexpress.com/Dashboard/15263/creating-dashboards/creating-dashboards-in-the-winforms-designer/designing-dashboard-items/cards).

![](https://github.com/DevExpress-Examples/winviewer-how-to-create-custom-card-layout-template/blob/18.1.3%2B/images/CardCustomLayoutTemplateExample.png)

To accomplish this, create the [CardCustomLayoutTemplate](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.CardCustomLayoutTemplate) instance and assign it to the [Card.LayoutTemplate](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Card.LayoutTemplate) property of a new [Card](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Card) instance. Specify required settings and add the **Card** instance to the [CardDashboardItem.Cards](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.CardDashboardItem.Cards) collection.
