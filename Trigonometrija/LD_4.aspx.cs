using System;
using System.Collections.Generic;
using System.Web.UI;
using Trigonometrija.App_Code;

namespace Trigonometrija.App_Code
{
    public partial class LD_4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 1. Nuskaitome duomenis naudodami statinius įrankius
                RectangleList  rs = InOutUtils.ReadRectangles(Server.MapPath("~/App_Data/Staciakampiai.txt"));
                TriangleList ts = InOutUtils.ReadTriangles(Server.MapPath("~/App_Data/Trikampiai.txt"));

                // 2. Išsaugome nestatinius objektus sesijoje
                Session["Rects"] = rs;
                Session["Tris"] = ts;

                // 3. Pirminis duomenų rodymas
                GridView1.DataSource = ConvertRectsToList(rs);
                GridView1.DataBind();
                GridView2.DataSource = ConvertTrisToList(ts);
                GridView2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RectangleList rs = (RectangleList)Session["Rects"];
            TriangleList ts = (TriangleList)Session["Tris"];

            if (rs == null || ts == null) return;

            MatchList resOne = new MatchList();
            MatchList resWhole = new MatchList();

            // Atliekame geometrinius skaičiavimus
            PerformCalculations(rs, ts, resOne, resWhole);

            // Užpildome rezultatų lenteles
            GridView3.DataSource = ConvertMatchesToList(resOne);
            GridView3.DataBind();
            GridView4.DataSource = ConvertMatchesToList(resWhole);
            GridView4.DataBind();

            // Randame ir parodome didžiausius plotus
            ShowMaxAreas(rs, ts);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TriangleList ts = (TriangleList)Session["Tris"];
            if (ts != null && !string.IsNullOrEmpty(TextBox1.Text))
            {
                ts.RemoveByName(TextBox1.Text); // Tavo dinaminio sąrašo metodas
                Session["Tris"] = ts;

                // Atnaujiname pradinių duomenų lentelę
                GridView2.DataSource = ConvertTrisToList(ts);
                GridView2.DataBind();

                // Automatiškai perskaičiuojame rezultatus po pašalinimo
                Button1_Click(null, null);
            }
        }

        // --- SKAIČIAVIMŲ LOGIKA (Be UI elementų) ---

        private void PerformCalculations(RectangleList rs, TriangleList ts, MatchList m1, MatchList m2)
        {
            for (RectNode rn = rs.GetHead(); rn != null; rn = rn.Link)
            {
                for (TriNode tn = ts.GetHead(); tn != null; tn = tn.Link)
                {
                    int pointsInside = 0;
                    if (rn.Data.ContainsPoint(tn.Data.X1, tn.Data.Y1)) pointsInside++;
                    if (rn.Data.ContainsPoint(tn.Data.X2, tn.Data.Y2)) pointsInside++;
                    if (rn.Data.ContainsPoint(tn.Data.X3, tn.Data.Y3)) pointsInside++;

                    if (pointsInside == 1)
                        m1.Add(new MatchResult(rn.Data.Name, tn.Data.Name, "Viena viršūnė"));
                    else if (pointsInside == 3)
                        m2.Add(new MatchResult(rn.Data.Name, tn.Data.Name, "Visas trikampis"));
                }
            }
        }

        private void ShowMaxAreas(RectangleList rs, TriangleList ts)
        {
            Rectangle maxR = null;
            for (RectNode rn = rs.GetHead(); rn != null; rn = rn.Link)
                if (maxR == null || rn.Data.GetArea() > maxR.GetArea()) maxR = rn.Data;

            Triangle maxT = null;
            for (TriNode tn = ts.GetHead(); tn != null; tn = tn.Link)
                if (maxT == null || tn.Data.GetArea() > maxT.GetArea()) maxT = tn.Data;

            List<object> maxItems = new List<object>();
            if (maxR != null) maxItems.Add(new { Pavadinimas = maxR.Name, Plotas = maxR.GetArea(), Tipas = "Stačiakampis" });
            if (maxT != null) maxItems.Add(new { Pavadinimas = maxT.Name, Plotas = maxT.GetArea(), Tipas = "Trikampis" });

            GridView5.DataSource = maxItems;
            GridView5.DataBind();
        }

        // --- UI PAGALBINIAI METODAI (Konvertavimas GridView vaizdavimui) ---

        private List<Rectangle> ConvertRectsToList(RectangleList rl)
        {
            List<Rectangle> temp = new List<Rectangle>();
            for (RectNode curr = rl.GetHead(); curr != null; curr = curr.Link) temp.Add(curr.Data);
            return temp;
        }

        private List<Triangle> ConvertTrisToList(TriangleList tl)
        {
            List<Triangle> temp = new List<Triangle>();
            for (TriNode curr = tl.GetHead(); curr != null; curr = curr.Link) temp.Add(curr.Data);
            return temp;
        }

        private List<MatchResult> ConvertMatchesToList(MatchList ml)
        {
            List<MatchResult> temp = new List<MatchResult>();
            for (MatchNode curr = ml.GetHead(); curr != null; curr = curr.Link) temp.Add(curr.Data);
            return temp;
        }
    }
}