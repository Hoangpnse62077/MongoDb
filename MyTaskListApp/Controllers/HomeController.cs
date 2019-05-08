using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTaskListApp.Models;
using System.Configuration;
using NotificationListApp;
using System.Threading.Tasks;

namespace MyTaskListApp.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        private Dal dal = new Dal();
        private bool disposed = false;
        //
        // GET: /MyTask/

        public async Task<ActionResult> Index(int pageSize = 10)
        {
            long total = 0;
            var test = await dal.GetAllTasks(total, pageSize);
            ViewBag.Total = total;
            return View(test);
        }

        //
        // GET: /MyTask/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MyTask/Create

        [HttpPost]
        public async Task<JsonResult> Create(MyTask task)
        {
            try
            {


                List<List<Notification>> allNotifications = new List<List<Notification>>();
                //for (int x = 0; x < 10; x++)
                //{

                //    allNotifications.Add(listNoti);
                //}
                List<string> s = new List<string>();
                var temp = 0;



                for (int k = 0; k < 5; k++)
                {
                    var listNoti = new List<Notification>();
                    for (int i = 0; i < 100; i++)
                    {
                        var notification = new Notification()
                        {
                            A2000Color = "Test",
                            NotificationUsers = new List<NotificationUser>()

                        };
                        for (int j = 0; j < 10; j++)
                        {
                            notification.NotificationUsers.Add(new NotificationUser()
                            {
                                Id = Guid.NewGuid(),
                                UserId = 274
                            });
                        }
                        listNoti.Add(notification);
                    }
                    allNotifications.Add(listNoti);

                }
                List<Task> tasks = new List<Task>();
                Parallel.ForEach(allNotifications, x =>
                {
                    var result = Task.Factory.StartNew(() => dal.CreateMany(x));
                    tasks.Add(result);

                });
                Task.WaitAll(tasks.ToArray());
                return Json(new { });
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return Json(new { });
            }
        }

        public ActionResult About()
        {
            return View();
        }

        # region IDisposable

        new protected void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        new protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dal.Dispose();
                }
            }

            this.disposed = true;
        }

        # endregion

    }
}