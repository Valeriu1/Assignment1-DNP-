using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assigment1.Persistence;
using Models;

namespace FileData
{
    public class FileContext : IFileContext
    {
        public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(adultsFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing families
            // string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            // {
            //     WriteIndented = true
            // });
            // using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            // {
            //     outputFile.Write(jsonFamilies);
            // }

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public IList<Adult> GetPersons()
        {
            List<Adult> tmp = new List<Adult>(Adults);
            return tmp;
        }

        public void AddPerson(Adult adult)
        {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = (++max);
            Adults.Add(adult);
            SaveChanges();
        }

        public void RemovePerson(int personId)
        {
            Adult toRemove = Adults.First(t => t.Id == personId);
            Adults.Remove(toRemove);
            SaveChanges();
        }

        public void Update(Adult adult)
        {
            Adult toUpdate = Adults.First(t => t.Id == adult.Id);
            //Fields to update
            SaveChanges();
        }

        public Adult Get(int id)
        {
            return Adults.FirstOrDefault(t => t.Id == id);
        }
    }
}