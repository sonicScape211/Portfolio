﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab6.Models;

namespace Lab6.Controllers
{
    public class ProductsController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductDocument).Include(p => p.ProductModel).Include(p => p.ProductSubcategory).Include(p => p.UnitMeasure).Include(p => p.UnitMeasure1);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID");
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name");
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategories, "ProductSubcategoryID", "Name");
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name");
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,ProductNumber,MakeFlag,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,StandardCost,ListPrice,Size,SizeUnitMeasureCode,WeightUnitMeasureCode,Weight,DaysToManufacture,ProductLine,Class,Style,ProductSubcategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID", product.ProductID);
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategories, "ProductSubcategoryID", "Name", product.ProductSubcategoryID);
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.SizeUnitMeasureCode);
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.WeightUnitMeasureCode);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID", product.ProductID);
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategories, "ProductSubcategoryID", "Name", product.ProductSubcategoryID);
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.SizeUnitMeasureCode);
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.WeightUnitMeasureCode);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,ProductNumber,MakeFlag,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,StandardCost,ListPrice,Size,SizeUnitMeasureCode,WeightUnitMeasureCode,Weight,DaysToManufacture,ProductLine,Class,Style,ProductSubcategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID", product.ProductID);
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategories, "ProductSubcategoryID", "Name", product.ProductSubcategoryID);
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.SizeUnitMeasureCode);
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.WeightUnitMeasureCode);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
