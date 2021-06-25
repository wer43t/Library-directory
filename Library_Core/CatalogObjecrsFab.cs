
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Core
{
    public class CatalogObjectsData
    {
        public string Name;
        public Dictionary<string, string> Data;

        public override string ToString()
        {
            return Name;
        }
    }

    static public class CatalogObjectsFab
    {
        public static CatalogObject Make(CatalogObjectsData CatalogObjectsData)
        {
            CatalogObject fig = null;

            switch (CatalogObjectsData.Name)
            {
                case "Book":
                    fig = new Book(CatalogObjectsData.Data["Name"], CatalogObjectsData.Data["Creator"], CatalogObjectsData.Data["authors"], CatalogObjectsData.Data["illustrator"], CatalogObjectsData.Data["publishingYear"]);
                    break;
                case "Puzzle":
                    fig = new Puzzle(CatalogObjectsData.Data["Name"], CatalogObjectsData.Data["Creator"], CatalogObjectsData.Data["amountElements"]);
                    break;
                case "TableGame":
                    fig = new TableGame(CatalogObjectsData.Data["Name"], CatalogObjectsData.Data["Creator"], CatalogObjectsData.Data["description"], CatalogObjectsData.Data["playerNumbers"]);
                    break;
            }

            return fig;
        }

        public static List<CatalogObjectsData> InitFiguresData()
        {
            var catalogObjectsData = new List<CatalogObjectsData>();

            catalogObjectsData.Add(new CatalogObjectsData
            {
                Name = "Book",
                Data = new Dictionary<string, string>
                {
                    { "Name", "" },
                    { "Creator", "" },
                    { "authors", "" },
                    { "illustrator", "" },
                    { "publishingYear", "" }
                }
            });

            catalogObjectsData.Add(new CatalogObjectsData
            {
                Name = "Puzzle",
                Data = new Dictionary<string, string>
                {
                    { "Name", "" },
                    { "Creator", "" },
                    { "amountElements", "" }
                }
            });

            catalogObjectsData.Add(new CatalogObjectsData
            {
                Name = "TableGame",
                Data = new Dictionary<string, string>
                {
                    { "Name", "" },
                    { "Creator", "" },
                    { "description", "" },
                    { "playerNumbers", "" }
                }
            });

            return catalogObjectsData;
        }
    }
}