using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigonometrija.App_Code;

namespace Trigonometrija.App_Code
{
    /// <summary>
    /// Main WebForm page that handles data loading, calculations and UI updates
    /// </summary>
    public partial class LD_4 : System.Web.UI.Page
    {
        /// <summary>
        /// Loads data from files on first page load
        /// </summary>
        /// <param name="sender">Event source</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RectangleList rs = InOutUtils.ReadRectangles
                    (Server.MapPath("~/App_Data/Staciakampiai1.txt"));
                TriangleList ts = InOutUtils.ReadTriangles
                    (Server.MapPath("~/App_Data/Trikampiai1.txt"));

                Session["Rects"] = rs;
                Session["Tris"] = ts;

                string resultPath = Server.MapPath("~/App_Data/PradDuomenys.txt");
                InOutUtils.PrintInitialData(resultPath, rs, ts);

                RefreshMainGrids();
            }
        }

        /// <summary>
        /// Handles calculation button click
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            RectangleList rs = (RectangleList)Session["Rects"];
            TriangleList ts = (TriangleList)Session["Tris"];
            if (rs == null || ts == null) return;

            rs.Sort();
            ts.Sort();

            MatchList resOne = new MatchList();
            MatchList resWhole = new MatchList();

            TaskUtils.PerformCalculations(rs, ts, resOne, resWhole);

            resOne.Sort();
            resWhole.Sort();

            if (resOne.Count() == 0)
            {
                GridView3.Visible = false;
                Label1.Text = "a) Nėra stačiakampių su viena viršūne";
            }
            else
            {
                GridView3.Visible = true;
                GridView3.DataSource = resOne;
                GridView3.DataBind();
            }

            if (resWhole.Count() == 0)
            {
                GridView4.Visible = false;
                Label2.Text = "b) Nėra stačiakampių su visu trikampiu";
            }
            else
            {
                GridView4.Visible = true;
                GridView4.DataSource = resWhole;
                GridView4.DataBind();
            }

            Rectangle maxRect = TaskUtils.FindMaxRectangle(rs);
            Triangle maxTri = TaskUtils.FindMaxTriangle(ts);

            string resultsPath = Server.MapPath("~/App_Data/Rezultatai.txt");
            InOutUtils.PrintCalculationResults(resultsPath, resOne, resWhole, 
                maxRect, maxTri);

            int count = 0;
            if (maxRect != null) count++;
            if (maxTri != null) count++;

            object[] maxItems = new object[count];
            int i = 0;
            if (maxRect != null) maxItems[i++] = new { Name = maxRect.Name, 
                Area = maxRect.GetArea(), Type = "Stačiakampis" };
            if (maxTri != null) maxItems[i++] = new { Name = maxTri.Name, 
                Area = maxTri.GetArea(), Type = "Trikampis" };

            GridView5.DataSource = maxItems;
            GridView5.DataBind();

            Label4.Text = CompareMaxAreas(maxRect, maxTri);
        }

        /// <summary>
        /// Removes Triangle by name when Button2 is clicked
        /// </summary>
        protected void Button2_Click(object sender, EventArgs e)
        {
            TriangleList ts = (TriangleList)Session["Tris"];
            if (ts != null && !string.IsNullOrEmpty(TextBox1.Text))
            {
                ts.RemoveByName(TextBox1.Text);
                Session["Tris"] = ts;
                RefreshMainGrids();
                Button1_Click(null, null);
            }
        }

        /// <summary>
        /// Refreshes the data displayed in the main grid.
        /// </summary>
        private void RefreshMainGrids()
        {
            RectangleList rs = (RectangleList)Session["Rects"];
            TriangleList ts = (TriangleList)Session["Tris"];

            if (rs != null)
            {
                GridView1.DataSource = rs;
                GridView1.DataBind();
            }
            if (ts != null)
            {
                GridView2.DataSource = ts;
                GridView2.DataBind();
            }
        }

        /// <summary>
        /// Compares the areas of the specified 
        /// <see cref="Rectangle"/> and <see cref="Triangle"/>
        /// </summary>
        private string CompareMaxAreas(Rectangle maxRect, Triangle maxTri)
        {
            if (maxRect == null || maxTri == null)
            {
                return "Nepakanka duomenų palyginimui";
            }

            if (maxRect.GetArea() > maxTri.GetArea())
            {
                return "Stačiakampis didesnis";
            }
            else if (maxRect.GetArea() < maxTri.GetArea())
            {
                return "Trikampis didesnis";
            }
            else
            {
                return "Plotai lygūs";
            }
        }
    }
}