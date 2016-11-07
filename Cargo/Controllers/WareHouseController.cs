using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;

using System.IO;

namespace Cargo.Controllers
{
    public class WareHouseController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        // GET: WhareHouse
        public ActionResult Index()
        {
            return View();
        }

        //private string Create_Tr(IEnumerable<Warehouse> ware)
        //{
        //    var returnstring = string.Empty;

        //    for (int i = 0; i < ware.Count(); i++)
        //    {
        //        returnstring = returnstring + "<tr><td>" + ware
        //    }
        //}

        public void OpenPdf()
        {
            Byte[] bytes;

            using (var ms = new MemoryStream())
            {
                using (var doc = new Document(PageSize.A3, 5, 5, 5, 5)) {

                    using (var writer = PdfWriter.GetInstance(doc, ms)) {
                        doc.Open();
                        var example_html = System.IO.File.ReadAllText(Server.MapPath("~/Views/WareHouse/Receipt.cshtml"));
                        var example_css = System.IO.File.ReadAllText(Server.MapPath("~/Content/print.css"));

                        iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(Server.MapPath("/Images/LOGO_cargo.jpg"));
                        iTextSharp.text.Image barCode = iTextSharp.text.Image.GetInstance(Server.MapPath("/Images/qrcode.png")); 

                        png.ScaleAbsoluteWidth(100);
                        png.ScaleAbsoluteHeight(80);

                        barCode.ScaleAbsoluteWidth(100);
                        barCode.ScaleAbsoluteHeight(100);

                        //png.SetAbsolutePosition(10f, doc.PageSize.Height - 90f);
                        barCode.SetAbsolutePosition(doc.PageSize.Width - 36f - 68f, doc.PageSize.Height - 36f - 81.6f);

                        doc.Add(barCode);
                        doc.Add(png);

                        example_html = example_html.Replace("[[LOGO]]", "Hola inmundo");

                        using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        {
                            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_html)))
                            {

                                //Parse the HTML
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                            }
                        }


                        doc.Close();
                    }
                }
                bytes = ms.ToArray();
                var testFile = Path.Combine(Server.MapPath("~/Reports/Warehouse/Receipts"), "Receipt.pdf");
                System.IO.File.WriteAllBytes(testFile, bytes);
                Response.ContentType = "Application/pdf";
                Response.TransmitFile(Server.MapPath("~/Reports/Warehouse/Receipts/Receipt.pdf"));

            }
        }
        public ActionResult Receipt()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create([Bind(Include = "WarehouseID,NumberCode,Fk_BranchID,CreationDate,Fk_ShipperID,Fk_Consignee,Fk_Agent,Fk_DeliveryCompany,Fk_Condition,Description,Fk_Origin,Fk_Destination")] Warehouse wareHouse, List<Courier> courier, string[] types)
        {
            GenerateId generator = new GenerateId();
            wareHouse.WarehouseID = generator.generateID();
            db.Warehouses.Add(wareHouse);
            db.SaveChanges();
            ////Add Types
            List<WarehouseTypeRelation> typeList = new List<WarehouseTypeRelation>();
            foreach (var item in types)
            {
                var idType = db.WarehouseTypes.Where(x => x.TypeName == item).Select(x => x.TypeId).SingleOrDefault();
                WarehouseTypeRelation typeItem = new WarehouseTypeRelation();
                typeItem.WarehouseTypeRelationId=generator.generateID();
                typeItem.WarehouseId = wareHouse.WarehouseID;
                typeItem.TypeId = idType;
                typeList.Add(typeItem);
            }

            foreach (var item in courier)
            {
                Courier courierItem = new Courier();
                item.CourierID = generator.generateID();
                item.CreationDate = DateTime.Now;
                item.Deleted = false;
                item.Fk_WarehouseID = wareHouse.WarehouseID;
                db.Couriers.Add(item);

            }

            foreach (var item in typeList)
            {
                db.WarehouseTypeRelations.Add(item);
            }

            db.SaveChanges();

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllWarehouses()
        {
            var list = (from q in db.Warehouses
                        select new
                        {
                            WarehouseID=q.WarehouseID,
                            NumberCode=q.NumberCode,
                            CreationDate= q.CreationDate,
                            Fk_BranchID =q.Fk_BranchID,
                            Fk_ShipperID=q.Fk_ShipperID,
                            Fk_Consignee=q.Fk_Consignee,
                            Fk_Agent=q.Fk_Agent,
                            Fk_DeliveryCompany=q.Fk_DeliveryCompany,
                            Fk_Condition=q.Fk_Condition,
                            Description=q.Description,
                            Fk_Origin=q.Fk_Origin,
                            Fk_Destination=q.Fk_Destination
                        });

            return Json(new { data=list.ToList()}, JsonRequestBehavior.AllowGet);
        }
    }
}