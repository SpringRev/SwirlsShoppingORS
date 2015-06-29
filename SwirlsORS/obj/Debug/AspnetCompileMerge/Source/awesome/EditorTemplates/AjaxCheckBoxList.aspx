<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%= Html.AjaxCheckBoxList(ViewData.TemplateInfo.GetFullHtmlFieldName(""), ViewData.TemplateInfo.FormattedModelValue) %>