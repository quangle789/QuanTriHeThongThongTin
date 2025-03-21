﻿using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCatetory()
        {
            var model = new productCatetoryDao().ListAll();
            return PartialView(model);
        }

        public JsonResult ListName(string q)
        {
            var data = new ProductDao().listName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string keyword,int page = 1,int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.keyword = keyword;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);

        }

        public ActionResult Category(long cateId, int page = 1, int pageSize = 1)
        {
            var category = new CatetoryDao().viewDetail(cateId);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListbyCatetoryId(cateId, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            

            return View(model);
        }

        [OutputCache(Duration = int.MaxValue, VaryByParam = "id", Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Detail(int idP)
        {
            var product = new ProductDao().viewDetail(idP);
            ViewBag.Catetory = new productCatetoryDao().Detail(product.CatetoryID.Value);
            ViewBag.RelateProduct = new ProductDao().ListRelatedProduct(idP);
            return View(product);
        }
    }
}