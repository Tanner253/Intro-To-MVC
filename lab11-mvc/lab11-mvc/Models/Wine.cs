using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab11_mvc.Models
{
    public class Wine
    {
        //come back
        public string ID { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
        public int Points { get; set; }
        public int Price { get; set; }
        public string Region_1 { get; set; }
        public string Region_2 { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }

        public static List<Wine> ProcessData(int price, int points)
        {
            string path = "C:/Users/perci/codefellows/401/lab11-Intro-To-MVC/wine.csv";

            string[] data = File.ReadAllLines(path);

            List<Wine> wines = new List<Wine>();

            //source 
            StreamReader sr = new StreamReader(path);
            
            //reads each line
            for (int i = 1; i < data.Length; i++)
            {
                //var temp = data[i].Split(',');
                //dan and stack overflow
                string[] temp = Regex.Split(data[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                //wines.Add(new Wine
                //{
                //    ID = temp[0],
                //    Country = (temp[1] == "") ? "Country not available" : temp[1],
                //    Description = (temp[2] == "") ? "description not available" : temp[2],
                //    Designation = (temp[3] == "") ? "Designation not available" : temp[3],
                //    Points = Convert.ToInt32(temp[7]),
                //    Price = (temp[8] == "") ? 0 : Convert.ToInt32(temp[8]),
                //    Region_1 = (temp[9] == "") ? "region 1 not available" : temp[9],
                //    Region_2 = (temp[10] == "") ? "Region 2 not available" : temp[10],
                //    Variety = (temp[11] == "") ? "Variety not available" : temp[11],
                //    Winery = (temp[12] == "") ? "Winery not available" : temp[12]
                //});

                Wine wine = new Wine();

                wine.ID = temp[0];
                wine.Country = temp[1];
                wine.Description = temp[2];
                wine.Designation = temp[3];
                wine.Points = Convert.ToInt32(temp[4]);
                wine.Price = Convert.ToInt32(temp[5]);
                wine.Region_1 = temp[6];
                wine.Region_2 = temp[7];
                wine.Variety = temp[8];
                wine.Winery = temp[9];


                wines.Add(wine);
            }
            List<Wine> filteredWines = wines.Where(n => n.Points >= points && n.Price <= price).ToList();

            return filteredWines; ;
        }



    }
}

