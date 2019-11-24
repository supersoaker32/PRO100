using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class School
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Class
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Subclass
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class RootSpell
    {
        public string _id { get; set; }
        public int index { get; set; }
        public string name { get; set; }

        private List<string> desc;
        public List<string> Desc
        {
            get { return desc; }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    value[i] = value[i].Replace("â€™", "'");
                    value[i] = value[i].Replace("™", "");
                    value[i] = value[i].Replace("€", "");
                    value[i] = value[i].Replace("â", "");
                    value[i] = value[i].Replace("�", "");
                    value[i] = value[i].Replace("œ", "");
                }
                desc = value;
            }
        }

        private List<string> higher_level;
        public List<string> Higher_Level
        {
            get { return higher_level; }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    value[i] = value[i].Replace("â€™", "'");
                }
                higher_level = value;
            }
        }
        public string page { get; set; }
        public string range { get; set; }
        public List<string> components { get; set; }

        private string material;

        public string Material
        {
            get { return material; }
            set { material = value.Replace("â€™", "'"); }
        }

        public string ritual { get; set; }
        public string duration { get; set; }
        public string concentration { get; set; }
        public string casting_time { get; set; }
        public int level { get; set; }
        public School school { get; set; }
        public List<Class> classes { get; set; }
        public List<Subclass> subclasses { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            string returnString;

            string description = "";
            foreach (string descript in desc)
            {
                description += descript;
            }

            string higherLevel = "";
            if (higher_level != null)
            {
                foreach (string highlevel in higher_level)
                {
                    higherLevel += highlevel;
                }
            }

            string componentsDisplay = "";
            foreach (string component in components)
            {
                componentsDisplay += component;
            }

            string classesDisplay = "";
            foreach (Class classInClasses in classes)
            {
                classesDisplay += classInClasses.name + "\n\t";
            }
            returnString =
                $"Name: {name}\n" +
                $"Description: {description}\n" +
                $"Higher Level: {higherLevel}\n" +
                $"Page: {page}\n" +
                $"Range: {range}\n" +
                $"Components: {componentsDisplay}\n" +
                $"Material: {material}\n" +
                $"Ritual: {ritual}\n" +
                $"Duration: {duration}\n" +
                $"Concentration: {concentration}\n" +
                $"Level: {level}\n" +
                $"School: {school.name}\n" +
                $"Classes:   {classesDisplay}";
            return returnString;
        }
    }
}
