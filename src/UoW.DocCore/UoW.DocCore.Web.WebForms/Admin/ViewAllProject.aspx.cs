using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UoW.DocCore.Web.WebForms.Admin
{
    public partial class ViewAllProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // pageload when page is loaded first time

                //FriendProfiles new1 = new FriendProfiles();
                // DataList1.DataSource = new1.FriendProfiless();
                //DataList1.DataBind();
                var products = new List<Product>();
                products.Add(new Product() { ProductID = 1, Name = "Bike", Price = 150.00 });
                products.Add(new Product() { ProductID = 2, Name = "Helmet", Price = 19.99 });
                products.Add(new Product() { ProductID = 3, Name = "Tire", Price = 10.00 });


                DataList1.DataSource = products;
                DataList1.DataBind();



            }

        }

        protected void outerRep_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var test = new List<Test>();
                test.Add(new Test() { testName = "Bike1" });
                test.Add(new Test() { testName = "Bike2" });
                test.Add(new Test() { testName = "Bike3" });

                //System.Data.DataRowView drv = e.Item.DataItem as System.Data.DataRowView;
                DataList innerDataList = e.Item.FindControl("DataList2") as DataList;
                DataList innerDataList1 = e.Item.FindControl("DataList3") as DataList;
                innerDataList.DataSource = test;
                innerDataList.DataBind();
                innerDataList1.DataSource = test;
                innerDataList1.DataBind();
            }
        }
        public class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }

            public double Price { get; set; }
        }
        public class Test
        {
            public string testName { get; set; }

        }

    }
}