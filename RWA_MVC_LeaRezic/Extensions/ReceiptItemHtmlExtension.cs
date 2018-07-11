using RWA_MVC_LeaRezic.Models.ViewModels;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RWA_MVC_LeaRezic.Extensions
{
    public static class ReceiptItemHtmlExtension
    {
        public static HtmlString ReceiptItems(this HtmlHelper html, ReceiptItemVM item, bool isAlternate = false)
        {
            string panelClass = isAlternate ? "panel-primary" : "panel-success";
            StringBuilder output = new StringBuilder();
            output.Append($"<div class='panel {panelClass}'><div class='panel-heading'><h3 class='panel-title'>{item.Product}</h3></div><div class='panel-body'>");
            output.Append($"<b>Color:</b> {item.Color}<br/>");
            output.Append($"<b>Subcategory:</b> {item.Subcategory}<br/>");
            output.Append($"<b>Category:</b> {item.Category}<br/>");
            output.Append($"<b>Price:</b> {item.Price}<br/>");
            output.Append($"<b>Amount:</b> {item.Amount}<br/>");
            if (item.DiscountPercentage != 0)
            {
                output.Append($"<b>Discount (percentage):</b> {item.DiscountPercentage}<br/>");
            }
            output.Append($"<b>Total price:</b> {item.TotalPrice}</div></div>");
            return new HtmlString(output.ToString());
        }
    }
}