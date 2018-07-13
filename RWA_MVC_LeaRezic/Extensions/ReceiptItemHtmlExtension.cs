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
            string textClass = isAlternate ? "primary" : "success";
            StringBuilder output = new StringBuilder();
            output.Append("<div class='col-sm-6 col-md-3' style='padding:5px;'>");
            output.Append($"<div class='panel panel-{textClass}'><div class='panel-heading'><h3 class='panel-title'>{item.Product}</h3></div><div class='panel-body'>");
            output.Append($"<span class='text-{textClass}'><b>Category:</b></span> {item.Category}<br/>");
            output.Append($"<b>Subcategory:</b> {item.Subcategory}<br/>");
            output.Append($"<b>Color:</b> {item.Color}<br/>");
            output.Append($"<span class='text-{textClass}'><b>Price:</b></span> {item.Price}<br/>");
            output.Append($"<b>Amount:</b> {item.Amount}<br/>");
            if (item.DiscountPercentage != 0)
            {
                output.Append($"<span class='text-warning'><b>Discount (percentage):</b></span> {item.DiscountPercentage}<br/>");
            }
            output.Append($"<span class='text-{textClass}'><b>Total price:</b></span> {item.TotalPrice}</div></div></div>");
            return new HtmlString(output.ToString());
        }
    }
}