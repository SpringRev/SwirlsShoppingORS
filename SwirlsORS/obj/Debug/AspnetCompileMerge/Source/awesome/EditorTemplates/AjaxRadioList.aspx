<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%= Html.AjaxRadioList(ViewData.TemplateInfo.GetFullHtmlFieldName(""), ViewData.TemplateInfo.FormattedModelValue) %>