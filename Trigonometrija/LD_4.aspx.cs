using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trigonometrija.App_Code;

namespace Trigonometrija.App_Code
{
    public partial class LD_4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RectangleList rs = InOutUtils.ReadRectangles(Server.MapPath("~/App_Data/Staciakampiai.txt"));
                TriangleList ts = InOutUtils.ReadTriangles(Server.MapPath("~/App_Data/Trikampiai.txt"));

                Session["Rects"] = rs;
                Session["Tris"] = ts;

                RefreshMainGrids();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RectangleList rs = (RectangleList)Session["Rects"];
            TriangleList ts = (TriangleList)Session["Tris"];
            if (rs == null || ts == null) return;

            // skaic
            MatchList resOne = new MatchList();
            MatchList resWhole = new MatchList();
            PerformCalculations(rs, ts, resOne, resWhole);

            // max radimas
            Rectangle maxRect = FindMaxRectangle(rs);
            Triangle maxTri = FindMaxTriangle(ts);

            // rez
            GridView3.DataSource = ConvertMatchesToList(resOne);
            GridView3.DataBind();

            GridView4.DataSource = ConvertMatchesToList(resWhole);
            GridView4.DataBind();

            // max idejimas
            List<object> maxItems = new List<object>();
            if (maxRect != null) maxItems.Add(new { Pavadinimas = maxRect.Name, Plotas = maxRect.GetArea(), Tipas = "Stačiakampis" });
            if (maxTri != null) maxItems.Add(new { Pavadinimas = maxTri.Name, Plotas = maxTri.GetArea(), Tipas = "Trikampis" });

            GridView5.DataSource = maxItems;
            GridView5.DataBind();
        }

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

        private void ProcessSingleRectangle(Rectangle r, TriangleList ts, MatchList m1, MatchList m2)
        {
            for (ts.Begin(); ts.Exist(); ts.Next())
            {
                Triangle t = ts.Get();
                int pointsInside = 0;
                if (r.ContainsPoint(t.X1, t.Y1)) pointsInside++;
                if (r.ContainsPoint(t.X2, t.Y2)) pointsInside++;
                if (r.ContainsPoint(t.X3, t.Y3)) pointsInside++;

                if (pointsInside == 1)
                    m1.Add(new MatchResult(r.Name, t.Name, "Viena viršūnė"));
                else if (pointsInside == 3)
                    m2.Add(new MatchResult(r.Name, t.Name, "Visas trikampis"));
            }
        }
        private void PerformCalculations(RectangleList rs, TriangleList ts, MatchList m1, MatchList m2)
        {
            for (rs.Begin(); rs.Exist(); rs.Next())
            {
                ProcessSingleRectangle(rs.Get(), ts, m1, m2);
            }
        }

        private Rectangle FindMaxRectangle(RectangleList rs)
        {
            Rectangle maxR = null;
            for (rs.Begin(); rs.Exist(); rs.Next())
            {
                Rectangle curr = rs.Get();
                if (maxR == null || curr.GetArea() > maxR.GetArea())
                    maxR = curr;
            }
            return maxR;
        }

        private Triangle FindMaxTriangle(TriangleList ts)
        {
            Triangle maxT = null;
            for (ts.Begin(); ts.Exist(); ts.Next())
            {
                Triangle curr = ts.Get();
                if (maxT == null || curr.GetArea() > maxT.GetArea())
                    maxT = curr;
            }
            return maxT;
        }

        private void RefreshMainGrids()
        {
            GridView1.DataSource = ConvertRectsToList((RectangleList)Session["Rects"]);
            GridView1.DataBind();
            GridView2.DataSource = ConvertTrisToList((TriangleList)Session["Tris"]);
            GridView2.DataBind();
        }

        private List<Rectangle> ConvertRectsToList(RectangleList rl)
        {
            List<Rectangle> temp = new List<Rectangle>();
            for (rl.Begin(); rl.Exist(); rl.Next()) temp.Add(rl.Get());
            return temp;
        }

        private List<Triangle> ConvertTrisToList(TriangleList tl)
        {
            List<Triangle> temp = new List<Triangle>();
            for (tl.Begin(); tl.Exist(); tl.Next()) temp.Add(tl.Get());
            return temp;
        }

        private List<MatchResult> ConvertMatchesToList(MatchList ml)
        {
            List<MatchResult> temp = new List<MatchResult>();
            for (ml.Begin(); ml.Exist(); ml.Next()) temp.Add(ml.Get());
            return temp;
        }
    }
}