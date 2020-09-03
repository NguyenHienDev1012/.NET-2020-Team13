using System.Collections.Generic;
using System.Web.Mvc;
using Web2020Project.Admin.Dao;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Controllers.Admin
{
    public class ProducerController : Controller
    {
        public const string PRODUCER_TABLE = "NHACUNGCAP";
        public const string ID_PRODUCER = "MANHACUNGCAP";
        public const string NAME_PRODUCER = "TENNHACUNGCAP";

        // GET

        public ActionResult Producer()
        {
            ViewBag.Title = "Nhà cung cấp";
            List<Producer> listProducer = ProducerDAO.LoadProducer();
            return View(listProducer);
        }

        [ActionName("Producer_Delete")]
        public ActionResult Producer_Manage(string ProducerID)
        {
            if (RemoveObj.Remove(PRODUCER_TABLE, ID_PRODUCER, ProducerID, false))
            {
                Session.Add("dia-log", "sucXóa Thành Công");
            }

            return RedirectToAction("Producer");
        }

        [HttpGet] //Phần này dùng để lấy ra đối tượng member để gán giá trị trong form update member nè
        public ActionResult Producer_Update(string ProducerID)
        {
            ViewBag.Title = "Cập nhật nhà cung cấp";
            Producer producer = ProducerDAO.GetProducer(ProducerID);
            return View(producer);
        }

        [HttpPost] //Phần này thêm, sửa thành viên nè
        public ActionResult Producer_Update(Producer producer)
        {
            if (ModelState.IsValid)
            {
                string action = Request["action"];
                if (action.Equals("edit"))
                {
                    string producerID_temp = Request["producerID_temp"];
                    string producerName_temp = Request["producerID_temp"];
                    if (!producerID_temp.Equals(producer.ProducerId) &&
                        CheckObjExists.IsExist(PRODUCER_TABLE, ID_PRODUCER, producer.ProducerId))
                    {
                        Session.Add("dia-log", "errThất Bại! Email " + producer.ProducerId + " đã tồn tại.");
                    }
                    else if (ProducerDAO.EditProducer(producer))
                    {
                        Session.Add("dia-log", "sucSửa Thành Công");
                    }

                    if (!producerID_temp.Equals(producer.ProducerId) && !producerName_temp.Equals(producer.ProducerName)
                                                                     && CheckObjExists.IsExist(PRODUCER_TABLE,
                                                                         ID_PRODUCER, producer.ProducerId)
                                                                     && CheckObjExists.IsExist(PRODUCER_TABLE,
                                                                         NAME_PRODUCER, producer.ProducerName))
                    {
                        Session.Add("dia-log",
                            "errThất Bại! Email " + producer.ProducerId + " và " + producer.ProducerName +
                            " đã tồn tại.");
                    }
                    else if (ProducerDAO.EditNewID(producer, producerID_temp))
                    {
                        Session.Add("dia-log", "sucSửa Thành Công");
                    }
                }

                else if (action.Equals("add"))
                {
                    if (!CheckObjExists.IsExist(PRODUCER_TABLE, ID_PRODUCER, producer.ProducerId))
                    {
                        if (ProducerDAO.AddProducer(producer))
                        {
                            Session.Add("dia-log", "sucThêm mới tài khoản thành Công");
                        }
                    }
                    else
                    {
                        Session.Add("producer", producer);
                        if (CheckObjExists.IsExist(PRODUCER_TABLE, ID_PRODUCER, producer.ProducerId))
                        {
                            Session.Add("dia-log", "errThất Bại! Tài khoản " + producer.ProducerId + " đã tồn tại.");
                        }
                    }
                }
            }

            return RedirectToAction("Producer");
        }

        public ActionResult Producer_Update()
        {
            return View();
        }
    }
}