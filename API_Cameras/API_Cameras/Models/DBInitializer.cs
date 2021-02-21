using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace API_Cameras.Models
{
    public class DBInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Cameras.Any())
            {

                try
                {
                    var csvTable = new DataTable();
                    using (var csvReader = new LumenWorks.Framework.IO.Csv.CsvReader(new StreamReader(System.IO.File.OpenRead(Directory.GetCurrentDirectory() + @"\datasets\cameras-defb.csv")), true))
                    {
                        csvTable.Load(csvReader);
                        for (int i = 0; i < csvTable.Rows.Count; i++)
                        {
                            if (i > 0) //Skip first row
                            {
                                string[] columns = csvTable.Rows[i][0].ToString().Split(';');
                                if (columns.Length == 3)
                                {
                                    //Opsplitsen van omschrijving om hieruit de camera naam & nummer te halen.
                                    string[] splitString = columns[0].Split(' ');

                                    context.Cameras.Add(new Camera
                                    {
                                        ID = i,
                                        Name = splitString[0],
                                        Number = Int32.Parse(splitString[0].Substring(splitString[0].Length - 3)),
                                        Description = columns[0],
                                        Latitude = float.Parse(columns[1].Replace('.', ',')),
                                        Longitude = float.Parse(columns[2].Replace('.', ','))
                                    });
                                }

                            }

                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                context.SaveChanges();
            }
        }
    }
}
