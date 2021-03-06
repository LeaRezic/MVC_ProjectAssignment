﻿using RWA_MVC_LeaRezic.BLL.DataManagers;
using System.Web.Mvc;

namespace RWA_MVC_LeaRezic.Controllers
{
    public class ReceiptItemController : Controller
    {
        

        // GET: ReceiptItem
        public ActionResult DisplayForReceipt(int id)
        {
            ViewBag.receipt = ReceiptManager.Get(id);
            return View(ReceiptItemManager.GetAllForReceipt(id));
        }
    }
}