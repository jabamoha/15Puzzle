using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCc.Models;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace WebMVCc.Controllers
{
    public class HomeController : Controller
    {
        static Random myRand = new Random();
        List<HomeModel> myListModelO = new List<HomeModel>(16);

        //
        // GET: /My/


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ShuffleAction()
        {
            await Task.Run(() => Shuffle());
            return Json(myListModelO, JsonRequestBehavior.AllowGet);
        }

        public void Shuffle()
        {
            List<HomeModel> myListModel = new List<HomeModel>(16);
            int[] arr = new int[16];
            for (short i = 0; i < 15; i++)
                arr[i] = i + 1;
            arr[15] = -1;
            //Random myRand = new Random();
            for (short i = 14; i > 0; i--)
            {
                int r = myRand.Next(i);
                int temp = arr[i];
                arr[i] = arr[r];
                arr[r] = temp;
            }
            for (int i = 0; i < 16; i++)
            {
                HomeModel tempModel = new HomeModel();
                tempModel.Text = arr[i].ToString();
                tempModel.hexRGB = myRand.Next(50, 256).ToString("x") + myRand.Next(50, 256).ToString("x") + myRand.Next(50, 256).ToString("x");
                myListModel.Add(tempModel);
            }
            myListModelO = myListModel;
        }


        }
}